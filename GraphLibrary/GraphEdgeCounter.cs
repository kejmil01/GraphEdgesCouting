using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Graphs
{
    public class GraphEdgeCounter
    {
        private Graph graph;

        [ThreadStatic]
        private int result = 0;
        [ThreadStatic]
        private Thread[] threadArray = null;
        
        public GraphEdgeCounter(Graph graph)
        {
            if (graph == null)
                throw new ArgumentNullException();
            this.graph = graph;
            InitializeThreadArray();
            InitializeThreads();
        }

        private void InitializeThreadArray()
        {
            int sizeOfArray = graph.Array.GetLength(0);
            threadArray = new Thread[sizeOfArray];
        }

        private void InitializeThreads()
        {
            object _lock = new object();
            for (int i = 0; i < threadArray.Length; i++)
            {
                int numberOfRow = i;
                threadArray[i] = new Thread(delegate()
                {
                    int numberOfEdgesInRow = CountEdgesInGraphArrayRow(graph.Array, numberOfRow);
                    lock (_lock)
                    {
                        result += numberOfEdgesInRow;
                    }

                });
            }
        }

        public int Count()
        {
            result = 0;

            for (int i = 0; i < graph.Array.GetLength(0); i++)
            {
                result += CountEdgesInGraphArrayRow(graph.Array, i);
            }
            return result;
        }

        public int CountConcurrently()
        {
            result = 0;

            StartThreads();
            WaitForResult();
            return result;
        }

        private void StartThreads()
        {
            foreach (Thread t in threadArray)
                t.Start();
        }

        private void WaitForResult()
        {
            foreach (Thread t in threadArray)
                t.Join();
        }

        private int CountEdgesInGraphArrayRow(int[,] array, int numberOfRow)
        {
            int numberOfEdgesInRow = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (GraphHasConnectionBetween(array, numberOfRow, i))
                    numberOfEdgesInRow++;
            }
            return numberOfEdgesInRow;
        }

        private bool GraphHasConnectionBetween(
            int[,] array,
            int numberOfFirstVertex,
            int numberOfSecondVertex)
        {
            if (array[numberOfFirstVertex, numberOfSecondVertex] == 1)
                return true;
            return false;
        }
    }
}
