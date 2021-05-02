﻿using BOL.Interfaces;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Models
{
    public class ProductDataAccess : IProductDataAccess
    {
        public void AddProduct(Product product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr("PetShopInventory")))
            {
                connection.Execute("AddProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProduct(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            using (IDbConnection connection = new SqlConnection(Helper.Constr("PetShopInventory")))
            {
                connection.Execute("DeleteProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Product> GetProducts()
        {
            using (IDbConnection connection = new SqlConnection(Helper.Constr("PetShopInventory")))
            {
                var sql = $"select * from PetShopInventory";
                var output = connection.Query<Product>(sql);
                return output.ToList();
            }
        }

        public void UpdateProduct(Product product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", product.ID);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr("PetShopInventory")))
            {
                connection.Execute("UpdateProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
