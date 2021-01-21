using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace viwodio.Localization
{
    [CustomEditor(typeof(LocalizationSettingsData<,>), true)]
    public abstract class LocalizationSettingsDataEditor<TDictionary, TValue> : Editor
        where TDictionary : Dictionary<TValue>
    {
        SerializedProperty languagePrefsKeyProp;
        SerializedProperty defaultLanguageProp;
        SerializedProperty keysProp;
        SerializedProperty translationsProp;
        LocalizationSettingsData<TDictionary, TValue> localizationSettingsData;

        private void OnEnable()
        {
            localizationSettingsData = target as LocalizationSettingsData<TDictionary, TValue>;
            languagePrefsKeyProp = serializedObject.FindProperty("_languagePrefsKey");
            defaultLanguageProp = serializedObject.FindProperty("_defaultLanguage");
            keysProp = serializedObject.FindProperty("_keys");
            translationsProp = serializedObject.FindProperty("_translations");
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginVertical(EditorStyles.helpBox);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Language Prefs Key", GUILayout.Width(120));
            EditorGUILayout.PropertyField(languagePrefsKeyProp, GUIContent.none);
            GUILayout.EndHorizontal();

            DefaultLanguagePropertyDrawer();
            GUILayout.EndVertical();

            if (GUILayout.Button("Synchronize Keys"))
                localizationSettingsData.SynchronizeKeys();

            EditorGUILayout.PropertyField(translationsProp);
            EditorGUILayout.PropertyField(keysProp);

            serializedObject.ApplyModifiedProperties();
        }

        private void DefaultLanguagePropertyDrawer()
        {
            LanguageData defaultLanguage = (defaultLanguageProp.objectReferenceValue as LanguageData);
            List<LanguageData> languageList = localizationSettingsData.GetLanguageList().ToList();

            if (languageList.Count == 0) return;

            string[] languageNameList = localizationSettingsData.GetLanguageNames();
            int defaultLanguageIndex = languageList.IndexOf(defaultLanguage);
            defaultLanguageIndex = Mathf.Clamp(defaultLanguageIndex, 0, languageList.Count - 1);

            GUILayout.BeginHorizontal();

            GUILayout.Label("Default Language", GUILayout.Width(120));

            defaultLanguageIndex =
                EditorGUILayout.Popup(defaultLanguageIndex,languageNameList);

            defaultLanguageProp.objectReferenceValue = languageList[defaultLanguageIndex];

            GUILayout.EndHorizontal();
        }
    }
}
