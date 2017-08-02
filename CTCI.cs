﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ctci.MinStack();
            #endregion
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

        #region Stack & Queue
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
    }

    class ThreeInOneStack {
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

    class MinStack : Stack<int> {
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
}
