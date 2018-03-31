using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.LC;

namespace ConsoleApp
{
    class CTCI
    {
        internal static void Run()
        {
            var ctci = new CTCI();

            #region String/Array
            //ctci.IsUniqueChars();
            //ctci.PermutationOfPalindrome();
            //ctci.OneEditAway();
            //ctci.RotateMatrix(); 
            //ctci.SetZeros();
            #endregion

            #region LinkedList
            //ctci.ReturnKthToLast();
            //ctci.DeleteNode();
            //ctci.LoopDetection();
            //ctci.LinkIntersection();
            #endregion

            #region Stack & Queue
            //ctci.ThreeInOneStack();
            //ctci.MinStack();
            //ctci.QueueviaStack();
            //ctci.SortStack();
            //ctci.AnimalShelter();
            #endregion

            #region Tree & Graph
            // ctci.MinimalTreeWithSortedArray();
            //ctci.ListOfNodes();
            //ctci.IsBalancedTree();
            //ctci.BinarySearchTree();
            //ctci.SuccessorNode();
            ctci.SuccesorTreeNode();
            #endregion
        }

        private void SuccesorTreeNode()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            var tree = TreeNode.CreateTreeFromArray(array, 0, array.Length - 1);
            var root = TreeNode.GetNode(tree, 1);

            if (root == null) return;

            if (root.Right != null)
            {
                var node = root.Right;
                while (node.Left != null)
                    node = node.Left;
                Console.WriteLine(node.Data);
            }
            else
            {
                var current = root;
                var parent = current.Parent;

                while (parent != null && parent.Left != current) {
                    current = parent;
                    parent = parent.Parent;
                }

                if (parent != null)
                    Console.WriteLine(parent.Data);
                else
                    Console.WriteLine("no successor");
            }


        }

        private void SuccessorNode()
        {
            var array = new int[] { 1,2,3,4,5,6,7 };

            var tree = TreeNode.CreateTreeFromArray(array, 0, array.Length - 1);

            foreach (var item in array)
            {
                Console.WriteLine("============================");
                Console.WriteLine($"Node {item}");

                var root = TreeNode.GetNode(tree, item);

                if (root == null) Console.WriteLine("Successor found - Root");

                // Right node is not empty, traverse to get last left node from right node
                if (root.Right != null) 
                {
                    var temp = root.Right;
                    while (temp.Left != null)
                        temp = temp.Left;

                    Console.WriteLine("Successor found {0}", temp.Data);
                }
                else // Right node is empty, get parent
                {
                    var current = root;
                    var parent = current.Parent;

                    while (parent != null && current != parent.Left) {
                        current = parent;
                        parent = parent.Parent;
                    }

                    if (parent != null)
                        Console.WriteLine($"Successor found {parent.Data}");
                    else
                        Console.WriteLine("Successor found NULL");
                }
            }
        }

        #region Tree & Graph
        private void BinarySearchTree()
        {
            var root = Tree.GetTree();

            Console.WriteLine(CheckBST(root, null, null));
            var array = new int[] { 1, 2, 3, 4, 5, 6 };
            root = CreateTreeFromArray(array, 0, array.Length - 1);
            Console.WriteLine(CheckBST(root, null, null));
        }

        private bool CheckBST(Tree root, int? min, int? max)
        {
            if (root == null) return true;

            if ((min != null && root.data <= min.Value) || (max != null && root.data > max.Value)) 
            {
                return false;
            }

            if (!CheckBST(root.left, min, root.data) || !CheckBST(root.right, root.data, max)) {
                return false;
            }

            return true;
        }

        private void IsBalancedTree()
        {
            var array = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
            var root = CreateTreeFromArray(array, 0, array.Length - 1);

            if (CheckHeight(root) != int.MinValue)
            {
                Console.WriteLine("Tree is balanced");
            }
        }

        private int CheckHeight(Tree root)
        {
            if (root == null) return -1;

            int leftTree = CheckHeight(root.left);
            if (leftTree == int.MinValue) return int.MinValue;

            int rightTree = CheckHeight(root.right);
            if (rightTree == int.MinValue) return int.MinValue;

            int diff = Math.Abs(leftTree - rightTree);

            int value = (diff > 1) ? int.MinValue :
                                Math.Max(leftTree, rightTree) + 1;
            Console.WriteLine($"Node {root.data}: height {value}");
            return value;
        }
        
        private void ListOfNodes()
        {
            Tree root = CreateTreeFromArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 0, 14);
            ListOfNodes(root, true);
            ListOfNodes(root, false);
        }

        private void ListOfNodes(Tree root, bool isDepthFirstSearch)
        {
            Console.WriteLine("{0} First Search", isDepthFirstSearch ? "Depth" : "Breadth");
            
            List<LinkedList<Tree>> nodelist = new List<LinkedList<Tree>>();

            if (isDepthFirstSearch)
                CreateDFSLinkedListNodes(root, nodelist, 0);
            else
                CreateBFSLinkedListNodes(root, nodelist);

            int level = 1;
            foreach (var list in nodelist)
            {
                Console.WriteLine("Level : {0}", level++);
                Console.WriteLine(string.Join(",", list.Select(x => x.data)));
            }
        }

        private void CreateDFSLinkedListNodes(Tree root, List<LinkedList<Tree>> allNodeList, int level)
        {
            if (root == null) return;

            LinkedList<Tree> levelList;
            if (allNodeList.Count == level)
            {
                levelList = new LinkedList<Tree>();
                allNodeList.Add(levelList);
            }
            else
            {
                levelList = allNodeList[level];
            }
            levelList.AddLast(root);

            CreateDFSLinkedListNodes(root.left, allNodeList, level + 1);
            CreateDFSLinkedListNodes(root.right, allNodeList, level + 1);
        }

        private void CreateBFSLinkedListNodes(Tree root, List<LinkedList<Tree>> nodelist)
        {
            LinkedList<Tree> child = new LinkedList<Tree>();
            child.AddLast(root);

            while (child.Count > 0)
            {
                nodelist.Add(child);
                LinkedList<Tree> parent = child;
                child = new LinkedList<Tree>();

                foreach (var node in parent)
                {
                    if (node.left != null) child.AddLast(node.left);
                    if (node.right != null) child.AddLast(node.right);
                }
            }
        }

        private void MinimalTreeWithSortedArray()
        {
            int[] array = new int[] { 1,2,3,4,5,6,7,8,9,10} ;

            Tree tree = CreateTreeFromArray(array, 0, array.Length - 1);
        }

        private Tree CreateTreeFromArray(int[] array, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end) / 2;

            Tree node = new Tree(array[mid]);
            node.left = CreateTreeFromArray(array, start, mid - 1);
            node.right = CreateTreeFromArray(array, mid + 1, end);

            return node;
        }
        #endregion

        #region Stack & Queue
        private void AnimalShelter()
        {
            AnimalShelter ani = new ConsoleApp.AnimalShelter();
            ani.Enqueue(new Dog("Dog1"));
            ani.Enqueue(new Cat("Cat1"));
            ani.Enqueue(new Dog("Dog2"));
            ani.Enqueue(new Cat("Cat2"));
            ani.Enqueue(new Dog("Dog3"));
            ani.Enqueue(new Cat("Cat3"));
            ani.Enqueue(new Cat("Cat4"));
            ani.Enqueue(new Dog("Dog4"));

            Console.WriteLine(ani.Size());
            Console.WriteLine(ani.DequeueAny().Name);
            Console.WriteLine(ani.DequeueDog().Name);
            Console.WriteLine(ani.DequeueCat().Name);
            Console.WriteLine(ani.DequeueDog().Name);
            Console.WriteLine(ani.DequeueCat().Name);
            Console.WriteLine(ani.DequeueAny().Name);
            Console.WriteLine(ani.DequeueAny().Name);
            Console.WriteLine(ani.DequeueAny().Name);
            Console.WriteLine(ani.Size());
        }

        private void SortStack()
        {
            Stack<int> stack = new Stack<int>();

            new List<int> { 5,7,10,2,4,1 }.ForEach(x => stack.Push(x));

            Stack<int> temp = new Stack<int>();
            while (stack.Count > 0)
            {
                int value = stack.Pop();

                while (temp.Count > 0 && value < temp.Peek()) {
                    stack.Push(temp.Pop());
                }
                temp.Push(value);
            }

            while (temp.Count > 0) stack.Push(temp.Pop());

            Console.WriteLine("{0}", string.Join(",", stack.ToList()));
        }

        private void QueueviaStack()
        {
            QueueviaStack<int> queue = new QueueviaStack<int>();
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);
            Console.WriteLine(queue.Remove());
            Console.WriteLine(queue.Remove());
            queue.Add(3);
            queue.Add(4);
            queue.Add(5);
            Console.WriteLine(queue.Size());
        }

        private void MinStack()
        {
            MinStack stack = new MinStack();

            stack.Push(5);
            stack.Push(3);
            stack.Push(2);
            stack.Push(6);
            stack.Push(1);
            Console.WriteLine(stack.Min());
            stack.Pop();
            stack.Pop();
            
            Console.WriteLine(stack.Min());
            Console.WriteLine(stack.Min());
        }

        private void ThreeInOneStack()
        {
            ThreeInOneStack tios = new ThreeInOneStack(3);

            tios.Push(0, 11);
            tios.Push(0, 12);
            tios.Push(0, 13);
            tios.Push(1, 21);
            tios.Push(1, 22);
            tios.Push(2, 31);
            tios.Push(2, 32);
            tios.Push(2, 33);
            try
            {
                tios.Push(0, 14);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(tios.Pop(0));
            Console.WriteLine(tios.Pop(0));
            Console.WriteLine(tios.Pop(0));
            Console.WriteLine(tios.Pop(1));
            Console.WriteLine(tios.Pop(1));
            Console.WriteLine(tios.Pop(2));
            try
            {
                Console.WriteLine(tios.Pop(1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } 
        #endregion

        #region LinkedList
        private void LinkIntersection()
        {
            var list1 = LinkedNode.GetLinkedNodes(new int[] { 1, 2, 3, 4});
            var list2 = LinkedNode.GetLinkedNodes(new int[] { 11, 12 });
            bool flag = true;
            for (int i = 5; i < 9; i++)
            {
                var node = new LinkedNode(i);
                list1.Append(node);
                if (flag)
                {
                    flag = false;
                    list2.Append(node);
                }
            }
            list1.Print();
            list2.Print();
            int size1, size2;
            var tail1 = GetTailAndSize(list1, out size1);
            var tail2 = GetTailAndSize(list2, out size2);

            if (tail1 != tail2 && tail1 != null) {
                Console.WriteLine("No intersection");
                return;
            }

            int diff = Math.Abs(size1 - size2);

            tail1 = (size1 > size2) ? list1 : list2;
            tail2 = (size1 > size2) ? list2 : list1;

            while (diff-- > 0) {
                tail1 = tail1.Next;
            }

            while (tail1 != tail2) {
                tail1 = tail1.Next;
                tail2 = tail2.Next;
            }

            Console.WriteLine("Intersection point : {0}", tail1.Value);
        }

        private LinkedNode GetTailAndSize(LinkedNode one, out int size) {
            size = 0;
            LinkedNode node = one;
            if (node == null) return node;
            size = 1;
            while (node.Next != null) {
                size++;
                node = node.Next;
            }

            return node;
        }

        private void LoopDetection()
        {
            var list = LinkedNode.GetLinkedNodes(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            list.LastNode().Next = list.NthNode(5);

            var slow = list;
            var fast = list;

            while (fast != null && fast.Next != null) {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (slow == fast) break; //collision
            }

            if (fast == null || fast.Next == null) Console.WriteLine("No collision");

            slow = list;
            while (slow != fast) {
                slow = slow.Next;
                fast = fast.Next;
            }

            Console.WriteLine("collision at {0}",slow.Value);
        }

        private void ReturnKthToLast()
        {
            Console.WriteLine("ReturnKthToLast");
            var list = LinkedNode.GetLinkedNodes(new int[] { 1, 2, 3, 4, 5 });
            int kthToLast = 2; // node 4

            var fast = list;
            while (kthToLast-- > 0 && fast != null) {
                fast = fast.Next;
            }

            var slow = list;
            while (slow != null && fast != null) {
                slow = slow.Next;
                fast = fast.Next;
            }

            if (slow != null)
                Console.WriteLine(slow.Value);
            else
                Console.WriteLine("Not available");
        }

        private void DeleteNode()
        {
            var list = LinkedNode.GetLinkedNodes(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Before");
            list.Print();
            deleteNode(list.Next.Next);
            
            Console.WriteLine("After");
            list.Print();
        }

        bool deleteNode(LinkedNode n)
        {
            if (n == null || n.Next == null)
            {
                return false;
            }
            LinkedNode next = n.Next;
            n.Value = next.Value;
            n.Next = next.Next;
            return true;
        } 
        #endregion

        #region Strings/Array
        private void SetZeros()
        {
            int[][] matrix = new int[][] {
                new int[] { 1, 2, 0, 4, 5 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 0, 3, 4, 5 },
                new int[] { 1, 2, 3, 0, 5 }
            };

            bool hasRowZero = false, hasColZero = false;
            int rowCount = 4; // matrix.GetUpperBound(0) - matrix.GetLowerBound(0) + 1;
            int colCount = 5; // matrix[0].GetUpperBound(1) - matrix[0].GetLowerBound(1) + 1;

            for (int i = 0; i < rowCount; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (matrix[i][0] == 0)
                {
                    hasRowZero = true;
                    break;
                }
            }

            for (int i = 0; i < colCount; i++)
            {
                if (matrix[0][i] == 0)
                {
                    hasColZero = true;
                    break;
                }
            }

            for (int i = 1; i < rowCount; i++)
            {
                for (int j = 1; j < colCount; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // nullify rows
            for (int i = 0; i < rowCount; i++)
            {
                if (matrix[i][0] == 0)
                    nullifyRow(matrix, i, colCount);
            }

            // nullify columns
            for (int i = 0; i < colCount; i++)
            {
                if (matrix[0][i] == 0)
                    nullifyColumn(matrix, i, rowCount);
            }

            // nullify first row
            if (hasRowZero)
                nullifyRow(matrix, 0, rowCount);

            // nullify first column
            if (hasColZero)
                nullifyColumn(matrix, 0, colCount);

            for (int i = 0; i < rowCount; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private void nullifyColumn(int[][] matrix, int col, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
                matrix[i][col] = 0;
        }

        private void nullifyRow(int[][] matrix, int row, int colCount)
        {
            for (int i = 0; i < colCount; i++)
                matrix[row][i] = 0;
        }

        private void RotateMatrix()
        {
            var matrix = new int[4, 4] {
                {1,2,3,4 },
                {12,13,14,5 },
                {11,16,15,6 },
                {10,9,8,7 },
            };

            int n = 4;
            int first;
            int last;
            int offset;
            for (int layer = 0; layer < n / 2; layer++)
            {
                first = layer; //0
                last = n - 1 - layer; //4-1-0 = 3
                for (int i = first; i < last; i++)
                {
                    offset = i - first;
                    int top = matrix[first, i];

                    //top = left
                    matrix[first, i] = matrix[last - offset, first];
                    //left = bottom;
                    matrix[last - offset, first] = matrix[last, last - offset];
                    //bottom = right
                    matrix[last, last - offset] = matrix[i, last];
                    //right = top
                    matrix[i, last] = top;
                }
            }
        }

        private void OneEditAway()
        {
            string one = "bale";
            string two = "pale";

            if (Math.Abs(one.Length - two.Length) > 1)
            {
                Console.WriteLine("Not one edit away");
                return;
            }

            string shorter = one.Length < two.Length ? one : two;
            string longer = one.Length < two.Length ? two : one;
            bool found = false;
            int index1 = 0, index2 = 0;
            while (index1 < shorter.Length && index2 <= longer.Length)
            {
                if (shorter[index1] != longer[index2])
                {
                    if (found)
                    {
                        Console.WriteLine("Not one edit away");
                        return;
                    }
                    found = true;

                    if (shorter.Length == longer.Length)
                        index1++;
                }
                else
                    index1++;

                index2++;
            }

            Console.WriteLine("One Edit Away");
        }

        private void IsUniqueChars()
        {
            string s = "the quick brown jumps over the lazy dog";

            int checker = 0;
            int value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                value = Char.ToLower(s[i]) - 'a';

                if ((checker & (1 << value)) > 0)
                {
                    Console.WriteLine("not unique {0}", s[i]);
                    break;
                }

                checker |= (1 << value);
            }

            Console.WriteLine("unique");
        }

        private void PermutationOfPalindrome()
        {
            string phrase = "race car";

            int[] table = new int['z' - 'a' + 1];
            int count = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (Char.IsLetter(phrase[i]))
                {
                    int x = Char.ToLower(phrase[i]) - 'a';
                    table[x]++;

                    if (table[x] % 2 == 1)
                        count++;
                    else
                        count--;
                }
            }

            Console.WriteLine("Result : {0}", (count <= 1));
        }
        #endregion

        #region Maths
        static void Add(int x, int y)
        {
            int carry = 0;
            while (y != 0)
            {
                carry = x & y;
                x = x ^ y;
                y = carry << 1;
            }

            Console.WriteLine($"Sum is {x}");
        }

        static void Subtract(int x, int y)
        {
            int carry = 0;
            do
            {
                carry = ~x & y;
                x = x ^ y;
                y = carry << 1;

            } while (carry != 0);

            Console.WriteLine($"Result is {x}");
        }
        #endregion
    }

    #region Classes
    class ThreeInOneStack
    {
        private int stackCount = 3;
        private int stackCapacity;
        private int[] stackValues;
        private int[] size;

        public ThreeInOneStack(int stackCapacity)
        {
            this.stackCapacity = stackCapacity;
            size = new int[stackCount];
            stackValues = new int[stackCapacity * stackCount];
        }

        public void Push(int stackIndex, int value)
        {
            if (IsFull(stackIndex)) throw new Exception("Stack is full");

            stackValues[GetTop(stackIndex)] = value;
            size[stackIndex]++;
        }

        public int Pop(int stackIndex)
        {
            if (IsEmpty(stackIndex))
                throw new Exception("Stack is empty");

            int top = GetTop(stackIndex) - 1;
            int value = stackValues[top];
            stackValues[top] = 0;
            size[stackIndex]--;
            return value;
        }

        public int Peek(int stackIndex)
        {
            if (IsEmpty(stackIndex))
                throw new Exception("Stack is empty");
            int top = GetTop(stackIndex);
            return stackValues[top];

        }

        public bool IsEmpty(int stackIndex)
        {
            if (!IsValidStackIndex(stackIndex)) throw new Exception("Stack Index out of range");
            return size[stackIndex] == 0;
        }

        public bool IsFull(int stackIndex)
        {
            if (!IsValidStackIndex(stackIndex)) throw new Exception("Stack Index out of range");
            return size[stackIndex] == stackCapacity;
        }

        private bool IsValidStackIndex(int stackIndex)
        {
            return (stackIndex >= 0 || stackIndex < stackCount);
        }

        private int GetTop(int stackIndex)
        {
            int offset = stackCapacity * stackIndex;
            return size[stackIndex] + offset;
        }
    }

    class MinStack : Stack<int>
    {
        private Stack<int> _minStack = new Stack<int>();

        public void Push(int value)
        {
            if (value <= this.Min())
                _minStack.Push(value);

            base.Push(value);
        }

        public int Pop()
        {
            int value = base.Pop();
            if (value == this.Min())
                _minStack.Pop();

            return value;
        }

        public int Peek()
        {
            return base.Peek();
        }

        public int Min()
        {
            return (_minStack.Count == 0) ? int.MaxValue : _minStack.Peek();
        }
    }

    class QueueviaStack<T>
    {
        private Stack<T> _newest;
        private Stack<T> _oldest;

        public QueueviaStack()
        {
            _newest = new Stack<T>();
            _oldest = new Stack<T>();
        }

        public void Add(T value)
        {
            _newest.Push(value);
        }

        public T Remove()
        {
            UpdateOldestStack();
            return _oldest.Pop();
        }

        public T Peek()
        {
            UpdateOldestStack();
            return _oldest.Peek();
        }

        public int Size()
        {
            return _newest.Count + _oldest.Count;
        }

        private void UpdateOldestStack()
        {
            if (_oldest.Count == 0)
            {
                while (_newest.Count > 0)
                {
                    _oldest.Push(_newest.Pop());
                }
            }
        }
    }

    abstract class Animal
    {
        public int Order { get; set; }
        public string Name { get; set; }

        public bool IsOlder(Animal animal)
        {
            return this.Order < animal.Order;
        }
    }

    class Dog : Animal
    {
        public Dog(string name)
        {
            this.Name = name;
        }
    }

    class Cat : Animal
    {
        public Cat(string name)
        {
            this.Name = name;
        }
    }

    class AnimalShelter {
        Queue<Dog> dogs = new Queue<Dog>();
        Queue<Cat> cats = new Queue<Cat>();
        int _order = 1;

        public void Enqueue(Animal animal)
        {
            animal.Order = _order++;

            if (animal is Dog) dogs.Enqueue(animal as Dog);
            else if (animal is Cat) cats.Enqueue(animal as Cat);
        }

        public int Size()
        {
            return dogs.Count + cats.Count;
        }

        public Animal DequeueAny()
        {
            if (dogs.Count == 0) return this.DequeueCat();

            if (cats.Count == 0) return this.DequeueDog();

            var dog = dogs.Peek();
            var cat = cats.Peek();

            if (dog.IsOlder(cat)) return DequeueDog();
            else return DequeueCat();
        }

        public Dog DequeueDog()
        {
            return (dogs.Count > 0) ? dogs.Dequeue() : null;
        }

        public Cat DequeueCat()
        {
            return (cats.Count > 0) ? cats.Dequeue() : null;
        }
    }

    class Graph {
        public GraphNode[] Nodes ;

        public static Graph GetGraph() {
            Graph graph = new Graph();

            var start = new GraphNode[1];
            start[0] = new GraphNode();
            start[0].Name = "Start";
            start[0].Childrens = new GraphNode[3];
            

            graph.Nodes = start;
            return graph;
        }

    }

    class GraphNode
    {
        public string Name { get; set; }
        public bool IsVisited { get; set; }
        public GraphNode[] Childrens { get; set; }
    }

    class TreeNode {
        public TreeNode Parent;
        public int Data;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int data)
        {
            this.Data = data;
        }

        public static TreeNode CreateTreeFromArray(int[] array, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end) / 2;

            TreeNode node = new TreeNode(array[mid]);

            node.Left = CreateTreeFromArray(array, start, mid - 1);
            if (node.Left != null) node.Left.Parent = node;

            node.Right = CreateTreeFromArray(array, mid + 1, end);
            if (node.Right != null) node.Right.Parent = node;

            return node;
        }

        public static TreeNode GetNode(TreeNode root, int data)
        {
            if (root != null && root.Data == data)  return root;

            if (root == null) return null;

            return (root.Data > data) ? GetNode(root.Left, data) : GetNode(root.Right, data);
        }
    }
    #endregion
}
