using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Calculator.XuLyLogic;

namespace Calculator
{
    public partial class CalculatorForm : Form, ILog
    {
        Logic logic;
        TachSo tachSo;

        public CalculatorForm()
        {
            InitializeComponent();
            logic = new Logic(this);
            tachSo = new TachSo(this);
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
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
            log("Input: " + txtInput.Text);
            logic.clearHashTable();
            List<PhanTu> phanTus = tachSo.createPhanTus(txtInput.Text);
            foreach(PhanTu pt in phanTus)
            {
                logic.PushItem(pt);
            }
            txtInput.Text = logic.result();
            log("Result: " + txtInput.Text);
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

        public void log(String s)
        {
            txtLog.AppendText(s);
            txtLog.AppendText(Environment.NewLine);
        }
    }
}
