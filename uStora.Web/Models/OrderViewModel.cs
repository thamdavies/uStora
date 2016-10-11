using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uStora.Web.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        public string CustomerMessage { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(128)]
        public string CreatedBy { get; set; }

        [MaxLength(250)]
        public string PaymentMethod { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; }

        [Required]
        public bool Status { get; set; }

        [MaxLength(128)]
        public string CustomerId { get; set; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}