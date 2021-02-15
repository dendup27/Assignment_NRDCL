using System.ComponentModel.DataAnnotations;

namespace Assignment_NRDCL.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        [Required(ErrorMessage = "Customer CID is mandatory.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Customer CID must have a minimum and maximum length of 11.")]
        [Display(Name = "Customer CID")]
        public string CustomerCID { get; set; }

        [Required(ErrorMessage = "Customer Name is mandatory.")]
        [StringLength(250, MinimumLength = 3)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [RegularExpression("[0-9]{8,8}", ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Mail Address")]
        public string MailId { get; set; }
    }
}
