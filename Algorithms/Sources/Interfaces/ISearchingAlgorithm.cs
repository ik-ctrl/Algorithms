namespace Algorithms.Sources
{
    /// <summary>
    /// Статистика алгоритма
    /// </summary>
    public interface ISearchingAlgorithm:IAlgorithmStatistics
    {
        /// <summary>
        /// Запуск алгоритма тупого поиска
        /// </summary>
        /// <param name="array">Массив в котором ищем нужное число</param>
        /// <param name="needItem">Необходимое число</param>
        /// <returns>Индекс искомого числа или -1</returns>
        public int Process(int[] array, int needItem);
    }
}