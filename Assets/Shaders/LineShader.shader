Shader "LineShader" {

  SubShader {
    Pass {
      Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
      Blend SrcAlpha OneMinusSrcAlpha
        ZWrite On
        Lighting Off
        Cull Off
        AlphaTest Greater 0.5
        CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

        uniform float _Phase;

      struct VertOut {
        float4 position : POSITION;
        float3 color : COLOR;
      };

      struct VertIn {
        float4 vertex : POSITION;
        float3 color : COLOR;
      };

      VertOut vert (VertIn input)
      {
        float4 draw_color = float4(0.695, 0.492, 0.277, 1.0);
        float4 base_color = float4(0.277, 0.492, 0.695, 0.1);
        VertOut output;
        output.position = mul (UNITY_MATRIX_MVP, input.vertex);
        float t = fmod(_Phase + input.color[0], 1.0);
        t = clamp(t * t * t * t - 0.4, 0.0, 1.0);
        output.color = t * 5.0 * draw_color + 0.2 * base_color;
        return output;
      }

      half4 frag (VertOut input) : COLOR
      {
        return half4 (input.color, 1.0);
      }
      ENDCG
    }
  }

  FallBack "VertexLit"
} 
