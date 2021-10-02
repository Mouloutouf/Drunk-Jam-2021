Shader "Unlit/Toon"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "LightMode"="ForwardBase"}
        LOD 100

        Pass
        {
            Cull Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma multi_compile_fwdadd_fullshadows

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			#include "AutoLight.cginc"

            struct appdata
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				SHADOW_COORDS(1)
                float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				half4 worldPos : TEXCOORD2;
				float3 viewDir : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			fixed4 _Color;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.uv = v.texcoord;
				o.viewDir = normalize(WorldSpaceViewDir(v.vertex));
				TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float3 normal = normalize(i.worldNormal);

				float fresnel = dot(i.viewDir, normal);

				float NdotL = dot(_WorldSpaceLightPos0, normal);
                NdotL = step(0.0, NdotL);

				float3 h = reflect(-_WorldSpaceLightPos0, normal);
				float spec = smoothstep(0.9, 1, dot(h, i.viewDir));

                float shadow = step(0.5, SHADOW_ATTENUATION(i));
                shadow *= NdotL;

				float3 diffuse = shadow * _LightColor0 + ShadeSH9(half4(normal, 1));
                fixed4 col = tex2D(_MainTex, i.uv);
				//return fixed4(ShadeSH9(half4(normal, 1)), 1);

				col.rgb *= _Color * diffuse;

                return col;
            }
            ENDCG
        }

		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
