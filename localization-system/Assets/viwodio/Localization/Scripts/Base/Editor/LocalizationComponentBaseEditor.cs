using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace viwodio.Localization
{
    [CustomEditor(typeof(LocalizationComponentBase<,,,>), true)]
    public abstract class LocalizationComponentBaseEditor<TDictionary, TValue, TManager> : Editor
        where TDictionary : Dictionary<TValue>
        where TManager : LocalizationManager<TDictionary, TValue>
    {
        SerializedProperty localizationManagerProp;
        SerializedProperty localizationKeyProp;
        SerializedProperty onUpdateValueProp;

        LocalizationManager<TDictionary, TValue> localizationManager;

        private void OnEnable()
        {
            onUpdateValueProp = serializedObject.FindProperty("onUpdateValue");
            localizationManagerProp = serializedObject.FindProperty("_localizationManager");
            localizationKeyProp = serializedObject.FindProperty("_localizationKey");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(localizationManagerProp);

            if (localizationManagerProp.objectReferenceValue != null)
            {
                localizationManager =
                    (LocalizationManager<TDictionary, TValue>)localizationManagerProp.objectReferenceValue;
            }

            LocalizationKeyPropertyDrawer();

            EventsDrawer();

            serializedObject.ApplyModifiedProperties();
        }

        private void LocalizationKeyPropertyDrawer()
        {
            if (localizationManager != null)
            {
                string[] keyArray = localizationManager.GetTranslationKeys();
                if (keyArray.Length > 0)
                {
                    int currentKeyIndex = keyArray.ToList().IndexOf(localizationKeyProp.stringValue);
                    currentKeyIndex = EditorGUILayout.Popup("Translation Key", currentKeyIndex, keyArray);
                    currentKeyIndex = Mathf.Clamp(currentKeyIndex, 0, keyArray.Length - 1);
                    localizationKeyProp.stringValue = keyArray[currentKeyIndex];
                }
            }
        }

        private void EventsDrawer()
        {
            GUILayout.BeginHorizontal(EditorStyles.helpBox);
            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            GUILayout.BeginVertical();
            onUpdateValueProp.isExpanded = EditorGUILayout.Foldout(onUpdateValueProp.isExpanded, "Events", true);
            if (onUpdateValueProp.isExpanded)
                EditorGUILayout.PropertyField(onUpdateValueProp);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
    }
}