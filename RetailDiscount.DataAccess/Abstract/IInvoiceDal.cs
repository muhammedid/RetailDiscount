using RetailDiscount.Core.DataAccess;
using RetailDiscount.Entities.Concrete;
using RetailDiscount.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.DataAccess.Abstract
{
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
        public InvoiceDetailDTO GetInvoiceDetail(int id);
    }
}
