using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Event
{
    public class MyButton : Button 
    {
        protected override void OnClick(EventArgs e)
        {
            this.Text = "Clicked";
            base.OnClick(e);
        }
    }
}
