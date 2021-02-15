using System.ComponentModel.DataAnnotations;

namespace Assignment_NRDCL.Models
{
    public class Deposit : BaseEntity
    {

        [Key]
        public string CustomerID { get; set; }
        public decimal LastAmount { get; set; }
        public decimal Balance { get; set; }
    }

}
