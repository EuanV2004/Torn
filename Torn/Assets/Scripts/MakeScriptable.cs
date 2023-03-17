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
        [MenuItem("Assets/Create/ScriptableObjects/OfficeAnswers")]

        public static void CreateMyAsset()
        {
            ScriptableOfficePuzzle asset = ScriptableObject.CreateInstance<ScriptableOfficePuzzle>();
            ScriptableOfficeAnswer asset2 = ScriptableObject.CreateInstance<ScriptableOfficeAnswer>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/OfficePuzzlePieces/OfficePuzzlePieces.asset");
            AssetDatabase.CreateAsset(asset2, "Assets/ScriptableObjects/OfficePuzzlePieces/OfficeAnswers.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
            Selection.activeObject = asset2;
        }
    }
}
#endif
