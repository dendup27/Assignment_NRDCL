using System.ComponentModel.DataAnnotations;

namespace Assignment_NRDCL.Models
{
    public class Product : BaseEntity
    {

        [Key]
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public decimal Rate { get; private set; }
    }
}
