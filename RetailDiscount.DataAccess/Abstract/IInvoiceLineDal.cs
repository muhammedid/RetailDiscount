using RetailDiscount.Core.DataAccess;
using RetailDiscount.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.DataAccess.Abstract
{
    public interface IInvoiceLineDal: IEntityRepository<InvoiceLine>
    {
    }
}
