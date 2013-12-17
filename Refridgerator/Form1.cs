using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Refridgerator
{
    public partial class Form1 : Form
    {
        Fridge fridge;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fridge = new Fridge(7);
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                if (button.Width == 15) // it is open now
                {
                    button.Width = 95;
                    button.Text = boxNumber.ToString();
                    fridge.CloseBox(boxNumber - 1);
                }
                else
                {
                    button.Width = 15;
                    button.Text = "X";
                    fridge.OpenBox(boxNumber - 1);

                }
            }
        }

        private void boxButton2_Click(object sender, EventArgs e)
        {

        }

        private void listAllProducts_Click(object sender, EventArgs e)
        {
            var articles = fridge.getAllArticleList();
            var productListForm = new ProductsListForm();
            productListForm.DataBindItems(articles);
            productListForm.Show();
        }

        private void boxPlusButton1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                var form = new ArticleForm(fridge, boxNumber);
                form.ShowDialog();
            }
        }

        private void boxMinusButton1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                var form = new BarcodeForm(fridge, boxNumber);
                form.ShowDialog();
            }
        }

        private void listBoxButton1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                var articles = fridge.getArticleListInBox(boxNumber);
                var productListForm = new ProductsListForm();
                productListForm.DataBindItems(articles);
                productListForm.Show();
            }
        }

        private void defrostButton1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                fridge.DefrostBox(boxNumber - 1);
            }
        }
    }
}
