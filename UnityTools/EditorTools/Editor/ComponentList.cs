using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;
using GUIWrapper;

namespace EditorTools
{
	public class ComponentList : EditorWindow 
	{
		private GUIVertical _gui;

		[MenuItem( "Window/Pixelated/Editor Tools/Component List")]
		public static void Init()
		{
			ComponentList win = EditorWindow.GetWindow( typeof( ComponentList)) as ComponentList;
			win.titleContent = new GUIContent( "Component List");
			win.Show();
		}

		public void RefreshList( GameObject gameObject)
		{
			_gui = new GUIVertical();

			if( gameObject == null)
			{
				_gui.Add( new GUILabel( new GUIContent( "Select a GameObject to edit it's component list.")));
			}
			else
			{
				_gui.Add( new GUIButton( new GUIContent( "Highlight " + gameObject.name), HighlightSelectedGameObjectClicked));

				GUIScrollView scrollView = new GUIScrollView();
				_gui.Add( scrollView);

				Component[] components = gameObject.GetComponents<Component>();
				int index = 0;
				int maxIndex = Math.Max( 0, components.Length - 1);
				foreach( Component component in components)
				{
					GUIContent componentName = new GUIContent( component.GetType().Name);
					GUIDelayedIntField field = new GUIDelayedIntField( componentName, 
																	   index++, 
																	   1,
																	   maxIndex,
																	   ComponentIndexChanged);
					
					field.isEnabled = index > 1;

					scrollView.Add( field);
				}
			}

			Repaint();
		}

		#region GUI Actions

		void HighlightSelectedGameObjectClicked( GUIBase sender)
		{
			EditorGUIUtility.PingObject( SelectedGameObject());
		}

		void ComponentIndexChanged( GUIBase sender)
		{
			GUIDelayedIntField field = sender as GUIDelayedIntField;
			GameObject gameObject = SelectedGameObject();

			ReorderComponent( gameObject, field.previousValue, field.value);
			RefreshList( gameObject);
		}

		#endregion

		void ReorderComponent( GameObject gameObject, int index, int newIndex)
		{
			Component component = GetComponent( gameObject, index);
			if( component != null)
			{
				if( newIndex < index)
				{
					while( UnityEditorInternal.ComponentUtility.MoveComponentUp( component) && --index != newIndex) {}
				}
				else if( newIndex > index)
				{
					while( UnityEditorInternal.ComponentUtility.MoveComponentDown( component) && ++index != newIndex) {}
				}
			}
		}

		GameObject SelectedGameObject()
		{
			UnityEngine.Object[] gameObjects = Selection.GetFiltered( typeof( GameObject), 
																	  SelectionMode.Editable | SelectionMode.TopLevel);
			return gameObjects.Length > 0 ? gameObjects[0] as GameObject : null;
		}

		Component GetComponent( GameObject gameObject, int index)
		{
			if( gameObject != null)
			{
				Component[] components = gameObject.GetComponents<Component>();

				if( index >= 0 && index < components.Length)
				{
					return components[ index];
				}
			}

			return null;
		}

		void OnHierarchyChange()
		{
			RefreshList( SelectedGameObject());
		}

		void OnSelectionChange()
		{
			RefreshList( SelectedGameObject());
		}

		void OnEnable()
		{
			RefreshList( SelectedGameObject());
		}

		void OnDisable()
		{
			_gui = null;
		}

		void OnGUI()
		{
			if( _gui != null)
			{
				_gui.OnGUI();
			}
		}
	}
}
