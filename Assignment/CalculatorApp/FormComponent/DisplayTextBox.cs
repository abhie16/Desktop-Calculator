using System.Drawing;
using System.Windows.Forms;

namespace CalculatorApp
{
    public class DisplayTextbox : TextBox
    {
        public DisplayTextbox()
        {
            this.Text = "0";
            this.Dock = DockStyle.Fill;
            this.SelectionStart = 0;
            this.SelectionLength = 1;
            this.MaximumSize = new Size(1000, 50);
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.None;
            this.Font = new Font(this.Font.FontFamily, 26);
            this.TextAlign = HorizontalAlignment.Right;
        }
    }
}
