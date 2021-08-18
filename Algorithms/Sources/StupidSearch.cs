using System.Diagnostics;

namespace Algorithms.Sources
{
    public class StupidSearch : IAlgorithmStatistics
    {
        private int _stepsCount = 0;
        private double _timeSpent = 0;

        /// <summary>
        /// Запуск алгоритма тупого поиска
        /// </summary>
        /// <param name="array">Массив в котором ищем нужное число</param>
        /// <param name="needItem">Необходимое число</param>
        /// <returns>Индекс искомого числа или -1</returns>
        public int Process(int[] array, int needItem)
        {
            if (array == null) return -1;
            var watch = new Stopwatch();
            StartWatch(watch);
            for (int i = 0; i < array.Length - 1; i++)
            {
                _stepsCount++;
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
        /// Количество шагов
        /// </summary>
        public int StepsCount =>_stepsCount ;

        /// <summary>
        /// Затраченное время
        /// </summary>
        public double TimeSpent => _timeSpent;
        
        /// <summary>
        /// Сброс данных
        /// </summary>
        public void Flush()
        {
            _stepsCount = 0;
            _timeSpent = 0;
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