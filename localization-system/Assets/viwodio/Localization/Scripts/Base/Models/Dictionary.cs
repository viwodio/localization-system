using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace viwodio.Localization
{
    [Serializable]
    public class Dictionary<KValue, TValue>
    {
        [SerializeField, HideInInspector] private List<KeyValueStore<KValue, TValue>> _baseList = new List<KeyValueStore<KValue, TValue>>();

        public void Insert(KValue key, TValue value)
        {
            _baseList.Add(new KeyValueStore<KValue, TValue>(key, value));
        }

        public void Remove(KValue key)
        {
            if (!HasKey(key)) return;

            _baseList.RemoveAt(IndexOf(key));
        }

        public void Clear()
        {
            _baseList.Clear();
        }

        public bool HasKey(KValue key)
        {
            return FindByKey(key) != null;
        }

        public int GetCount() => _baseList.Count;

        public int IndexOf(KValue key)
        {
            return _baseList.IndexOf(FindByKey(key));
        }

        public KValue GetKey(int index)
        {
            return _baseList[index].GetKey();
        }

        public KValue[] GetKeys()
        {
            return _baseList.Select(item => item.GetKey()).ToArray();
        }

        private KeyValueStore<KValue, TValue> FindByKey(KValue key)
        {
            for (int index = 0; index < _baseList.Count; index++)
            {
                if (_baseList[index].GetKey().Equals(key))
                {
                    return _baseList[index];
                }
            }

            return null;
        }

        public TValue GetValue(KValue key)
        {
            return HasKey(key) ? FindByKey(key).GetValue() : default;
        }

        public void InsertKeys(KValue[] keys)
        {
            foreach (var key in keys)
                if (!HasKey(key))
                    Insert(key, default);
        }

        public void DeleteKeys(KValue[] keys)
        {
            foreach (var key in keys)
                Remove(key);
        }
    }

    [Serializable]
    public class Dictionary<TValue> : Dictionary<string, TValue>
    {

    }
}