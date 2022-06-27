using RetailDiscount.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Entities.DTOs
{
    public  class InvoiceDetailDTO
    {
        public int InvoiceID { get; set; }      
        public Customer Customer { get; set; }    
        public decimal InvoiceTotalAmount { get; set; }
        public decimal DiscountTotalAmount { get; set; }
        public decimal PayableAmount { get; set; }        
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
