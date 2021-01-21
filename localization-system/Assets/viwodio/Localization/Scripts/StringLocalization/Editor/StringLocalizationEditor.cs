using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(StringLocalization))]
    public class StringLocalizationEditor : LocalizationComponentBaseEditor<StringDictionary, string, StringLocalizationManager>
    {

    }
}