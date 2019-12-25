using System;
using System.Collections.Generic;
//using System.Linq;

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
            RectangleOverlap();
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
#endregion

