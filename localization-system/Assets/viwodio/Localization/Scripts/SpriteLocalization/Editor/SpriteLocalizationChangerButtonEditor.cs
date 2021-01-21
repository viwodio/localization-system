using UnityEngine;
using System.Collections;
using UnityEditor;

namespace viwodio.Localization
{
    [CustomEditor(typeof(SpriteLocalizationChangerButton), true)]
    public class SpriteLocalizationChangerButtonEditor : LocalizationChangerButtonEditor<SpriteDictionary, Sprite>
    {

    }
}