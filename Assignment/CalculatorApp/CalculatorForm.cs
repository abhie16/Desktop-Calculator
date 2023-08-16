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
	public enum CalculatorModes
	{
		Simple,
		Scientific
	}
	public class CalculatorForm : Form
	{
		private Dictionary<Button, string> _buttonDict = new Dictionary<Button, string>();
		public ExpressionEvaluator Evaluator;
		public MemoryOperations MemoryOperation;
		private TableLayoutPanel _tableLayout;
		private TextBox _displayTextBox;
		private bool _isScientificMode = false;
        private bool _isOperatorAllowed = true;
        private Button _toggleBtn;
		public List<ButtonInfo> ButtonInfoList;
		public CalculatorForm()
		{
			Evaluator = new ExpressionEvaluator();
			MemoryOperation = new MemoryOperations();

			string json = File.ReadAllText(Resources.ButtonConfigFile);
			ButtonInfoList = JsonConvert.DeserializeObject<List<ButtonInfo>>(json);

			InitializeComponent();
			LoadButtonsFromJson();
		}

		private void InitializeComponent()
		{
			_tableLayout = new TableLayoutPanel();
			_displayTextBox = new TextBox();



			this.Dock = DockStyle.Fill;
			this.Text = Resources.FormText;
			this.Padding = new Padding(30);
			this.AutoSize = true;


			// toggle button
			_toggleBtn = new Button();
			_toggleBtn.Font = new Font(_toggleBtn.Font.FontFamily, 10);
			_toggleBtn.AutoSize = true;
			_toggleBtn.BringToFront();
			_toggleBtn.Text = Resources.ScientificModeButtonText;
			_toggleBtn.Location = new Point(0, 0);

			_toggleBtn.Click += ToggleModeButtonClick;


			// display text box
			_displayTextBox.Text = "0";
			_displayTextBox.Dock = DockStyle.Fill;
			_displayTextBox.SelectionStart = 0;
			_displayTextBox.SelectionLength = 1;
			_displayTextBox.ReadOnly = true;
			_displayTextBox.BorderStyle = BorderStyle.None;
			_displayTextBox.Font = new Font(_displayTextBox.Font.FontFamily, 26);
			_displayTextBox.TextAlign = HorizontalAlignment.Right;

			// table layout
			_tableLayout.Padding = new Padding(0, 50, 0, 0);
			_tableLayout.Dock = DockStyle.Fill;
			_tableLayout.AutoSize = true;

			// Menu bar
			MainMenu menu = new MainMenu();

			MenuItem edit = menu.MenuItems.Add(Resources.MenuItemEdit);
			edit.MenuItems.Add(new MenuItem(Resources.MenuSubitemCopy));
			edit.MenuItems.Add(new MenuItem(Resources.MenuSubitemPaste));

			MenuItem exit = menu.MenuItems.Add(Resources.MenuItemExit, new EventHandler(this.FormCloseOnClick));
			MenuItem help = menu.MenuItems.Add(Resources.MenuItemHelp, new EventHandler(this.HelpOnClick));


			// adding to form controls
			this.Controls.Add(_displayTextBox);
			this.Controls.Add(_toggleBtn);
			this.Controls.Add(_tableLayout);
			this.Menu = menu;

		}

		private void FormCloseOnClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void HelpOnClick(object sender, EventArgs e)
		{
			MessageBox.Show(Resources.HelpText);
		}

		private void LoadButtonsFromJson()
		{
			try
			{
                _tableLayout.Controls.Clear();
                foreach (var buttonInfo in ButtonInfoList)
				{
					Button button = new Button();
					button.Width = 50;
					button.Height = 50;
					button.Text = buttonInfo.Text;
					button.Margin = new Padding(5);
					button.Click += ButtonClick;
					button.KeyPress += ButtonPress;
					button.Focus();

					
					if (buttonInfo.Mode == CalculatorModes.Simple && !_tableLayout.Controls.Contains(button))
					{
						_tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
						_buttonDict.Add(button, buttonInfo.Value);
					}
					if(buttonInfo.Mode == CalculatorModes.Scientific && _isScientificMode == true && !_tableLayout.Controls.Contains(button))
					{
						_tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
						_buttonDict.Add(button, buttonInfo.Value);
					}
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

			if (_displayTextBox.Text == "0")
			{
				_isOperatorAllowed = true;
                _displayTextBox.Text = buttonText;
			}
			else if(buttonText == "MC" || buttonText == "M+" || buttonText == "M-" || buttonText == "MS" || buttonText == "MR")
			{
				CalculatorMemory(buttonText);
			}
			else if (button.Text == "=")
			{
				CalculateExpression();

            }
			else if (button.Text == "." && _displayTextBox.Text == "0")
			{
                _isOperatorAllowed = false;
                _displayTextBox.Text = "0" + buttonText;
			}
			else if (button.Text == "C" || button.Text == "CE")
			{
                _isOperatorAllowed = true;
                _displayTextBox.Text = "0";
			}
			else if (button.Text == "Del")
			{
				if (_displayTextBox.Text.Length > 0)
				{
					_displayTextBox.Text = _displayTextBox.Text.Remove(_displayTextBox.Text.Length - 1);
				}
				if(_displayTextBox.Text.Length == 0)
				{
					_displayTextBox.Text = "0";
				}
			}
            else if (IsNumeric(buttonText) || (IsOperator(buttonText) && _isOperatorAllowed))
            {
                _displayTextBox.Text += buttonText;
                _isOperatorAllowed = !IsOperator(buttonText);
            }
			else if (!IsOperator(buttonText))
			{
				_displayTextBox.Text += buttonText;
			}
        }

        private bool IsNumeric(string text)
        {
            return double.TryParse(text, out _);
        }

		private bool IsOperator(string text)
		{
			return text == "+" || text == "-" || text == "*" || text == "/" || text == "%" || text == ".";
        }

		private void CalculatorMemory(string text)
		{
			if(text == "MS")
			{
				if (IsNumeric(_displayTextBox.Text))
				{
					MemoryOperation.SaveToMemory(_displayTextBox.Text);
					_displayTextBox.Text = "0";
				}
			}
			else if(text == "MR")
			{
				_displayTextBox.Text = MemoryOperation.GetMemoryValue().ToString();
			}
			else if(text == "M+")
			{
                if (IsNumeric(_displayTextBox.Text))
                {
                    _displayTextBox.Text = MemoryOperation.AddToMemory().ToString();
                }
            }
            else if (text == "M-")
            {
                if (IsNumeric(_displayTextBox.Text))
                {
                    _displayTextBox.Text = MemoryOperation.SubtractFromMemory().ToString();
                }
            }
            else if (text == "MC")
            {
				MemoryOperation.ClearMemory();
				_displayTextBox.Text = "0";
            }
        }

        private void CalculateExpression()
		{
            try
            {
                double result = Evaluator.Evaluate(_displayTextBox.Text);
                _displayTextBox.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show(Resources.DialogBoxMessage);
            }
        }

		private void ButtonPress(object sender, KeyPressEventArgs e)
		{
			if (IsNumeric(e.KeyChar.ToString()))
			{
                _isOperatorAllowed = true;
                _displayTextBox.Text += e.KeyChar.ToString();
            }
                
			if(IsOperator(e.KeyChar.ToString()) && _isOperatorAllowed)
			{
				if (_displayTextBox.Text.Length > 0) {
					_displayTextBox.Text += e.KeyChar.ToString();
					_isOperatorAllowed = false;
				}
            }
        }
		private void ToggleModeButtonClick(object sender, EventArgs e)
		{
			_isScientificMode = !_isScientificMode;
            
            LoadButtonsFromJson();

			if (!_isScientificMode)
			{
				_toggleBtn.Text = Resources.ScientificModeButtonText;
			}
			else if (_isScientificMode)
			{        
                _toggleBtn.Text = Resources.SimpleModeButtonText;
			}
			
		}


	}
}
