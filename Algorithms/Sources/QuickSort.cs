using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sources
{
    /// <summary>
    /// Бастрая сортировка | O(n*logn)
    /// </summary>
    public class QuickSort : ISortAlgorithm
    {
        /// <summary>
        /// Сортировка по возрастанию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Отсортированный массив по возрастанию</returns>
        /// <exception cref="ArgumentNullException"> array==null</exception>
        public int[] SortAscending(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length < 2)
                return array;

            var pivotIndex = FindPivotIndex(array);
            var lowerPivotArray = array.Where((x, index) => pivotIndex != index && x <= array[pivotIndex]).ToArray();
            var greaterPivotArray = array.Where((x) => x > array[pivotIndex]).ToArray();
            var resultList = new List<int>();
            resultList.AddRange(SortAscending(lowerPivotArray));
            resultList.Add(array[pivotIndex]);
            resultList.AddRange(SortAscending(greaterPivotArray));
            return resultList.ToArray();
        }


        /// <summary>
        /// Сортировка по убыванию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Отсортированный массив по убыванию</returns>
        /// <exception cref="ArgumentNullException"> array==null</exception>
        public int[] SortDescending(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length < 2)
                return array;

            var pivotIndex = FindPivotIndex(array);
            var lowerPivotArray = array.Where((x) => x < array[pivotIndex]).ToArray();
            var greaterPivotArray = array.Where((x,index) => pivotIndex != index && x >= array[pivotIndex]).ToArray();
            var resultList = new List<int>();
            resultList.AddRange(SortDescending(greaterPivotArray));
            resultList.Add(array[pivotIndex]);
            resultList.AddRange(SortDescending(lowerPivotArray));
            return resultList.ToArray();
        }

        /// <summary>
        /// Находит индекс опорного элемента.
        /// Опорный элемент берется как центральный элемент.
        /// </summary>
        /// <returns>Индекс опорного элемента</returns>
        private int FindPivotIndex(int[] array) => (int) (array.Length - 1) / 2;
    }
}