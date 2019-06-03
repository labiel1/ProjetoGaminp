
Shader "limbo"
{
	Properties
	{
		_Color("Color", Color) = (0,1,0,1)
		_MainTex ("Texture", 2D) = "white" {}
	    _Tex("noise", 2D) = "white" {}
		_Range("Range", Float) = 0.01
		_ColorMultiplier("Color Multiplier", Float) = 1
		_ColorMask("Color Mask", 2D) = "white" {}
		_ttt("maskk",Float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float2 uv_depth : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uv_depth = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _Tex;
			sampler2D _ColorMask;
			sampler2D_float _CameraDepthTexture;
			float _Range;
			float _ColorMultiplier;
			float _ttt;
			fixed4 _Color;

			fixed lum(fixed3 color) {
				return 0.299*color.r + 0.587*color.g + 0.114*color.b;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float d = sin(_Time.y*0.3);
				if (d >=0.999||d>=0.995&&d<=0.996) {
				
					_ttt = 0.7;

				}
				else {
				_ttt = 1;
				}
				float depth = DecodeFloatRG(tex2D(_CameraDepthTexture, i.uv));
				float linearDepth = Linear01Depth(depth); 
				linearDepth = max(0, (_Range - linearDepth) / _Range);
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 mask = tex2D(_ColorMask, i.uv)*_ttt;
				fixed noise = tex2D(_Tex, (i.uv*4)+_Time.y);

				fixed color = (lum(col) * _ColorMultiplier) + linearDepth;
				return _Color * color  * mask * noise;
			}
			ENDCG
		}
	}
}
