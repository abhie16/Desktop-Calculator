using CalculatorApp.Properties;
using MathLibrary;
using System;
using System.Windows.Forms;

namespace CalculatorApp
{
	public class ButtonEventHandler : CalculatorForm
	{

		private bool _isScientificMode = false;

		LoadFileFromJson LoadJsonFile;
		public void ButtonClick(object sender, EventArgs e)
		{
			
			Button button = (Button)sender;

			string buttonText = LoadJsonFile.ButtonDictionary[button];
			if (DispalyTextBox.Text == "0")
			{
				DispalyTextBox.Text = buttonText;
			}
			else if (button.Text == "=")
			{
				try
				{
					ExpressionEvaluator evaluator = new ExpressionEvaluator();
					double result = evaluator.Evaluate(DispalyTextBox.Text);
					DispalyTextBox.Text = result.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else if (button.Text == "." && DispalyTextBox.Text == "0")
			{
				DispalyTextBox.Text = "0" + buttonText;
			}
			else if (button.Text == "C" || button.Text == "CE")
			{
				DispalyTextBox.Text = "0";
			}
			else if (button.Text == "Del")
			{
				if (DispalyTextBox.Text.Length > 0)
				{
					DispalyTextBox.Text = DispalyTextBox.Text.Remove(DispalyTextBox.Text.Length - 1);
				}
				else
				{
					DispalyTextBox.Text = "0";
				}
			}
			else
			{
				DispalyTextBox.Text += buttonText;
			}
		}

		public void ToggleModeButtonClick(object sender, EventArgs e)
		{
			LoadJsonFile = new LoadFileFromJson();
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
			LoadJsonFile.ButtonDictionary.Clear();

			if (_isScientificMode)
			{
				LoadJsonFile.LoadButtonsFromJson(Resources.ScientificButtonJsonPath);
			}
			else
			{
				LoadJsonFile.LoadButtonsFromJson(Resources.SimpleButtonJsonPath);
			}
		}
	}
}
