using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphArrayGenerator
    {
        Random randomProvider = new Random();

        public int[,] Generate(int size)
        {
            int[,] graphArray = new int[size, size];
            Fill(graphArray);
            return graphArray;
        }

        private void Fill(int[,] graphArray)
        {
            if (graphArray == null)
                throw new ArgumentNullException();

            int size = graphArray.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = (i + 1); j < size; j++)
                {
                    graphArray[i, j] = randomProvider.Next(0, 2);
                    graphArray[j, i] = graphArray[i, j];
                }
            } 
        }

        public int[,] GenerateConcurrently(int size)
        {
            int[,] graphArray = new int[size, size];
            FillConcurrently(graphArray);
            return graphArray;
        }

        private void FillConcurrently(int[,] graphArray)
        {
            if (graphArray == null)
                throw new ArgumentNullException();

            int size = graphArray.GetLength(0);
            Parallel.For(0, size, i =>
            {
                Parallel.For(i + 1, size, j =>
                {
                    graphArray[i, j] = randomProvider.Next(0, 2);
                    graphArray[j, i] = graphArray[i, j];
                });
            });
        }
    }
}
