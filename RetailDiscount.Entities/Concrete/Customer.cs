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
    public class Customer:IEntity
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string? CutomerSurname { get; set; }        
        public CustomerTypeEnum CustomerType { get; set; }        
        public DateTime RecordDate { get; set; }

    }
}
