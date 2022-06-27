using RetailDiscount.Core.DataAccess.EntityFreamwork;
using RetailDiscount.DataAccess.Abstract;
using RetailDiscount.Entities.Concrete;
using RetailDiscount.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.DataAccess.Concrete.EntityFramework
{
    public class EFInvoiceDal : EFEntityRepositoryBase<Invoice, RetailContext>, IInvoiceDal
    {
        public InvoiceDetailDTO GetInvoiceDetail(int id)
        {
            using (var db= new RetailContext())
            {
                var invDetail = from inv in db.Invoices
                                join cus in db.Customers
                                on inv.CustomerID equals cus.CustomerID
                                select new InvoiceDetailDTO
                                {
                                    InvoiceID = inv.InvoiceID,
                                    Customer = cus,
                                    DiscountTotalAmount = inv.DiscountTotalAmount,
                                    InvoiceLines = db.InvoiceLines.Where(v => v.InvoiceID.Equals(id)).ToList(),
                                    InvoiceTotalAmount = inv.InvoiceTotalAmount,
                                    PayableAmount = inv.PayableAmount,
                                    
                                };
                

                //    db.Invoices.Where(v => v.InvoiceID.Equals(id)).Select(s => new InvoiceDetailDTO
                //{
                //    InvoiceID = s.InvoiceID,
                //    Customer = s.Customer,
                //    DiscountTotalAmount = s.DiscountTotalAmount,
                //    InvoiceLines = s.InvoiceLines,
                //    InvoiceTotalAmount = s.InvoiceTotalAmount,
                //    PayableAmount = s.PayableAmount
                //}).ToList();
                return invDetail.First();
            }

        }
    }
}
