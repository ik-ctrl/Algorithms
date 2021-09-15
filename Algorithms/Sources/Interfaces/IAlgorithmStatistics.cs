namespace Algorithms.Sources
{
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
        /// Очистка данных
        /// </summary>
        public void Flush();
    }
}