using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Event
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void userControl11_ControlButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("폼에서 발생한 이벤트 입니다.");
        }
    }
}