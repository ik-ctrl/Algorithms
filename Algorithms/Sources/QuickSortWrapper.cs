using System.Diagnostics;

namespace Algorithms.Sources
{
    /// <summary>
    /// Обертка вокруг быстрой сортировки
    /// </summary>
    public class QuickSortWrapper:ISortAlgorithm,IAlgorithmStatistics
    {
        private QuickSort _sorter;
        private long _timeSpent;

        public QuickSortWrapper()
        {
            _sorter = new QuickSort();
        }
        
        /// <summary>
        /// Сортировка по возрастанию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Отсортированный массив по возрастанию</returns>
        /// <exception cref="ArgumentNullException"> array==null</exception>
        public int[] SortAscending(int[] array)
        {
            var watch = new Stopwatch();
            StartWatch(watch);
            var result =_sorter.SortAscending(array);
            StopWatch(watch);
            return result;
        }
        
        /// <summary>
        /// Сортировка по убыванию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Отсортированный массив по убыванию</returns>
        /// <exception cref="ArgumentNullException"> array==null</exception>
        public int[] SortDescending(int[] array)
        {
            var watch = new Stopwatch();
            StartWatch(watch);
            var result =_sorter.SortDescending(array);
            StopWatch(watch);
            return result;
        }

        /// <summary>
        /// Времменные затраты
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Запуск таймера
        /// </summary>
        /// <param name="watch">Таймер</param>
        private void StartWatch(Stopwatch watch) => watch?.Restart();

        /// <summary>
        /// Фиксация времени и остановка таймера
        /// </summary>
        /// <param name="watch"> таймер</param>
        private void StopWatch(Stopwatch watch)
        {
            _timeSpent = (long) watch?.ElapsedMilliseconds;
            watch?.Stop();
        }
        
        /// <summary>
        /// Сброс статистики
        /// </summary>
        public void Flush()
        {
            _timeSpent = default;
            _sorter = new QuickSort();
        }
    }
}