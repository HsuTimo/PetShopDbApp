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
            setButtonsEnabled(false);
        }
        public void LoadProducts()
        {
            this.grid_PetShopDB.DataSource = _productRepo.GetProducts();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Input not valid. Please try again");
            }
            finally
            {
                clearSelection();
            }


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lbl_ID.Text != "none")
            {
                _productRepo.DeleteProduct(Int32.Parse(lbl_ID.Text));
                LoadProducts();
                clearSelection();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            
            try
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
            catch (Exception)
            {
                MessageBox.Show("Input not valid. Please try again");
            }
            finally
            {
                clearSelection();
            }
        }

        private void grid_PetShopDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_ID.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Name.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Quantity.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Price.Text = grid_PetShopDB.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearSelection();
        }
        private void setButtonsEnabled(bool set)
        {
            btn_New.Enabled = set;
            btn_Update.Enabled = set;
            btn_Delete.Enabled = set; 
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            checkButtons();
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            checkButtons();
        }

        private void txt_Price_TextChanged(object sender, EventArgs e)
        {
            checkButtons();
        }
        private bool isTextFieldsComplete()
        {
            if (String.IsNullOrWhiteSpace(txt_Name.Text)|| String.IsNullOrWhiteSpace(txt_Quantity.Text)|| String.IsNullOrWhiteSpace(txt_Price.Text)){
                return false;
            }
            return true;
        }
        private void checkButtons()
        {
            if (isTextFieldsComplete()&&lbl_ID.Text != "none")
            {
                setButtonsEnabled(true);
            }
            else if (isTextFieldsComplete() && lbl_ID.Text == "none")
            {
                setButtonsEnabled(false);
                btn_New.Enabled = true;
            }
            else
            {
                setButtonsEnabled(false);
            }
        }
        private void clearSelection()
        {
            setButtonsEnabled(false);
            lbl_ID.Text = "none";
            txt_Name.Text = null;
            txt_Quantity.Text = null;
            txt_Price.Text = null;
        }
    }
}
