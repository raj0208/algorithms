using System;
using System.Collections.Generic;
using System.Linq;

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
            //QuickSort();

            //ContainerWater();
            //MinCandies();
            //RangeSummary();
            //LargestRectangle();
            LargestOneMatrix();

            //CloneLinkedList();
        }

        private static void LargestOneMatrix()
        {
            int[][] matrix = {
                new int[]{ 1,1,0,1,0 },
                new int[]{ 0,1,1,1,0 },
                new int[]{ 1,1,1,1,0 },
                new int[]{ 0,1,1,1,1 },
            };

            var clone = (int[][]) matrix.Clone();

            int result = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (row == 0 || col == 0) continue;

                    if (clone[row][col] > 0) {
                        clone[row][col] = 1 + Math.Min(clone[row - 1][col],
                                                Math.Min(clone[row][col - 1], clone[row -1][col-1]));
                    }
                    if (clone[row][col] > result) result = clone[row][col];
                }
            }
            Console.WriteLine(result);
            
            Console.ReadLine();
        }

        private static void CloneLinkedList()
        {
            LinkedList list = LinkedList.GetList(new int[] { 1,2,3,4 });

            var newList = list.CloneList();

            Console.WriteLine(newList.Data);
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

        private static void QuickSort()
        {
            int[] arr = { 6,3,4,9,2,7,5,1,8 };
            Console.WriteLine(string.Join(",", arr));
            
            SortElements(arr, 0, arr.Length);
            Console.WriteLine(string.Join(",", arr));
        }

        private static void SortElements(int[] arr, int low, int high)
        {
            if (low >= high) return;
            int pivot = Partition(arr, low, high);
            SortElements(arr, low, pivot);
            SortElements(arr, pivot + 1, high);
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int i = low, j = high;
            int pivot = arr[low];

            Action<int[], int, int> swap = (arr, i, j) => {
                arr[i] ^= arr[j];
                arr[j] ^= arr[i];
                arr[i] ^= arr[j];
            };
                
            while (i < j)
            {
                do { i++; } while (arr[i] <= pivot);
                do { j--; } while (arr[j] > pivot);
                if (i < j)
                {
                    swap(arr, i, j);
                }
            }

            swap(arr, low, j);



            
            return j;
        }

        

        private static void RectangleOverlap()
        {
            int left1 =4, top1 = 3, right1 = 4, bottom1 = 1;
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

            Console.WriteLine($"{tl^al}, {tr^ar}");
        }

        private static void OneMissingNumber()
        {
            int[] nums = { 1,2,3,5 };
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
            Tree root = Tree.GetTree(new int[]{1,2,3,4,5,6,7,8,9});

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
            while(queue.Count > 0)
            {
                levelcount = queue.Count;
                level++;
                while(levelcount-- > 0)
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
        LinkedList root = new LinkedList(0);

        LinkedList curr = this;

        LinkedList head = root;

        Dictionary<int, LinkedList> newList = new Dictionary<int, LinkedList>();


        while (curr != null)
        {
            var temp = new LinkedList(curr.Data);
            newList.Add(curr.Data, temp);
            head.Next = temp;
            curr = curr.Next;
            head = head.Next;
        }

        curr = this;

        while (curr != null)
        {
            newList[curr.Data].Random = curr.Random;
            curr = curr.Next;
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

