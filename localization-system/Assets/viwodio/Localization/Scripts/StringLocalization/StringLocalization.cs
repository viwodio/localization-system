using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace viwodio.Localization
{
    [AddComponentMenu("viwodio/Localization/String Localization")]
    public class StringLocalization : LocalizationComponentBase<StringDictionary, string, StringLocalizationManager, StringLocalization.UpdateValueEvent>
    {
        [Serializable] public class UpdateValueEvent : UnityEvent<string> { };
    }
}
