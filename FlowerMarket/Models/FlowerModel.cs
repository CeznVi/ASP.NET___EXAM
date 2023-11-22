using System.Data.SqlTypes;

namespace FlowerMarket.Models
{
    public class FlowerModel
    {
        /// <summary>
        /// Id цветка
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название цветка
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Описание цветка
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        public string Img { get; set; } = string.Empty;
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; } 

    }
}
