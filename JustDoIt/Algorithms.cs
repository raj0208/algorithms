using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace JustDoIt
{
    public class Algorithms
    {
        public static void Run()
        {
            //PreorderTraversal();
            //MorrisPreorderTraversal();
            //InorderTranversal();
            //PostorderTraversal();
            //DFSTraversal();
            //BFSTraversal();
            //MinHeap();
            //SingleNonDuplicate();
            //OneMissingNumber();
            //TwoMissingNumber();
            //RectangleOverlap();

            //LongestSequence();
            //MajorityElement();

            //ContainerWater();
            //MinCandies();
            //RangeSummary();
            //LargestRectangle();
            //LargestOneMatrix();

            //QuickSort();
            //BinarySearch();
            //MergeSort();

            //ClosestPoints cp = new ClosestPoints();
            //cp.Run();

            //CloneLinkedList();
            //MoviesInFlight();
            //ZombieMatrix();
            //Question1();
            //OrangesRotting();
            //FindPairWithSum();
            //TopNCompetitors();
            //ReorderLogFiles();
            //ReorderLogFiles2();
            //ReorderLogFilesWorking();

            //SubTree();
            //SuggestedProducts();

            //RotateMatrix();
            //MatrixProduct();
            //LongestSubstring();

            //TreasureIsland();
            //SpiralMatrix();
            //PrisonCellAfterNDays();

            //MaximumSumSubTree();
            //LevelOrderTraversal();
            //Console.ReadLine();
            FindElementInSortedRowColMatrix();
            


        }

        private static void FindElementInSortedRowColMatrix()
        {
            int[][] matrix = {
                new int[] { 15,20,40,85 },
                new int[] { 20,35,80,95 },
                new int[] { 30,55,95,105 },
                new int[] { 40,80,100,120 },
            };

            int search = 55;

            int row = 0;
            int col = matrix[0].Length;

            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == search)
                {
                    Console.WriteLine($"Found {search} at {row},{col}");
                }
                else if (matrix[row][col] < search)
                {
                    col--;
                }
                else if (matrix[row][col] > search)
                {
                    row++;
                }
            }

            Console.WriteLine($"Not found {search}");
        }

        private static void Question1()
        {
            int[,] grid = new int[5,5];


            int[][] adjacentServers = {
            new int[] { 0, 1 }, // down
		    new int[] { 0, -1 }, // up
		    new int[] { 1, 0 }, // right
		    new int[] { -1, 0 }, // left
		    };


            Queue<int[]> allServers = new Queue<int[]>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (grid[i, j] == 1) // queue all ok servers
                        allServers.Enqueue(new int[] { i, j });
                }
            }

            int totalServers = grid.Length;
            int serverCount = allServers.Count;

            if (serverCount == 0 || serverCount == totalServers)
                return;

            int days = 0;
            while (allServers.Count > 0)
            {
                if (serverCount == totalServers) break;

                int count = allServers.Count;

                for (int i = 0; i < count; i++)
                {
                    var ser = allServers.Dequeue();

                    foreach (var dir in adjacentServers)
                    {
                        int ni = ser[0] + dir[0];
                        int nj = ser[1] + dir[1];

                        if (ni >= 0 && ni < grid.GetUpperBound(0) &&
                            nj >= 0 && nj < grid.GetUpperBound(1) &&
                            grid[ni, nj] == 0)
                        {
                            // enquwuw
                            serverCount++;
                            grid[ni, nj] = 1;
                            allServers.Enqueue(new int[] { i, nj });
                        }
                    }
                }
                days++;
            }
        }

        private static void LevelOrderTraversal()
        {
            TreeNode root = new TreeNode(1);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                Console.WriteLine(curr.val + " ");
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
        }

        class SumTreeNode
        {
            public int val;
            public List<SumTreeNode> children;

            SumTreeNode() { }
            SumTreeNode(int val, List<SumTreeNode> children)
            {
                this.val = val;
                this.children = children;
            }
        }

        static int maxSum;
        private static void MaximumSumSubTree()
        {
            SumTreeNode currMaxNode = null, root = null;
            var curr = HelperMaxSumNode(root, currMaxNode);

        }

        private  static int[] HelperMaxSumNode(SumTreeNode node, SumTreeNode currMaxNode)
        {
            if (node == null) return new int[] { 0, 0 };

            
            int currSum = node.val;
            int currCount = 1;

            for (int i = 0; i < node.children.Count; i++)
            {
                var temp = HelperMaxSumNode(node.children[i], currMaxNode);
                currSum += temp[0];
                currCount += temp[1];
            }

            if (currCount > 1 && (currMaxNode == null || (currSum / currCount) > maxSum))
            {
                currMaxNode = node;
                maxSum = currSum / currCount;
            }

            return new int[] { currSum, currCount };
        }

        private static void PrisonCellAfterNDays()
        {
            int[] cells = { 0, 1, 0, 1, 1, 0, 0, 1};
            int N = 1000000000;
            
            Dictionary<string, int> map = new Dictionary<string, int>();

            string cellsStr = string.Join("", cells);

            for (int i = 0; i < N; i++)
            {

                map[cellsStr] = i; // keep track of the state and day

                cells = NextDay(cells); // advance the state
                cellsStr = string.Join("", cells); // serialize it

                // if we've seen this state before, fast-forward
                if (map.ContainsKey(cellsStr))
                {
                    int daysAgo = i + 1 - map[cellsStr]; // how many days ago was it when we saw this state?
                    int daysLeft = N - (i + 1); // how many days do we have left (if we don't fast-forward)?
                    //return DoLastNDays(cells, daysLeft % daysAgo);
                    DoLastNDays(cells, daysLeft % daysAgo);
                    break;
                }

            }

            // if we never get a cycle, we can stay in the current for-loop
            //return cells;

            Console.WriteLine("Resilt:" + string.Join(",", cells));
        }

        private static int[] DoLastNDays(int[] cells, int N)
        {
            for (int i = 0; i < N; i++)
            {
                cells = NextDay(cells);
            }

            return cells;
        }

        // advance the state by one day
        private static int[] NextDay(int[] cells)
        {
            int[] newCells = new int[cells.Length];

            for (int i = 1; i < cells.Length - 1; i++)
            {
                if (cells[i - 1] == cells[i + 1])
                    newCells[i] = 1;
                else
                    newCells[i] = 0;
            }

            return newCells;
        }

        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            int[] first = new int[cells.Length];
            int[] newCells = new int[cells.Length];

            for (int cycle = 0; N > 0; N--, cycle++)
            {
                for (int i = 1; i < cells.Length - 1; i++)
                    newCells[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;

                if (cycle == 0)
                    first = Copy(newCells);
                else
                {
                    string fc = string.Join("", first);
                    string nc = string.Join("", newCells);
                    if (fc.Equals(nc))
                        N %= cycle;
                }

                cells = Copy(newCells);
            }
            return cells;

        }

        private int[] Copy(int[] newCells)
        {
            int[] copy = new int[newCells.Length];
            for (int i = 0; i < newCells.Length; i++)
            {
                copy[i] = newCells[i];
            }
            return copy;
        }

        //public int[] prisonAfterNDays(int[] c, int N)
        //{
        //    int[] f_c = new int[c.Length], next_c = new int[c.Length];

        //    for (int cycle = 0; N-- > 0; c = next_c.Clone()), ++cycle)
        //    {
        //        for (int i = 1; i < c.length - 1; ++i)
        //            next_c[i] = (c[i - 1] == c[i + 1] ? 1 : 0);

        //        if (cycle == 0)
        //            f_c = next_c.clone();
        //        else if (Arrays.equals(next_c, f_c))
        //            N %= cycle;
        //    }
        //    return c;
        //}

        private static void SpiralMatrix()
        {
            int n = 5;
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            int rowStart = 0, rowEnd = n - 1;
            int colStart = 0, colEnd = n - 1;

            int counter = 1;
            while (counter <= n*n)
            {
                // top row
                for (int i = colStart; i <= colEnd; i++)
                {
                    matrix[rowStart][i] = counter--;
                }
                rowStart++;

                for (int i = rowStart; i <= rowEnd; i++)
                {
                    matrix[i][colEnd] = counter--;
                }
                colEnd--;

                for (int i = colEnd; i >= colStart; i--)
                {
                    matrix[rowEnd][i] = counter--;
                }
                rowEnd--;

                for (int i = rowEnd; i >= rowStart; i--)
                {
                    matrix[i][colStart] = counter--;
                }
                colStart++;
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(",", row));
            }
        }

        private static void TreasureIsland()
        {
            char[][] island = {
                new char[] { '0', '0', '0', '0' },
                new char[] { 'D', '0', 'D', '0' },
                new char[] { '0', 'D', '0', '0' },
                new char[] { 'X', '0', '0', '0' }
            };

            if (island == null || island.Length == 0 || island[0][0] == 'D')
            {
                Console.WriteLine("No treasure");
                return;
            }

            if (island[0][0] == 'X')
            {
                Console.WriteLine("Treasure found 0 steps");
                return;
            }

            Queue<int[]> queue = new Queue<int[]>();          
            queue.Enqueue(new int[] { 0, 0 });

            List<int[]> directions = new List<int[]>() {
                new int[] { 0, 1 }, // up
                new int[] { 0, -1 }, // down
                new int[] { 1, 0 },
                new int[] { -1, 0 },
            };

            int minSteps = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var cur = queue.Dequeue();
                    if (island[cur[0]][cur[1]] == 'D')
                        continue;

                    foreach (var dir in directions)
                    {
                        int nx = cur[0] + dir[0];
                        int ny = cur[1] + dir[1];

                        if (nx >= 0 && nx < island.Length &&
                            ny >= 0 && ny < island[0].Length)
                        {
                            if (island[nx][ny] == 'X')
                            { 
                                Console.WriteLine("steps : {0}", minSteps  + 1);
                                return;
                            }
                            else if (island[nx][ny] == '0')
                            {
                                island[cur[0]][cur[1]] = 'V';
                                queue.Enqueue(new int[] { nx, ny });
                            }
                        }
                    }
                }
                minSteps++;
            }

            Console.WriteLine("No treasure found");
        }

        private static void LongestSubstring()
        {
            string a = "abdababc";
            string b = "abc";

            int m = a.Length;
            int n = b.Length;
            int maxLength = 0;
            int[][] cache = new int[m][];

            for (int i = 0; i < m; i++)
            {
                cache[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (a[i] == b[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            cache[i][j] = 1;
                        }
                        else
                            cache[i][j] = cache[i - 1][j - 1] + 1;

                        if (maxLength < cache[i][j])
                            maxLength = cache[i][j];
                    }
                }
            }

            Console.WriteLine(maxLength);
        }

        private static void MatrixProduct()
        {
            int[][] matrix = {
                new int[] {1,2,3},
                new int[] {4,5,6},
                new int[] {7,8,9}
            };

            int[][] minCache = new int[matrix.Length][];
            int[][] maxCache = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                minCache[i] = new int[matrix[i].Length];
                maxCache[i] = new int[matrix[i].Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == j)
                    {
                        minCache[i][j] = matrix[i][j];
                        maxCache[i][j] = matrix[i][j];
                        continue;
                    }

                    int maxVal = int.MinValue;
                    int minVal = int.MaxValue;

                    if (i > 0)
                    {
                        int tempMax = Math.Max(
                                matrix[i][j] * maxCache[i -1][j],
                                matrix[i][j] * minCache[i - 1][j]
                            );
                        maxVal = Math.Max(maxVal, tempMax);
                        int tempMin = Math.Min(
                                matrix[i][j] * maxCache[i - 1][j],
                                matrix[i][j] * minCache[i - 1][j]
                            );
                        minVal = Math.Min(minVal, tempMin);
                    }
                    if (j > 0)
                    {
                        int tempMax = Math.Max(
                                matrix[i][j] * maxCache[i][j - 1],
                                matrix[i][j] * minCache[i][j - 1]
                            );
                        maxVal = Math.Max(maxVal, tempMax);
                        int tempMin = Math.Min(
                                matrix[i][j] * maxCache[i][j - 1],
                                matrix[i][j] * minCache[i][j - 1]
                            );
                        minVal = Math.Min(minVal, tempMin);
                    }

                    maxCache[i][j] = maxVal;
                    minCache[i][j] = minVal;
                }
            }

            Console.WriteLine(maxCache[matrix.Length - 1][matrix[0].Length - 1]);
        }

        private static void RotateMatrix()
        {
            int[][] matrix = {
                new int[] { 11,12,13,14,15 },
                new int[] { 21,22,23,24,25 },
                new int[] { 31,32,33,34,35 },
                new int[] { 41,42,43,44,45 },
                new int[] { 51,52,53,54,55 },
            };

            int size = matrix.Length;

            if (matrix.Length != matrix[0].Length)
            {
                Console.WriteLine("Not a square matrix");
                return;
            }

            for (int layer = 0; layer < size / 2; layer++)
            {
                int first = layer;
                int last = size - 1 - layer; 

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    // clockwise
                    //int temp = matrix[first][i];
                    //matrix[first][i] = matrix[last - offset][first];
                    //matrix[last - offset][first] = matrix[last][last - offset];
                    //matrix[last][last - offset] = matrix[i][last];
                    //matrix[i][last] = temp;

                    // anti clockwise
                    int temp = matrix[first][i];
                    matrix[first][i] = matrix[i][last];
                    matrix[i][last] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[last - offset][first];
                    matrix[last - offset][first] = temp;
                }                
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static void SuggestedProducts()
        {
            string[] products = { }; 
            string searchWord = string.Empty;

            Trie trie = new Trie();

            Array.Sort(products);
            products.Max(x => x.Length);

            foreach (var product in products)
            {
                trie.Insert(product);
                
            }

            IList<IList<string>> result = new List<IList<string>>();

            for (int i = 0; i < searchWord.Length; i++)
            {
                result.Add(trie.Search(searchWord.Substring(0, i + 1)));
            }

            //return result;
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            if (products == null || searchWord == null) return null;

            IList<IList<string>> result = new List<IList<string>>();

            Array.Sort(products);
            int maxProductLength = 0;
            foreach (var product in products)
                if (product.Length > maxProductLength)
                    maxProductLength = product.Length;

            bool flag = true;
            for (int i = 0; i < searchWord.Length; i++)
            {
                List<string> temp = new List<string>();
                string prefix = searchWord.Substring(0, i + 1);
                int prefixLength = prefix.Length;
                int count = 0;

                foreach (var product in products)
                {
                    if (product.Length >= prefixLength)
                    {
                        if (product.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                        {
                            temp.Add(product);
                            count++;
                        }
                        if (count == 3) break;
                    }
                }

                result.Add(temp);
            }

            return result;
        }


        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
                return s == t;

            return IsSame(s, t) || (IsSubtree(s.left, t) || IsSubtree(s.right, t));

        }

        public bool IsSame(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
                return s == t;

            return (s.val != t.val) && (IsSame(s.left, t.left) && IsSame(s.right, t.right));

        }



        private static void SubTree()
        {
            TreeNode s = TreeNode.GetTree(new int[] { 1,2 });
            TreeNode t = TreeNode.GetTree(new int[] { 2 });

            StringBuilder ss = new StringBuilder();
            StringBuilder st = new StringBuilder();

            FlattenTree(s, ss);
            FlattenTree(t, st);

            string main = ss.ToString();
            string sub = st.ToString();

            Console.WriteLine(main.IndexOf(sub, StringComparison.InvariantCultureIgnoreCase) != -1);
        }

        private static void FlattenTree(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("{X}");
                return;
            }

            sb.Append($"{{{root.val}}}");
            FlattenTree(root.left, sb);
            FlattenTree(root.right, sb);

        }

        

        class LogData
        { 
            public string Identifier;
            public string Data;
            public bool IsDigitLog;

            public LogData(string logData)
            {
                int idx = logData.IndexOf(' ');
                Identifier = logData.Substring(0, idx);
                Data = logData.Substring(idx + 1);
                IsDigitLog = char.IsDigit(Data[0]);
            }

            public string GetLogData()
            {
                return Identifier + " " + Data;
            }
        }

        private static string[] ReorderLogFiles()
        {
            string[] logs = {
                "l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51",
                "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg",
                "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u",
                "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg",
                "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00",
                "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171",
                "0 81650258784962331", "t3df gjjn nxbrryos b"
            };

            int logLength = logs.Length;
            
            LogData[] allLogs = new LogData[logLength];
            for (int i = 0; i < logLength; i++)
            {                
                allLogs[i] = new LogData(logs[i]);
            }

            Array.Sort(allLogs, (l1, l2) => {

                if (l1.IsDigitLog ^ l2.IsDigitLog)
                {
                    int res = 1;
                    if (l1.IsDigitLog && !l2.IsDigitLog) res = 1;
                    else if (!l1.IsDigitLog && l2.IsDigitLog) res = -1;
                    else
                    {
                        var d1 = long.Parse(l1.Data.Split(' ')[1]);
                        var d2 = long.Parse(l2.Data.Split(' ')[1]);

                        res = (int)(d1 - d2);
                    }
                    return res;
                    //return l1.IsDigitLog ? 1 : -1;
                }
                else
                {
                    if (l1.IsDigitLog)
                    {
                        return 0;
                    }
                    else
                    {
                        int result = string.Compare(l1.Data, l2.Data);
                        if (result == 0)
                        {
                            result = string.Compare(l1.Identifier, l2.Identifier);
                        }

                        return result;
                    }
                }            
            });

            string[] res = new string[logLength];
            for (int i = 0; i<logLength; i++) {
                res[i] = allLogs[i].GetLogData();
            }

            Console.WriteLine(string.Join("\",\"", res));
            return res;
        }

        private static void ReorderLogFilesWorking()
        {
            //string[] logs = { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            //string[] logs = {
            //    "l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51",
            //    "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg",
            //    "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u",
            //    "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg",
            //    "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00",
            //    "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171",
            //    "0 81650258784962331", "t3df gjjn nxbrryos b"
            //};

            //string[] logs = { "1 n u", "r 527", "j 893", "6 14", "6 82" };
            string[] logs = { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo", "a2 act car" };
            
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            foreach (var log in logs)
            {
                var s = log.Split(' ');
                if (double.TryParse(s[1], out double a))
                {
                    digitLogs.Add(log);
                }
                else
                    letterLogs.Add(log);
            }

            var arr = letterLogs.ToArray();
            Array.Sort(arr, (x, y) =>
            {

                int idxX = x.IndexOf(' ');
                string first = x.Substring(idxX + 1);

                int idxY = y.IndexOf(' ');
                string second = y.Substring(idxY + 1);

                int result = string.Compare(first, second);

                if (result == 0)
                {
                    string identifier1 = x.Substring(0, idxX);
                    string identifier2 = y.Substring(0, idxY);
                    result = string.Compare(identifier1, identifier2);
                }

                return result;
            });


            string[] reorderLogs = new string[logs.Length];
            for (int i = 0; i < arr.Length; i++)
                reorderLogs[i] = arr[i];

            for (int i = 0; i < digitLogs.Count; i++)
                reorderLogs[arr.Length + i] = digitLogs[i];

            Console.WriteLine(string.Join(",",reorderLogs));
        }


        private static void ReorderLogFiles2()
        {
            //You have an array of logs.  Each log is a space delimited string of words.

            //For each log, the first word in each log is an alphanumeric identifier.Then, either:

            //Each word after the identifier will consist only of lowercase letters, or;
            //Each word after the identifier will consist only of digits.
            //We will call these two varieties of logs letter - logs and digit-logs.It is guaranteed that each log has at least one word after its identifier.

            //Reorder the logs so that all of the letter - logs come before any digit-log.
            //The letter - logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties.
            //The digit-logs should be put in their original order.

            //Return the final order of the logs.

            //Example 1:

            //Input: logs = ["dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"]
            //Output: ["let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6"]

            //string[] logs = { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            //string[] logs = {
            //    "l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51",
            //    "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg",
            //    "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u",
            //    "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg",
            //    "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00",
            //    "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171",
            //    "0 81650258784962331", "t3df gjjn nxbrryos b"
            //};

            //string[] logs = { "1 n u", "r 527", "j 893", "6 14", "6 82" };
            string[] logs = {"a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo","a2 act car"};

            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();
            Func<string, bool> isNumber = (data) =>
            {
                bool flag = false;

                for (int i = 0; i < data.Length; i++)
                {
                    if (!(flag = char.IsDigit(data[i])))
                        break;
                }

                return flag;
            };

            foreach (var log in logs)
            {
                var s = log.Split(' ');
                if (isNumber(s[1]))
                {
                    digitLogs.Add(log);
                }
                else
                    letterLogs.Add(log);
            }

            //letterLogs.OrderBy(x => x.Substring(x.IndexOf(' ') + 1)).ThenBy(x => x.Substring(0, x.IndexOf(' '))).Concat(digitLogs);
            //Console.WriteLine(string.Join(",", letterLogs.OrderBy(x => x.Substring(x.IndexOf(' ') + 1)).ThenBy(x => x.Substring(0, x.IndexOf(' '))).Concat(digitLogs)));

            var array = letterLogs.ToArray();
            //Array.Sort(array, new StringComparer());
            Array.Sort(array, (x, y) =>
            {
                int idxX = x.IndexOf(' ');
                string first = x.Substring(idxX + 1);

                int idxY = y.IndexOf(' ');
                string second = y.Substring(idxY + 1);

                int result = string.Compare(first, second);

                if (result == 0)
                {
                    string identifier1 = x.Substring(0, idxX);
                    string identifier2 = y.Substring(0, idxY);
                    result = string.Compare(identifier1, identifier2);
                }

                return result;
            });

            letterLogs = new List<string>(array);
            letterLogs.AddRange(digitLogs);

            string[] redorderLogs = new string[array.Length + digitLogs.Count];
            for (int i = 0; i < array.Length; i++)
            {
                redorderLogs[i] = array[i];
            }

            for (int i = 0; i < digitLogs.Count; i++)
                redorderLogs[array.Length + i] = digitLogs[i];

            Console.WriteLine(string.Join("\",\"", redorderLogs));
            //return letterLogs.AddRange(digitLogs);

        }

        private class StringComparer : IComparer<string>
        {
            public int Compare([AllowNull] string x, [AllowNull]

            string y)
            {
                int idxX = x.IndexOf(' ');
                string first = x.Substring(idxX + 1);

                int idxY = y.IndexOf(' ');
                string second = y.Substring(idxY + 1);

                int result = string.Compare(first, second);

                if (result == 0)
                {
                    string identifier1 = x.Substring(0, idxX);
                    string identifier2 = y.Substring(1, idxY);
                    result = string.Compare(identifier1, identifier2);
                }

                return result;
            }
        }

        private static void TopNCompetitors()
        {

            //If the frequency is the same, then we need to sort based on the occurrences of each toy in different quotes.
            //Ex: If both "Elmo" and "Elsa" are occurring 2 times, then we need to sort like this:
            //If Elmo appears in more quotes than Elsa does, then Elma gets the highest priority.
            //If both occur the same number of times in different quotes given, then we need to sort them alphabetically.

            //Still didn't get it? no problem, read this:
            //Ex:
            //quotes = [
            //"Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
            //"The new Elmo dolls are super high quality",
            //"Expect the Elsa dolls to be very popular this year, Elsa!",
            //"Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
            //"For parents of older kids, look into buying them a drone",
            //"Warcraft is slowly rising in popularity ahead of the holiday season"];

            //Elmo - 4
            //Elsa - 4
            //Elmo should be placed before Elsa in the result because Elmo appears in 3 different quotes and Elsa appears in 2 different quotes.




            int numToys = 6;
            int topToys = 2;
            String[] toys = { "elmo", "elsa", "legos", "drone", "tablet", "warcraft" };
            int numQuotes = 6;
            String[] quotes = {
            "Emo is the hottest of the season! Elmo will be on every kid's wishlist!",
            "The new Elmo dolls are super high quality",
            "Expect the Elsa dolls to be very popular this year",
            "Elsa and Elmo are the toys I'll be buying for my kids",
            "For parents of older kids, look into buying them a drone",
            "Warcraft is slowly rising in popularity ahead of the holiday season"};

            List<string> result = ReturnTopToys(numToys, topToys, toys, numQuotes, quotes);
            Console.WriteLine(string.Join(",", result));
        }

        private class WordFrequency
        {
            public int TotalCount = 0;
            public int QuoteCount = 0;
        }

        private static List<string> ReturnTopToys(int numToys, int topToys, string[] toys, int numQuotes, string[] quotes)
        {
            List<string> result = new List<string>();
            var toyFrequency = new Dictionary<string, WordFrequency>();

            foreach (var toy in toys)
                toyFrequency[toy.ToLower()] = new WordFrequency();

            WordFrequency wordFreq;
            foreach (var quote in quotes)
            {
                var quoteWords = quote.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool isNewQuote = true;
                foreach (var word in quoteWords)
                {
                    if (toyFrequency.TryGetValue(word, out wordFreq))
                    {
                        wordFreq.TotalCount += 1;

                        if (isNewQuote)
                        {
                            wordFreq.QuoteCount += 1;
                            isNewQuote = false;
                        }
                    }
                }
            }


            //If the value of topToys is more than the number of toys, return the names of only the toys mentioned in the quotes.
            //If toys are mentioned an equal number of times in quotes, sort alphabetically.
            if (topToys > toys.Length)
            {
                result.AddRange(
                     //toyFrequency.Where(x => x.Value.QuoteCount > 0).OrderByDescending(x => x.Value.TotalCount).ThenByDescending(x => x.Value.QuoteCount).OrderBy(x => x.Key).Select(x => x.Key)
                     toyFrequency.Where(x => x.Value.QuoteCount > 0).Select(x => x.Key)
                );
            }
            else
            {
                result.AddRange(
                    toyFrequency.OrderByDescending(x => x.Value.TotalCount).Take(topToys).OrderByDescending(x => x.Value.QuoteCount).OrderBy(x => x.Key).Select(x => x.Key)
                );
            }
            return result;
        }

        private static void FindPairWithSum()
        {
            //Given a list of positive integers nums and an int target, return indices of the two numbers such that they add up to a target -30.

            //Conditions:

            //You will pick exactly 2 numbers.
            //You cannot pick the same element twice.
            //If you have muliple pairs, select the pair with the largest number.
            //Example 1:

            //Input: nums = [1, 10, 25, 35, 60], target = 90
            //Output: [2, 3]
            //Explanation:
            //nums[2] + nums[3] = 25 + 35 = 60 = 90 - 30
            //Example 2:

            //Input: nums = [20, 50, 40, 25, 30, 10], target = 90
            //Output: [1, 5]
            //Explanation:
            //nums[0] + nums[2] = 20 + 40 = 60 = 90 - 30
            //nums[1] + nums[5] = 50 + 10 = 60 = 90 - 30
            //You should return the pair with the largest number.

            int[] nums = { 20, 50, 40, 25, 30, 10 };
            int target = 90;
            target = target - 30;

            var map = new Dictionary<int, int>();
            int[] result = { -1, -1 };
            int max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];

                if (map.ContainsKey(diff) && (nums[i] > max || diff > max))
                {
                    result[0] = map[diff];
                    result[1] = i;
                    max = Math.Max(diff, nums[i]);
                }
                else
                    map[nums[i]] = i;
            }

            Console.WriteLine($"{result[0]}, {result[1]}");
        }

        private static void OrangesRotting()
        {
            //In a given grid, each cell can have one of three values:

            //the value 0 representing an empty cell;
            //the value 1 representing a fresh orange;
            //the value 2 representing a rotten orange.
            //Every minute, any fresh orange that is adjacent(4 - directionally) to a rotten orange becomes rotten.

            //Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead.
            //Input: [[2, 1, 1],[1,1,0],[0,1,1]]
            //Output: 4
            //Input: [[2, 1, 1],[0,1,1],[1,0,1]]
            //Output: -1
            //Explanation:  The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.
            //Input: [[0,2]]
            //Output: 0
            //Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
            int[][] grid = {
                new int[] { 2, 1, 1},
                new int[] { 1,1,0 },
                new int[] { 0,1,1 }
            };

            Queue<int[]> rotten = new Queue<int[]>();

            int totalOranges = grid.Length * grid[0].Length;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0) totalOranges--;
                    else if (grid[i][j] == 2)
                    {
                        rotten.Enqueue(new int[] { i, j });
                    }
                }
            }

            int totalRotten = rotten.Count;
            int minutes = 0;
            int[][] directions = {
                new int[] {0,1}, //down
                new int[] {0,-1}, // up
                new int[] {1,0}, // right
                new int[] {-1,0}, // left
            };

            while (rotten.Any())
            {
                if (totalRotten == totalOranges)
                    break;
                int count = rotten.Count;
                for (int i = 0; i < count; i++)
                {
                    int[] curRotten = rotten.Dequeue();
                    foreach (var dir in directions)
                    {
                        int ni = curRotten[0] + dir[0];
                        int nj = curRotten[1] + dir[1];

                        if (ni >= 0 && ni < grid.Length &&
                            nj >= 0 && nj < grid[0].Length &&
                            grid[ni][nj] == 1)
                        {
                            totalRotten++;
                            grid[ni][nj] = 2;
                            rotten.Enqueue(new int[] { ni, nj });
                        }
                    }
                }

                minutes++;
            }

            Console.WriteLine(totalRotten == totalOranges ? minutes : -1);
        }

        private static void ZombieMatrix()
        {
            //Given a 2D grid, each cell is either a zombie 1 or a human 0.Zombies can turn adjacent(up / down / left / right) human beings into zombies every hour.
            //Find out how many hours does it take to infect all humans?
            //Input:
            //[[0, 1, 1, 0, 1],
            // [0, 1, 0, 1, 0],
            // [0, 0, 0, 0, 1],
            // [0, 1, 0, 0, 0]]

            int[][] matrix = {
                new int[] { 0, 1, 1, 0, 1 },
                new int[] { 0, 1, 0, 1, 0 },
                new int[] { 0, 0, 0, 0, 1 },
                new int[] { 0, 1, 0, 0, 0 },
            };


            int[][] directions = {
                new int[]{ 0, 1 }, // down
                new int[]{ 0, -1 }, // update
                new int[]{ 1, 0 }, // right
                new int[]{ -1, 0 } // left
            };


            Queue<int[]> zombieQ = new Queue<int[]>(); // Get all zombies
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 1)
                        zombieQ.Enqueue(new int[] { i, j });
                }
            }

            int totalCells = matrix.Length * matrix[0].Length;
            int zombieCount = zombieQ.Count;
            // if zombie count is zero or all are zombie, return zero
            if (zombieCount == 0 || zombieCount == totalCells)
            {
                Console.WriteLine(0);
                return;
            }


            int hour = 0;
            while (zombieQ.Any())
            {
                if (zombieCount == totalCells) break;

                int count = zombieQ.Count; // new zombies

                for (int i = 0; i < count; i++)
                {
                    var zb = zombieQ.Dequeue();
                    foreach (var dir in directions)
                    {
                        int ni = zb[0] + dir[0];
                        int nj = zb[1] + dir[1];

                        if (ni >= 0 && ni < matrix.Length &&
                            nj >= 0 && nj < matrix[0].Length &&
                            matrix[ni][nj] == 0)
                        {
                            zombieCount++; // increment zombiecount
                            matrix[ni][nj] = 1;
                            zombieQ.Enqueue(new int[] { ni, nj });
                        }
                    }
                }

                hour++; // increment hour
            }

            Console.WriteLine(hour);

        }

        private static void MoviesInFlight()
        {
            //Question:
            //You are on a flight and wanna watch two movies during this flight.
            //You are given List<Integer> movieDurations which includes all the movie durations.
            //You are also given the duration of the flight which is d in minutes.
            //Now, you need to pick two movies and the total duration of the two movies is less than or equal to(d - 30min).

            //Find the pair of movies with the longest total duration and return they indexes.If multiple found, return the pair with the longest movie.

            //Example 1:

            //Input: movieDurations = [90, 85, 75, 60, 120, 150, 125], d = 250
            //Output: [0, 6]
            //Explanation: movieDurations[0] + movieDurations[6] = 90 + 125 = 215 is the maximum number within 220(250min -30min)

            //int[] movieDurations = { 90, 85, 75, 60, 120, 150, 125 }; //[0, 6]
            //int[] movieDurations = { 90, 85, 75, 60, 155, 150, 125 }; //[3, 4]
            int[] movieDurations = { 90, 85, 75, 60, 120, 110, 110, 150, 125 }; //[5, 6] 
            int d = 250;
            int flightTotal = d - 30;

            if (movieDurations.Length < 2 || flightTotal < 0) return;

            var originalIndex = new Dictionary<int, List<int>>();
            for (int i = 0; i < movieDurations.Length; i++)
            {
                if (!originalIndex.ContainsKey(movieDurations[i]))
                    originalIndex[movieDurations[i]] = new List<int> { i };
                else
                    originalIndex[movieDurations[i]].Add(i); // handle duplicate movie length
            }

            int[] movies = { -1, -1 };
            int max = -1;
            Array.Sort<int>(movieDurations);

            int low = 0, high = movieDurations.Length - 1;
            while (low < high)
            {
                int movieTotal = movieDurations[low] + movieDurations[high];
                if (movieTotal <= flightTotal)
                {
                    if (movieTotal > max)
                    {
                        movies[0] = movieDurations[low];
                        movies[1] = movieDurations[high];
                        max = movieTotal;
                    }

                    low++;
                }
                else
                    high--;
            }

            movies[1] = originalIndex[movies[1]][movies[0] == movies[1] ? 1 : 0];
            movies[0] = originalIndex[movies[0]][0];


            Console.WriteLine($"[{movies[0]}, {movies[1]}]");
        }

        private static void CloneLinkedList()
        {
            LinkedList list = LinkedList.GetList(new int[] { 1, 2, 3, 4 });

            var newList = list.CloneList();

            Console.WriteLine(newList.Data);
        }

        #region QuickSort
        private static void QuickSort()
        {
            int[] arr = { 16, 3, 14, 9, 12, 7, 5, 1, 8 };
            Console.WriteLine(string.Join(",", arr));

            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(",", arr));
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high) return;

            int pivot = Partition(arr, low, high);
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot, high);
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];

            Action<int[], int, int> swap = (arr, i, j) =>
            {
                arr[i] ^= arr[j];
                arr[j] ^= arr[i];
                arr[i] ^= arr[j];
            };

            while (left <= right)
            {
                while (arr[left] < pivot) left++;

                while (arr[right] > pivot) right--;

                if (left <= right)
                {
                    swap(arr, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
        #endregion

        #region MergeSort
        private static void MergeSort()
        {
            int[] arr = { 8, 3, 17, 7, 14, 12, 29, 36, 25, 15, 37, 23, 13, 27, 62 };
            int[] temp = new int[arr.Length];
            MergeSort(arr, temp, 0, arr.Length - 1);
            Console.WriteLine(string.Join(",", arr));
        }

        private static void MergeSort(int[] arr, int[] temp, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(arr, temp, low, mid);
                MergeSort(arr, temp, mid + 1, high);
                Merge(arr, temp, low, high);
            }
        }

        private static void Merge(int[] arr, int[] temp, int low, int high)
        {
            int lowEnd = (low + high) / 2;
            int lowStart = low;
            int highStart = lowEnd + 1;
            int index = low;
            while (lowStart <= lowEnd && highStart <= high)
            {
                if (arr[lowStart] <= arr[highStart])
                    temp[index++] = arr[lowStart++];
                else
                    temp[index++] = arr[highStart++];
            }

            while (lowStart <= lowEnd)
                temp[index++] = arr[lowStart++];

            while (highStart <= high)
                temp[index++] = arr[highStart++];

            for (int i = low; i <= high; i++)
                arr[i] = temp[i];
        }
        #endregion

        #region Binary Search

        private static void BinarySearch()
        {
            int[] arr = { 3, 6, 8, 12, 14, 17, 25, 29, 31, 36, 42, 47, 53, 55, 62 };

            //BinarySearchIterative(arr, 0, arr.Length - 1, 53);
            BinarySearchRecursive(arr, 0, arr.Length - 1, 53);
        }

        private static void BinarySearchRecursive(int[] arr, int low, int high, int target)
        {
            if (low == high)
            {
                if (arr[low] == target)
                {
                    Console.WriteLine("found " + low);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
                return;
            }
            else
            {
                int mid = (low + high) / 2;
                if (arr[mid] > target)
                {
                    BinarySearchRecursive(arr, low, mid - 1, target);
                }
                else if (arr[mid] < target)
                {
                    BinarySearchRecursive(arr, mid + 1, high, target);
                }
                else
                {
                    Console.WriteLine($"found {mid}");
                }
            }
        }

        private static void BinarySearchIterative(int[] arr, int low, int high, int target)
        {
            if (low > high) return;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == target)
                {
                    Console.WriteLine("found index " + mid);
                    return;
                }
                if (arr[mid] > target)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            Console.WriteLine("Not found");
        }
        #endregion

        private static void LargestOneMatrix()
        {
            int[][] matrix = {
                new int[]{ 1,1,0,1,0 },
                new int[]{ 0,1,1,1,0 },
                new int[]{ 1,1,1,1,0 },
                new int[]{ 0,1,1,1,1 },
            };

            var clone = (int[][])matrix.Clone();

            int result = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (row == 0 || col == 0) continue;

                    if (clone[row][col] > 0)
                    {
                        clone[row][col] = 1 + Math.Min(clone[row - 1][col],
                                                Math.Min(clone[row][col - 1], clone[row - 1][col - 1]));
                    }
                    if (clone[row][col] > result) result = clone[row][col];
                }
            }
            Console.WriteLine(result);

            Console.ReadLine();
        }



        //1. Implement a method that takes a list of strings as input and returns list of strings that are anagrams of other strings in the input.

        //e.g.input - [book, kobo, rats, mart, tars, cart, arts]
        //output- [book, kobo, rats, tars, arts]
        private static void Anagrams()
        {
            string[] input = { "book", "kobo", "rats", "mart", "tars", "cart", "arts" };

            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                var s = new string(input[i]).ToCharArray();
                Array.Sort(s);
                string key = new string(s);
                if (result.ContainsKey(key))
                {
                    result[key].Add(input[i]);
                }
                else
                {
                    result[key] = new List<string>() { input[i] };
                }
            }

            var list = result.Values.Where(x => x.Count > 1).SelectMany(x => x);
            Console.WriteLine(string.Join(",", list));
        }



        private static void LargestRectangle()
        {
            int[] heights = { 2, 1, 5, 6, 2, 3 };
            int max = 0;
            int i = 0;
            Stack<int> stack = new Stack<int>();

            while (i < heights.Length)
            {
                // push index to stack, if the current height is >= previous height
                if (stack.Count == 0 || heights[i] >= heights[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    int index = stack.Pop();
                    int ht = heights[index];
                    int wd = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    max = Math.Max(max, ht * wd);
                }
            }

            while (stack.Count > 0)
            {
                int index = stack.Pop();
                int ht = heights[index];
                int wd = stack.Count == 0 ? i : i - stack.Peek() - 1;
                max = Math.Max(max, ht * wd);
            }

            Console.WriteLine(max);
        }

        private static void RangeSummary()
        {
            int[] arr = { 0, 1, 2, 4, 5, 6, 7 };

            int pre = arr[0];
            int first = pre;
            List<string> result = new List<string>();



            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == pre + 1)
                {
                    if (i == arr.Length - 1)
                    {
                        result.Add($"{first}->{arr[i]}");
                    }
                }
                else
                {
                    if (first == pre)
                    {
                        result.Add(first + "");
                    }
                    else
                    {
                        result.Add($"{first}->{pre}");
                    }

                    if (i == arr.Length - 1)
                        result.Add(arr[i] + "");

                    first = arr[i];
                }
                pre = arr[i];
            }

            Console.WriteLine(string.Join(",", result));
        }

        private static void MinCandies()
        {
            int[] ratings = { 1, 2, 1, 3, 4, 5, 1 };

            int[] candies = new int[ratings.Length];
            candies[0] = 1;
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
                else
                    candies[i] = 1;
            }

            int result = candies[ratings.Length - 1];

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                int curr = 1;
                if (ratings[i] > ratings[i + 1])
                {
                    curr = candies[i + 1] + 1;
                }
                result += Math.Max(curr, candies[i]);
                candies[i] = curr;
            }

            Console.WriteLine(result);
        }

        private static void ContainerWater()
        {
            int[] container = { 1, 2, 5, 4, 5, 2, 6 };

            int left = 0;
            int right = container.Length - 1;
            int volume = int.MinValue;
            while (left < right)
            {
                volume = Math.Max(volume,
                    (right - left) * (Math.Min(container[left], container[right])));

                if (container[left] > container[right]) right--;
                else left++;
            }
            Console.WriteLine(volume);
        }

        private static void MajorityElement()
        {
            int[] arr = { 1, 3, 3, 2, 4 };

            Array.Sort(arr);
            Console.WriteLine(arr[arr.Length / 2]);

            arr = new int[] { 1, 2, 3, 3, 4 };

            int count = 0;
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (count == 0)
                {
                    result = arr[i];
                    count = 1;
                }
                else if (result == arr[i]) count++;
                else
                {
                    count--;
                    result = arr[i];
                }
            }
            Console.WriteLine(result);
        }

        private static void LongestSequence()
        {
            int[] arr = { 2, 1, 6, 7, 9, 3, 4 };
            int longest = 0;
            HashSet<int> set = new HashSet<int>();

            foreach (var num in arr)
            {
                set.Add(num);
            }

            foreach (var num in set)
            {
                if (!set.Contains(num - 1))
                {
                    int curr = num, count = 1;
                    while (set.Contains(curr + 1))
                    {
                        curr++;
                        count++;
                    }
                    longest = Math.Max(longest, count);
                }
            }

            Console.WriteLine(longest);
        }





        private static void RectangleOverlap()
        {
            int left1 = 4, top1 = 3, right1 = 4, bottom1 = 1;
            int left2 = 2, top2 = 4, right2 = 5, bottom2 = 2;

            int left = Math.Max(left1, left2);
            int right = Math.Min(right1, right2);
            int top = Math.Min(top1, top2);
            int bottom = Math.Max(bottom1, bottom2);

            if (left >= right || top <= bottom) Console.WriteLine("No overlap");
            else
                Console.WriteLine($"left:{left}, top:{top}, right:{right}, bottom:{bottom}");
            Console.ReadLine();

        }

        private static void TwoMissingNumber()
        {
            int[] nums = { 1, 2, 3, 5, 7 };
            int size = nums.Length + 2;
            int totalSum = (size * (size + 1)) / 2;
            int arrSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                arrSum += nums[i];
            }

            int pivot = (totalSum - arrSum) / 2;
            int tl = 0, tr = 0, al = 0, ar = 0;
            for (int i = 1; i <= pivot; i++) tl ^= i;
            for (int i = pivot + 1; i <= size; i++) tr ^= i;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= pivot) al ^= nums[i];
                else ar ^= nums[i];
            }

            Console.WriteLine($"{tl ^ al}, {tr ^ ar}");
        }

        private static void OneMissingNumber()
        {
            int[] nums = { 1, 2, 3, 5 };
            int totalXOR = 0;
            int arrXOR = 0;

            for (int i = 0; i < nums.Length + 1; i++)
            {
                totalXOR ^= (i + 1);

                if (nums.Length > i)
                    arrXOR ^= nums[i];
            }

            Console.WriteLine(totalXOR ^ arrXOR);

        }

        private static void SingleNonDuplicate()
        {
            int[] nums = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 8, 8 };

            int single = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                single ^= nums[i];
            }
            Console.WriteLine(single);
            Console.ReadLine();
        }


        private static void PreorderTraversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(root);
            Tree curr;
            while (stack.Count > 0)
            {
                curr = stack.Pop();
                Console.WriteLine($"{curr.Value} ");
                if (curr.Right != null) stack.Push(curr.Right);
                if (curr.Left != null) stack.Push(curr.Left);
            }

        }

        private static void MorrisPreorderTraversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Tree curr = root;
            Tree prev = null;

            while (curr != null)
            {
                if (curr.Left == null)
                {
                    Console.WriteLine($"{curr.Value} ");
                    curr = curr.Right;
                }
                else
                {
                    prev = curr.Left;

                    while (prev.Right != null && prev.Right != curr)
                    {
                        prev = prev.Right;
                    }

                    if (prev.Right == null)
                    {
                        prev.Right = curr;
                        Console.WriteLine($"{curr.Value} ");
                        curr = curr.Left;
                    }
                    else
                    {
                        prev.Right = null;
                        curr = curr.Right;
                    }
                }

            }
        }

        private static void InorderTranversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Stack<Tree> stack = new Stack<Tree>();
            Tree curr = root;

            while (stack.Count > 0 | curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    Console.WriteLine($"{curr.Value} ");
                    curr = curr.Right;
                }
            }
        }

        private static void PostorderTraversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(root);
            Tree curr = null, prev = null;

            while (stack.Count > 0)
            {
                curr = stack.Peek();
                if (prev == null || prev.Left == curr || prev.Right == curr)
                {
                    if (curr.Left != null)
                    {
                        stack.Push(curr.Left);

                    }
                    else if (curr.Right != null)
                    {
                        stack.Push(curr.Right);
                    }
                    else
                    {
                        Console.WriteLine($"{curr.Value} ");
                        stack.Pop();
                    }
                }
                else if (curr.Left == prev)
                {
                    if (curr.Right != null) stack.Push(curr.Right);
                    else
                    {
                        Console.WriteLine($"{curr.Value} ");
                        stack.Pop();
                    }
                }
                else
                {
                    Console.WriteLine($"{curr.Value} ");
                    stack.Pop();
                }
            }

        }

        private static void DFSTraversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(root);
            Tree curr = null;
            int levelCount = 0;

            while (stack.Count > 0)
            {
                curr = stack.Pop();
                Console.Write($"{curr.Value} ");

                if (curr.Right != null) stack.Push(curr.Right);
                if (curr.Left != null) stack.Push(curr.Left);
            }
            Console.WriteLine();
        }

        private static void BFSTraversal()
        {
            Tree root = Tree.GetTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(root);
            Tree curr = null;
            int level = 0;
            int total = 0;
            int levelcount = 0;
            while (queue.Count > 0)
            {
                levelcount = queue.Count;
                level++;
                while (levelcount-- > 0)
                {
                    curr = queue.Dequeue();
                    //Console.Write($"{curr.Value} ");
                    if (level % 2 != 0) total += curr.Value;
                    if (curr.Left != null) queue.Enqueue(curr.Left);
                    if (curr.Right != null) queue.Enqueue(curr.Right);
                }
            }
            Console.WriteLine(total);
        }

        private static void MinHeap()
        {

            Heap minHeap = new Heap(3, false);
            for (int i = 0; i < 10; i++)
            {
                minHeap.AddItem(i);
            }
            minHeap.PrintHeap();

            minHeap.AddItem(6);
            minHeap.AddItem(2);
            minHeap.AddItem(4);
            minHeap.AddItem(3);
            minHeap.AddItem(5);
            minHeap.PrintHeap();
            minHeap.AddItem(1);
            minHeap.ExtractItem();
            minHeap.PrintHeap();
        }
    }
}

#region Helper Classes


public class Trie
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Childrens { get; set; }
        public bool IsEndOfWord { get; set; }
        public List<string> Words;

        public TrieNode()
        {
            this.Childrens = new Dictionary<char, TrieNode>();
            this.IsEndOfWord = false;
            this.Words = new List<string>();
        }
    }

    private TrieNode Root { get; set; }

    public Trie()
    {
        this.Root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode curr = Root;

        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];

            if (!curr.Childrens.TryGetValue(ch, out TrieNode child))
            {
                child = new TrieNode();
                curr.Childrens[ch] = child; 
            }

            curr = child;
            curr.Words.Add(word);
        }
        curr.IsEndOfWord = true;
    }

    public IList<string> Search(string word)
    {
        TrieNode curr = this.Root;

        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];
            if (!curr.Childrens.TryGetValue(ch, out TrieNode child))
            {
                return new List<string>();
            }
            curr = child;
        }

        return curr.Words;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }

    public static TreeNode GetTree(int[] arr)
    {
        return CreateTreeFromArray(arr, 0, arr.Length - 1);
    }

    private static TreeNode CreateTreeFromArray(int[] array, int start, int end)
    {
        if (end < start) return null;

        int mid = (start + end) / 2;

        TreeNode node = new TreeNode(array[mid]);
        node.left = CreateTreeFromArray(array, start, mid - 1);
        node.right = CreateTreeFromArray(array, mid + 1, end);

        return node;
    }
}

public class Tree
{
    public int Value { get; set; }
    public Tree Left { get; set; }
    public Tree Right { get; set; }

    public Tree(int value)
    {
        this.Value = value;
    }

    public static Tree GetTree(int[] arr)
    {
        return GetChild(arr, 0, arr.Length - 1);
    }

    private static Tree GetChild(int[] arr, int left, int right)
    {
        if (left > right)
            return null;

        int mid = (left + right) / 2;
        Tree root = new Tree(arr[mid]);
        root.Left = GetChild(arr, left, mid - 1);
        root.Right = GetChild(arr, mid + 1, right);

        return root;
    }
}

public class Graph
{
    public int Value { get; set; }
    public List<Graph> AdjacentNodes = new List<Graph>();
}

public class Heap
{
    private int _size;
    private int _capacity = 3;
    private bool _isMinHeap;

    private int[] _items;

    public Heap(int capacity = 3, bool isMinHeap = false)
    {
        _capacity = capacity;
        _isMinHeap = isMinHeap;
        _items = new int[_capacity];
    }

    public void PrintHeap()
    {
        Console.WriteLine(string.Join("->", this._items));
    }

    public int HeapTop()
    {
        if (_size == 0) return int.MinValue;
        return _items[0];
    }

    public void AddItem(int item)
    {
        if (_size == _capacity && !IsExtracted(item)) return;

        _items[_size] = item;
        _size++;
        HeapifyUp();
    }

    public int ExtractItem()
    {
        if (_size == 0) return int.MinValue;

        int item = _items[0];
        _items[0] = _items[_size - 1];
        _items[_size - 1] = -1;
        _size--;
        HeapifyDown();
        return item;
    }

    private void HeapifyDown()
    {
        int currIndex = 0; // root

        while (currIndex < _size)
        {
            int parent = currIndex;
            int left = (2 * parent) + 1;
            int right = (2 * parent) + 2;

            if (left < _size &&
                ((_isMinHeap && _items[left] < _items[parent]) ||
                 (!_isMinHeap && _items[left] > _items[parent])))
                parent = left;

            if (right < _size &&
                ((_isMinHeap && _items[right] < _items[parent]) ||
                 (!_isMinHeap && _items[right] > _items[parent])))
                parent = right;

            if (parent != currIndex)
            {
                SwapItems(parent, currIndex);
            }
            else
                break;

            currIndex = parent;
        }
    }

    private void HeapifyUp()
    {
        int currIndex = _size - 1;  // last item

        while (currIndex > 0)
        {
            int parentIndex = (currIndex - 1) / 2;
            if ((_isMinHeap && _items[parentIndex] > _items[currIndex]) ||
                (!_isMinHeap && _items[parentIndex] < _items[currIndex]))
            {
                SwapItems(parentIndex, currIndex);
            }
            else
                break;

            currIndex = parentIndex;
        }
    }

    private void SwapItems(int parentIndex, int currIndex)
    {
        _items[parentIndex] ^= _items[currIndex];
        _items[currIndex] ^= _items[parentIndex];
        _items[parentIndex] ^= _items[currIndex];
    }

    private bool IsExtracted(int item)
    {
        if ((_isMinHeap && HeapTop() < item) ||
            (!_isMinHeap && HeapTop() > item))
        {
            ExtractItem();
            return true;
        }

        return false;
    }
}

public class MinHeap
{
    public int _capacity = 0;
    public int _size = 0;
    public int[] _heap;

    public MinHeap(int capacity)
    {
        _capacity = capacity;
        _heap = new int[_capacity];
    }

    #region Public Methods
    public int Peek()
    {
        if (_size == 0) return -1;
        return _heap[0];
    }

    public void AddItem(int item)
    {
        if (_size == _capacity)
        {
            if (item < Peek())
                Extract();
            else
                return;
        }

        _heap[_size] = item;
        _size++;
        HeapifyUp();
    }

    public int Extract()
    {
        if (_size == 0) return -1;

        int value = _heap[0];
        _heap[0] = _heap[_size - 1];
        _heap[_size - 1] = -1;
        _size--;
        HeapifyDown();

        return value;

    }

    private void HeapifyDown()
    {
        int index = 0;

        while (index < _size)
        {
            int smaller = index;
            int left = GetChildIndex(smaller, true);
            int right = GetChildIndex(smaller, false);

            if (left < _size && _heap[left] < _heap[smaller]) smaller = left;
            if (right < _size && _heap[right] < _heap[smaller]) smaller = right;

            if (_heap[smaller] < _heap[index])
            {
                Swap(smaller, index);
            }
            else
                break;
            index = smaller;
        }
    }

    private void HeapifyUp()
    {
        int index = _size - 1;

        while (index > 0)
        {
            int parent = GetParentIndex(index);

            if (_heap[parent] > _heap[index])
            {
                Swap(parent, index);
            }
            else
            {
                break;
            }
            index = parent;
        }
    }

    private void Swap(int parent, int index)
    {
        _heap[parent] ^= _heap[index];
        _heap[index] ^= _heap[parent];
        _heap[parent] ^= _heap[index];
    }

    private int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) / 2;
    }

    private int GetChildIndex(int parentIndex, bool isLeftChild)
    {
        return (2 * parentIndex) + ((isLeftChild) ? 1 : 2);
    }

    #endregion
}

public class LinkedList
{
    public int Data { get; set; }
    public LinkedList Next;
    public LinkedList Random;

    public LinkedList(int data)
    {
        this.Data = data;
    }

    public LinkedList CloneList()
    {
        LinkedList curr = this;
        LinkedList root = new LinkedList(0);
        LinkedList head = root;

        var nodeMap = new Dictionary<int, LinkedList>();

        while (curr != null)
        {
            if (!nodeMap.ContainsKey(curr.Data))
                nodeMap.Add(curr.Data, new LinkedList(curr.Data));

            head.Next = nodeMap[curr.Data];

            if (!nodeMap.ContainsKey(curr.Random.Data))
                nodeMap.Add(curr.Random.Data, new LinkedList(curr.Random.Data));

            head.Next.Random = nodeMap[curr.Random.Data];

            curr = curr.Next;
            head = head.Next;
        }

        return root.Next;
    }

    public LinkedList CloneList(LinkedList old)
    {
        var curr = old;

        while (curr != null)
        {
            var temp = new LinkedList(curr.Data);
            temp.Next = curr.Next;
            curr.Next = temp;
            curr = curr.Next.Next;
        }

        curr = old;
        while (curr != null)
        {
            curr.Next.Random = curr.Random.Next;
            curr = curr.Next.Next;
        }

        var copy = old.Next;
        curr = old;
        while (curr.Next != null)
        {
            var temp = curr.Next;
            curr.Next = curr.Next.Next;
            curr = temp;
        }

        return copy;
    }

    public static LinkedList GetList(int[] arr)
    {
        LinkedList root = new LinkedList(0);
        Dictionary<int, LinkedList> dict = new Dictionary<int, LinkedList>();
        var head = root;
        for (int i = 0; i < arr.Length; i++)
        {
            LinkedList node = new LinkedList(arr[i]);
            head.Next = node;
            head = head.Next;
            dict.Add(node.Data, node);
        }

        dict[1].Random = dict[3];
        dict[2].Random = dict[1];
        dict[3].Random = dict[3];
        dict[4].Random = dict[2];

        return root.Next;
    }
}
#endregion

