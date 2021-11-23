using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUITextureField : GUIBase 
	{
		public Texture2D texture;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUITextureField( GUIContent content, OnGUIAction action=null, OnGUIPreAction preAction=null)
		{
			_content = content;
			if( preAction != null)
			{
				onGUIPreAction += preAction;
			}

			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			Texture2D newTexture = EditorGUILayout.ObjectField( _content, texture, typeof( Texture2D), false) as Texture2D;
			if( newTexture != texture)
			{
				CallGUIPreAction();
				texture = newTexture;
				CallGUIAction();
			}
		}
	}
}
