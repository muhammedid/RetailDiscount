using RetailDiscount.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Entities.Concrete
{
    public class Invoice:IEntity
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public decimal InvoiceTotalAmount { get; set; }
        public decimal DiscountTotalAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
