using UnityEngine;
using System.Linq;
using UnityEditor;

namespace viwodio.Localization
{
    public abstract class TranslationData<TDictionary, TValue> : ScriptableObject
        where TDictionary : Dictionary<TValue>
    {
        [SerializeField] private LanguageData _languageData;
        [SerializeField] private TDictionary _dictionary;

        public LanguageData GetLanguage() => _languageData;

        public void SynchronizeDictionaryKeys(string[] keys)
        {
            //block call in runtime
            if (Application.isPlaying) return;

            string[] keysNotInDictionary = keys.Except(_dictionary.GetKeys()).ToArray();
            string[] unnecessaryKeys = _dictionary.GetKeys().Except(keys).ToArray();

            _dictionary.InsertKeys(keysNotInDictionary);
            _dictionary.DeleteKeys(unnecessaryKeys);

            EditorUtility.SetDirty(this);
        }

        public TValue GetTranslation(string key)
        {
            return _dictionary.GetValue(key);
        }
    }
}
