using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(StringLocalizationChangerButton), true)]
    public class StringLocalizationChangerButtonEditor : LocalizationChangerButtonEditor<StringDictionary, string>
    {

    }
}