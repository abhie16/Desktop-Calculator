using System;
using System.Windows.Forms;
using MathLibrary;

namespace CalculatorApp
{
    public class TableLayout : TableLayoutPanel
    {
        DisplayTextBox displayBox;

        string[] buttonLabels =
            {
                "%", "CE", "C", "Del",
                "reci", "sq", "cube", "/",
                "7", "8", "9", "*",
                "4", "5", "6", "-",
                "1", "2", "3", "+",
                "neg", "0", ".", "="
            };
        public TableLayout(int height, int width, int row, int column, object textBox)
        {
            DisplayTextBox displayBox = (DisplayTextBox)textBox;
            this.Padding = new Padding(10,10, 10, 10);
            this.Height = height;
            this.Width = width;
            this.RowCount = row;
            this.ColumnCount = column;
            CreateButtonPanel(row,column);
        }

        public void CreateButtonPanel(int rows, int columns)
        {
            

            int buttonLabelCount = 0;

            for(int row = 0; row < rows; row++)
            {
                for(int  column = 0; column < columns; column++)
                {
                    Button button = new Button();

                    button.Text = buttonLabels[buttonLabelCount];
                    button.Width = this.Width/this.ColumnCount-20;
                    button.Height = this.Height/this.RowCount-20;
                    button.Click += ButtonClick;

                    this.Controls.Add(button);
                    buttonLabelCount++;
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string buttonText = button.Text;
            if (displayBox.Text == "0")
            {
                displayBox.Text = buttonText;
            }
            else if (button.Text == "=")
            {
                try
                {
                    ExpressionEvaluator evaluator = new ExpressionEvaluator();
                    double result = evaluator.Evaluate(displayBox.Text);
                    displayBox.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (button.Text == "." && displayBox.Text == "0")
            {
                displayBox.Text = "0" + buttonText;
            }
            else if (button.Text == "C" || button.Text == "CE")
            {
                displayBox.Text = "0";
            }
            else if (button.Text == "Del")
            {
                if (displayBox.Text.Length > 0)
                {
                    displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1);
                }
            }
            else
            {
                displayBox.Text += buttonText;
            }
        }
    }
}
