using RetailDiscount.Core.Utilities.Results;
using RetailDiscount.Entities.Concrete;
using RetailDiscount.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<List<Invoice>> GetAll();
        IDataResult<InvoiceDetailDTO> GetInvoiceCalculate(int id);
        IDataResult<InvoiceDetailDTO> GetInvoiceDetail(int id);
    }
}
