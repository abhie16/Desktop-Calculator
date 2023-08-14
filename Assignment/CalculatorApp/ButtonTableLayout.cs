using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    internal class ButtonTableLayout : TableLayoutPanel
    {
        public ButtonTableLayout()
        {
            this.Padding = new Padding(0, 50, 0, 0);
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
        }
    }
}
