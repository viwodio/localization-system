using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace viwodio.Localization
{
    public abstract class LocalizationSettingsData<TDictionary, TValue> : ScriptableObject
        where TDictionary : Dictionary<TValue>
    {
        [SerializeField] private string _languagePrefsKey = "current_language";
        public string LanguagePrefsKey => _languagePrefsKey;

        [SerializeField] private List<TranslationData<TDictionary, TValue>> _translations = new List<TranslationData<TDictionary, TValue>>();
        [SerializeField] private string[] _keys = new string[0];
        [SerializeField] private LanguageData _defaultLanguage;

        public LanguageData[] GetLanguageList()
        {
            List<LanguageData> languageList = new List<LanguageData>();

            foreach (var translation in _translations)
                if (translation != null)
                    if (translation.GetLanguage() != null)
                        if (!languageList.Contains(translation.GetLanguage()))
                            languageList.Add(translation.GetLanguage());

            return languageList.ToArray();
        }

        public bool ContainsLanguage(string languageCode)
        {
            return FindLanguage(languageCode) != null;
        }

        public bool ContainsLanguage(LanguageData languageData)
        {
            return GetLanguageList().Contains(languageData);
        }

        public LanguageData FindLanguage(string languageCode)
        {
            return GetLanguageList()
                .Single(language => language.GetCode().Equals(languageCode));
        }

        public TranslationData<TDictionary, TValue> GetTranslationContainer(LanguageData language)
        {
            return _translations
                .Single(translation => translation.GetLanguage().Equals(language));
        }

        public string[] GetLanguageNames()
        {
            return GetLanguageList().Select(language => language.GetName()).ToArray();
        }

        public string[] GetLanguageCodes()
        {
            return GetLanguageList().Select(language => language.GetCode()).ToArray();
        }

        public string[] GetKeys() => _keys;

        public LanguageData GetDefaultLanguage() => _defaultLanguage;

        public void SynchronizeKeys()
        {
            foreach (var translation in _translations)
                translation.SynchronizeDictionaryKeys(_keys);
        }
    }
}
