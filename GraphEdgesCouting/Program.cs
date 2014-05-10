using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Graphs;

namespace GraphEdgeCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfVertices;
            Console.WriteLine("Enter the number of vertices: ");
            numberOfVertices = int.Parse(Console.ReadLine());

            GraphArrayGenerator generator = new GraphArrayGenerator();
            Graph graph = new Graph(generator.GenerateAsynchronously(numberOfVertices));
            if(numberOfVertices <  16)
                Console.WriteLine("Graph\n{0}\n", graph.ToString());

            GraphEdgeCounter counter = new GraphEdgeCounter(graph);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int numberOfEdges = counter.Count();      
            watch.Stop();
            Console.WriteLine("Number of edges: {0}\nTime(ms): {1}\n\n", numberOfEdges, watch.ElapsedMilliseconds);

            watch.Restart();
            numberOfEdges = counter.CountAsynchronously();
            watch.Stop();
            Console.WriteLine("Multi-threaded\nNumber of edges: {0}\nTime(ms): {1}", numberOfEdges, watch.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
