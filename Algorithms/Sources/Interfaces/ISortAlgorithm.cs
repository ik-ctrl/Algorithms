namespace Algorithms.Sources
{
    public interface ISortAlgorithm:IAlgorithmStatistics
    {
        /// <summary>
        /// Сортировка по возрастанию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Массив, отсортированный по возрастанию</returns>
        public int[] SortAscending(int[] array);

        /// <summary>
        /// Сортировка по убыванию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Массив, отсортированный по убыванию</returns>
        public int[] SortDescending(int[] array);
    }
}