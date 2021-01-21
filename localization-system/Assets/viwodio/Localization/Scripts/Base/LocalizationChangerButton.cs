using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace viwodio.Localization
{
    public abstract class LocalizationChangerButton<TDictionary, TValue, TManager> : MonoBehaviour
        where TDictionary : Dictionary<TValue>
        where TManager : LocalizationManager<TDictionary, TValue>
    {
        [SerializeField] private Button _button;
        [SerializeField] private TManager _localizationManager;
        [SerializeField] private string _languageCode;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _localizationManager.ChangeLanguage(_languageCode);
        }
    }
}