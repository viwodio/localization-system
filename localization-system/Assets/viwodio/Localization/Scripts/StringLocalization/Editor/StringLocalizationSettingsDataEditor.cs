using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

namespace viwodio.Localization
{
    [CustomEditor(typeof(StringLocalizationSettingsData), true)]
    public class StringLocalizationSettingsDataEditor : LocalizationSettingsDataEditor<StringDictionary, string>
    {
        
    }
}
