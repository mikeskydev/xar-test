Shader "TaskShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _BlendColor ("BlendColor", Color) = (1, 1, 1, 1)
        _Lerp ("Lerp", Range (-1, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            fixed4 _Color;
            fixed4 _BlendColor;
            fixed _Lerp;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float PerlinNoise(float x, float y, float time)
            {
                return (frac(sin(x + y + time) * 49) * 2.0 - 1.0 ) * 0.5;
            }

            v2f vert (appdata v)
            {
                v2f o;
                float noiseValue = PerlinNoise(v.vertex.x, v.vertex.y, _Time);
                v.vertex.xyz += v.normal * noiseValue * 0.2;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }


            fixed4 frag (v2f i) : SV_Target
            {
                fixed remapLerp = (_Lerp + 1) * 0.5;
                fixed4 col = lerp(_Color, _BlendColor, remapLerp);

                return col;
            }
            ENDCG
        }
    }
}
