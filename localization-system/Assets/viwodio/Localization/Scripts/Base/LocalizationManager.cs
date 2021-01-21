    using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace viwodio.Localization
{
    public abstract class LocalizationManager<TDictionary, TValue> : MonoBehaviour
        where TDictionary : Dictionary<TValue>
    {
        [SerializeField]
        private LocalizationSettingsData<TDictionary, TValue> _localizationSettings;

        public UnityEvent onChangeLanguage;

        private void Start()
        {
            onChangeLanguage.Invoke();
        }

        public void ChangeLanguage(string languageCode)
        {
            LanguageData languageData = _localizationSettings.FindLanguage(languageCode);
            ChangeLanguage(languageData);
        }

        public void ChangeLanguage(LanguageData languageData)
        {
            if (SetCurrentLanguage(languageData))
            {
                onChangeLanguage?.Invoke();
            }
        }

        private bool SetCurrentLanguage(LanguageData languageData)
        {
            if (_localizationSettings.ContainsLanguage(languageData))
            {
                PlayerPrefs.SetString(
                    _localizationSettings.LanguagePrefsKey, languageData.GetCode());

                return true;
            }
            else
            {
                return false;
            }
        }

        public TValue GetTranslation(string key)
        {
            return _localizationSettings
                .GetTranslationContainer(GetCurrentLanguage())
                .GetTranslation(key);
        }

        public string[] GetTranslationKeys()
        {
            if (_localizationSettings == null)
                return new string[0];
            else
                return _localizationSettings.GetKeys();
        }

        public string[] GetLanguageNames()
        {
            if (_localizationSettings == null)
                return new string[0];
            else
                return _localizationSettings.GetLanguageNames();
        }

        public string[] GetLanguageCodes()
        {
            if (_localizationSettings == null)
                return new string[0];
            else
                return _localizationSettings.GetLanguageCodes();
        }

        public LanguageData GetCurrentLanguage()
        {
            string languageCode = PlayerPrefs.GetString(
                _localizationSettings.LanguagePrefsKey,
                _localizationSettings.GetDefaultLanguage().GetCode());

            return _localizationSettings.FindLanguage(languageCode);
        }
    }
}