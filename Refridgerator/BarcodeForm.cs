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
    partial class BarcodeForm : Form
    {
        int boxNumber;
        Fridge fridge;
        public BarcodeForm(Fridge fridge, int boxNumber)
        {
            this.boxNumber = boxNumber;
            this.fridge = fridge;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var article = fridge.GetFromBox(boxNumber-1, this.barcodeTextBox.Text);
            if (article == null)
            {
                MessageBox.Show("Article not found");
            }
            else
            {
                MessageBox.Show("Deleted: " + article.Title);
                this.Close();
            }

        }
    }
}
