using System.ComponentModel.DataAnnotations;

namespace Assignment_NRDCL.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerCID { get; set; }
        public decimal PriceAmount { get; set; }
        public decimal TansportAmount { get; set; }
        public decimal AdvanceBalance { get; set; }
    }
}
