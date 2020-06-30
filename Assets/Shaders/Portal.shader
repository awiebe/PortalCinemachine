Shader "Unlit/PortalShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            #pragma target 3.0
           
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
            };
 
 
            sampler2D _MainTex;
            float4 _MainTex_ST;
           
            struct v2f
            {
                UNITY_FOG_COORDS(1)
            };
 
            v2f vert (
                float4 vertex : POSITION,
                out float4 outpos : SV_POSITION
                )
            {
                outpos = UnityObjectToClipPos(vertex);
                v2f o;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
           
            fixed4 frag (v2f i, UNITY_VPOS_TYPE vpos : VPOS) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, vpos.xy / _ScreenParams.xy);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
 