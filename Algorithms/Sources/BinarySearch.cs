using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sources
{
    public class BinarySearch : ISearchingAlgorithm
    {
        private long _timeSpent;

        /// <summary>
        /// Запуск алгоритма бинарного поиска
        /// </summary>
        /// <param name="array">Массив в котором ищем нужное число</param>
        /// <param name="needItem">Необходимое число</param>
        /// <returns>Индекс искомого числа или -1</returns>
        public int Process(int[] array, int needItem)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (!array.Any())
                return -1;
            
            var lowIndex = 0;
            var highIndex = array.Length - 1;
            var watch = new Stopwatch();
            StartWatch(watch);
            while (lowIndex <= highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                var theory = array[middleIndex];
                if (needItem == theory)
                {
                    StopWatch(watch);
                    return middleIndex;
                }
                
                if (needItem > theory)
                    lowIndex = middleIndex + 1;
                else
                    highIndex = middleIndex - 1;
            }
            StopWatch(watch);
            return -1;
        }

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
        
    }
}