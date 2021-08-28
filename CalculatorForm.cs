using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {

        private String input = "";

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            input = txtInput.Text;
            log(input);
        }

        private void type(String s)
        {
            txtInput.Text += s;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            type(((Button)sender).Text);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // TODO: Xu ly
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(txtInput.Text.Length > 0)
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            }
        }

        private void log(String s)
        {
            txtLog.AppendText(s);
            txtLog.AppendText(Environment.NewLine);
        }
    }
}
