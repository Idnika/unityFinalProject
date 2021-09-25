Shader "Custom/Shader_Map"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
			float3 worldPos;

        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		float _TimeDeltaF01;
		float _TimeDeltaB01;
		float _TimeDeltaF02;
		float _TimeDeltaB02;
		float _TimeDeltaF03;
		float _TimeDeltaB03;
		float4 _StartPos;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)



        void surf (Input IN, inout SurfaceOutputStandard o)
        {

			float3 vWorldPos = IN.worldPos;
			vWorldPos.y = 0;

			float3 vWorldPos2 = IN.worldPos;
			vWorldPos2.x = 0;
			float3 vWorldPos3 = IN.worldPos;
			vWorldPos3.z = 0;

			float4 vStartPos = _StartPos;
			vStartPos.y = 0;

			float4 vStartPos2 = _StartPos;
			vStartPos2.x = 0;
			vStartPos2.y = 0;

			float4 vStartPos3 = _StartPos;
			vStartPos3.z = 0;
			vStartPos3.y = 0;


			float fDis01 = distance(float4(vWorldPos.x, 0, vWorldPos.z, 0), vStartPos);
			float fWaveMid01 = (_TimeDeltaF01 + _TimeDeltaB01) * 0.5;
			float fRadius01 = (_TimeDeltaF01 - _TimeDeltaB01) * 0.5;

			float fDis02 = distance(float4(0, 0, vWorldPos.z, 0), vStartPos2);
			float fWaveMid02 = (_TimeDeltaF02 + _TimeDeltaB02) * 0.5;
			float fRadius02 = (_TimeDeltaF02 - _TimeDeltaB02) * 0.5;

			float fDis03 = distance(float4(vWorldPos.x, 0, 0, 0), vStartPos3);
			float fWaveMid03 = (_TimeDeltaF03 + _TimeDeltaB03) * 0.5;
			float fRadius03 = (_TimeDeltaF03 - _TimeDeltaB03) * 0.5;

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;


			if (fDis01 > _TimeDeltaB01 && fDis01 < _TimeDeltaF01)
			{
				o.Albedo = o.Albedo + float3(0, 1, 0) * pow((1 - abs(fDis01 - fWaveMid01) / fRadius01), 3);
			}

			if (fDis02 > _TimeDeltaB02 && fDis02 < _TimeDeltaF02)
			{
				o.Albedo = o.Albedo + float3(1, 0, 0) * pow((1 - abs(fDis02 - fWaveMid02) / fRadius02), 3);
			}

			if (fDis03 > _TimeDeltaB03 && fDis03 < _TimeDeltaF03)
			{
				o.Albedo = o.Albedo + float3(0, 0, 1) * pow((1 - abs(fDis03 - fWaveMid03) / fRadius03), 3);
			}



            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
