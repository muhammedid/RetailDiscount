using RetailDiscount.Business.Abstract;
using RetailDiscount.Core.Utilities.Results;
using RetailDiscount.DataAccess.Abstract;
using RetailDiscount.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Business.Concrete
{
    public class InvoiceDiscountManager : IInvoiceDiscountService
    {
        IInvoiceDiscountDal _invoiceDiscount;

        public InvoiceDiscountManager(IInvoiceDiscountDal invoiceDiscount)
        {
            _invoiceDiscount = invoiceDiscount;
        }

        public IDataResult<List<InvoiceDiscount>> GetAll()
        {
            return new DataResult<List<InvoiceDiscount>>(_invoiceDiscount.GetAll(), true);

        }
    }
}
