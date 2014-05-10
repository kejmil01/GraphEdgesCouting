using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Graphs
{
    [TestFixture]
    class GraphTests
    {
        [Test]
        public void ReturnsGraphObjectWhenPassingArrayToConstructor()
        {
            int[,] array = { { 0, 1 }, { 1, 0 } };
            Graph graph = new Graph(array);

            Assert.NotNull(graph);
            Assert.AreEqual(array, graph.Array);
        }

        [Test]
        public void ReturnsValidString()
        {         
            int[,] array = {{0, 1}, {1, 0}};
            Graph graph = new Graph(array);

            string expectedString = "0 1\r\n1 0";
            Assert.AreEqual(expectedString, graph.ToString());
        }
    }
}
