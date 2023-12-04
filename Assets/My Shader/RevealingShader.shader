Shader"Revealing Under Light"{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _LightDirection ("Light Direction", Vector) = (0, 0, 1, 0)
        _LightPosition ("Light Position", Vector) = (0, 0, 0, 0)
        _LightAngle ("Light Angle", Range(0, 180)) = 45
        _StrengthScaler ("Strength", Float) = 50
    }

    SubShader
    {
        Tags {"Queue" = "Overlay" }
LOD 100

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0

sampler2D _MainTex;

struct Input
{
    float2 UV_MainTex;
    float3 worldPos;
};

half _Glossiness;
half _Metallic;
fixed4 _Color;
float4 _LightPosition;
float4 _LightDirection;
float _LightAngle;
float _StrengthScaler;

void surf(Input IN, inout SurfaceOutputStandard o)
{
    float3 Dir = normalize(_LightPosition - IN.worldPos);
    float Scale = dot(Dir, _LightDirection);
    float Strength = saturate(Scale - cos(_LightAngle * (3.14 / 180.0)));
    Strength = Strength * _StrengthScaler;

    fixed4 c = tex2D(_MainTex, IN.UV_MainTex) * _Color;

            // Adjust Albedo based on Strength
    o.Albedo = c.rgb * Strength;

            // Emission adds light to the scene
    o.Emission = c.rgb * Strength;

    o.Metallic = _Metallic;
    o.Smoothness = _Glossiness;
    o.Alpha = Strength * c.a;
}
        ENDCG
    }

Fallback"Diffuse"
}
