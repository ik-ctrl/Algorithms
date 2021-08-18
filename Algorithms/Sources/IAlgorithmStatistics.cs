using System.Diagnostics;

namespace Algorithms.Sources
{
    /// <summary>
    /// Статистика алгоритма
    /// </summary>
    public interface IAlgorithmStatistics
    {
        /// <summary>
        /// Количество шагов
        /// </summary>
        public int StepsCount { get; }

        /// <summary>
        /// Затраченное время в секундах
        /// </summary>
        public double TimeSpent { get; }

        /// <summary>
        /// Стирание данных
        /// </summary>
        public void Flush();
    }
}