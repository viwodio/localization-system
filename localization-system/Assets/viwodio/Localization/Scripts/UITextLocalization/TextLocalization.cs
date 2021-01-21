using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace viwodio.Localization
{
    [RequireComponent(typeof(Text))]
    [AddComponentMenu("viwodio/Localization/UIText Localization")]
    public class TextLocalization : StringLocalization
    {
        private Text _component;

        private void Awake()
        {
            _component = GetComponent<Text>();
        }

        protected override void UpdateValue(string value)
        {
            _component.text = value;
        }
    }
}
