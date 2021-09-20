namespace HelpersEntities
{
    /// <summary>
    /// Сущность продавца
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Тип продаваемой продукции
        /// </summary>
        public ProductType Type { get; set; }
        
        /// <summary>
        /// Имя продавца
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Был ли человек проверен алгоритмом
        /// </summary>
        public bool IsChecked { get; set; } = false;
    }
}