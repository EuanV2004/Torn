using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR

namespace Torn.Office
{
    public class MakeScriptableObject
    {
        [MenuItem("Assets/Create/ScriptableObjects/OfficePuzzlePieces")]

        public static void CreateMyAsset()
        {
            ScriptableOfficePuzzle asset = ScriptableObject.CreateInstance<ScriptableOfficePuzzle>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/OfficePuzzlePieces/OfficePuzzlePieces.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
#endif
