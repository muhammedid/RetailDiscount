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
    public class InvoiceLineManager : IInvoiceLineService
    {
        IInvoiceLineDal _invoiceLine;

        public InvoiceLineManager(IInvoiceLineDal invoiceLine)
        {
            _invoiceLine = invoiceLine;
        }

        public IDataResult<List<InvoiceLine>> GetAll()
        {
            return new DataResult<List<InvoiceLine>>(_invoiceLine.GetAll(), true);

        }
    }
}
