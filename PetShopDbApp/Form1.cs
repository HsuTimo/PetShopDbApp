using BLL.Models;
using BOL.Interfaces;
using BOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopDbApp
{
    public partial class PetShopDBForm : Form
    {
        private IProductDataAccess _productRepo = new ProductRepository(new ProductDataAccess());
        public PetShopDBForm()
        {
            InitializeComponent();
            LoadProducts();
        }
        public void LoadProducts()
        {
            this.grid_PetShopDB.DataSource = _productRepo.GetProducts();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {

            Product product = new Product()
            {
                ProductName = txt_Name.Text,
                Quantity = Int32.Parse(txt_Quantity.Text),
                Price = Decimal.Parse(txt_Price.Text)
            };
            _productRepo.AddProduct(product);
            LoadProducts();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            _productRepo.DeleteProduct(Int32.Parse(lbl_ID.Text));
            LoadProducts();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                ID = Int32.Parse(lbl_ID.Text),
                ProductName = txt_Name.Text,
                Quantity = Int32.Parse(txt_Quantity.Text),
                Price = Decimal.Parse(txt_Price.Text)
            };
            _productRepo.UpdateProduct(product);
            LoadProducts();
        }

        private void grid_PetShopDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_ID.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Name.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Quantity.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Price.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
