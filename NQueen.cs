using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rnd
{
    class NQueen
    {
        public static void Solve()
        {

        }




        public NQueen(int queenCount = 4)
        {
            _queenCount = queenCount;
        }

        readonly int _queenCount;
 
        /* A utility function to print solution */
        private void PrintSolution(int[][] board)
        {
            for (int i = 0; i < _queenCount; i++)
            {
                for (int j = 0; j < _queenCount; j++)
                    Console.Write(" " + board[i][j]
                                        + " ");
                Console.WriteLine();
            }
        }
 
        /* A utility function to check if a queen can
           be placed on board[row][col]. Note that this
           function is called when "col" queens are already
           placeed in columns from 0 to col -1. So we need
           to check only left side for attacking queens */
        private bool IsSafe(int[][] board, int row, int col)
        {
            int i, j;
 
            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row][i] == 1)
                    return false;
 
            /* Check upper diagonal on left side */
            for (i=row, j=col; i>=0 && j>=0; i--, j--)
                if (board[i][j] == 1)
                    return false;
 
            /* Check lower diagonal on left side */
            for (i=row, j=col; j>=0 && i<_queenCount; i++, j--)
                if (board[i][j] == 1)
                    return false;
 
            return true;
        }
 
        /* A recursive utility function to solve N
           Queen problem */
        private bool SolveNQUtil(int[][] board, int col)
        {
            /* base case: If all queens are placed
               then return true */
            if (col >= _queenCount)
                return true;
 
            /* Consider this column and try placing
               this queen in all rows one by one */
            for (int i = 0; i < _queenCount; i++)
            {
                /* Check if queen can be placed on
                   board[i][col] */
                if (IsSafe(board, i, col))
                {
                    /* Place this queen in board[i][col] */
                    board[i][col] = 1;
 
                    /* recur to place rest of the queens */
                    if (SolveNQUtil(board, col + 1) == true)
                        return true;
 
                    /* If placing queen in board[i][col]
                       doesn't lead to a solution then
                       remove queen from board[i][col] */
                    board[i][col] = 0; // BACKTRACK
                }
            }
 
            /* If queen can not be place in any row in
               this colum col, then return false */
            return false;
        }
 

        public bool SolveNQ()
        {
            var board = new int[_queenCount][];

            // initialize
            for (int i = 0; i < _queenCount; i++)
            {
                board[i] = new int[_queenCount];
                for (int j = 0; j < _queenCount; j++)
                    board[i][j] = 0;
            }
            
            if (SolveNQUtil(board, 0) == false)
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }
 
            PrintSolution(board);
            return true;
        }
    }
}
