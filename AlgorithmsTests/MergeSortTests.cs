using Algorithms.Sources;
using NUnit.Framework;

namespace AlgorithmsTests
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void SortDescending_Test()
        {
            var first = new int[] { 7, 5, 4, 3, 2, 1 };
            var second = new int[] { 10, 9, 8, 6 };
            var expected = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var result = MergeSort.SortDescending(first, second);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [Test]
        public void SortAscending_Test()
        {
            var first = new int[] { 1, 2, 3, 4, 5, 7 };
            var second = new int[] { 6, 8, 9, 10 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = MergeSort.SortAscending(first, second);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}