using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        private int[,] array;

        public int[,] Array
        {
            get { return array; }
        }

        public Graph(int[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
        }

        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if(i > 0)
                    toReturn += Environment.NewLine;
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if(y > 0)
                        toReturn += " ";
                    toReturn += array[i, y].ToString();
                }
            }
            return toReturn;
        }
    }
}
