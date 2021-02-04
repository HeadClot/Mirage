using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Mirror
{
    [CustomEditor(typeof(NetworkScene), true)]
    [CanEditMultipleObjects]
    public class NetworkSceneInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Register All Prefabs"))
            {
                Undo.RecordObject(target, "Register prefabs for spawn");
                PrefabUtility.RecordPrefabInstancePropertyModifications(target);
                OnPostProcessScene((NetworkScene)target);
            }
        }

        public static void OnPostProcessScene(NetworkScene target)
        {
            target.SceneObjects.Clear();

            IEnumerable<NetworkIdentity> identities = Resources.FindObjectsOfTypeAll<NetworkIdentity>();

            foreach (NetworkIdentity identity in identities)
            {
                target.SceneObjects.Add(identity);
            }
        }
    }
}
