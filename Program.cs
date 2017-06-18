//using MongoDB.Bson;
//using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace ConsoleApp
{
    class ProgramOld
    {
        static void MainOld(string[] args)
        {
            //int n=6;
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine(new String('#', i + 1).PadLeft(n, ' '));

            //Console.WriteLine(isUniqueChars("Rajesh Sharma"));//
            //replaceSpaces("Rajesh Sharma   ".ToCharArray(), 13);
            //OneEditAway("Rajesh", "Rajsh");
            //Rotate();
            //LinkedList();
            //Recommendation();
            //Codec.CodecTinyURL();
            //TinyURL.TestTinyURL();
            //SingleNonDuplicate();
            //SortSubArray();
            //ReverseInt();
            MinMaxSum();
            Console.ReadLine();
        }

        private static void MinMaxSum()
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
            Console.WriteLine(numbers.OrderBy(x => x).Take(4).Sum());
            Console.WriteLine(numbers.OrderBy(x => x).Skip(1).Sum());
        }

        private static void ReverseInt()
        {
            int num = -12345;
            bool isNegative = num < 0;
            int t = num;
            long reverse = 0;

            if (isNegative) num = num * -1;

            while (num != 0) {
                reverse = (reverse * 10) + (num % 10);
                num /= 10;
            }

            if (isNegative) reverse = reverse * -1;

            if (reverse < int.MinValue || reverse > int.MaxValue) reverse = 0;

            

            Console.WriteLine("reverse of {0} is {1},",t, reverse);
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

        public static void SingleNonDuplicate()
        {
            int[] nums = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 8, 8 };
            // binary search
            int n = nums.Length, lo = 0, hi = n / 2;
            while (lo < hi)
            {
                int m = (lo + hi) / 2;
                if (nums[2 * m] != nums[2 * m + 1]) hi = m;
                else lo = m + 1;
            }

            Console.WriteLine(nums[2 * lo]);
        }

        #region Amazon
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

        // LRU

        // TinyURL
        public class Codec
        {
            Dictionary<string, string> index = new Dictionary<string, string>();
            Dictionary<string, string> revIndex = new Dictionary<string, string>();
            static String BASE_HOST = "http://tinyurl.com/";

            public static void CodecTinyURL()
            {
                Codec tiny = new Codec();
                string url = tiny.encode("http://www.google.com");
                Console.WriteLine(url);
                Console.WriteLine(tiny.decode(url));
            }



            // Encodes a URL to a shortened URL.
            public String encode(String longUrl)
            {
                if (revIndex.ContainsKey(longUrl)) return BASE_HOST + revIndex[longUrl];

                String charSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                String key = null;

                Random random = new Random();
                do
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 6; i++)
                    {
                        int r = (int)(random.Next(charSet.Length));
                        sb.Append(charSet[r]);
                    }
                    key = sb.ToString();
                } while (index.ContainsKey(key));
                index.Add(key, longUrl);
                revIndex.Add(longUrl, key);
                return BASE_HOST + key;
            }

            // Decodes a shortened URL to its original URL.
            public String decode(String shortUrl)
            {
                return index[shortUrl.Replace(BASE_HOST, "")];
            }
        }

        public class TinyURL
        {
            private static String ALPHABET_MAP = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" ;
	        private static ulong BASE = (ulong)ALPHABET_MAP.Length;

            public static void TestTinyURL()
            {
                ulong index = 134;
                string e = encode(index);
                var i = decode(e);
                Console.WriteLine( "Encoding for 123 is " + e) ;
                Console.WriteLine( "Decoding for b9 is " + i) ;
            }

            public static String encode(ulong IndexNum)
            {
                StringBuilder sb = new StringBuilder();

                while (IndexNum > 0)
                {
                    sb.Insert(0,ALPHABET_MAP[(int)(IndexNum % BASE)]);
                    IndexNum /= BASE;
                }
                
                return sb.ToString();
            }

            public static ulong decode(String str)
            {
                ulong Num = 0;

                for (int i = 0, len = str.Length; i < len; i++)
                {
                    Num = Num * BASE + (ulong)ALPHABET_MAP.IndexOf(str[i]);
                }
                return Num;
            }
        }

        // sort subarray to sort whole array
        private static void SortSubArray()
        {
            int[] array = new int[] {0,2,5,4,6,7,3};

            int head = 0, tail = array.Length - 1;

            if (array[head] > array[tail]) // boundary condition
            {
                Console.WriteLine("sort from {0} to {1}", head, tail);
                return;
            }

            while (head < tail) {
                if (array[head] < array[tail] && array[head] < array[head + 1])
                {
                    head++;
                }
                else
                    break;
            }

            Console.WriteLine("sort from {0} to {1}", head, tail);
        }
        #endregion

        private static void RemoveNthNode()
        {
            var list = LinkedNode.GetLinkedNodes(new int[] {1,2,3,4,5,6});
            int remove = 2;

            var dummyHead = new LinkedNode();
            dummyHead.Next = list;
            var slow = dummyHead.Next;
            var fast = dummyHead.Next;

            while (fast.Next != null) {
                if (remove <= 0) 
                    slow = slow.Next;
                else
                    remove--;

                fast = fast.Next;
            }

            if (slow.Next != null) {
                slow.Next = slow.Next.Next;
            }
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

    class Program1
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
            Console.WriteLine(lengthOfLongestSubstring("Rajesh Sharma is great"));

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


    #region LFU cache
    //Design and implement a data structure for Least Frequently Used(LFU) cache.It should support the following operations: get and put.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //put(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item.For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

    //Follow up:
    //Could you do both operations in O(1) time complexity?


    //Two HashMaps are used, one to store<key, value> pair, another store the<key, node>.
    //I use double linked list to keep the frequent of each key. In each double linked list node, keys with the same count are saved using java built in LinkedHashSet.This can keep the order.
    //Every time, one key is referenced, first find the current node corresponding to the key, If the following node exist and the frequent is larger by one, add key to the keys of the following node, else create a new node and add it following the current node.
    //All operations are guaranteed to be O(1).

    public class LFUCache
    {
        private Node head = null;
        private int cap = 0;
        private Dictionary<int, int> valueHash = null;
        private Dictionary<int, Node> nodeHash = null;

        public LFUCache(int capacity)
        {
            this.cap = capacity;
            valueHash = new Dictionary<int, int>();
            nodeHash = new Dictionary<int, Node>();
        }

        public int get(int key)
        {
            if (valueHash.ContainsKey(key))
            {
                increaseCount(key);
                return valueHash[key];
            }
            return -1;
        }

        public void set(int key, int value)
        {
            if (cap == 0) return;
            if (valueHash.ContainsKey(key))
            {
                valueHash.Add(key, value);
            }
            else
            {
                if (valueHash.Count < cap)
                {
                    valueHash.Add(key, value);
                }
                else
                {
                    removeOld();
                    valueHash.Add(key, value);
                }
                addToHead(key);
            }
            increaseCount(key);
        }

        private void addToHead(int key)
        {
            if (head == null)
            {
                head = new Node(0);
                head.keys.Add(key);
            }
            else if (head.count > 0)
            {
                Node node = new Node(0);
                node.keys.Add(key);
                node.next = head;
                head.prev = node;
                head = node;
            }
            else
            {
                head.keys.Add(key);
            }
            nodeHash.Add(key, head);
        }

        private void increaseCount(int key)
        {
            Node node = nodeHash[key];
            node.keys.Remove(key);

            if (node.next == null)
            {
                node.next = new Node(node.count + 1);
                node.next.prev = node;
                node.next.keys.Add(key);
            }
            else if (node.next.count == node.count + 1)
            {
                node.next.keys.Add(key);
            }
            else
            {
                Node tmp = new Node(node.count + 1);
                tmp.keys.Add(key);
                tmp.prev = node;
                tmp.next = node.next;
                node.next.prev = tmp;
                node.next = tmp;
            }

            nodeHash.Add(key, node.next);
            if (node.keys.Count == 0) remove(node);
        }

        private void removeOld()
        {
            if (head == null) return;
            int old = 0;
            foreach (int n in head.keys)
            {
                old = n;
                break;
            }
            head.keys.Remove(old);
            if (head.keys.Count == 0) remove(head);
            nodeHash.Remove(old);
            valueHash.Remove(old);
        }

        private void remove(Node node)
        {
            if (node.prev == null)
            {
                head = node.next;
            }
            else
            {
                node.prev.next = node.next;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
        }

        class Node
        {
            public int count = 0;
            public List<int> keys = null;
            public Node prev = null, next = null;

            public Node(int count)
            {
                this.count = count;
                keys = new List<int>();
                prev = next = null;
            }
        }
    }



    #endregion




}