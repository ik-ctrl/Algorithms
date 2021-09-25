using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sources
{
    /// <summary>
    /// Сущность реализующая "тупой" поиск
    /// </summary>
    public class StupidSearch : ISearchingAlgorithm
    {
        private long _timeSpent = default;

        /// <summary>
        /// Запуск алгоритма тупого поиска
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

            var watch = new Stopwatch();
            StartWatch(watch);
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (array[i] == needItem)
                {
                    StopWatch(watch);
                    return i;
                }
            }
            StopWatch(watch);
            return -1;
        }

        /// <summary>
        /// Затраченное время
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Сброс данных
        /// </summary>
        public void Flush()
        {
            _timeSpent = 0;
        }

        /// <summary>
        /// Запусе таймера 
        /// </summary>
        /// <param name="watch">Запускаемый таймер</param>
        private void StartWatch(Stopwatch watch)
        {
            watch.Start();
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