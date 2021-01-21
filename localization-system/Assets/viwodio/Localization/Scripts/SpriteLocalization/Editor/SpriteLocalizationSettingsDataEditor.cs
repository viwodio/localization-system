using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(SpriteLocalizationSettingsData), true)]
    public class SpriteLocalizationSettingsDataEditor : LocalizationSettingsDataEditor<SpriteDictionary, Sprite>
    {

    }
}