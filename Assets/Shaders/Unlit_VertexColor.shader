Shader "Unlit/Vertex Color" {

	Properties {
		_Color ("Color Tint", Color) = (1,1,1,1)
		_Intensity ("Add White", Range (0, 1)) = 0
	}

	SubShader {
		ZWrite On
		Cull Off
		Lighting Off

		Pass {
			CGPROGRAM
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			// Vert
			struct vertexInput {
				half4 vertex : POSITION;
				fixed4 color : COLOR;
			};

			// Frag
			struct vertexOutput {
				half4 pos : SV_POSITION;
				fixed4 color : COLOR;
			};

			// Uniforms
			uniform fixed4 _Color;
			uniform fixed _Intensity;

			// Vertex Program
			vertexOutput vert(vertexInput v) {
				vertexOutput o;

				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color * _Color;

				return o;
			}

			/// Fragment Program
			fixed4 frag(vertexOutput i) : COLOR {

				return i.color + (_Intensity * 2);
			}
			ENDCG

		}
	}
}