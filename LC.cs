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
            //LRUCacheTest();
            //ReversePolishEvalution();
            //TinyURL();
            //TwoSum();
            //ReverseString();
            //ReverseString2(); //*********
            //LengthOfLongestSubString(); //*********
            //MissingNumbers();  //*********
            //LongestPalindrome(); //*********

            //SortSubArray();
            //InsertNode();

            //FindNode();
            //RotateArray();
            AlgorithmicCrush();

        }

        private static void AlgorithmicCrush()
        {
            //5 3
            //1 2 100
            //2 5 100
            //3 4 100

            {
                /*
                you are adding sum to a[p] and adding negative sum at a[q + 1]. which make sure that 
                when you add element from a[p] to a[q] sum is added only once and it should be subtracted 
                at a[q + 1] as this sum span from p to q only.Rest array element are either 0 or some 
                other input sum.max of addition will be output. refer to below code for p, q, and sum.
                */
  
                long N = 5, K = 3, p, q, sum, i, j, max = 0, x = 0;

                //cin >> N >> K;
                long[] a = new long[N + 1];

                for (i = 0; i < K; i++)
                {
                    
                    var input = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                    p = input[0];
                    q = input[1];
                    sum = input[2];

                    a[p] += sum;
                    if ((q + 1) <= N) a[q + 1] -= sum;
                }

                for (i = 1; i <= N; i++)
                {
                    x = x + a[i];
                    if (max < x) max = x;

                }
                Console.WriteLine(max);
            }

            {

                //int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                //int[] array = Enumerable.Repeat(0, input[0]).ToArray();

                //int count = input[1];
                //int max = 0;
                //for (int i = 0; i < count; i++)
                //{
                //    input = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                //    for (int j = input[0] - 1; j < input[1]; j++)
                //    {
                //        array[j] += input[2];
                //        if (max < array[j]) max = array[j];
                //    }
                //}
                //Console.WriteLine(max);
            }
        }

        private static void RotateArray()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string[] arr_temp = Console.ReadLine().Split(' ');
            int rotations = Array.ConvertAll(arr_temp, Int32.Parse)[1];
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            if (rotations > 0 && array.Length >= rotations)
            {
                Rotate(ref array, 0, rotations - 1);
                Rotate(ref array, rotations, array.Length - 1);
                Rotate(ref array, 0, array.Length - 1);
            }
            Console.WriteLine(string.Join(" ", array));
        }

        static void Rotate(ref int[] array, int start, int end)
        {
            int mid = (end - start) / 2;
            for (int i = 0; i <= mid; i++)
            {
                int temp = array[start + i];
                array[start + i] = array[end - i];
                array[end - i] = temp;
            }
        }
    

        private static void FindNode() {
            //2 1 3 5 6
            LinkedNode head = new LinkedNode(6);
            head.Next = new LinkedNode(5);
            head.Next.Next = new LinkedNode(3);
            head.Next.Next.Next = new LinkedNode(1);

            var t = head;
            while (t != null)
            {
                Console.WriteLine(t.Value);
                t = t.Next;
            }

            var fast = head;
            var slow = head;
            int position = 1;
            int index = 0;

            while (fast != null) {
                fast = fast.Next;

                if (index++ > position) {
                    slow = slow.Next;
                }
            }

            Console.WriteLine("Value at {0} is {1}", position, slow.Value);
        }

        private static void InsertNode()
        {
            {
                LinkedNode head1 = new LinkedNode(3);
                head1.Next = new LinkedNode(5);
                head1.Next.Next = new LinkedNode(4);
                int value = 2, position = 3;
                
                // This is a "method-only" submission. 
                // You only need to complete this method.    
                LinkedNode newHead = head1;
                int counter = 0;
                while (counter != position && newHead != null)
                {
                    newHead = newHead.Next;

                    if (newHead.Next == null)
                    {
                        newHead.Next = new LinkedNode(value);
                        return;
                    }
                    

                    counter++;
                }

                LinkedNode newNode = new LinkedNode(value);
                
                // head
                if (newHead == null)
                    newHead = newNode;
                else
                {
                    newNode.Next = newHead.Next;
                    newHead.Next = newNode;
                }

                return;
            }



            LinkedNode head = new LinkedNode();
            head = new LinkedNode(2);
            int data = 5;
                LinkedNode start = new LinkedNode();
                start.Next = head;

                while (start.Next!= null)
                {
                    Console.Write(start.Next.Value + "-->");
                    start = start.Next;
                }

                start.Next = new LinkedNode();
                start.Next.Value = data;
            Console.WriteLine(start.Next.Value);
        }

        private static void SortSubArray()
        {
            int[] number = new int[] { 1,2,2,2,3,3,3,4,1,2,3,4,7,8,9};

            printUnsorted(number, number.Length);

            Console.WriteLine();

        }


        private static void printUnsorted(int[] arr, int n)
        {
            int s = 0, e = n - 1, i, max, min;

            // step 1(a) of above algo
            for (s = 0; s < n - 1; s++)
            {
                if (arr[s] > arr[s + 1])
                    break;
            }
            if (s == n - 1)
            {
                Console.WriteLine("The complete array is sorted");
                return;
            }

            // step 1(b) of above algo
            for (e = n - 1; e > 0; e--)
            {
                if (arr[e] < arr[e - 1])
                    break;
            }

            // step 2(a) of above algo
            max = arr[s]; min = arr[s];
            for (i = s + 1; i <= e; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }

            // step 2(b) of above algo
            for (i = 0; i < s; i++)
            {
                if (arr[i] > min)
                {
                    s = i;
                    break;
                }
            }

            // step 2(c) of above algo
            for (i = n - 1; i >= e + 1; i--)
            {
                if (arr[i] < max)
                {
                    e = i;
                    break;
                }
            }

            // step 3 of above algo
            Console.WriteLine(" The unsorted subarray which makes the given array sorted lies between the indees {0} and {1}", s, e);
            return;
        }



        private static void LongestPalindrome()
        {
            {
                Func<string, int, int, int> ExpandAroundCenter = (s, left, right) => {
                    int L = left, R = right;
                    while (L >= 0 && R < s.Length && s[L] == s[R])
                    {
                        L--;
                        R++;
                    }
                    return R - L - 1;
                };

                string str = "abacdfgdcaba";
                int start = 0, end = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int len1 = ExpandAroundCenter(str, i, i);
                    int len2 = ExpandAroundCenter(str, i, i + 1);
                    int len = Math.Max(len1, len2);
                    if (len > end - start)
                    {
                        start = i - (len - 1) / 2;
                        end = i + len / 2;
                    }
                }
                Console.WriteLine(str.Substring(start, end - start + 1));
            }
        }

        private static void MissingNumbers()
        {
            {
                int[] numbers = new int[] {3, 50, 75};

                int start = 0;
                int end = 99;
                int prev = start-1;
                

                var ranges = new List<string>();

                Func<int, int, string> AddRange = (s, e) => {
                    return (s == e) ? s.ToString() : $"{s}->{e}";
                };

                for (int i = 0; i <= numbers.Length; i++)
                {
                    int curr = (i == numbers.Length) ? end: numbers[i];
                    if (prev == start - 1 && curr != start || curr - prev >= 2)
                    {
                        ranges.Add(AddRange(prev + 1, curr-1));
                    }
                    prev = curr;
                }

                Console.WriteLine(string.Join(", ", ranges));
            }
        }

        private static void LengthOfLongestSubString()
        {
            {
                string s = "abcabcbb";
                //string s = "bbbbbbbb";
                int[] charMap = Enumerable.Repeat(-1, 256).ToArray();
                //for (int k = 0; k < charMap.Length; k++)
                //    charMap[k] = -1;

                int i = 0, maxLen = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (charMap[s[j] - 'a'] >= i)
                    {
                        i = charMap[s[j] - 'a'] + 1;
                    }
                    charMap[s[j] - 'a'] = j;
                    maxLen = Math.Max(j - i + 1, maxLen);
                }
                Console.WriteLine(maxLen);
            }

            {
                string s = "abaac";
                int i = 0, j = -1, maxLen = 0;
                for (int k = 1; k < s.Length; k++)
                {
                    if (s[k] == s[k - 1]) continue;
                    if (j >= 0 && s[j] != s[k])
                    {
                        maxLen = Math.Max(k - i, maxLen);
                        i = j + 1;
                    }
                    j = k - 1;
                }
                Console.WriteLine(Math.Max(s.Length - i, maxLen)); 
            }

            {
                string s = "abaac";
                int[] count = new int[256];
                int i = 0, numDistinct = 0, maxLen = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (count[s[j]] == 0) numDistinct++;
                    count[s[j]]++;
                    while (numDistinct > 2)
                    {
                        count[s[i]]--;
                        if (count[s[i]] == 0) numDistinct--;
                        i++;
                    }
                    maxLen = Math.Max(j - i + 1, maxLen);
                }
                Console.WriteLine(maxLen);
            }
        }

        private static void ReverseString()
        {
            string str = "the sky is blue";
            int j = str.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >=0; i--)
            {
                if (str[i] == ' ')
                {
                    j = i;
                }
                else if (i == 0 || str[i - 1] == ' ')
                {
                    if (sb.Length != 0) sb.Append(' ');
                    sb.Append(str.Substring(i, j-i));
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private static void ReverseString2()
        {
            //var str = "the sky is blue".ToCharArray();
            var str = "Rajesh Sunisha Pratiksha Pratham".ToCharArray();
            Console.WriteLine(str);
            //var str = "0123 456".ToCharArray();
            Reverse(str, 0, str.Length);
            Console.WriteLine(str);
            for (int i = 0, j = 0; j <= str.Length; j++)
            {
                if (j == str.Length || str[j] == ' ')
                {
                    Reverse(str, i, j);
                    i = j + 1;
                }
            }
            Console.WriteLine(str);
        }

        private static void Reverse(char[] s, int start, int end)
        {
            for (int i = 0; i < (end - start)/2; i++)
            {
                char t = s[start + i];
                s[start + i] = s[end - i - 1];
                s[end - i - 1] = t;
            }
        }

        private static void ReversePolishEvalution()
        {
            String[] tokens = new String[] 
            //{ "2", "1", "+", "3", "*" }; // ((2 + 1) * 3) -> 9
            { "4", "13", "5", "/", "+"};  // (4 + (13 / 5)) -> 6

            var stack = new Stack<int>();

            string operators = "/*+-";

            foreach (var token in tokens)
            {
                if (Char.IsNumber(token[0]))
                {
                    stack.Push(int.Parse(token));
                    continue;
                }
                else
                {
                    int a = stack.Pop();
                    int b = stack.Pop();

                    switch (operators.IndexOf(token))
                    {
                        case 0: // division
                            stack.Push(b / a);
                            break;
                        case 1: // multiply
                            stack.Push(b * a);
                            break;
                        case 2: // addition
                            stack.Push(b + a);
                            break;
                        case 3: // subtraction
                            stack.Push(b - a);
                            break;
                    }
                }
            }

            Console.WriteLine(stack.Pop());
        }

        private static void LRUCacheTest()
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

        private static void TinyURL()
        {
        }

        //------------------------------------------------------
        //Given an array of integers, find two numbers 
        //such that they add up to a specific target number.
        private static void TwoSum()
        {
            int[] numbers = new int[] { 1,2,3,4,5 };
            int target = 5;

            var map = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int x = numbers[i];
                if (map.ContainsKey(target - x))
                {
                    break;
                }
                map[x] = i;
            }
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