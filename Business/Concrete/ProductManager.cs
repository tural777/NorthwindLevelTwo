using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        readonly private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }


        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryID == categoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }
    }
}
