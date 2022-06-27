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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var cs = _customerDal.GetAll();
            return  new DataResult<List<Customer>>(cs,true);
        }

        public IDataResult<Customer> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
