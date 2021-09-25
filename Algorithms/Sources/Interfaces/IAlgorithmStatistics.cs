namespace Algorithms.Sources
{
    public interface IAlgorithmStatistics
    {
        /// <summary>
        /// Затраченное время в секундах
        /// </summary>
        public long TimeSpent { get; }

        /// <summary>
        /// Очистка данных
        /// </summary>
        public void Flush();
    }
}