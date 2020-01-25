using System;
using System.Collections.Generic;

namespace JustDoIt
{
    public class LRUCache
    {
        int _capacity;
        Dictionary<int, CacheItem> _cache = new Dictionary<int, CacheItem>();
        CacheItem _head;
        CacheItem _tail;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public void SetItem(int key, int value)
        {
            // If available, update
            if (_cache.ContainsKey(key))
            {
                var temp = _cache[key];
                MoveFirst(temp);
                temp.Value = value;
                return;
            }

            // If capacity full, remove last item
            if (_cache.Count >= _capacity)
            {
                int itemId = _tail.Key;
                Remove(_tail);
                _cache.Remove(itemId);
            }

            // add item
            var newItem = new CacheItem(key, value);
            Add(newItem);
            _cache[key] = newItem;
        }

        public int GetItem(int key)
        {
            if (_cache.ContainsKey(key))
            {
                var temp = _cache[key];
                MoveFirst(temp);
                return temp.Value;
            }
            return -1;
        }

        private void Add(CacheItem item)
        {
            if (_head == null)
            {
                _head = item;
                _tail = item;
                return;
            }

            _head.Prev = item;
            item.Next = _head;
            _head = item;
        }

        private void Remove(CacheItem item)
        {
            if (_head == null || item == null)
                return;

            // only item
            if (_head == _tail && _head == item)
            {
                _head = null;
                _tail = null;
                return;
            }

            // head item
            if (_head == item)
            {
                _head.Next.Prev = null;
                _head = _head.Next;
                item.Next = null;
                return;
            }

            // tail item
            if (_tail == item)
            {
                _tail.Prev.Next = null;
                _tail = _tail.Prev;
                item.Prev = null;
                return;
            }


            // middle item
            item.Next.Prev = item.Prev;
            item.Prev.Next = item.Next;
            item.Next = null;
            item.Prev = null;
        }

        private void MoveFirst(CacheItem item)
        {
            Remove(item);
            Add(item);
        }
    }

    public class CacheItem
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public CacheItem Next { get; set; }
        public CacheItem Prev { get; set; }

        public CacheItem(int key, int value)
        {
            this.Key = key;
            this.Value = value;
            this.Next = this.Prev = null;
        }
    }
}
