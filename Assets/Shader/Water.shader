Shader "Custom/Water"
{
	Properties
	{
		_Bumpmap("NormalMap", 2D) = "bump" {}
		_Cube("Cube", Cube) = "" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue"="Transparent" }

		CGPROGRAM
		#pragma surface surf Lambert alpha:fade

		samplerCUBE _Cube;
		sampler2D _Bumpmap;

		struct Input {
			float2 uv_Bumpmap;
			float3 worldRefl;
			float3 viewDir;
			INTERNAL_DATA
		};

        void surf (Input IN, inout SurfaceOutput o)
        {
			o.Normal = UnpackNormal(tex2D(_Bumpmap, IN.uv_Bumpmap));
			float3 refcolor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));
			o.Emission = refcolor;
			o.Alpha = 0.2;
        }
        ENDCG
    }
    FallBack "Legacy Shaders/Transparent/Vertexlit"
}
