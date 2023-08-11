using System.Windows.Forms;

namespace CalculatorApp
{
    public class DisplayTextBox : TextBox
    {
        public DisplayTextBox()
        {
            this.Text = "0";
            this.Dock = DockStyle.Fill;
            this.ReadOnly = true;
            this.SelectionStart = 0;
            this.SelectionLength = 1;
            this.TextAlign = HorizontalAlignment.Right;
            this.BorderStyle = BorderStyle.None;
            this.Padding = new Padding(10,10, 10, 10);
        }
    }
}
