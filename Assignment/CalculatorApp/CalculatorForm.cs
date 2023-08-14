using MathLibrary;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CalculatorApp
{
    public class CalculatorForm : Form
    {
        private Dictionary<Button, string> _buttonDict = new Dictionary<Button, string>();
        private ButtonTableLayout _tableLayout;
        private DisplayTextbox _dispalyTextBox;
        private bool _isScientificMode = false;
        private Button _toggleBtn;
        public CalculatorForm()
        {
            InitializeComponent();
            LoadButtonsFromJson("C:\\Users\\GPCTAdmin\\Desktop\\Abhishek_pandey_intern_iimt\\Assignment\\CalculatorApp\\ButtonsSimple.json");
        }

        private void InitializeComponent()
        {
            _tableLayout = new ButtonTableLayout();
            _dispalyTextBox = new DisplayTextbox();

            this.Dock = DockStyle.Fill;
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Padding = new Padding(20);
            this.AutoSize = true;

            _toggleBtn = new Button();
            _toggleBtn.Text = "ScientificMode";

            _toggleBtn.Click += ToggleModeButton_Click;

            this.Controls.Add(_dispalyTextBox);
            this.Controls.Add(_toggleBtn);
            this.Controls.Add(_tableLayout);

        }

        private void LoadButtonsFromJson(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);

                List<ButtonInfo> buttonInfoList = JsonConvert.DeserializeObject<List<ButtonInfo>>(json);

                foreach (var buttonInfo in buttonInfoList)
                {
                    CustomButton button = new CustomButton();
                    button.Text = buttonInfo.Text;
                    button.Click += Button_Click;

                    button.Margin = new Padding(5);

                    _tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
                    _buttonDict.Add(button, buttonInfo.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading buttons: {ex.Message}");
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string buttonText = _buttonDict[button];
            if (_dispalyTextBox.Text == "0")
            {
                _dispalyTextBox.Text = buttonText;
            }
            else if (button.Text == "=")
            {
                try
                {
                    ExpressionEvaluator evaluator = new ExpressionEvaluator();
                    double result = evaluator.Evaluate(_dispalyTextBox.Text);
                    _dispalyTextBox.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (button.Text == "." && _dispalyTextBox.Text == "0")
            {
                _dispalyTextBox.Text = "0" + buttonText;
            }
            else if (button.Text == "C" || button.Text == "CE")
            {
                _dispalyTextBox.Text = "0";
            }
            else if (button.Text == "Del")
            {
                if (_dispalyTextBox.Text.Length > 0)
                {
                    _dispalyTextBox.Text = _dispalyTextBox.Text.Remove(_dispalyTextBox.Text.Length - 1);
                }
            }
            else
            {
                _dispalyTextBox.Text += buttonText;
            }
        }

        private void ToggleModeButton_Click(object sender, EventArgs e)
        {
            _isScientificMode = !_isScientificMode;

            if (!_isScientificMode)
            {
                _toggleBtn.Text = "ScientificMode";
            }
            else if (_isScientificMode)
            {
                _toggleBtn.Text = "SimpleMode";
            }

            _tableLayout.Controls.Clear();
            _buttonDict.Clear();

            if (_isScientificMode)
            {
                LoadButtonsFromJson("C:\\Users\\GPCTAdmin\\Desktop\\Abhishek_pandey_intern_iimt\\Assignment\\CalculatorApp\\ButtonsScientific.json");
            }
            else
            {
                LoadButtonsFromJson("C:\\Users\\GPCTAdmin\\Desktop\\Abhishek_pandey_intern_iimt\\Assignment\\CalculatorApp\\ButtonsSimple.json");
            }
        }
    }
}
