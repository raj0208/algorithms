using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
namespace ConsoleApp
{
    public class MinHeap
    {
        public int[] items = new int[3];
        int size = 0;
        int capacity = 3;

        public int Peek()
        {
            return (size == 0) ? -1 : items[0];
        }

        public void Add(int item)
        {
            if (size == capacity)
                if (item < Peek())
                    Extract();
                else
                {
                    return;
                }
            
            items[size] = item;
            size++;
            HeapifyUp();
        }

        public int Extract()
        {
            if (size == 0) return -1;

            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        private void HeapifyUp()
        {
            int index = size - 1;
            while (index > 0)
            {
                int parent = ParentIndex(index);
                if (items[index] > items[parent])
                {
                    Swap(index, parent);
                }
                else
                    break;
                index = parent;
            }
        }

        private void HeapifyDown()
        {
            int index = 0;

            while (LeftChildIndex(index) < size)
            {
                int smaller = index;
                int left = LeftChildIndex(index);
                int right = RightChildIndex(index);

                if (left < size && items[left] > items[smaller]) smaller = left;
                if (right < size && items[right] > items[smaller]) smaller = right;

                if (smaller != index)
                {
                    Swap(smaller, index);
                }
                else
                    break;
                index = smaller;
            }

        }

        private int LeftChildIndex(int parent) { return (2 * parent) + 1; }
        private int RightChildIndex(int parent) { return (2 * parent) + 2; }
        private int ParentIndex(int child) { return (child - 1) / 2; }
        private void Swap(int index1, int index2)
        {
            items[index1] ^= items[index2];
            items[index2] ^= items[index1];
            items[index1] ^= items[index2];
        }
    }

    class AppLauncher
    {
        static void Main1(string[] args)
        {
            LC.Run();
            //CTCI.Run();
            Console.ReadLine();
        }

        struct Point {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public class Item
        {
            public int weight { get; set; }
            public int value { get; set; }

            public Item(int weight, int value)
            {
                this.weight = weight;
                this.value = value;
            }
        }

        static void Main(string[] args)
        {
            //CTCI.Run();
            AppLauncherMain(args);
            Console.ReadLine();
        }

        private static void HeapTest()

        {
            MinHeap heap = new MinHeap();
            heap.Add(10);
            heap.Add(5);
            heap.Add(7);
            Console.WriteLine(string.Join(",", heap.items));

            Console.WriteLine(heap.Extract());
            Console.WriteLine(string.Join(",", heap.items));

            heap.Add(4);
            heap.Add(1);
            Console.WriteLine(string.Join(",", heap.items));
            heap.Add(15);
            //Console.WriteLine(heap.Extract());
            heap.Add(2);
            Console.WriteLine(string.Join(",", heap.items));
        }

        static void AppLauncherMain(string[] args)
        {
            HeapTest();
            //KLargestElement();
            //Knapsack01();
            //Heapify();
            MissingNumber();
            Add();
            Subtract();
            //BinarySearch();
            //TreeTraversal();
            Console.ReadLine();
            return;
            DeleteNode(2);
            // First code from mac
            MaxCandies();
            // Testing
            //MostContainerWater();
            //RandonArray();
            //KingThreatenedByQueen();
            //==============================
            //LevelPrintTree(TreeNode.CreateTreeFromArray(new int[] { 1,2,3,4,5,6,7,8,9 }, 0, 6));
            //==============================
            //FindOddNumber(new int[] { 1, 2, 3, 4, 2, 1, 4 });
            //==============================
            //MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });
            //==============================
            //LongestSubSequence();
            //==============================
            //Console.WriteLine(FibonacciSeries());
            //==============================
            //SearchMatrix();
            //==============================
            //Console.WriteLine(MaxHistogramArea());
            //==============================
            //string S = "abcdefghijklmnopqrstuvwxyz";
            //int[] w = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            //Console.WriteLine(NumberOfLines(w, S));
            //S = "bbbcccdddaaa";
            //w = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            //Console.WriteLine(NumberOfLines(w, S));
            //==============================
            //var grid = new int[][] {
            //    new int[] { 3, 0, 8, 4 },
            //    new int[] { 2, 4, 5, 7},
            //    new int[] { 9, 2, 6, 3 },
            //    new int[] { 0, 3, 1, 0 }
            //};
            //Console.WriteLine(MaxIncreaseKeepingSkyline(grid));
            //==============================
            //var word = new string[] { "gin", "zen", "gig", "msg" };
            //Console.WriteLine(UniqueMorseRepresentations(word));
            //==============================
            //IsUniqueChars();
            //ReverseLinkedList();
            //TreeTraversal();
            Console.ReadLine();
        }

        private static void KLargestElement()
        {
            int[] arr = { 2,5,4,6,7,8 };








        }

        private static void MissingNumber()
        {
            int[] a = { 1, 2, 4 };

            int n = 3;

            {
                int i;
                int x1 = a[0]; /* For xor of all the elemets in arary */
                int x2 = 1; /* For xor of all the elemets from 1 to n+1 */
                for (i = 1; i < n; i++)
                    x1 = x1 ^ a[i];
                for (i = 2; i <= n + 1; i++)
                    x2 = x2 ^ i;
                Console.WriteLine(x1 ^ x2);
            }
        }

        private static void Subtract()
        {
            int x = 15, y = 7;
            int carry = 0;

            do
            {
                carry = ~x & y;
                x = x ^ y;
                y = carry << 1;
            } while (carry != 0);
            Console.WriteLine($"{x}, {y}");
        }

        private static void Add()
        {
            int x = 5, y = 7;
            int carry = 0;
            while (y != 0)
            {
                carry = x & y;
                x = x ^ y;
                y = carry << 1;
            }

            Console.WriteLine($"{x}, {y}");

        }



        private static void Heapify()
        {
            int[] arr = { 1,3,5,4,6,13,10,9,8,15,17 };


            int n = arr.Length;
            PrintHeap(arr, n);

            BuildMaxHeap(arr, n, true);
            PrintHeap(arr, n);

            BuildMaxHeap(arr, n, false);
            PrintHeap(arr, n);
        }

        private static void PrintHeap(int[] arr, int n)
        {
            Console.WriteLine("Array representation of Heap is:");

            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        private static void BuildMaxHeap(int[] arr, int n, bool isMaxHeap)
        {
            int lastNonLeafNode = (n / 2) - 1; // last non leaf node

            for (int i = lastNonLeafNode; i >= 0; i--)
            {
                MinMaxHeapify(arr, n, i, isMaxHeap);
            }
        }

        private static void MinMaxHeapify(int[] arr, int n, int i, bool max)
        {
            int largest = i;         // parent
            int left = (2 * i) + 1 ; // left child
            int right = (2 * i) + 2; // right child

            if (left < n && (
                    (max && arr[largest] < arr[left]) ||
                    (!max && arr[largest] > arr[left])))
                largest = left;
            if (right < n && (
                    (max && arr[largest] < arr[right]) ||
                    (!max && arr[largest] > arr[right])))
                largest = right;

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                MinMaxHeapify(arr, n, largest, max);
            }
        }

        private static void Knapsack01()
        {
            var items = new List<Item>() 
                { new Item(1, 6),  new Item(2,10), new Item(3, 12)};
            int W = 5;


            var cache = new int[items.Count + 1, W + 1];
            for (int i = 1; i <= items.Count; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    // If including item[i-1] would exceed max weight j, don't 
                    // include the item. Otherwise take the max value of including
                    // or excluding the item
                    if (items[i - 1].weight > j) cache[i, j] = cache[i - 1,j];
                    else cache[i,j] = Math.Max(cache[i - 1,j], cache[i - 1,j - items[i - 1].weight] + items[i - 1].value);
                }
            }

            Console.WriteLine(cache[items.Count,W]);
        }

        private static void BinarySearch()
        {
            var array = new int[] { 3, 6, 8, 12, 14, 17, 25, 29, 31, 36, 42, 47, 53, 55, 62 };
            int key = 65;
            Console.WriteLine(IterativeBinarySearch(array, key));
            Console.WriteLine(RecursiveBinarySearch(array, 0, array.Length - 1, key));
        }

        private static int RecursiveBinarySearch(int[] array, int low, int high, int key)
        {
            if (low == high)
            {
                return array[low] == key ? low : -1;
            }
            else
            {
                int mid = (low + high) / 2;

                if (array[mid] == key)
                    return mid;

                if (array[mid] < key)
                    return RecursiveBinarySearch(array, low + 1, high, key);
                else
                    return RecursiveBinarySearch(array, low, high - 1, key);
            }
        }



        private static int IterativeBinarySearch(int[] array, int keyToSearch)
        {
            int low = 0, high = array.Length - 1, mid = 0;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (array[mid] == keyToSearch)
                    return mid;

                if (array[mid] < keyToSearch)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }

        private static void DeleteNode(int nthlast)
        {
            int[] data = { 1, 2, 3, 4, 5 };
            Node head = Node.GetNodeList(data);
            head.PrintNodes();

            Node nHead = head;
            Node runner = nHead;

            for (int i = 0; i < nthlast; i++)
            {
                runner = runner.Next;
            }

            while (runner != null)
            {
                nHead = nHead.Next;
                runner = runner.Next;
            }

            nHead.Next = nHead.Next.Next;
            
            head.PrintNodes();

            Console.ReadLine();
        }

        private static void MaxCandies()
        {
            var ratings = new int[] { 1,2,1,2,3, 2, 5 };

            var candies = new int[ratings.Length];
            candies[0] = 1;
            // left to right
            for (int i = 1; i < ratings.Length; i++)
            {
                candies[i] = (ratings[i] > ratings[i - 1])
                             ? candies[i - 1] + 1
                             : 1;
            }

            //right to left
            int maxCandies = candies[ratings.Length - 1];
            for (int i = candies.Length - 2; i >= 0; i--)
            {
                int candy = 1;
                if (ratings[i] < ratings[i + 1])
                {
                    candy = candies[i + 1] + 1;
                }

                maxCandies += Math.Max(candy, candies[i]);
                candies[i] = candy;
            }

            Console.WriteLine(maxCandies);
        }

        private static void MostContainerWater()
        {
            int[] height = new int[] { 1, 2, 3, 2, 3, 2, 4, 2 };

            if (height == null || height.Length < 2) return;

            int left = 0, right = height.Length - 1, max = 0;

            while (left < right) {
                max = Math.Max(max, (right - left) * Math.Min(height[right], height[left]));

                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            Console.WriteLine("Max is {0}", max);
        }

        private static void RandonArray()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            var random = new Random();
            Console.WriteLine(string.Join(" ", arr));



            for (int i = 0; i < arr.Length; i++)
            {
                int temp = random.Next(i, arr.Length - 1);
                int val = arr[temp];
                arr[temp] = arr[i];
                arr[i] = val; 
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void KingThreatenedByQueen()
        {
            Point king = new Point(3,1);
            Point queen = new Point(3,4);

            Func<Point, bool> validate = (p) =>
            {
                if ((p.X >= 1 && p.X <= 8) &&
                    (p.Y >= 1 && p.Y <= 8)) {
                    Console.WriteLine("valid coordinate");
                    return true;   
                }

                Console.WriteLine("Invalid coordinate");

                return false;
            };

            if (!validate(king) || !validate(queen)) {
                return;
            }

            // king and queen x is same
            if ( (king.X == queen.X) 
                 || (king.Y == queen.Y) 
                 || Math.Abs(king.X - queen.X) == Math.Abs(king.Y - queen.Y))
                Console.WriteLine("threatened");
            else
                Console.WriteLine("Not threatened");
            // king and queen y is same

            // abs(kx-qx)=abs(ky-qy)
        }

        private static void LevelPrintTree(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            root.Level = 1;
            queue.Enqueue(root);
            int level = 0;
            while (queue.Any()) {
                var node = queue.Dequeue();
                if (level != node.Level) {
                    Console.Write(Environment.NewLine);
                    level = node.Level;
                }

                if (node.Left != null) {
                    node.Left.Level = node.Level + 1;
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null) {
                    node.Right.Level = node.Level + 1;
                    queue.Enqueue(node.Right);
                }
                Console.Write(node.Data + " ");
            }
        }

        private static void FindOddNumber(int[] array)
        {
            int odd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                odd = odd ^ array[i];
            }

            Console.WriteLine(odd);
        }

        static int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length == 1)
                return 0;
            int result = nums.Length;
            int start = 0;
            int sum = 0;
            int i = 0;
            bool exists = false;
            while (i <= nums.Length)
            {
                if (sum >= s)
                {
                    exists = true; //mark if there exists such a subarray
                    if (start == i - 1)
                    {
                        return 1;
                    }
                    result = Math.Min(result, i - start);
                    sum = sum - nums[start];
                    start++;
                }
                else
                {
                    if (i == nums.Length)
                        break;
                    sum = sum + nums[i];
                    i++;
                }
            }
            if (exists)
                return result;
            else
                return 0;
        }

        private static void LongestSubSequence()
        {
            int[] array = new int[] { 2, 1, 6, 4, 7, 5, 9, 3 };

            HashSet<int> map = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!map.Contains(array[i]))
                    map.Add(array[i]);
            }
            int longest = 0;
            foreach (var item in map)
            {
                if (!map.Contains(item - 1)) {
                    int curr = item;
                    int count = 1;

                    while (map.Contains(curr + 1)) {
                        curr++;
                        count++;
                    }
                    
                    longest = Math.Max(longest, count);
                }
            }

            Console.WriteLine(longest);
        }

        private static int FibonacciSeries() // constant space, linear o(n)
        {
            int pos = 5;
            int last = 1;
            int slast = 0;
            int currPos = 2;

            while (currPos <= pos) {
                int temp = last;
                last = slast + last;
                slast = temp;
                currPos++;
            }

            return last;
        }

        private static void SearchMatrix()
        {
            int[][] matrix = new int[][] {
                new int[] { 1, 4, 7, 11, 15 },
                new int[] {2, 5, 8, 12, 19 },
                new int[] {3, 6, 9, 16, 22 },
                new int[] {10, 13, 14, 17, 24 },
                new int[] { 18, 21, 23, 26, 30 }
            };

            int target =0;

            int rows = matrix.Length - 1;
            int cols = matrix[0].Length - 1;

            int r = rows;
            int c = 0;

            while (r >= 0 && c <= cols) {
                if (target < matrix[r][c]) r--;
                else if (target > matrix[r][c]) c++;
                else
                {
                    Console.WriteLine("found"); break;
                }
            }

            Console.WriteLine("not found");
        }

        public static int MaxHistogramArea()
        {
            //int[] hist = new int[] { 1 };
            int[] hist = new int[] { 1, 2, 3, 4, 5, 3, 3, 2 };
            if (hist == null || !hist.Any()) return 0;

            Stack<int> stack = new Stack<int>();
            int max = 0;
            int index = 0;

            while (index < hist.Length)
            {
                if (stack.Count == 0 || hist[index] >= hist[stack.Peek()])
                {
                    stack.Push(index);
                    index++;
                }
                else
                {
                    max = MaxArea(hist, stack, max, index);
                }
            }

            while (stack.Any())
            {
                max = MaxArea(hist, stack, max, index);
            }

            return max;
        }

        private static int MaxArea(int[] hist, Stack<int> stack, int max, int index)
        {
            int currentIndex = stack.Pop();
            int height = hist[currentIndex];
            int width = stack.Any() ? (index - 1 - stack.Peek()) : index - 1;
            max = Math.Max(max, height * width);
            return max;
        }

        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int[] cols = new int[grid[0].Length] ;
            int[] rows = new int[grid.Length];
            // Get max for each row
            for (int row = 0; row < rows.Length; row++)
            {
                for (int col = 0; col < cols.Length; col++)
                {
                    if (rows[row] < grid[row][col]) rows[row] = grid[row][col];
                    if (cols[col] < grid[row][col]) cols[col] = grid[row][col];
                }
            }

            int total = 0;
            // for each cell [i,j], get difference between value and min of [maxrow[i],maxcol[j]] and add to sum
            for (int row = 0; row < rows.Length; row++)
            {
                for (int col = 0; col < cols.Length; col++)
                {
                    int offset = Math.Min(rows[row], cols[col]);
                    grid[row][col] = (offset > grid[row][col]) ? offset - grid[row][col] : 0;
                    total += grid[row][col];
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine(string.Join(" ", grid[i]));
            }

            // return sum
            return total;
        }


        public static int UniqueMorseRepresentations(string[] words)
        {
            string[] codes = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
                "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
                "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

            var unique = new HashSet<string>();
            int count = 0;

            StringBuilder coded = new StringBuilder();
            foreach (var item in words)
            {
                coded.Clear();
                for (int i = 0; i < item.Length; i++)
                {
                    coded.Append(codes[item[i] - 'a']);
                }

                if (!unique.Contains(coded.ToString()))
                {
                    unique.Add(coded.ToString());
                    count++;
                }
            }

            return count;
        }

        public static string NumberOfLines(int[] widths, string S)
        {
            int total = 0;
            int index = 0;
            int lines = 1;
            
            for (int i = 0; i < S.Length; i++)
            {
                index = S[i] - 'a';

                if (total + widths[index] > 100)
                {
                    lines++;
                    total = widths[index];
                }
                else
                    total += widths[index];
            }

            return string.Join(" ", new int[] { lines, total});
        }


        private static void IsUniqueChars()
        {
            string s = "rajezhma";

            int checker = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int val = s[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    Console.WriteLine("not unique");
                    return;
                }
                checker |= 1 << val;
            }

            Console.WriteLine("Unique");
        }

        private static void ReverseLinkedList()
        {
            var root = LinkedNode.GetLinkedNodes(new int[] {1,2,3,4,5 });

            LinkedNode curr = root;
            LinkedNode prev = null, next = null;
            curr.Print();

            while (curr != null) {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            prev.Print();
        }

        private static void ReverseLinkedListWith2Ptrs()
        {
            var root = LinkedNode.GetLinkedNodes(new int[] { 1, 2, 3, 4, 5 });

            LinkedNode prev = null;
            LinkedNode current = root;

            // at last prev points to new head
            while (current != null)
            {
                // This expression evaluates from left to right
                // current->next = prev, changes the link fron
                //                 next to prev node
                // prev = current, moves prev to current node for
                //        next reversal of node
                // This example of list will clear it more 1->2->3->4
                // initially prev = 1, current = 2
                // Final expression will be current = 1^2^3^2^1,
                // as we know that bitwise XOR of two same
                // numbers will always be 0 i.e; 1^1 = 2^2 = 0
                // After the evaluation of expression current = 3 that
                // means it has been moved by one node from its
                // previous position
                //current =  ((ut)prev^(ut)current^(ut)(current->next)^
                //                          (ut)(current->next = prev)^
                //                          (ut)(prev = current));
            }


            //* head_ref = prev;
        }


        private static void TreeTraversal()
        {
            TreeNode root = TreeNode.CreateTreeFromArray(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 5);

            /*        3
                 1        5
               n    2  4     6
            */ 
            
            Preorder(root); //3 1 2 5 4 6
            Inorder(root); // 1 2 3 4 5 6
            Postorder(root);
        }

        private static void Postorder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode curr = null, prev = null;

            while (stack.Any()) {
                curr = stack.Peek();

                if (prev == null || prev.Left == curr || prev.Right == curr)
                {
                    if (curr.Left != null) stack.Push(curr.Left);
                    else if (curr.Right != null) stack.Push(curr.Right);
                    else {
                        Console.Write(curr.Data + " ");
                        stack.Pop();
                    }
                }
                else if (curr.Left == prev)
                {
                    if (curr.Right != null) stack.Push(curr.Right);
                    else
                    {
                        Console.Write(curr.Data + " ");
                        stack.Pop();
                    }
                }
                else if (curr.Right == prev)
                {
                    Console.Write(curr.Data + " ");
                    stack.Pop();
                }

                prev = curr;
            }

            Console.Write("\n");
        }

        private static void Inorder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;

            while (stack.Any() || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else {
                    curr = stack.Pop();
                    Console.Write(curr.Data + " ");
                    curr = curr.Right;
                }
            }

            Console.Write("\n");
        }

        private static void Preorder(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode current = null;

            while (stack.Any())
            {
                current = stack.Pop();
                Console.Write(current.Data + " ");
                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }
            Console.Write("\n");
        }

        private static void MorrisPreorder(TreeNode root)
        {
            if (root == null) return;

            TreeNode curr = root, prev = null;

            while (curr != null)
            {
                if (curr.Left == null)
                {
                    Console.WriteLine(curr.Data + " ");
                    curr = curr.Right;
                }
                else {
                    prev = curr.Left;

                    while (prev.Right != null || prev.Right != curr)
                        prev = prev.Right;

                    if (prev.Right == null)
                    {
                        prev.Right = curr;
                        Console.WriteLine(curr.Data + " ");
                        curr = curr.Left;
                    }
                    else {
                        prev.Right = null;
                        curr = curr.Right;
                    }
                }
            }
        }
    }
}


//Max Increase to Keep City Skyline
//User Accepted: 1195
//User Tried: 1211
//Total Accepted: 1202
//Total Submissions: 1357
//Difficulty: Medium
//In a 2 dimensional array grid, each value grid[i][j] represents the height of a building located there.We are allowed to increase the height of any number of buildings, by any amount(the amounts can be different for different buildings). Height 0 is considered to be a building as well.

//At the end, the "skyline" when viewed from all four directions of the grid, i.e.top, bottom, left, and right, must be the same as the skyline of the original grid.A city's skyline is the outer contour of the rectangles formed by all the buildings when viewed from a distance. See the following example.


//What is the maximum total sum that the height of the buildings can be increased?

//Example:
//Input: grid = [[3, 0, 8, 4], [2,4,5,7], [9,2,6,3], [0,3,1,0]]
//Output: 35
//Explanation: 
//The grid is:
//[ [3, 0, 8, 4], 
//  [2, 4, 5, 7],
//  [9, 2, 6, 3],
//  [0, 3, 1, 0] ]

//The skyline viewed from top or bottom is: [9, 4, 8, 7]
//The skyline viewed from left or right is: [8, 7, 9, 3]

//The grid after increasing the height of buildings without affecting skylines is:

//gridNew = [ [8, 4, 8, 7],
//            [7, 4, 7, 7],
//            [9, 4, 8, 7],
//            [3, 3, 3, 3] ]

//Notes:

//1 < grid.length = grid[0].length <= 50.
//All heights grid[i][j] are in the range[0, 100].
//All buildings in grid[i][j] occupy the entire grid cell: that is, they are a 1 x 1 x grid[i][j]
//rectangular prism.


//-----------------------

//805. Split Array With Same Average
//User Accepted: 77
//User Tried: 396
//Total Accepted: 78
//Total Submissions: 856
//Difficulty: Hard
//In a given integer array A, we must move every element of A to either list B or list C. (B and C initially start empty.)

//Return true if and only if after such a move, it is possible that the average value of B is equal to the average value of C, and B and C are both non-empty.

//Example :
//Input: 
//[1,2,3,4,5,6,7,8]
//Output: true
//Explanation: We can split the array into[1, 4, 5, 8] and[2, 3, 6, 7], and both of them have the average of 4.5.
//Note:

//The length of A will be in the range[1, 30].
//A[i] will be in the range of[0, 10000].


public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public static Node GetNodeList(int[] data)
    {
        Node head = new Node(0);
        Node current = head;
        foreach (int i in data)
        {
            current.Next = new Node(i);
            current = current.Next;
        }

        return head.Next;
    }

    public void PrintNodes()
    {
        Node temp = this;

        while (temp != null)
        {
            Console.WriteLine(temp.Data + "->");
            temp = temp.Next;
        }
        Console.WriteLine("NULL");
    }
}