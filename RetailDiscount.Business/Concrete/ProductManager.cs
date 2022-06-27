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
    public class ProductManager : IProductService
    {
        IProductDal _product;

        public ProductManager(IProductDal product)
        {
            _product = product;
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new DataResult<List<Product>>(_product.GetAll(), true);

        }
    }
}
