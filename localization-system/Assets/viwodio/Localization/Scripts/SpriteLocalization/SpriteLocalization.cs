using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace viwodio.Localization
{
    [AddComponentMenu("viwodio/Localization/Sprite Localization")]
    public class SpriteLocalization : LocalizationComponentBase<SpriteDictionary, Sprite, SpriteLocalizationManager, SpriteLocalization.UpdateValueEvent>
    {
        [Serializable] public class UpdateValueEvent : UnityEvent<Sprite> { };
    }
}
