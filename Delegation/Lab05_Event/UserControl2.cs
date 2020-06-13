using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Event
{
    public delegate void BeforeSelectedIndexChangedEventHandler(object sender, object value);
    public delegate void AfterSelectedIndexChangedEventHandler(object sender, object value, int a);

    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        public event BeforeSelectedIndexChangedEventHandler BeforeSelectedIndexChanged = null;
        public event AfterSelectedIndexChangedEventHandler AfterSelectedIndexChanged = null;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 3;
            if (BeforeSelectedIndexChanged != null)
            {
                BeforeSelectedIndexChanged(sender, comboBox1.SelectedItem);
            }

            MessageBox.Show("나는 수행 중입니다. (Before 다음에)");
            a = 3 + 4;

            if (AfterSelectedIndexChanged != null)
            {
                AfterSelectedIndexChanged(sender, comboBox1.SelectedItem, a);
            }
        }
    }
}
