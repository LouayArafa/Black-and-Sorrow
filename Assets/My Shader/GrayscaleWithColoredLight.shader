Shader"Custom/GrayscaleWithColoredLight"
 {
 
    Properties {
        _DesatVal ("Desaturation value", Range(1, 100)) = 1
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
//        [HideInInspector] _TempColor ("Temp Color", Color) = (1,1,1,1)
//        [HideInInspector] _TempAlpha ("Temp Alpha", float) = 2
    }
 
    SubShader {
ColorMask RGB
 
        Tags {
        "RenderType" = "Transparent"
        "Queue" = "Transparent"
        "IgnoreProjector" = "True"
        }
 
Lighting On

Cull Off

ZWrite on

Blend SrcAlpha
OneMinusSrcAlpha
 
 
        CGPROGRAM
        #pragma surface surf SimpleLambert alpha:fade
 
sampler2D _MainTex;
 
fixed4 _Color;
//        fixed4 _TempColor;
//        fixed _TempAlpha;
 
half _DesatVal;
 
struct Input
{
    float2 uv_MainTex;
};
 
half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten)
{
    half NdotL = dot(s.Normal, lightDir);
    half4 c;
    float lightValue = (NdotL * atten * 2);
    c.rgb = s.Albedo * _LightColor0.rgb * lightValue;
    c.a = lightValue;
    return c;
}
 
void surf(Input IN, inout SurfaceOutput o)
{
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
//            _TempColor = c; // get texture default color
//            _TempAlpha = tex2D(_MainTex, IN.uv_MainTex).a;
    o.Albedo = c.rgb;
    o.Alpha = 0;
}
 
    ENDCG
    }
Fallback"Diffuse"
}