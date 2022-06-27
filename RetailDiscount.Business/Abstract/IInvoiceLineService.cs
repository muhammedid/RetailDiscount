using RetailDiscount.Core.Utilities.Results;
using RetailDiscount.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Business.Abstract
{
    public interface IInvoiceLineService
    {
        IDataResult<List<InvoiceLine>> GetAll();
    }
}
