Shader "Custom/GenshinToonShader" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1, 1, 1, 1)
        _Threshold ("Threshold", Range(0, 1)) = 0.5
        _Smoothness ("Smoothness", Range(0, 1)) = 0.2
        _OutlineWidth ("Outline Width", Range(0, 0.05)) = 0.01
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
            float4 _OutlineColor;
            float _Threshold;
            float _Smoothness;
            float _OutlineWidth;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float4 col = tex2D(_MainTex, i.uv);
                float3 final_col = col.rgb;

                float4 outline = float4(0, 0, 0, 0);
                for (int x = -1; x <= 1; x++) {
                    for (int y = -1; y <= 1; y++) {
                        if (x == 0 && y == 0) continue;
                        float4 sample = tex2D(_MainTex, i.uv + float2(x, y) * _OutlineWidth);
                        float sample_avg = (sample.r + sample.g + sample.b) / 3.0;
                        float col_avg = (col.r + col.g + col.b) / 3.0;
                        if (sample_avg > col_avg + _Threshold) {
                            outline = sample;
                            break;
                        }
                    }
                }

                float4 blended_col = lerp(col, outline, _Smoothness);
                final_col = blended_col.rgb * _OutlineColor.rgb;

                return float4(final_col, col.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
