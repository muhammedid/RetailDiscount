using RetailDiscount.Business.Abstract;
using RetailDiscount.Core.Utilities.Results;
using RetailDiscount.DataAccess.Abstract;
using RetailDiscount.Entities.Concrete;
using RetailDiscount.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoice;

        public InvoiceManager(IInvoiceDal invoice)
        {
            _invoice = invoice;
        }

        public IDataResult<List<Invoice>> GetAll()
        {
            return new DataResult<List<Invoice>>(_invoice.GetAll(), true);

        }

        public List<InvoiceDiscount> GetInvoiceDiscounts(int invoiceID)
        {
            var inv = _invoice.GetInvoiceDetail(invoiceID);

            var customer = inv.Customer;

            var invDiscount = new List<InvoiceDiscount>();

            switch (customer.CustomerType)
            {
                //2.	If the user is an affiliate of the store, he gets a 10% discount
                case Entities.Concrete.Enums.CustomerTypeEnum.Customer:
                    {
                        //6.	A user can get only one of the percentage based discounts on a bill.
                        if (invDiscount.Any(a => a.DiscountType == Entities.Concrete.Enums.DiscountTypeEnum.Percentage))
                            break;
                        invDiscount.Add(new InvoiceDiscount()
                        {
                            DiscountType = Entities.Concrete.Enums.DiscountTypeEnum.Percentage,
                            DiscountValue = 10,
                            InvoiceID = inv.InvoiceID
                        });
                    }
                    break;
                case Entities.Concrete.Enums.CustomerTypeEnum.Groceries:
                    break;
                //1.	If the user is an employee of the store, he gets a 30% discount
                case Entities.Concrete.Enums.CustomerTypeEnum.Employee:
                    {
                        //6.	A user can get only one of the percentage based discounts on a bill.
                        if (invDiscount.Any(a => a.DiscountType == Entities.Concrete.Enums.DiscountTypeEnum.Percentage))
                            break;
                        invDiscount.Add(new InvoiceDiscount()
                        {
                            DiscountType = Entities.Concrete.Enums.DiscountTypeEnum.Percentage,
                            DiscountValue = 30,
                            InvoiceID = inv.InvoiceID
                        });
                    }
                    break;
                default:
                    break;
            }
            //5.	The percentage based discounts do not apply on groceries.
            if (customer.CustomerType != Entities.Concrete.Enums.CustomerTypeEnum.Groceries)
            {
                //3.	If the user has been a customer for over 2 years, he gets a 5% discount.
                if ((customer.RecordDate - DateTime.Now).TotalDays > (365 * 2))
                {
                    //6.	A user can get only one of the percentage based discounts on a bill.
                    if (!invDiscount.Any(a => a.DiscountType == Entities.Concrete.Enums.DiscountTypeEnum.Percentage))
                    {
                        invDiscount.Add(new InvoiceDiscount()
                        {
                            DiscountType = Entities.Concrete.Enums.DiscountTypeEnum.Percentage,
                            DiscountValue = 5,
                            InvoiceID = inv.InvoiceID
                        });
                    }
                }
            }

            //4.	For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
            decimal total = inv.InvoiceLines.Sum(s => s.TotalAmount);
            int inv100 = Convert.ToInt32(Math.Floor(total / 100));
            if (inv100 > 0)
            {
                invDiscount.Add(new InvoiceDiscount()
                {
                    DiscountType = Entities.Concrete.Enums.DiscountTypeEnum.Amount,
                    DiscountValue = inv100 * 5,
                    InvoiceID = inv.InvoiceID
                });
            }

            return invDiscount;
        }

        public IDataResult<InvoiceDetailDTO> GetInvoiceCalculate(int id)
        {
            var inv = _invoice.GetInvoiceDetail(id);
            var invDiscount = GetInvoiceDiscounts(id);

            decimal total = inv.InvoiceLines.Sum(s => s.TotalAmount);

            var discPercentage = invDiscount.Where(v => v.DiscountType == Entities.Concrete.Enums.DiscountTypeEnum.Percentage).ToList();
            decimal newTotal = total;
            foreach (var discPerItem in discPercentage)
            {
                newTotal = newTotal - (newTotal * (discPerItem.DiscountValue / 100));
            }

            decimal discAmount = invDiscount.Where(v => v.DiscountType == Entities.Concrete.Enums.DiscountTypeEnum.Amount).Sum(s => s.DiscountValue);
            if (discAmount > 0)
                newTotal = newTotal - discAmount;

            inv.DiscountTotalAmount= total-newTotal;
            inv.InvoiceTotalAmount = total;
            inv.PayableAmount= newTotal;

            return new DataResult<InvoiceDetailDTO>(inv, true);

        }

        public IDataResult<InvoiceDetailDTO> GetInvoiceDetail(int id)
        {
            return new DataResult<InvoiceDetailDTO>(_invoice.GetInvoiceDetail(id), true);
        }
    }
}
