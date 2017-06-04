using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    using Tree = LC.Tree;

    class DSA
    {
        public static void Run()
        {
            PreorderTraversal(Tree.GetTree());
            MorrisPreorderTraversal(Tree.GetTree());
            InorderTraversal(Tree.GetTree());
            PostorderTraversal(Tree.GetTree());
            
        }

        private static void PostorderTraversal(Tree root)
        {
            Console.WriteLine("\nPostorderTraversal");
            if (root == null) return;
            
            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(root);
            Tree prev = null;
            Tree curr = null;

            while (stack.Any())
            {
                curr = stack.Peek();

                if (prev == null || prev.left == curr || prev.right == curr)
                {
                    if (curr.left != null)
                        stack.Push(curr.left);
                    else if (curr.right != null)
                        stack.Push(curr.right);
                    else
                    {
                        Console.Write(curr.data + " ");
                        stack.Pop();
                    }
                }
                else if (curr.left == prev)
                {
                    if (curr.right != null)
                        stack.Push(curr.right);
                    else
                    {
                        Console.Write(curr.data + " ");
                        stack.Pop();
                    }
                }
                else if (curr.right == prev)
                {
                    Console.Write(curr.data + " ");
                    stack.Pop();
                }

                prev = curr;    
            }

        }

        private static void InorderTraversal(Tree root)
        {
            Console.WriteLine("\nInorderTraversal");
            if (root == null) return;

            Stack<Tree> stack = new Stack<Tree>();
            Tree curr = root;

            while (stack.Any() || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    curr = stack.Pop();
                    Console.Write(curr.data + " ");
                    curr = curr.right;
                }
            }
        }

        private static void PreorderTraversal(Tree root)
        {
            Console.WriteLine("\nPreorderTraversal");
            if (root == null) return;

            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(root);
            Tree curr = null;
            while (stack.Any())
            {
                curr = stack.Pop();
                Console.Write(curr.data + " ");

                if (curr.right != null) stack.Push(curr.right);
                if (curr.left != null) stack.Push(curr.left);
            }
        }

        private static void MorrisPreorderTraversal(Tree root)
        {
            Console.WriteLine("MorrisPreorderTraversal");

            if (root == null) return;

            Tree curr = root;
            Tree prev = null;
            while (curr != null)
            {
                if (curr.left == null)
                {
                    Console.Write(curr.data + " ");
                    curr = curr.right;
                }
                else
                {
                    prev = curr.left;

                    while (prev.right != null && prev.right != curr)
                        prev = prev.right;

                    if (prev.right == null)
                    {
                        prev.right = curr;
                        Console.Write(curr.data + " ");
                        curr = curr.left;
                    }
                    else {
                        prev.right = null;
                        curr = curr.right;
                    }
                }
            }
        }

        
    }
}
