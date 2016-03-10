// Taken from http://answers.unity3d.com/questions/392616/fade-shader-one-texture-fades-in-the-other-fades-o.html

Shader "Custom/AlphaBlendTransition" {
 Properties {
     _Blend ("Blend", Range (0, 1) ) = 0.0
     _BaseTexture ("Base Texture", 2D) = "" {}
     _OverlayTexture ("Texture 2 with alpha", 2D) = "" {}
 
 }
 SubShader {
         Pass {
             SetTexture[_BaseTexture]
             SetTexture[_OverlayTexture] {
                 ConstantColor (0,0,0, [_Blend]) 
                 combine texture Lerp(constant) previous
             }
         }
     }
 }