using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor.Experimental;
using UnityEditor.Experimental.Graph;
using Object = UnityEngine.Object;

namespace UnityEditor.Experimental
{
    internal class VFXEdNodeBlockHeaderToggleable : VFXEdNodeBlockHeaderSimple
    {
        public bool Enabled { get { return m_Enabled; } set { m_Enabled = value; } }
        protected bool m_Enabled;

        public VFXEdNodeBlockHeaderToggleable(string Text, Texture2D icon, bool Collapseable, VFXBlockModel model) 
            : base(Text, icon, Collapseable)
        {
            AddManipulator(new Toggleable(VFXEditorMetrics.NodeBlockHeaderToggleRect, model));
        }

        public override void Render(Rect parentRect, Canvas2D canvas)
        {
            base.Render(parentRect, canvas);

            Rect drawablerect = GetDrawableRect();

            Rect toggleRect = VFXEditorMetrics.NodeBlockHeaderToggleRect;
            toggleRect.min = toggleRect.min + drawablerect.min;
            toggleRect.size = VFXEditorMetrics.NodeBlockHeaderToggleRect.size;
            if (Event.current.type == EventType.Repaint)
            {
                EditorStyles.toggle.Draw(toggleRect, false, Enabled, Enabled, false);
            }

            /*bool enabled = GUI.Toggle(toggleRect, m_Enabled, GUIContent.none);
            if(enabled != m_Enabled)
            {
                m_Model.Enabled = enabled;
                ((VFXEdDataSource)ParentCanvas().dataSource).SyncView(m_Model);
            }*/
        }
    }
}
