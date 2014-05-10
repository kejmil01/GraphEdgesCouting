using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Graphs
{
    [TestFixture]
    class GraphEdgeCounterTests
    {
        [Test]
        public void ReturnsGraphEdgeCounterObject()
        {
            int[,] array = { { 0, 1 }, { 1, 0 } };
            Graph graph = new Graph(array);
            GraphEdgeCounter edgeCounter = new GraphEdgeCounter(graph);
            Assert.IsNotNull(edgeCounter);
        }

        [Test]
        public void ThrowsExceptionWhenPassingGraphNullReference()
        {
            Graph graph = null;
            GraphEdgeCounter edgeCounter;
            Assert.Throws(typeof(ArgumentNullException), () =>
                {
                    edgeCounter = new GraphEdgeCounter(graph);
                });
        }


        [Test]
        public void CountsGraphEdges()
        {
            int[,] array = { { 0, 1 }, { 1, 0 } };
            Graph graph = new Graph(array);
            GraphEdgeCounter edgeCounter = new GraphEdgeCounter(graph);

            int numberOfEdges = edgeCounter.Count();

            Assert.AreEqual(2, numberOfEdges);
        }

        [Test]
        public void CountsGraphEdgesAsynchronously()
        {
            int[,] array = { { 0, 1 }, { 1, 0 } };
            Graph graph = new Graph(array);
            GraphEdgeCounter edgeCounter = new GraphEdgeCounter(graph);

            int numberOfEdges = edgeCounter.CountAsynchronously();

            Assert.AreEqual(2, numberOfEdges);
        }
    }
}
