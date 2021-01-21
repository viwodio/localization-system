using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

namespace viwodio.Localization
{
    public abstract class LocalizationComponentBase<TDictionary, TValue, TManager, TEvent> : MonoBehaviour
        where TDictionary : Dictionary<TValue>
        where TManager : LocalizationManager<TDictionary, TValue>
        where TEvent : UnityEvent<TValue>
    {
        [SerializeField] private TManager _localizationManager;
        [SerializeField] private string _localizationKey;

        public TEvent onUpdateValue;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_localizationManager != null)
                _localizationManager.onChangeLanguage.AddListener(UpdateValue);
        }

        private void OnEnable()
        {
            UpdateValue();
        }

        public void UpdateValue()
        {
            TValue value = _localizationManager.GetTranslation(_localizationKey);
            UpdateValue(value);
            onUpdateValue?.Invoke(value);
        }

        protected virtual void UpdateValue(TValue value) { }
    }
}