﻿//using MongoDB.Bson;
//using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace ConsoleApp.Final
{
    class ProgramFinal
    {
        static void MainFinal(string[] args)
        {
            //Stack<int> s = new Stack<int>();

            //int n=6;
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine(new String('#', i + 1).PadLeft(n, ' '));

            //Console.WriteLine(isUniqueChars("Rajesh Sharma"));//
            //replaceSpaces("Rajesh Sharma   ".ToCharArray(), 13);
            //OneEditAway("Rajesh", "Rajsh");
            //Rotate();
            //LadderLength();
            //TwoSum sum = new TwoSum();
            //sum.Add(1);
            //sum.Add(3);
            //sum.Add(5);
            //Console.WriteLine(sum.Find(4));
            //Console.WriteLine(sum.Find(7));

            //FindBeginning();
            //RemoveFromHeap();
            //Program1.Add(7, 5);
            //Program1.sub(7, 5);
            //Program1.multiply(4, 5);
            //IsPrimeNumber(6);
            //ToBinary(5);
            //int x= GreatestCommonFactor(18, 24);
            //BinaryNumber(0.72);
            //BubbleSort();
            //Console.WriteLine();
            //SelectionSort();
            //InsertionSort();
            //MergeSort();
            //MergeArray();
            //CreateMinimalBST();
            //LinkedList();
            //lengthoflongest();
            //findMedianSortedArrays();
            intToRoman();

            //Recommendation();
            Console.ReadLine();
        }

        void HackerRank()
        {

            string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
            TextWriter tw = new StreamWriter(@fileName, true);
            int res = 0;

            int _numbers_size = 0;
            _numbers_size = Convert.ToInt32(Console.ReadLine());
            int[] _numbers = new int[_numbers_size];
            int _numbers_item;
            for (int _numbers_i = 0; _numbers_i < _numbers_size; _numbers_i++)
            {
                _numbers_item = Convert.ToInt32(Console.ReadLine());
                _numbers[_numbers_i] = _numbers_item;
            }

            //res = sum(_numbers);
            tw.WriteLine(res);

            tw.Flush();
            tw.Close();
        }

        static void HackerRankMain(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < n; t++)
            {
                String str = Console.ReadLine();
                String[] strArr = str.Split();
                int a = Convert.ToInt32(strArr[0]);
                int b = Convert.ToInt32(strArr[1]);
                Console.WriteLine(a + b);
            }
        }

        static bool isUniqueChars(String str) {
            int checker = 0;
            for (int i = 0; i < str.Length; i++) {
            int val = str[i] - 'a';
            if ((checker & (1 << val)) > 0) {
                return false;
            }
            checker |= (1 << val);
            }
            return true;
        } 


        #region NumbertoRoman
        private static int[] values = {
            1000, 900, 500, 400,
            100, 90, 50, 40,
            10, 9, 5, 4,
            1
            };
        private static string[] symbols = {
            "M", "CM", "D", "CD",
            "C", "XC", "L", "XL",
            "X", "IX", "V", "IV",
            "I"
            };
        public static String intToRoman()
        {
            int num = 14;
            StringBuilder roman = new StringBuilder();
            int i = 0;
            while (num > 0)
            {
                int k = num / values[i];
                for (int j = 0; j < k; j++)
                {
                    roman.Append(symbols[i]);
                    num -= values[i];
                }
                i++;
            }
            return roman.ToString();
        }
        #endregion

        static void ReverseInt()
        {
            int num = 123;
            int rev = 0;
            while (num >= 0)
            {
                rev = rev * 10 + (num % 10);
                num = num / 10;
            }

            Console.WriteLine(rev);
        }

        static void lengthoflongest()
        {
            string s = "abaac";

            int i = 0, j = -1, maxlen = 0;
            for (int k = 1; k < s.Length; k++)
            {
                if (s[k] == s[k - 1]) continue;
                if (j >= 0 && s[j] != s[k])
                {
                    maxlen = Math.Max(k - i, maxlen);
                    i = j + 1;
                }
                j = k - 1;
            }

            int len = Math.Max(s.Length - i, maxlen);
            Console.WriteLine(len);

        }

        #region Prime number
        static bool IsPrimeNumber(int n)
        {
            for (int i = 2; i < n; i++)
            {
                for (int j = 1; j < Math.Sqrt(n); j++)
                {
                    if (i * j == n)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region ToBinary
        static void ToBinary(int n)
        {
            var s = new List<int>();            
            while (n > 0)
            {
                s.Add(n % 2);
                n = n / 2;
            }
            s.Reverse();
            Console.WriteLine(string.Join(",", s));
        
        
        }
        #endregion

        #region GreatestCommonFactor
        static int GreatestCommonFactor(int m, int n)
        {
            while (n != 0)
            {
                int t = n;
                n = m % n;
                m = t;
            }

            return m;

            //if (n == 0) return m;

            //return GreatestCommonFactor(n, m % n);
        }
        #endregion

        #region Heap Removal
        static void RemoveFromHeap()
        {
            int[] heap = new int[] {1,3,9,12,13};
            int count = 4;

            int i = 0;

            heap[0] = heap[count];

            while ((2 * i + 1) < count && (
                (heap[i] > heap[(2 * i + 1)]) ||
                (heap[i] > heap[(2 * i + 2)])
                ))
            {
                if (heap[(2 * i + 1)] < heap[(2 * i + 2)])
                {
                    int temp = heap[(2 * i + 1)];
                    heap[(2 * i + 1)] = heap[i];
                    heap[i]= temp;
                    i = (2 * i + 1);
                }
                else
                {
                    int temp = heap[(2 * i + 2)];
                    heap[(2 * i + 2)] = heap[i];
                    heap[i] = temp;
                    i = (2 * i + 2);
                }
            }

            MinHeapify(heap);
            Console.WriteLine("{0}", string.Join(",", heap));
        }

        static void MinHeapify(int[] heap)
        {
            int i = heap.Length - 1;
            while (i > 0 && heap[i] < heap[(i - 1) / 2])
            { 
                int t = heap[i];
                heap[i] = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = t;
                i = (i - 1) / 2;
            }
        }
        #endregion

        #region FindBeginning of LinkedList
        static void FindBeginning()
        {
            LinkedNode head = LinkedNode.GetLinkedNodes(new int[] {1,2,3,4,5,6,7});

            var t = head;
            LinkedNode third = null;
            LinkedNode prev = null;
            int count = 0;
            while (t != null)
            {
                prev = t;
                t = t.Next;
                if (++count == 3)
                    third = prev;
            }

            prev.Next = third;

            LinkedNode fast = head;
            LinkedNode slow = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast) {
                    break;
                }
            }

            if (fast == null || fast.Next == null) return;

            slow = head;

            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            Console.WriteLine(fast.Value);
        }

        #endregion

        #region Ladder length
        public static int LadderLength(String start = "hit", String end = "cog", HashSet<String> dict = null)
        {
            dict = new HashSet<string>() {"hot","dot","dog","lot","log" };

            if (dict.Count == 0)
                return 0;
            dict.Add(end);
            LinkedList<String> wordQueue = new LinkedList<String>();
            LinkedList<int> distanceQueue = new LinkedList<int>();
            wordQueue.AddLast(start);
            distanceQueue.AddLast(1);
            //track the shortest path
            int result = int.MaxValue;
            while (wordQueue.Any())
            {
                var word = wordQueue.First;
                wordQueue.RemoveFirst();
                String currWord = word.Value;
                
                int currDistance = distanceQueue.First.Value;
                distanceQueue.RemoveFirst();

                if (currWord.Equals(end))
                {
                    result = Math.Min(result, currDistance);
                }
                for (int i = 0; i < currWord.Length; i++)
                {
                    char[] currCharArr = currWord.ToCharArray();
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        currCharArr[i] = c;
                        String newWord = new String(currCharArr);
                        if (dict.Contains(newWord))
                        {
                            wordQueue.AddLast(newWord);
                            distanceQueue.AddLast(currDistance + 1);
                            dict.Remove(newWord);
                        }
                    }
                }
            }
            if (result < int.MaxValue)
                return result;
            else
                return 0;
        }


        #endregion 

        #region Two Sum with datastructure


        public class TwoSum
        {
            private Dictionary<int, int> elements = new Dictionary<int, int>();
            public void Add(int number)
            {
                if (elements.ContainsKey(number))
                {
                    elements[number] = elements[number] + 1;
                }
                else
                {
                    elements[number] = 1;
                }
            }

            public bool Find(int value)
            {
                foreach (var i in elements.Keys)
                {
                    int target = value - i;
                    if (elements.ContainsKey(target))
                    {
                        if (i == target && elements[target] < 2)
                        {
                            continue;
                        }
                        return true;
                    }
                }
                return false;
            }
        }

        #endregion

        #region CreateMinimalBST
        static void CreateMinimalBST()
        {
            int[] array = new int[] {1,2,3,4,5,6,7,8,9,10};

            var tree = createBST(array, 0, array.Length - 1);
            Console.WriteLine(tree.Data);
        }

        static Tree createBST(int[] array, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end) / 2;
            Tree tree = new Tree(array[mid]);
            tree.Left = createBST(array, start, mid - 1);
            tree.Right = createBST(array, mid + 1, end);


            return tree;
        }
    
        #endregion

        #region Binary Number To String
        static void BinaryNumber(double num)
        {
            if (num >= 1 || num <= 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            var binary = new StringBuilder();

            binary.Append(".");
            while (num > 0)
            {
                if (binary.Length >= 32)
                {
                    Console.WriteLine("ERROR");
                }

                double rem = num * 2;
                if (rem >= 1)
                {
                    binary.Append("1");
                    num = rem - 1;
                }
                else
                {
                    binary.Append("0");
                    num = rem;
                }
            }

            Console.WriteLine(binary.ToString());        
        
        }
        #endregion

        #region Get and Set Bits
        static void GetBit()
        {
            int num = 26;
            int i = 3;
            int getbit = num & (1 << i);

            int setbit = num ^ (1 << i);

            num = num ^ i;
            i = i ^ num;
            num = num ^ i;


            Console.WriteLine("{0} {1}", getbit, setbit);
        }
        #endregion

        #region Median of sorted array
        public static void findMedianSortedArrays()
        {
            int[] A = {1,2,3,4,5};
            int[] B = {1,2,4 };

            int m = A.Length;
            int n = B.Length;
            if ((m + n) % 2 != 0) // odd
                Console.WriteLine((double)findKth(A, B, (m + n) / 2, 0, m - 1, 0, n - 1));
            else
            { // even
                Console.WriteLine((findKth(A, B, (m + n) / 2, 0, m - 1, 0, n - 1)
                + findKth(A, B, (m + n) / 2 - 1, 0, m - 1, 0, n - 1)) * 0.5);
            }
        }
        public static int findKth(int[] A, int[] B, int k,
        int aStart, int aEnd, int bStart, int bEnd)
        {
            int aLen = aEnd - aStart + 1;
            int bLen = bEnd - bStart + 1;
            // Handle special cases
            if (aLen == 0)
                return B[bStart + k];
            if (bLen == 0)
                return A[aStart + k];
            if (k == 0)
                return A[aStart] < B[bStart] ? A[aStart] : B[bStart];
            int aMid = aLen * k / (aLen + bLen); // a’s middle count
            int bMid = k - aMid - 1; // b’s middle count
            // make aMid and bMid to be array index
            aMid = aMid + aStart;
            bMid = bMid + bStart;
            if (A[aMid] > B[bMid])
            {
                k = k - (bMid - bStart + 1);
                aEnd = aMid;
                bStart = bMid + 1;
            }
            else
            {
                k = k - (aMid - aStart + 1);
                bEnd = bMid;
                aStart = aMid + 1;
            }
            return findKth(A, B, k, aStart, aEnd, bStart, bEnd);
        }

        
        #endregion

        static void MergeArray()
        {
            int[] a = new int[] {1,2,3,4,5,0,0,0 };
            int[] b = new int[] { 2, 4, 6 };

            int al = a.Length - 1;
            int bl = b.Length - 1;
            int ab = a.Length + b.Length - 1;

            while (bl >= 0)
            { 
                if (al >=0 && a[al] > b[bl]) {
                    a[ab] = a[al];
                    al--;
                }
                else
                {
                    a[ab] = b[bl];
                    bl--;
                }
                ab--;
            }
        
        
            Console.WriteLine(string.Join(",", a));
        
        }

        static void SelectionSort()
        {
            int[] num = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };

            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i+1; j < num.Length; j++)
                {
                    if (num[i] > num[j])
                    {
                        num[i] = num[i] ^ num[j];
                        num[j] = num[j] ^ num[i];
                        num[i] = num[i] ^ num[j];
                    }
                }
                Console.WriteLine(string.Join(",", num));
            }
        }

        static void BubbleSort()
        {
            int[] num = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };
            int temp;
            for (int outer = num.Length-1; outer > 0; outer--)
            {
                for (int inner = 0; inner < outer; inner++)
                {
                    if (num[inner] > num[inner + 1])
                    {
                        temp = num[inner];
                        num[inner] = num[inner + 1];
                        num[inner + 1] = temp;
                    }
                }
                Console.WriteLine(string.Join(",", num));
            }
        }

        static void InsertionSort()
        {
            int[] num = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };
            int inner, temp;
            for (int outer = 1; outer <= num.Length - 1; outer++)
            {
                temp = num[outer];
                inner = outer;
                while (inner > 0 && num[inner - 1] >= temp)
                {
                    num[inner] = num[inner - 1];
                    inner -= 1;
                }
                num[inner] = temp;
                Console.WriteLine(string.Join(",", num));
            }
        }

        static void MergeSort()
        {
            int[] num = new int[] {1,4,5,2,3 };
            int[] helper = new int[num.Length];
            MergeSortData(num, helper, 0, num.Length - 1);
        }

        static void MergeSortData(int[] num, int[] helper, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortData(num, helper, low, mid);
                MergeSortData(num, helper, mid + 1, high);
                Merge(num, helper, low, mid, high);
            }
        }

        static void Merge(int[] num, int[] helper, int low, int mid, int high)
        {
            for (int i = low; i <= high; i++)
            {
                helper[i] = num[i];
            }

            int helperLeft = low;
            int helperRight = mid + 1;
            int current = low;

            while (helperLeft <= mid && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    num[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    num[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            int remaining = mid - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                num[current + i] = helper[helperLeft + i];
            }
        }

        static bool OneEditAway(string first, string second)
        {
            if (Math.Abs(first.Length - second.Length) > 1)
                return false;

            string s1 = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;

            int index1 = 0, index2 = 0;

            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length) {
                if (s1[index1] != s2[index2])
                {
                    if (foundDifference) return false;
                    foundDifference = true;

                    if (s1.Length == s2.Length)
            
                        index1++;
                }
                else
                {
                    index1++;
                }
                index2++;
            }
            return true;
        }

        static string CompressedString(string str)
        {
            StringBuilder compressed = new StringBuilder();

            int sameCharacterLength = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sameCharacterLength++;

                if (i + 1 >= str.Length || str[i] != str[i + 1]) {
                    compressed.Append(str[i]);
                    compressed.Append(sameCharacterLength);
                    sameCharacterLength = 0;
                }
            }
            return compressed.Length < str.Length ? compressed.ToString() : str;
        }

        static void Rotate()
        {
            int[][] matrix = new int[][] { 
                new int[]{11,12,13,14,15,16},
                new int[]{21,22,23,24,25,26},
                new int[]{31,32,33,34,35,36},
                new int[]{41,42,43,44,45,46},
                new int[]{51,52,53,54,55,56},
                new int[]{61,62,63,64,65,66},
            };
            // matrix length is 0 or not a square matrix, return false
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length) return;
            int n = matrix.Length; //4

            Console.WriteLine("Before\n");
            printMatrix(matrix);

            for (int layer = 0; layer < n/2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int column = first; column < last; column++) {
                    int offset = column - first;
                    int top = matrix[first][column]; // top
                    matrix[first][column] = matrix[last-offset][first]; // copy left into top
                    matrix[last-offset][first] = matrix[last][last-offset]; // copy bottom into left
                    matrix[last][last-offset] = matrix[column][last]; // copy right into bottom
                    matrix[column][last] = top; // copy top into right
                }
            }

            Console.WriteLine("\n\nAfter:\n");
            printMatrix(matrix);
        }

        static void printMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine("{0}", string.Join(",", matrix[i]));
            }
        }

        static void replaceSpaces(char[] str, int trueLength) {
            int spaceCount = 0, index, i = 0;
            for (i = 0; i < trueLength; i++) {
                if (str[i] == ' ') {
                    spaceCount++;
                }
            }

            index = trueLength + spaceCount * 2;
            if (trueLength < str.Length) str[trueLength] = '\0';
            for (i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        } 

        static void Recommendation()
        {
            var purchases = GetPurchases();
            string searchItem = "ABC";

            var buyers = new Dictionary<string, List<string>>();
            var items = new Dictionary<string, List<string>>();

            foreach (var purchaseItem in purchases)
            {
                string[] data = purchaseItem.Split(':');

                if (!buyers.ContainsKey(data[0]))
                    buyers[data[0]] = new List<string>() { data[1] };
                else
                    buyers[data[0]].Add(data[1]);

                foreach (var bItem in buyers[data[0]])
                {
                    if (bItem != data[1])
                    {
                        if (!items.ContainsKey(bItem))
                            items[bItem] = new List<string>() { data[1] };
                        else
                            items[bItem].Add(data[1]);

                        if (!items.ContainsKey(data[1]))
                            items[data[1]] = new List<string>() { bItem };
                        else
                            items[data[1]].Add(bItem);
                    }
                }
            }

            int strongLinks = 0, weakLinks = 0;
            if (items.ContainsKey(searchItem))
            {
                strongLinks = items[searchItem].Count;

                var alllinks = FindAllConnections(items, searchItem, searchItem);

                weakLinks = alllinks.Except(items[searchItem]).Count();
            }

            Console.WriteLine("{0}, {1}", strongLinks, weakLinks);
        }

        static IList<string> FindAllConnections(Dictionary<string, List<string>> items, string key, string searchKey, List<string> allLinks = null)
        {
            List<string> connections = (allLinks != null) ? allLinks : new List<string>();
            
            foreach (var item in items[key])
	        {
                if (item != searchKey && !connections.Contains(item))
                {
                    connections.Add(item);
                    FindAllConnections(items, item, searchKey, connections);
                }
	        }

            return connections;
        }

        static List<string> GetPurchases()
        { 
            var purchases = new List<string>() {
                "first:ABC",
                "first:HIJ",
                "sec:HIJ",
                "sec:KLM",
                "third:NOP",
                "fourth:ABC",
                "fourth:QRS",
                "first:DEF",
                "fifth:KLM",
                "fifth:TUV"
            };
            return purchases; 
        }

        static void LinkedList()
        {
            ListNode list1 = null;
            list1 = new ListNode("Mumbai");
            //list1.Next = new ListNode("Baroda");
            //list1.Next.Next = new ListNode("Pune");
            //list1.Next.Next.Next = new ListNode("Noida");
            //list1.Next.Next.Next.Next = new ListNode("Gurgaon");


            ListNode list2 = null;
            //list2 = new ListNode("Noida");
            //list2.Next = new ListNode("Mumbai");
            //list2.Next.Next = new ListNode("Gurgaon");

            //Console.WriteLine("List1");
            //list1.Print();
            //Console.WriteLine("List2");
            //list2.Print();

            var list = GetExcept(list1, list2);
            if (list != null)
                list.Print();
            else
                Console.WriteLine("NULL");
        }

        private static ListNode GetExcept(ListNode list1, ListNode list2)
        {
            // check input parameter.  If either list is empty, return list1
            if (list1 == null || list2 == null) 
                return list1;

            // create a hashset from cities to be excluded
            HashSet<string> excludeCities = new HashSet<string>();
            while (list2 != null) 
            {
                if (!excludeCities.Contains(list2.Data))
                    excludeCities.Add(list2.Data);

                list2 = list2.Next;
            }

            ListNode newHead = new ListNode("");
            newHead.Next = list1;
            ListNode current = newHead;

            while (current.Next != null)
            {
                if (excludeCities.Contains(current.Next.Data))
                {
                    current.Next = current.Next.Next; // remove the node
                }
                else
                {
                    current = current.Next;
                }
            }

            return newHead.Next;
        }

        private static bool ReverseLinkedList(int[] nodes)
        { 
            var head = LinkedNode.GetLinkedNodes(nodes);

            LinkedNode fast = head, slow = head, slowptr = head, newHead = null;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                slowptr.Next = newHead;
                newHead = slowptr;
                slowptr = slow;
            }

            if (fast != null)
                slow = slow.Next;

            while (slow != null && newHead != null)
            {
                if (slow.Value != newHead.Value) return false;
                slow = slow.Next;
                newHead = newHead.Next;
            }

            return (slow == null && newHead == null);

        }

    }

    [DebuggerDisplay("Data : {Data}, Left : {Left}, Right : {Right}")]
    class Tree
    {
        public int Data { get; set; }
        public Tree Left { get; set; }
        public Tree Right { get; set; }

        public Tree(int data)
        {
            this.Data = data;
        }
    }

    [DebuggerDisplay("value : {Value}, Next : {Next}")]
    class LinkedNode
    {
        public LinkedNode Next;
        public int Value;

        public LinkedNode(int value = 0)
        {
            this.Value = value;
        }

        public static LinkedNode GetLinkedNodes(int[] nodes)
        {
            var head = new LinkedNode();
            var curr = head;
            foreach (var item in nodes)
            {
                head.Next = new LinkedNode(item);
                head = head.Next;
            }

            return curr.Next;
        }
    }

    [DebuggerDisplay("Node {Data}")]
    class ListNode
    {
        public string Data { get; set; }
        public ListNode Next { get; set; }
        
        
        public ListNode(string city, ListNode next = null)
        {
            this.Data = city;
            this.Next = next;
            
        }

        public void Add(string city)
        {
            ListNode newNode  = new ListNode(city);
            
        }

        public void Print()
        {
            var curr = this;
            while (curr != null)
            {
                Console.Write("{0}->", curr.Data);
                curr = curr.Next;
            }
            Console.WriteLine("NULL");
        }
    }

    class Program2
    {
        static void Main1(string[] args)
        {
            //UniqueCharacters();
            //Reverse();
           // ReplaceSpaces("Rajesh Sharma".ToCharArray(), "Rajesh Sharma".Length); 
            //var d = new MongoClient();
           // MainAsync(args).Wait();

            //TwoSum(new int[] {0,2,1,4,6 }, 3);
            //TwoSumSorted(new int[] { 0, 2, 3, 5, 7, 9 }, 5);
            //new TwoSumClass().Test();

           // Console.WriteLine(Add(-3,5));
            //Console.WriteLine(sub(-5,3));
            //Console.WriteLine(sub(-5, -3));
            //Console.WriteLine(sub(5, -3));
            //Console.WriteLine(sub(5, 3));
            //Console.WriteLine(multiply(3,-5));
            //Console.WriteLine(lengthOfLongestSubstring("Rajesh Sharma is great"));
            

            Console.ReadLine();
        }

        public static int Add(int x, int y)
        {
            int carry;
            // Iterate till there is no carry  
            while (y != 0)
            {
                // carry now contains common set bits of x and y
                carry = x & y;

                // Sum of bits of x and y where at least one of the bits is not set
                x = x ^ y;

                // Carry is shifted by one so that adding it to x gives the required sum
                y = carry << 1;
            }
            
            return x;
        }

        public static int sub(int x, int y)
        {
            int carry = 0;
            do
            {
                carry = ~x & y;
                x = x ^ y;
                y = carry << 1;                 
            } while (carry != 0);
            return x;
        }

        public static int multiply(int a, int b)
        {
            {
                int result1 = 0;
                int x = a;
                int y = b;
                int carry = 0;
                while (y != 0 && x != 0)
                {
                    carry = y & 1;
                    if (carry != 0)
                        result1 += x;
                    x <<= 1;
                    y >>= 1;
                }
                Console.WriteLine(result1);
            }










            int result = 0;
            while (b != 0)               // Iterate the loop till b==0
            {
                int x = b & 01;
                if (x != 0)                // Bitwise &  of the value of b with 01
                {
                    result = Add(result, a);     // Add a to result if b is odd .
                }
                a <<= 1;                   // Left shifting the value contained in 'a' by 1 
                // multiplies a by 2 for each loop
                b >>= 1;                   // Right shifting the value contained in 'b' by 1.
            }

            return result;
        }


        static void TwoSum(int[] arr, int target)
        {
            Console.WriteLine(string.Join(",", arr));
            Dictionary<int, int> ans = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int x = arr[i];

                if (ans.ContainsKey(target - x))
                {
                    Console.WriteLine("{0}={1}+{2}", target, ans[target - x] + 1, i + 1);
                }
                ans[x] = i;
            }
        }

        static void TwoSumSorted(int[] arr, int target)
        {
            int i = 0, j = arr.Length - 1;

            while (i < j)
            {
                int sum = arr[i] + arr[j];
                if (sum < target)
                    i++;
                else if(sum > target)
                    j--;
                else if (sum == target)
                {
                    Console.WriteLine("{0}, {1}, {2}", target, i + 1, j + 1);
                    break;
                }
            }
        }

        static int lengthOfLongestSubstring(String s) {
            int[] charMap = new int[256];
            for (int a = 0; a < charMap.Length; a++)
            {
                charMap[a] = -1;
            }
            
            int i = 0, maxLen = 0;
            
            for (int j = 0; j < s.Length; j++) {
                if (charMap[s[j]] >= i) {
                    i = charMap[s[j]] + 1;
                }
                charMap[s[j]] = j;
                maxLen = Math.Max(j - i + 1, maxLen);
            }

            return maxLen;
        }


        #region Mongo
        //static async Task MainAsync(string[] args) {
        //    // await AssignmentWeek2();
        //    //await AssignmentWeek3();
        //    //await AssignmentWeek4();
        //}

        //#region Week 4 Assignment
        //static async Task AssignmentWeek4()
        //{
        //}
        //#endregion

        //#region Week 3 Assignment
        //static async Task AssignmentWeek3()
        //{
        //    var client = new MongoClient();
        //    var db = client.GetDatabase("schoo");
        //    var col = db.GetCollection<Student>("students");

        //    var scores = await col.Find<Student>(x => 1 == 1).ToListAsync<Student>();
        //    for (int i = 0; i < scores.Count; i++)
        //    {
        //        var score = scores[i].scores.ToList();
        //        List<Scores> final = new List<Scores>();
        //        Scores hw = null;
        //        for (int j = 0; j < score.Count; j++)
        //        {
        //            if (score[j].type == "homework")
        //            {
        //                if (hw == null || hw.score < score[j].score) hw = score[j];
        //            }
        //            else
        //                final.Add(score[j]);
        //        }
        //        if (hw!=null) final.Add(hw);

        //        await col.UpdateOneAsync(Builders<Student>.Filter.Eq(x => x._id, scores[i]._id),
        //            Builders<Student>.Update.Set(x => x.scores, final));
        //    }
                
        //    Console.WriteLine("done");
        //}

        //class Student { 
        //    public int _id { get; set; }
        //    public string name { get; set; }
        //    public List<Scores> scores { get; set; }
        //}
        
        //class Scores {
        //    public string type { get; set; }
        //    public double score { get; set; }
        //}
        //#endregion

        //#region Week 2 Assignment
        //static async Task AssignmentWeek2()
        //{
        //    var client = new MongoClient();
        //    var db = client.GetDatabase("students");
        //    var col = db.GetCollection<Grade>("grades");

        //    var hw = await col.Find(x => x.type == "homework").SortBy(x => x.student_id).ThenBy(x => x.score).ToListAsync<Grade>();

        //    int studid = -1;
        //    int delCount = 0;
        //    Console.WriteLine("total count : {0}", hw.Count);
        //    for (int i = 0; i < hw.Count; i++)
        //    {
        //        if (studid != hw[i].student_id)
        //        {
        //            studid = hw[i].student_id;
        //            await col.DeleteOneAsync(x => x._id == hw[i]._id);
        //            delCount++;
        //        }
        //    }
        //    Console.WriteLine("delete count : {0}", delCount);
        //}

        //class Grade
        //{
        //    public ObjectId _id { get; set; }
        //    public int student_id { get; set; }
        //    public string type { get; set; }
        //    public double score { get; set; }
        //} 
        #endregion

        #region UniqueCharacters
        static void UniqueCharacters()
        {
            string s = "pratham";

            Console.WriteLine(isUniqueChars(s));
        }

        private static bool isUniqueChars(string s)
        {
            if (s.Length > 256) return false;
            //var char_set = new bool[256];
            int checker = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //int val = s[i];
                //if (char_set[val]) return false;
                //char_set[val] = true;
                int val = s[i] -'a';
                if ((checker & (1 << val)) > 0) return false;
                checker |= (1 << val);
            }

            return true;
        }
        #endregion

        #region Reverse
        static void Reverse()
        {
            string s = "RajeshXSharma";

            char[] charArray = s.ToCharArray();
            int length = s.Length - 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
                charArray[i] ^= charArray[length - i];
                charArray[length - i] ^= charArray[i];
                charArray[i] ^= charArray[length - i];
            }

            Console.WriteLine(new string(charArray));
        }
        #endregion

        #region Replace String
        static void ReplaceSpaces(char[] str, int length) {
            int spaceCount = 0, newLength, i;
            //int.MaxValue;
            for (i = 0; i < length; i++)
                if (str[i] == ' ') spaceCount++;

            newLength = length + spaceCount * 2;
            var strN = new char[newLength];
            strN[newLength] = '\0';

            for (i = length - 1; i >= 0; i--) {
                if (str[i] == ' ') {
                    strN[newLength - 1] = '0';
                    strN[newLength - 2] = '2';
                    strN[newLength - 3] = '%';
                    newLength = newLength - 3;
                } else {
                    strN[newLength - 1] = str[i];
                    newLength = newLength - 1;
                }
            }
        }
        #endregion
    }

    class TwoSumClass : Dictionary<int, int> { 
        public void Add(int value) {
            if (!ContainsKey(value))
            {
                this.Add(value, 1);
            }
            else 
            {
                this[value] = ++this[value];
            }
        }

        public void Find(int value)
        {
            foreach (var item in this)
            {
                int x = value - item.Key;

                if (x == item.Key)
                {
                    if (this[item.Key] >= 2)
                        Console.WriteLine("{0} Found", value);
                }
                else if (ContainsKey(x))
                    Console.WriteLine("{0} Found", value);
            }

            Console.WriteLine("{0} Not found", value);
        }

        public void Test()
        {
            Add(1); Add(3); Add(5); Find(4); Find(7);
        }
    }
}