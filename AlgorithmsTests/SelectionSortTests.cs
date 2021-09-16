using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources;
using NUnit.Framework;

namespace AlgorithmsTests
{
    public class SelectionSortTests
    {
        [TestCase(new int[] {5, 4, 3, 2, 1}, new int[] {1, 2, 3, 4, 5})]
        [TestCase(new int[] {5, 4, 3, 1, 2}, new int[] {1, 2, 3, 4, 5})]
        [TestCase(new int[] {5, 4, 3, 3, 1}, new int[] {1, 3, 3, 4, 5})]
        [TestCase(new int[] {50, 544, 23, 32, 121}, new int[] {23, 32, 50, 121, 544})]
        public void SortAscending_Test(int[] unsortedArray, int[] expectedArray)
        {
            var sorter = new SelectionSort();
            var newArray = sorter.SortAscending(unsortedArray);
            for (int i = 0; i <= expectedArray.Length - 1; i++)
            {
                if (newArray[i] != expectedArray[i])
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        [TestCase(500)]
        [TestCase(1000)]
        public void SortAscending_Random_Test(int arraySize)
        {
            var unsortedArray = GenerateRandomArray(arraySize);
            var sortArray = (int[])unsortedArray.Clone();
            Array.Sort(sortArray);
            var sorter = new SelectionSort();
            var newArray = sorter.SortAscending(unsortedArray);
            for (int i = 0; i <= sortArray.Length - 1; i++)
            {
                if (newArray[i] != sortArray[i]) Assert.Fail();
            }
            Assert.Pass();
        }


        [TestCase(new int[] { }, new int[] { })]
        public void SortAscending_EmptyArray_Test(int[] unsortedArray, int[] expectedArray)
        {
            var sorter = new SelectionSort();
            var newArray = sorter.SortAscending(unsortedArray);
            Assert.True(newArray.Length == expectedArray.Length);
        }

        [TestCase(null, new int[] {1, 2, 3, 4, 5})]
        public void SortAscending_Exception_Test(int[] unsortedArray, int[] expectedArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new SelectionSort();
                var index = searcher.SortAscending(unsortedArray);
            });
        }

        [TestCase(new int[] {5, 4, 3, 2, 1}, new int[] {5, 4, 3, 2, 1})]
        [TestCase(new int[] {5, 4, 3, 1, 2}, new int[] {5, 4, 3, 2, 1})]
        [TestCase(new int[] {5, 4, 3, 3, 1}, new int[] {5, 4, 3, 3, 1})]
        [TestCase(new int[] {50, 544, 23, 32, 121}, new int[] {544, 121, 50, 32, 23})]
        public void SortDescending_Test(int[] unsortedArray, int[] expectedArray)
        {
            var sorter = new SelectionSort();
            var newArray = sorter.SortDescending(unsortedArray);
            for (int i = 0; i <= expectedArray.Length - 1; i++)
            {
                if (newArray[i] != expectedArray[i])
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [TestCase(new int[] { }, new int[] { })]
        public void SortDescending__EmptyArray_Test(int[] unsortedArray, int[] expectedArray)
        {
            var sorter = new SelectionSort();
            var newArray = sorter.SortDescending(unsortedArray);
            Assert.True(newArray.Length == expectedArray.Length);
        }

        [TestCase(null, new int[] {1, 2, 3, 4, 5})]
        public void SortDescending_Exception_Test(int[] unsortedArray, int[] expectedArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new SelectionSort();
                var index = searcher.SortDescending(unsortedArray);
            });
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        [TestCase(500)]
        [TestCase(1000)]
        public void SortDescending_Random_Test(int arraySize)
        {
            var unsortedArray = GenerateRandomArray(arraySize);
            var sortArray = (int[])unsortedArray.Clone();
            Array.Sort(sortArray);
            Array.Reverse(sortArray);
            var sorter = new SelectionSort();
            var newArray = sorter.SortDescending(unsortedArray);
            for (int i = 0; i <= sortArray.Length - 1; i++)
            {
                if (newArray[i] != sortArray[i]) Assert.Fail();
            }
            Assert.Pass();
        }
        
        
        #region helpers

        private int[] GenerateRandomArray(int arraySize)
        {
            var randomizer = new Random(DateTime.Now.Millisecond & 0xf0f0f0);
            return Enumerable.Range(0, arraySize).Select(x => randomizer.Next(-1000, 1000)).ToArray();
        }

        #endregion
    }
}