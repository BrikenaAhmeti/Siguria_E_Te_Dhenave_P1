
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESready
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
  
        DES des = new DES();

private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKey.Text.Length <= 8)
            {
                txtCipher.Text = des.Enkripto(txtPlain.Text, txtKey.Text);
            }
            else
            {
                MessageBox.Show("Qelesi duhet te jete makssimumi 8 karaktere");
                txtKey.Focus();
            }
        }
