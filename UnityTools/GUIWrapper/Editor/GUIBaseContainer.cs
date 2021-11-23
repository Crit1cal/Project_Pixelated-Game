using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GUIWrapper
{
	public class GUIBaseContainer : GUIBase
	{
		private List<GUIBase> _children;

		protected virtual bool areChildrenHidden { get { return false; } }

		public GUIBaseContainer()
		{
			_children = new List<GUIBase>();
		}

		public GUIBase Add( GUIBase child)
		{
			_children.Add( child);
			return child;
		}

		public void Remove( GUIBase child)
		{
			_children.Remove( child);
		}

		public void RemoveAll()
		{
			_children.Clear();
		}

		protected override void CustomOnGUI()
		{
			BeginContainerOnGUI();

			if( areChildrenHidden == false)
			{
				foreach( GUIBase gui in _children)
				{
					gui.OnGUI();
				}
			}

			EndContainerOnGUI();
		}

		protected virtual void BeginContainerOnGUI()
		{
			
		}

		protected virtual void EndContainerOnGUI()
		{
			
		}
	}
}