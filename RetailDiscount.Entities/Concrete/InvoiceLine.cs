using RetailDiscount.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Entities.Concrete
{
    public class InvoiceLine:IEntity
    {
        [Key]
        public int LineID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PriceAmount { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
