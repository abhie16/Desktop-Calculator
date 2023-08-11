using CalculatorForm.Properties;
using MathLibrary;
using System;
using System.Windows.Forms;

namespace CalculatorForm
{
    public class CalculatorForm : Form
    {
        private TextBox _displayTextBox;
        private TableLayoutPanel _tableLayoutPanel;

        public CalculatorForm()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.Text = Resources.FormName;
            this.Width = int.Parse(Resources.WidthCalculatorForm);
            this.Height = int.Parse(Resources.HeightCalculatorForm);
            

            _displayTextBox = new TextBox();
            _displayTextBox.Text = "0";
            _displayTextBox.Dock = DockStyle.Fill;
            _displayTextBox.SelectionStart = 0;
            _displayTextBox.SelectionLength = 1;
            _displayTextBox.ReadOnly = true;
            _displayTextBox.TextAlign = HorizontalAlignment.Right;
            _displayTextBox.BorderStyle = BorderStyle.None;

            _tableLayoutPanel = new TableLayoutPanel();
            _tableLayoutPanel.Dock = DockStyle.Fill;
            _tableLayoutPanel.RowCount = int.Parse(Resources.TableRow);
            _tableLayoutPanel.ColumnCount = int.Parse(Resources.TableColumn);
            _tableLayoutPanel.Padding = new Padding(20,20, 20, 20);    

            string[] buttonLabels =
            {
                "%", "CE", "C", "Del",
                "reci", "sq", "cube", "/",
                "7", "8", "9", "*",
                "4", "5", "6", "-",
                "1", "2", "3", "+",
                "neg", "0", ".", "="
            };

            int buttonIndex = 0;

            for(int row=0; row<_tableLayoutPanel.RowCount; row++)
            {
                for(int column=0; column<_tableLayoutPanel.ColumnCount; column++)
                {
                    Button button = new Button();
                    button.Text = buttonLabels[buttonIndex];
                    button.Width= this.Width/_tableLayoutPanel.ColumnCount -20;
                    button.Height = this.Height / _tableLayoutPanel.RowCount - 20;
                    button.Click += ButtonClick;

                    _tableLayoutPanel.Controls.Add(button);

                    buttonIndex++;
                }
            }

            this.Controls.Add(_displayTextBox);
            this.Controls.Add(_tableLayoutPanel);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string buttonText = button.Text;
            if(_displayTextBox.Text == "0")
            {
                _displayTextBox.Text = buttonText;
            }
            else if(button.Text == "=") {
                Calculate();
            }
            else if(button.Text == "." && _displayTextBox.Text == "0")
            {
                _displayTextBox.Text = "0" + buttonText;
            }
            else if(button.Text == "C" || button.Text == "CE")
            {
                _displayTextBox.Text = "0";
            }
            else if(button.Text == "Del")
            {
                if(_displayTextBox.Text.Length > 0)
                {
                    _displayTextBox.Text = _displayTextBox.Text.Remove(_displayTextBox.Text.Length-1);
                }
            }
            else
            {
                _displayTextBox.Text += buttonText;
            }
        }

        private void Calculate()
        {
            try
            {
                ExpressionEvaluator evaluator = new ExpressionEvaluator();
                double result = evaluator.Evaluate(_displayTextBox.Text);
                _displayTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
