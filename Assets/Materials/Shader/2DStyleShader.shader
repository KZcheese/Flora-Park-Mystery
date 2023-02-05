Shader "Custom/2DStyleShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _Thickness ("Outline Thickness", Range(0, 1)) = 0.1
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 200

        Pass {
            Tags { "LightMode" = "Always" }
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

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
            float _Thickness;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float4 col = tex2D(_MainTex, i.uv);
                float4 outline = float4(0, 0, 0, 0);
                float2 offset = float2(0.5, 0.5) * _Thickness / i.vertex.w;

                outline.r = tex2D(_MainTex, i.uv + float2(-offset.x, -offset.y)).r;
                outline.g = tex2D(_MainTex, i.uv + float2(-offset.x, offset.y)).g;
                outline.b = tex2D(_MainTex, i.uv + float2(offset.x, -offset.y)).b;
                outline.a = tex2D(_MainTex, i.uv + float2(offset.x, offset.y)).a;

                float4 blended_col = lerp(col, outline, _OutlineColor.a);
                blended_col.rgb = blended_col.rgb * _OutlineColor.rgb;

                return blended_col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
