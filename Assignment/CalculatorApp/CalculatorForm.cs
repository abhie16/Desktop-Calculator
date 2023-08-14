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
		ExpressionEvaluator evaluator;
		private TableLayoutPanel _tableLayout;
		private TextBox _displayTextBox;
		private bool _isScientificMode = false;
		private Button _toggleBtn;
		List<ButtonInfo> buttonInfoList;
		public CalculatorForm()
		{
			evaluator = new ExpressionEvaluator();

			string json = File.ReadAllText(Resources.ButtonConfigFile);
			buttonInfoList = JsonConvert.DeserializeObject<List<ButtonInfo>>(json);

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
			_displayTextBox.MaximumSize = new Size(1000, 50);
			_displayTextBox.ReadOnly = true;
			_displayTextBox.BorderStyle = BorderStyle.None;
			_displayTextBox.Font = new Font(this.Font.FontFamily, 26);
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

			MenuItem exit = menu.MenuItems.Add(Resources.MenuItemExit);
			MenuItem help = menu.MenuItems.Add(Resources.MenuItemHelp);


			// adding to form controls
			this.Controls.Add(_displayTextBox);
			this.Controls.Add(_toggleBtn);
			this.Controls.Add(_tableLayout);
			this.Menu = menu;

		}

		private void LoadButtonsFromJson()
		{
			_tableLayout.Controls.Clear();
			try
			{

				foreach (var buttonInfo in buttonInfoList)
				{
					Button button = new Button();

					button.Width = 50;
					button.Height = 50;
					button.Text = buttonInfo.Text;
					button.Margin = new Padding(5);
					button.Click += ButtonClick;

					if (buttonInfo.Mode == CalculatorModes.Simple && !_tableLayout.Contains(button))
					{
						_tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
						_buttonDict.Add(button, buttonInfo.Value);
					}
					if(buttonInfo.Mode == CalculatorModes.Scientific && _isScientificMode == true && !_tableLayout.Contains(button))
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
				_displayTextBox.Text = buttonText;
			}
			else if (button.Text == "=")
			{
				try
				{
					double result = evaluator.Evaluate(_displayTextBox.Text);
					_displayTextBox.Text = result.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else if (button.Text == "." && _displayTextBox.Text == "0")
			{
				_displayTextBox.Text = "0" + buttonText;
			}
			else if (button.Text == "C" || button.Text == "CE")
			{
				_displayTextBox.Text = "0";
			}
			else if (button.Text == "Del")
			{
				if (_displayTextBox.Text.Length > 0)
				{
					_displayTextBox.Text = _displayTextBox.Text.Remove(_displayTextBox.Text.Length - 1);
				}
				else
				{
					_displayTextBox.Text = "0";
				}
			}
			else
			{
				_displayTextBox.Text += buttonText;
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
