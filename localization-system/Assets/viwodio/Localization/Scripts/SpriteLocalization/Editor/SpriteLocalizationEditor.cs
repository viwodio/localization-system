using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(SpriteLocalization))]
    public class SpriteLocalizationEditor : LocalizationComponentBaseEditor<SpriteDictionary, Sprite, SpriteLocalizationManager>
    {

    }
}