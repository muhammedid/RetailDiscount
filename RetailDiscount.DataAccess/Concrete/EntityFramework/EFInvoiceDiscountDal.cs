using RetailDiscount.Core.DataAccess.EntityFreamwork;
using RetailDiscount.DataAccess.Abstract;
using RetailDiscount.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.DataAccess.Concrete.EntityFramework
{
    public class EFInvoiceDiscountDal : EFEntityRepositoryBase<InvoiceDiscount, RetailContext>, IInvoiceDiscountDal
    {
    }
}
