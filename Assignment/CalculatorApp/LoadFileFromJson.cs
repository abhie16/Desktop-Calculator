using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.IO;

namespace CalculatorApp
{
	public class LoadFileFromJson : CalculatorForm
	{
		public Dictionary<Button, string> ButtonDictionary = new Dictionary<Button, string>();
		public void LoadButtonsFromJson(string filePath)
		{
			try
			{
				string json = File.ReadAllText(filePath);

				List<ButtonInfo> buttonInfoList = JsonConvert.DeserializeObject<List<ButtonInfo>>(json);

				foreach (var buttonInfo in buttonInfoList)
				{
					CustomButton button = new CustomButton();
					button.Text = buttonInfo.Text;
					button.Click += new EventHandler(new ButtonEventHandler().ButtonClick);

					button.Margin = new Padding(5);

					_tableLayout.Controls.Add(button, buttonInfo.Column, buttonInfo.Row);
					ButtonDictionary.Add(button, buttonInfo.Value);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
