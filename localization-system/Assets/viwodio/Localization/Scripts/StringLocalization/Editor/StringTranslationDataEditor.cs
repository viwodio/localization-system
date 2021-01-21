using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(StringTranslationData), true)]
    public class StringTranslationDataEditor : TranslationDataEditor<StringDictionary, string>
    {
        public override void DictionaryElementValueDrawer(SerializedProperty valueProperty)
        {
            EditorGUILayout.PropertyField(valueProperty, GUIContent.none, GUILayout.ExpandWidth(true));
        }
    }
}