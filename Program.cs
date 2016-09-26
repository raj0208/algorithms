//using MongoDB.Bson;
//using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList();
            Console.ReadLine();
        }

        static void LinkedList()
        {
            ListNode list1 = new ListNode("Mumbai");

            list1.Next = new ListNode("Baroda");
            list1.Next.Next = new ListNode("Pune");
            list1.Next.Next.Next = new ListNode("Noida");
            list1.Next.Next.Next.Next = new ListNode("Gurgaon");


            ListNode list2 = new ListNode("Noida");

            list2.Next = new ListNode("Mumbai");
            Console.WriteLine("List1");
            list1.Print();
            Console.WriteLine("List2");
            list2.Print();

            GetExcept(list1, list2);
        }

        private static void GetExcept(ListNode list1, ListNode list2)
        {
            HashSet<string> excludeCities = new HashSet<string>();

            while (list2 != null) 
            {
                if (excludeCities.Contains(list2.Data))
                    excludeCities.Add(list2.Data);
            }

            ListNode pointer = list1;
            while (pointer != null)
            {
                if (excludeCities.Contains(pointer.Data))
                {
                    
                }
            
            }
        }

    }

    private static GetExcept(ListNode list1, listN

    [DebuggerDisplay("Node {Data}")]
    class ListNode
    {
        public string Data { get; set; }
        public ListNode Next { get; set; }
        private ListNode Tail { get; set; }
        
        public ListNode(string city, ListNode next = null)
        {
            this.Data = city;
            this.Next = next;
            this.Tail = this.Next;
        }

        public void Add(string city)
        {
            ListNode newNode  = new ListNode(city);
            this.Tail.Next = newNode;
            this.Tail = newNode.Next;
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

        static int Add(int x, int y)
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

        static int sub(int x, int y)
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

        static int multiply(int a, int b)
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
}

