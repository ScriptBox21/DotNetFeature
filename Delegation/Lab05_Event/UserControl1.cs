using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Event
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public event EventHandler ControlButtonClick = null;
        public event EventHandler ControlComboBoxSelectedIndexChanged = null;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Control 내부에서 발생한 이벤트 입니다.");

            if (ControlButtonClick != null)
            {
                ControlButtonClick(sender, e);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ControlComboBoxSelectedIndexChanged != null)
            {
                ControlComboBoxSelectedIndexChanged(sender, e);
            }
        }
    }
}
