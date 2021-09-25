Shader "Custom/Toon"
{
    Properties
    {
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("NormalMap" , 2D) = "bump" {}
		_Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
		cull front
		// 1st Pass

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Nolight vertex:vert noshadow noambient

		void vert(inout appdata_full v) {
		v.vertex.xyz = v.vertex.xyz + normalize(v.normal.xyz) * 0.4;
		}

        struct Input
        {
			float4 color:COLOR;
        };
		void surf(Input IN, inout SurfaceOutput o) {

		}

		float4 LightingNolight(SurfaceOutput s, float3 lightDir, float atten) {
			return float4(0, 0, 0, 1);
		}
		ENDCG

		cull back
		// 2nd Pass

		CGPROGRAM
		#pragma surface surf Toon

		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _Color;
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			o.Albedo = c.rgb * _Color;
			o.Alpha = c.a;
		}

		float4 LightingToon(SurfaceOutput s, float3 lightDir, float atten) {
			float ndotl = dot(s.Normal, lightDir) * 0.5 + 0.5;

			if (ndotl > 0.7)
			{
				ndotl = 1;
			}
			else
			{
				ndotl = 0.3;
			}

			float4 final;

			final.rgb = s.Albedo * ndotl * _LightColor0.rgb;
			final.a = s.Alpha;

			return final;
		}
		ENDCG
    }
    FallBack "Diffuse"
}
