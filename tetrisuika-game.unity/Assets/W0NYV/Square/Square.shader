Shader "Unlit/Square"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha 
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            StructuredBuffer<float4> _ColorBuffer;

            v2f vert (appdata v, uint instanceID : SV_InstanceID)
            {
                v2f o;

                UNITY_SETUP_INSTANCE_ID(v);
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = _ColorBuffer[instanceID];
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {                
                fixed4 col = i.color;
                return col;
            }
            ENDCG
        }
    }
}
