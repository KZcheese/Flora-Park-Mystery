Shader "Custom/ToonShader" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Float) = 0.2
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            float _OutlineWidth;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float4 col = tex2D(_MainTex, i.uv);
                float4 outline = _OutlineColor;
                float2 uv = i.uv;
                uv.x = 1.0 - uv.x;
                float d = _OutlineWidth;
                float4 border = tex2D(_MainTex, uv);
                float4 smoothness = 1.0 - abs(border.r - col.r);
                smoothness = smoothness * smoothness;
                float3 final_col = lerp(col.rgb, outline.rgb, smoothness.r * d);
                return float4(final_col, col.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
