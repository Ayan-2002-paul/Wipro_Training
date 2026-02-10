using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            if (!string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("You entered: " + inputText);
                webBrowser1.Navigate(inputText);
                webBrowser1.Show();
            }
            else
            {
                MessageBox.Show("Please enter some text in the text box.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
