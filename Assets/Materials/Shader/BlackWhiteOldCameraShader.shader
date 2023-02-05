Shader "Custom/BlackWhiteOldCameraShader" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Vignette ("Vignette", Range(0, 1)) = 0.5
        _Noise ("Noise", Range(0, 1)) = 0.5
        _Scanlines ("Scanlines", Range(0, 1)) = 0.5
    }

    SubShader {
        Tags {"RenderType"="Opaque"}
        LOD 200

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
            float _Vignette;
            float _Noise;
            float _Scanlines;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float4 col = tex2D(_MainTex, i.uv);
                float avg = (col.r + col.g + col.b) / 3.0;
                float3 final_col = float3(avg, avg, avg);

                float2 pos = i.uv - 0.5;
                pos *= 1.0 + _Vignette * 2.0;
                float vignette = 1.0 - dot(pos, pos);
                vignette = pow(vignette, 3.0);
                final_col *= vignette;

                float3 noise = (tex2D(_MainTex, i.uv * 10.0).r - 0.5) * _Noise;
                final_col += noise;

                float3 scanline = (sin(i.uv.y * 40.0) * 0.5 + 0.5) * _Scanlines;
                final_col = lerp(final_col, final_col * 1.2, scanline);

                return float4(final_col, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
