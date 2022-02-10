using System;

namespace Algorithms.Sources
{
    /// <summary>
    /// Сортировка слиянием O(nlogn)
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Сортировка по убыванию
        /// </summary>
        /// <param name="firstOrderedArray">Первый массив отсортированный по убыванию</param>
        /// <param name="secondOrderedArray">Второй массив отсортированный по убыванию</param>
        /// <returns>Убыванию массив по возрастанию</returns>
        /// <exception cref="ArgumentException">Один из массивов равен null</exception>
        public static int[] SortDescending (int[] firstOrderedArray, int[] secondOrderedArray)
        {
            if (firstOrderedArray == null || secondOrderedArray == null)
                throw new ArgumentException("Один из массивов равен null");

            var i = 0;
            var j = 0;
            var k = 0;
            var resultArray = new int[firstOrderedArray.Length + secondOrderedArray.Length];
            while (i < firstOrderedArray.Length && j < secondOrderedArray.Length)
            {
                resultArray[k] = firstOrderedArray[i] >secondOrderedArray[j]
                    ? firstOrderedArray[i++]
                    : secondOrderedArray[j++];
                    k++;
            }
            
            while (i < firstOrderedArray.Length)
            {
                resultArray[k] = firstOrderedArray[i++];
                k++;
            }
            
            while (j < secondOrderedArray.Length)
            {
                resultArray[k] = secondOrderedArray[j++];
                k++;
            }
            return resultArray;
        }

        /// <summary>
        /// Сортировка по возрастанию
        /// </summary>
        /// <param name="firstOrderedArray">Первый массив отсортированный по возрастанию</param>
        /// <param name="secondOrderedArray">Второй массив отсортированный по возрастанию</param>
        /// <returns>Отсортированный массив по возрастанию</returns>
        /// <exception cref="ArgumentException">Один из массивов равен null</exception>
        public static int[] SortAscending(int[] firstOrderedArray, int[] secondOrderedArray)
        {
            if (firstOrderedArray == null || secondOrderedArray == null)
                throw new ArgumentException("Один из массивов равен null");

            var i = 0;
            var j = 0;
            var k = 0;
            var resultArray = new int[firstOrderedArray.Length + secondOrderedArray.Length];
            while (i < firstOrderedArray.Length && j < secondOrderedArray.Length)
            {
                resultArray[k] = firstOrderedArray[i] < secondOrderedArray[j]
                    ? firstOrderedArray[i++]
                    : secondOrderedArray[j++];
                k++;
            }
            
            while (i < firstOrderedArray.Length)
            {
                resultArray[k] = firstOrderedArray[i++];
                k++;
            }
            
            while (j < secondOrderedArray.Length)
            {
                resultArray[k] = secondOrderedArray[j++];
                k++;
            }
            return resultArray;
        }

        public static int[] ArraySort(int[] array)
        {
            
        }
    }
}