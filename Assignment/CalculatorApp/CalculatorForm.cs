
using System.Windows.Forms;

namespace CalculatorApp
{
    public class CalculatorForm : Form
    {
        public DisplayTextBox displayBox;
        public CalculatorForm() {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Height = 500;
            this.Width = 500;

            displayBox = new DisplayTextBox();
            TableLayout formTableLayout = new TableLayout(500,500,6,4,displayBox);

            this.Controls.Add(displayBox);
            this.Controls.Add(formTableLayout);
        }
    }
}
