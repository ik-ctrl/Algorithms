namespace Algorithms.Sources
{
    /// <summary>
    /// Статистика алгоритма
    /// </summary>
    public interface ISearchingAlgorithm
    {
        /// <summary>
        /// Запуск алгоритма тупого поиска
        /// </summary>
        /// <param name="array">Массив в котором ищем нужное число</param>
        /// <param name="needItem">Необходимое число</param>
        /// <returns>Индекс искомого числа или -1</returns>
        public int Process(int[] array, int needItem);
        
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