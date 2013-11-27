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
    partial class ArticleForm : Form
    {
        int boxNumber;
        Fridge fridge;
        public ArticleForm(Fridge fridge, int boxNumber)
        {
            this.boxNumber = boxNumber;
            this.fridge = fridge;
            InitializeComponent();
        }

        private void putButton_Click(object sender, EventArgs e)
        {
            var article = new Article() { Title = titleTextBox.Text, Barcode = barcodeTextBox.Text };
            fridge.PutInBox(boxNumber, article);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
