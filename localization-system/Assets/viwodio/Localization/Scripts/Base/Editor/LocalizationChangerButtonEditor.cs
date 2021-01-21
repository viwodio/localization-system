using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;

namespace viwodio.Localization
{
    [CustomEditor(typeof(LocalizationChangerButton<,,>), true)]
    public abstract class LocalizationChangerButtonEditor<TDictionary, TValue> : Editor
        where TDictionary : Dictionary<TValue>
    {
        SerializedProperty buttonProp;
        SerializedProperty localizationManagerProp;
        SerializedProperty languageCodeProp;
        LocalizationManager<TDictionary, TValue> localizationManager;

        private void OnEnable()
        {
            buttonProp = serializedObject.FindProperty("_button");
            localizationManagerProp = serializedObject.FindProperty("_localizationManager");
            languageCodeProp = serializedObject.FindProperty("_languageCode");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(buttonProp);
            EditorGUILayout.PropertyField(localizationManagerProp);
            if (localizationManagerProp.objectReferenceValue != null)
            {
                localizationManager =
                    (LocalizationManager<TDictionary, TValue>)localizationManagerProp.objectReferenceValue;
            }

            LanguageCodePropertyDrawer();

            serializedObject.ApplyModifiedProperties();
        }

        private void LanguageCodePropertyDrawer()
        {
            if (localizationManager != null)
            {
                string[] nameArray = localizationManager.GetLanguageNames();
                string[] codeArray = localizationManager.GetLanguageCodes();
                if (nameArray.Length > 0)
                {
                    int currentIndex = codeArray.ToList().IndexOf(languageCodeProp.stringValue);
                    currentIndex = EditorGUILayout.Popup("Language", currentIndex, nameArray);
                    currentIndex = Mathf.Clamp(currentIndex, 0, codeArray.Length - 1);
                    languageCodeProp.stringValue = codeArray[currentIndex];
                }
            }
        }
    }
}