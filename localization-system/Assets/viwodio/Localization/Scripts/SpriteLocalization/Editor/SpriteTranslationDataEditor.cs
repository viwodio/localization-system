using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(SpriteTranslationData), true)]
    public class SpriteTranslationDataEditor : TranslationDataEditor<SpriteDictionary, Sprite>
    {
        public override void DictionaryElementValueDrawer(SerializedProperty valueProperty)
        {
            EditorGUILayout.PropertyField(valueProperty,GUIContent.none, GUILayout.ExpandWidth(true));
        }
    }
}