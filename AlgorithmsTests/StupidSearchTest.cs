using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace AlgorithmsTests
{
    public class StupidSearchTest
    {
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 4, 5)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 1 ,0, 1)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 10, 9, 10)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 23, -1, 10)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 222, -1, 10)]
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 325, -1, 10)]
        [TestCase( new int[]{}, 325, -1, 0)]
        public void Process_Test(int[] array,int item,int indexItem,int stepCount)
        {
            var searcher = new StupidSearch(); 
            var index= searcher.Process(array, item);
            Assert.AreEqual(indexItem,index);
            Assert.AreEqual(stepCount,searcher.StepsCount);
        }
        
        [TestCase( null, 5, 4, 5)]
        public void Process_Exception_Test(int[] array,int item,int indexItem,int stepCount)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new StupidSearch();
                var index = searcher.Process(array, item);
            });
        }
        
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 4, 1000)]
        public void Timer_Test(int[] array,int item,int indexItem,int expectedTime)
        {
            var searcher = new StupidSearch(); 
            var index= searcher.Process(array, item);
            Assert.AreEqual(indexItem,index);
            Assert.True(searcher.TimeSpent<expectedTime);
        }
        
                
        [TestCase( new int[]{1,2,3,4,5,6,7,8,9,10}, 5, 0, 0)]
        public void Flush_Test(int[] array,int item,int stepsCount,int expectedTime)
        {
            var searcher = new StupidSearch(); 
            var index= searcher.Process(array, item);
            searcher.Flush();
            Assert.AreEqual(stepsCount,searcher.StepsCount);
            Assert.AreEqual(expectedTime,searcher.TimeSpent);
        }
        
    }
}