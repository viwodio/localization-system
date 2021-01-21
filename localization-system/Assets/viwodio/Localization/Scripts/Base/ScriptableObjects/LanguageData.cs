using UnityEngine;
using System.Collections;

namespace viwodio.Localization
{
    [CreateAssetMenu(fileName = "Language Data",menuName = "viwodio/Localization/Language")]
    public class LanguageData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _code;
        [SerializeField] private Sprite _icon;

        public string GetCode() => _code;
        public string GetName() => _name;
        public Sprite GetIcon() => _icon;
    }
}
