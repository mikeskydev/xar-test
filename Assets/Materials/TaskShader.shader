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

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 _Color;
            fixed4 _BlendColor;
            fixed _Lerp;

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
