using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(TranslationData<,>), true)]
    public abstract class TranslationDataEditor<TDictionary, TValue> : Editor
        where TDictionary : Dictionary<TValue>
    {
        SerializedProperty languageDataProp;
        SerializedProperty dictionaryProp;
        SerializedProperty dictionaryBaseListProp;


        private void OnEnable()
        {
            languageDataProp = serializedObject.FindProperty("_languageData");
            dictionaryProp = serializedObject.FindProperty("_dictionary");
            dictionaryBaseListProp = dictionaryProp.FindPropertyRelative("_baseList");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(languageDataProp);

            EditorGUILayout.Separator();

            DictionaryDrawer();

            serializedObject.ApplyModifiedProperties();
        }

        private void DictionaryDrawer()
        {
            for (int i = 0; i < dictionaryBaseListProp.arraySize; i++)
            {
                SerializedProperty keyValueStoreProperty = dictionaryBaseListProp.GetArrayElementAtIndex(i);
                DictionaryElementDrawer(keyValueStoreProperty);
            }
        }

        private void DictionaryElementDrawer(SerializedProperty keyValueStoreProperty)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(keyValueStoreProperty.FindPropertyRelative("_key").stringValue, GUILayout.Width(120));
            DictionaryElementValueDrawer(keyValueStoreProperty.FindPropertyRelative("_value"));
            GUILayout.EndHorizontal();
        }

        public abstract void DictionaryElementValueDrawer(SerializedProperty valueProperty);
    }
}