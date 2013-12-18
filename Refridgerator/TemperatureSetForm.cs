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
    partial class TemperatureSetForm : Form
    {
        Box box;
        Fridge fridge;
        public TemperatureSetForm(Fridge fridge, Box box)
        {
            this.box = box;
            this.fridge = fridge;

            InitializeComponent();
        }

        public void Databind()
        {
            this.minTemperatureControl.DataBindings.Add("Value", box, "minTemperature");
            this.maxTemperatureControl.DataBindings.Add("Value", box, "maxTemperature");
            this.lblCurrentTemperature.DataBindings.Add("Text", box, "currentTemperature");
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
