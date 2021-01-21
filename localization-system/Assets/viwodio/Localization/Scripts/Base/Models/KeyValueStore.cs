using System;
using System.Collections.Generic;
using UnityEngine;

namespace viwodio.Localization
{
    [Serializable]
    public class KeyValueStore<TKey,TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;

        public KeyValueStore(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public TKey GetKey() => _key;
        public TValue GetValue() => _value;
    }
}
