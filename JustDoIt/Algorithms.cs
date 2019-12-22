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
            BFSTraversal();
            //MinHeap();
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
            MinHeap minHeap = new MinHeap(3);

            minHeap.AddItem(6);
            minHeap.AddItem(2);
            minHeap.AddItem(4);
            Console.WriteLine(string.Join("->", minHeap._heap));
            Console.WriteLine(minHeap.Extract());
            minHeap.AddItem(3);
            minHeap.AddItem(5);
            Console.WriteLine(string.Join("->", minHeap._heap));
            Console.WriteLine(minHeap.Extract());
            minHeap.AddItem(1);
            Console.WriteLine(string.Join("->", minHeap._heap));
            Console.WriteLine(minHeap.Extract());
            Console.WriteLine(string.Join("->", minHeap._heap));
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

