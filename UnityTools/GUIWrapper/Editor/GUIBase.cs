using UnityEngine;
using System.Collections;

namespace GUIWrapper
{
	public class GUIBase 
	{
		public delegate void OnGUIPreAction( GUIBase sender);
		public OnGUIPreAction onGUIPreAction;

		public delegate void OnGUIAction( GUIBase sender);
		public OnGUIAction onGUIAction;

		public bool isHidden;
		public bool isEnabled;
		public bool shouldStoreLastRect;
		public int tag;
		public string controlName;

		private Rect _lastRect;
		public Rect lastRect { get { return _lastRect; } }

		public GUIBase()
		{
			isEnabled = true;
		}

		public void OnGUI()
		{
			if( isHidden == false)
			{
				bool oldGUIEnabled = GUI.enabled;
				GUI.enabled = isEnabled;
				if( controlName != null && controlName.Length > 0)
				{
					GUI.SetNextControlName( controlName);
				}
				CustomOnGUI();
				GUI.enabled = oldGUIEnabled;

				if( shouldStoreLastRect && Event.current.type == EventType.Repaint)
				{
					_lastRect = GUILayoutUtility.GetLastRect();
				}
			}
		}

		protected virtual void CustomOnGUI()
		{
			
		}

		protected void CallGUIPreAction()
		{
			if( onGUIPreAction != null)
			{
				onGUIPreAction( this);
			}
		}

		protected void CallGUIAction()
		{
			if( onGUIAction != null)
			{
				onGUIAction( this);
			}
		}
	}
}