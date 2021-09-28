using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Calculator.XuLyLogic;

namespace Calculator
{
    public partial class CalculatorForm : Form, ILog
    {
        Logic logic;
        TachSo tachSo;
        static int USE_HASHTABLE = 1;
        static int USE_LINKLIST = 2;

        static int structUsing = USE_HASHTABLE;

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
            log((structUsing == USE_HASHTABLE) ?
                "Using hashtable"
                : (structUsing == USE_LINKLIST) ?
                "Using linklist"
                : "");
            log("Input: " + txtInput.Text);
            List<PhanTu> phanTus = tachSo.createPhanTus(txtInput.Text);
            txtInput.Text = 
                (structUsing == USE_HASHTABLE) ? 
                logic.usingHashTable(phanTus)
                : (structUsing == USE_LINKLIST) ? 
                logic.usingLinkList(phanTus)
                : "";
            log("Result: " + txtInput.Text);
            log("\n------------------\n");
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

        public void setStructUsing(int use)
        {
            structUsing = use;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setStructUsing(USE_HASHTABLE);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setStructUsing(USE_LINKLIST);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] lines = File.ReadAllLines(openFileDialog1.FileName);
            txtInput.Text = "";
            foreach(string s in lines)
            {
                if (txtInput.Text.Equals(""))
                {
                    txtInput.Text = s;
                }
                else
                {
                    txtInput.Text += "+" + s;
                }
            }
        }

        private async void saveFileDialog1_FileOkAsync(object sender, CancelEventArgs e)
        {
            await File.WriteAllTextAsync(saveFileDialog1.FileName, txtLog.Text);
        }
    }
}
