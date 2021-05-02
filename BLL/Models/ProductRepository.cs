using BOL.Interfaces;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ProductRepository : IProductDataAccess
    {
        private readonly IProductDataAccess _productData;
        public ProductRepository(IProductDataAccess productData)
        {
            _productData = productData;
        }
        public void AddProduct(Product product)
        {
            _productData.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productData.DeleteProduct(id);
        }

        public List<Product> GetProducts()
        {
            return _productData.GetProducts();
        }

        public void UpdateProduct(Product product)
        {
            _productData.UpdateProduct(product);
        }
    }
}
