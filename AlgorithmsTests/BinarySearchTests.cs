using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace AlgorithmsTests
{
    public class BinarySearchTests
    {
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 4,4 )]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 1 ,0, 4)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 10, 9, 4)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 23, -1, 4)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 222, -1, 4)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 325, -1, 4)]
        [TestCase( new int[]{}, 325, -1, 0)]
        public void Process_Test(int[] array,int item,int indexItem,int maxStepCount)
        {
            var searcher = new BinarySearch(); 
            var index= searcher.Process(array, item);
            Assert.AreEqual(indexItem,index);
            Assert.True(maxStepCount>=searcher.StepsCount);
        }
        
        [TestCase( null, 5, 4, 5)]
        public void Process_Exception_Test(int[] array,int item,int indexItem,int stepCount)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new BinarySearch();
                var index = searcher.Process(array, item);
            });
        }
        
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 4, 200)]
        public void Timer_Test(int[] array,int item,int indexItem,int expectedTime)
        {
            var searcher = new BinarySearch(); 
            var index= searcher.Process(array, item);
            Assert.AreEqual(indexItem,index);
            Assert.True(searcher.TimeSpent<expectedTime);
        }
        
                
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 0, 0)]
        public void Flush_Test(int[] array,int item,int stepsCount,int expectedTime)
        {
            var searcher = new BinarySearch(); 
            var index= searcher.Process(array, item);
            searcher.Flush();
            Assert.AreEqual(stepsCount,searcher.StepsCount);
            Assert.AreEqual(expectedTime,searcher.TimeSpent);
        }

    }
}