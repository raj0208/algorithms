using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class LC
    {
        public static void Run()
        {
            LRUCacheTest();
        }

        static void LRUCacheTest()
        {
            LRUCache cache = new LRUCache(2);
            Console.WriteLine(cache.GetData(1));
            cache.SetData(1, 100);
            cache.SetData(2, 200);
            cache.SetData(3, 300);
            Console.WriteLine(cache.GetData(4));
            Console.WriteLine(cache.GetData(2));
            cache.SetData(3, 400);
            Console.WriteLine(cache.GetData(3));
            cache.SetData(4, 400);
            Console.WriteLine(cache.GetData(4));
            cache.SetData(5, 500);
            cache.SetData(6, 600);
        }

    }

    #region LRUCache
    class LRUCache
    {
        public class CacheNode
        {
            public int Key { get; private set; }
            public int Value { get; set; }
            public CacheNode Next { get; set; }
            public CacheNode Previous { get; set; }

            public CacheNode(int key, int value)
            {
                this.Key = key;
                this.Value = value;
                this.Next = null;
                this.Previous = null;
            }
        }

        private int Capacity { get; set; }
        private Dictionary<int, CacheNode> CacheElements { get; set; }
        private CacheNode Head { get; set; }
        private CacheNode Tail { get; set; }

        public LRUCache(int capacity = 5)
        {
            this.Capacity = capacity;
            this.CacheElements = new Dictionary<int, CacheNode>();
            this.Head = null;
            this.Tail = null;
        }

        public int GetData(int key)
        {
            if (this.CacheElements.ContainsKey(key))
            {
                var node = this.CacheElements[key];
                // move the node to head
                MoveToHead(node);
                return node.Value;
            }

            return -1;
        }

        public void SetData(int key, int value)
        {
            if (this.CacheElements.ContainsKey(key))
            {
                var node = this.CacheElements[key];
                MoveToHead(node);
                node.Value = value;
                return;
            }

            if (this.CacheElements.Count >= this.Capacity)
            {
                if (this.Tail != null)
                {
                    int id = this.Tail.Key;
                    RemoveElements(this.Tail);
                    this.CacheElements.Remove(id);
                }
            }

            var newNode = new CacheNode(key, value);
            AddElement(newNode);
            this.CacheElements[key] = newNode;
        }

        private void AddElement(CacheNode newNode)
        {
            newNode.Previous = null;
            newNode.Next = null;

            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }

            this.Head.Previous = newNode;
            newNode.Next = this.Head;
            this.Head = newNode;
        }

        private void RemoveElements(CacheNode node)
        {
            if (this.Head == null || node == null) return;

            // only node
            if (this.Head == this.Tail && this.Head == node)
            {
                this.Head = null;
                this.Tail = null;
                return;
            }

            // head
            if (this.Head == node)
            {
                this.Head.Next.Previous = null;
                this.Head = this.Head.Next;
                //node.Next = null;
                return;
            }

            // tail
            if (this.Tail == node)
            {
                this.Tail.Previous.Next = null;
                this.Tail = this.Tail.Previous;
                //node.Previous = null;
                return;
            }

            // middle
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            //node.Next = node.Previous = null;
        }

        private void MoveToHead(CacheNode node)
        {
            RemoveElements(node);
            AddElement(node);
        }
    }
    #endregion
}
