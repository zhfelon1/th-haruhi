// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33808,y:32609,varname:node_4795,prsc:2|emission-2393-OUT,alpha-6390-OUT,clip-4520-OUT,voffset-1458-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32453,y:32407,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4477-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:33082,y:32483,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-6126-RGB;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32536,y:32639,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32546,y:32788,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32516,y:33001,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:9781,x:32044,y:33204,ptovrint:False,ptlb:DissolveTex,ptin:_DissolveTex,varname:node_9781,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Step,id:2325,x:32304,y:33240,varname:node_2325,prsc:2|A-9781-R,B-8373-U;n:type:ShaderForge.SFN_TexCoord,id:8373,x:32027,y:33364,varname:node_8373,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Tex2d,id:5130,x:32422,y:33427,ptovrint:False,ptlb:MaskTex,ptin:_MaskTex,varname:node_5130,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6390,x:33156,y:33073,varname:node_6390,prsc:2|A-5130-R,B-5130-A,C-797-A,D-2053-A;n:type:ShaderForge.SFN_TexCoord,id:6081,x:31647,y:32580,varname:node_6081,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:4477,x:32075,y:32619,varname:node_4477,prsc:2|A-6081-UVOUT,B-5617-OUT;n:type:ShaderForge.SFN_Multiply,id:7110,x:31591,y:32842,varname:node_7110,prsc:2|A-7573-OUT,B-8986-T;n:type:ShaderForge.SFN_ValueProperty,id:7573,x:31238,y:32776,ptovrint:False,ptlb:u_speed,ptin:_u_speed,varname:node_7573,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:3754,x:31323,y:33062,ptovrint:False,ptlb:V_speed,ptin:_V_speed,varname:node_3754,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4524,x:31591,y:33042,varname:node_4524,prsc:2|A-8986-T,B-3754-OUT;n:type:ShaderForge.SFN_Time,id:8986,x:31284,y:32875,varname:node_8986,prsc:2;n:type:ShaderForge.SFN_Append,id:9597,x:31813,y:32842,varname:node_9597,prsc:2|A-7110-OUT,B-4524-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5617,x:32044,y:33004,ptovrint:False,ptlb:uv_on,ptin:_uv_on,varname:node_5617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9597-OUT,B-9799-OUT;n:type:ShaderForge.SFN_TexCoord,id:472,x:31656,y:33190,varname:node_472,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Append,id:9799,x:31913,y:33169,varname:node_9799,prsc:2|A-472-Z,B-472-W;n:type:ShaderForge.SFN_SwitchProperty,id:4520,x:33029,y:32942,ptovrint:False,ptlb:dissolve_on,ptin:_dissolve_on,varname:node_4520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3616-OUT,B-2325-OUT;n:type:ShaderForge.SFN_Vector1,id:3616,x:32794,y:32868,varname:node_3616,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:6955,x:32976,y:33412,ptovrint:False,ptlb:vertex,ptin:_vertex,varname:node_6955,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8313-OUT;n:type:ShaderForge.SFN_Multiply,id:1458,x:33639,y:33268,varname:node_1458,prsc:2|A-6955-RGB,B-3501-OUT,C-8222-W;n:type:ShaderForge.SFN_NormalVector,id:3501,x:33243,y:33393,prsc:2,pt:False;n:type:ShaderForge.SFN_TexCoord,id:8222,x:33073,y:33696,varname:node_8222,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Tex2d,id:6126,x:32939,y:32665,ptovrint:False,ptlb:tex2,ptin:_tex2,varname:node_6126,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Relay,id:8313,x:32381,y:33782,varname:node_8313,prsc:2|IN-4477-OUT;proporder:6074-797-9781-5130-7573-3754-5617-4520-6955-6126;pass:END;sub:END;*/

Shader "Fps/Effects/dissolve_blend_vertex" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        [HDR]_TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _DissolveTex ("DissolveTex", 2D) = "white" {}
        _MaskTex ("MaskTex", 2D) = "white" {}
        _u_speed ("u_speed", Float ) = 0
        _V_speed ("V_speed", Float ) = 0
        [MaterialToggle] _uv_on ("uv_on", Float ) = 0
        [MaterialToggle] _dissolve_on ("dissolve_on", Float ) = 1
        _vertex ("vertex", 2D) = "white" {}
        _tex2 ("tex2", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform sampler2D _DissolveTex; uniform float4 _DissolveTex_ST;
            uniform sampler2D _MaskTex; uniform float4 _MaskTex_ST;
            uniform float _u_speed;
            uniform float _V_speed;
            uniform fixed _uv_on;
            uniform fixed _dissolve_on;
            uniform sampler2D _vertex; uniform float4 _vertex_ST;
            uniform sampler2D _tex2; uniform float4 _tex2_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_8986 = _Time;
                float2 node_4477 = (o.uv0+lerp( float2((_u_speed*node_8986.g),(node_8986.g*_V_speed)), float2(o.uv1.b,o.uv1.a), _uv_on ));
                float2 node_8313 = node_4477;
                float4 _vertex_var = tex2Dlod(_vertex,float4(TRANSFORM_TEX(node_8313, _vertex),0.0,0));
                v.vertex.xyz += (_vertex_var.rgb*v.normal*o.uv1.a);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _DissolveTex_var = tex2D(_DissolveTex,TRANSFORM_TEX(i.uv0, _DissolveTex));
                float _dissolve_on_var = lerp( 1.0, step(_DissolveTex_var.r,i.uv1.r), _dissolve_on );
                clip(_dissolve_on_var - 0.5);
////// Lighting:
////// Emissive:
                float4 node_8986 = _Time;
                float2 node_4477 = (i.uv0+lerp( float2((_u_speed*node_8986.g),(node_8986.g*_V_speed)), float2(i.uv1.b,i.uv1.a), _uv_on ));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4477, _MainTex));
                float4 _tex2_var = tex2D(_tex2,TRANSFORM_TEX(i.uv0, _tex2));
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0*_tex2_var.rgb);
                float3 finalColor = emissive;
                float4 _MaskTex_var = tex2D(_MaskTex,TRANSFORM_TEX(i.uv0, _MaskTex));
                return fixed4(finalColor,(_MaskTex_var.r*_MaskTex_var.a*_TintColor.a*i.vertexColor.a));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
