using UnityEngine;
using System.Collections;

namespace PixelRender
{
	[ExecuteInEditMode]
	public class PixelOutlineEffect : MonoBehaviour
	{
		public Color outlineColor;
		[Range( 0.0f, 0.05f)]
		public float depthThreshold;
		private Material _outlineMaterial;


		void OnEnable()
		{
			Camera cam = GetComponent<Camera>();
			cam.depthTextureMode = DepthTextureMode.Depth;
		}

		[ImageEffectOpaque]
		void OnRenderImage( RenderTexture source, RenderTexture destination)
		{
			if( _outlineMaterial == null)
			{
				_outlineMaterial = new Material( Shader.Find( "Hidden/Pixelated/PixelRender/PixelOutline"));
				_outlineMaterial.hideFlags = HideFlags.HideAndDontSave;
			}

			_outlineMaterial.SetColor( "_OutlineColor", outlineColor);
			_outlineMaterial.SetFloat( "_DepthThreshold", -depthThreshold);

			Graphics.Blit( source, destination, _outlineMaterial);
		}
	}
}
