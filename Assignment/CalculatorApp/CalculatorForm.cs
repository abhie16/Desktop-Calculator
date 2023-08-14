using MathLibrary;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using CalculatorApp.Properties;
using System.Drawing;

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
            LoadButtonsFromJson(Resources.SimpleButtonJsonPath);
		}

        private void InitializeComponent()
        {
            CalculatorFormMenu menuInstance = new CalculatorFormMenu();
			_tableLayout = new ButtonTableLayout();
            _dispalyTextBox = new DisplayTextbox();

            

            this.Dock = DockStyle.Fill;
            this.Text = Resources.FormText;
            this.Padding = new Padding(20);
            this.AutoSize = true;

            _toggleBtn = new Button();
            _toggleBtn.Font = new Font(_toggleBtn.Font.FontFamily, 10);
            _toggleBtn.AutoSize = true;
            _toggleBtn.BringToFront();
            _toggleBtn.Text = Resources.ScientificModeButtonText;

            _toggleBtn.Click += ToggleModeButtonClick;

            this.Controls.Add(_dispalyTextBox);
            this.Controls.Add(_toggleBtn);
            this.Controls.Add(_tableLayout);
            this.Menu = menuInstance.menu;

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
                    button.Click += ButtonClick;

                    button.Margin = new Padding(5);

                    _tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
                    _buttonDict.Add(button, buttonInfo.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
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
                else
                {
                    _dispalyTextBox.Text = "0";
				}
            }
            else
            {
                _dispalyTextBox.Text += buttonText;
            }
        }

        private void ToggleModeButtonClick(object sender, EventArgs e)
        {
            _isScientificMode = !_isScientificMode;

            if (!_isScientificMode)
            {
                _toggleBtn.Text = Resources.ScientificModeButtonText;
            }
            else if (_isScientificMode)
            {
                _toggleBtn.Text = Resources.SimpleModeButtonText;
            }

            _tableLayout.Controls.Clear();
            _buttonDict.Clear();

            if (_isScientificMode)
            {
                LoadButtonsFromJson(Resources.ScientificButtonJsonPath);
            }
            else
            {
                LoadButtonsFromJson(Resources.SimpleButtonJsonPath);
            }
        }


    }
}
