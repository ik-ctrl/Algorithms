using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sources
{
    /// <summary>
    /// Сортировка выбором | O(n^2)
    /// </summary>
    public class SelectionSort : ISortAlgorithm,IAlgorithmStatistics
    {
        private long _timeSpent;

        /// <summary>s
        /// Затраченное время
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Сброс статистики
        /// </summary>
        public void Flush()
        {
            _timeSpent = default;
        }

        /// <summary>
        /// Запусе таймера 
        /// </summary>
        /// <param name="watch">Запускаемый таймер</param>
        private void StartWatch(Stopwatch watch)
        {
            watch.Restart();
        }

        /// <summary>
        /// Остановка таймера
        /// </summary>
        /// <param name="watch">Останавливаемый таймер</param>
        private void StopWatch(Stopwatch watch)
        {
            _timeSpent = watch.ElapsedMilliseconds;
            watch.Stop();
        }

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

            if (!array.Any())
                return array;

            var copyArray = (int[]) array.Clone();
            var newArray = new List<int>();
            var watch = new Stopwatch();
            var iteration = copyArray.Length - 1;
            Flush();
            StartWatch(watch);
            for (var i = 0; i <= iteration; i++)
            {
                var (value, index) = FindSmallestValue(copyArray);
                newArray.Add(value);
                copyArray = DeleteElementByIndex(copyArray, index);
            }
            StopWatch(watch);
            return newArray.ToArray();
        }

        /// <summary>
        /// Удаление элемента по указанному индексу
        /// </summary>
        /// <param name="array"> Массив</param>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        private int[] DeleteElementByIndex(int[] array, int index) => array.Take(index).Concat(array.Skip(index + 1)).ToArray();

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

            if (!array.Any())
                return array;

            var copyArray = (int[]) array.Clone();
            var newArray = new List<int>();
            var watch = new Stopwatch();
            var iteration = copyArray.Length - 1;
            Flush();
            StartWatch(watch);
            for (var i = 0; i <= iteration; i++)
            {
                var (value, index) = FindHighestValue(copyArray);
                newArray.Add(value);
                copyArray = DeleteElementByIndex(copyArray, index);
            }
            StopWatch(watch);
            return newArray.ToArray();
        }

        /// <summary>
        /// Поиск наименьшего числа
        /// </summary>
        /// <param name="array">Массив , в котором происходит поиск</param>
        /// <returns> Кортеж:1- наименьшее число в массиве,2- индекс наименьшего числа</returns>
        private (int, int) FindSmallestValue(int[] array)
        {
            var minValue = array[0];
            var minIndex = 0;
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (minValue > array[i])
                {
                    minIndex = i;
                    minValue = array[i];
                }
            }

            return (minValue, minIndex);
        }

        /// <summary>
        /// Поиск наибольшего числа
        /// </summary>
        /// <param name="array">Массив , в котором происходит поиск</param>
        /// <returns> Кортеж:1- наибольшее  число в массиве,2- индекс наибольшего числа</returns>
        private (int, int) FindHighestValue(int[] array)
        {
            var maxValue = array[0];
            var maxIndex = 0;
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (maxValue < array[i])
                {
                    maxIndex = i;
                    maxValue = array[i];
                }
            }

            return (maxValue, maxIndex);
        }
    }
}