using System;
using System.Collections.Generic;

namespace JustDoIt
{
    public class ClosestPoints
    {
        public void Run()
        {
            //[[1,3],[-2,2]], K = 1
            //Output: [[-2, 2]]
            //Input: points = [[3,3],[5,-1],[-2,4]], K = 2
            //Output: [[3,3],[-2,4]]

            //int[][] input = {
            //    new int[] { 1,3 },
            //    new int[] { -2, 2 }
            //};
            //int K = 1;
            int[][] input = {
                new int[] { 2, 2 },
                new int[] { 2, 2 },
                new int[] { 2, 2 },
                new int[] { 2, 2 },
                new int[] { 2, 2 },
                new int[] { 2, 2 },
                new int[] { 1, 1 },
                new int[] { 1, 1 }
            };
            int K = 4;

            var result = KClosest(input, K);

            foreach (var item in result)
            {
                Console.WriteLine("[" + string.Join(",", item) + "]");
            }
        }

        public int[][] KClosest(int[][] points, int K)
        {
            MinHeapPoints heap = new MinHeapPoints(K);
            for (int i = 0; i < points.Length; i++)
            {
                heap.Add(points[i]);
            }

            int[][] result = new int[K][];
            int index = 0;
            while (index < K)
            {
                result[index++] = heap.Remove().Point;
            }

            return result;
        }
    }
}

public class PointNode
{
    public int[] Point;
    public double Value;

    public PointNode(int[] point)
    {
        Point = point;
        Value = Math.Sqrt((point[0] * point[0]) + (point[1] * point[1]));
    }
}

public class MinHeapPoints
{
    private int size = 0;
    private int capacity = 3;
    private PointNode[] heap;

    public MinHeapPoints(int capacity)
    {
        this.capacity = capacity;
        this.heap = new PointNode[capacity];
    }

    public void Add(int[] item)
    {
        var pt = new PointNode(item);
        if (size == capacity)
        {
            if (Peek().Value > pt.Value)
                Remove();
            else
                return;
        }

        heap[size] = pt;
        size++;
        HeapifyUp();
    }

    public PointNode Remove()
    {
        if (size == 0) return null;

        var item = heap[0];
        heap[0] = heap[size - 1];
        heap[size - 1] = null;
        size--;
        HeapifyDown();
        return item;
    }

    public PointNode Peek()
    {
        if (size == 0) return null;
        return heap[0];
    }

    private void Swap(int index1, int index2)
    {
        var temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }

    private void HeapifyUp()
    {
        int currIndex = size - 1;

        while (currIndex > 0)
        {
            int parent = (currIndex - 1) / 2;
            if (heap[currIndex].Value > heap[parent].Value)
                Swap(parent, currIndex);
            else
                break;

            currIndex = parent;
        }
    }

    private void HeapifyDown()
    {
        int index = 0;

        while (index < size)
        {
            int parent = index;
            int left = (2 * parent) + 1;
            int right = left + 1;

            if (left < size && heap[left].Value > heap[parent].Value) parent = left;
            if (right < size && heap[right].Value > heap[parent].Value) parent = right;

            if (parent != index)
                Swap(parent, index);
            else
                break;

            index = parent;
        }
    }
}

