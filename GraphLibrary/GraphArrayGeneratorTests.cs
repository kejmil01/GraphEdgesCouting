using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Graphs
{
    [TestFixture]
    class GraphArrayGeneratorTests
    {

        [Test]
        public void Generate_ReturnsTwoDimensionalArrayWithSpecifiedSize()
        {
            int size = 3;
            GraphArrayGenerator generator = new GraphArrayGenerator();
            var graphArray = generator.Generate(size);
            Assert.NotNull(graphArray);
            Assert.AreEqual(graphArray.Rank, 2);
        }

        [Test]
        public void Generate_ReturnedArrayIsFilledWithZeroOneValues()
        {
            int size = 1;
            GraphArrayGenerator generator = new GraphArrayGenerator();
            var graphArray = generator.Generate(size);
            Assert.GreaterOrEqual(graphArray[0, 0], 0);
            Assert.LessOrEqual(graphArray[0, 0], 1);
        }

        [Test]
        public void GenerateConcurrently_ReturnsTwoDimensionalArrayWithSpecifiedSize()
        {
            int size = 3;
            GraphArrayGenerator generator = new GraphArrayGenerator();
            var graphArray = generator.GenerateConcurrently(size);
            Assert.NotNull(graphArray);
            Assert.AreEqual(graphArray.Rank, 2);
        }

        [Test]
        public void GenerateConcurrently_ReturnedArrayIsFilledWithZeroOneValues()
        {
            int size = 1;
            GraphArrayGenerator generator = new GraphArrayGenerator();
            var graphArray = generator.GenerateConcurrently(size);
            Assert.GreaterOrEqual(graphArray[0, 0], 0);
            Assert.LessOrEqual(graphArray[0, 0], 1);
        }
    }
}
