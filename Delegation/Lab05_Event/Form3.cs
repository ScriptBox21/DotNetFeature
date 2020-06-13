using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Event
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void userControl21_BeforeSelectedIndexChanged(object sender, object value)
        {
            MessageBox.Show("전에 발생하는 이벤트 입니다" + value.ToString());
        }

        private void userControl21_AfterSelectedIndexChanged(object sender, object value, int a)
        {
            MessageBox.Show(a.ToString());
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            myButton1.Text = "123";
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            myButton1.Text = "123";
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            myButton1.Text = "123";

        }

 
    }
}