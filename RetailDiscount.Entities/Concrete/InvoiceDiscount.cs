using RetailDiscount.Core.Entities.Abstract;
using RetailDiscount.Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Entities.Concrete
{
    public class InvoiceDiscount : IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        [Required]
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public Invoice Invoice { get; set; }        
    }
}
