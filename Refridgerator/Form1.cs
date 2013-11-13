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
            fridge = new Fridge(6);
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boxNumber = Convert.ToInt32(button.Tag);
                if (button.Width == 15) // open 
                {
                    button.Width = 95;
                    button.Text = boxNumber.ToString();
                    //fridge.OpenBox(boxNumber);
                }
                else
                {
                    button.Width = 15;
                    button.Text = "X";
                    //fridge.CloseBox(boxNumber);
                }
            }
        }

        private void boxButton2_Click(object sender, EventArgs e)
        {

        }

        private void listAllProducts_Click(object sender, EventArgs e)
        {
            IEnumerable<Article> articles = new Article[] { 
                new Article() { Barcode="123", Title="product1" },
                new Article() { Barcode="456", Title="second product" }
            }; //fridge.GetList();
        }
    }
}
