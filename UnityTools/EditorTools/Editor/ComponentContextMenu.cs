using UnityEngine;
using UnityEditor;

namespace EditorTools
{
	public static class ComponentContextMenu
	{
		[MenuItem("CONTEXT/Component/Open Component List")]
		static void OpenComponentList( MenuCommand menuCommand)
		{
			ComponentList.Init();
		}

		[MenuItem("CONTEXT/Component/Move To Top")]
		static void MoveComponentToTop( MenuCommand menuCommand)
		{
			Component component = menuCommand.context as Component;
			while( UnityEditorInternal.ComponentUtility.MoveComponentUp(component)) {}
		}

		[MenuItem("CONTEXT/Component/Move To Bottom")]
		static void MoveComponentToBottom( MenuCommand menuCommand)
		{
			Component component = menuCommand.context as Component;
			while( UnityEditorInternal.ComponentUtility.MoveComponentDown(component)) {}
		}
	}
}
