using Ecommerce.Enums;
using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string MainImage { get; set; }
        public string CategoryName { get; set; }

    }
}
