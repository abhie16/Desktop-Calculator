using CalculatorApp.Properties;
using System;
using System.Windows.Forms;

namespace CalculatorApp
{
	public class CalculatorFormMenu
	{
		public MainMenu menu;
		public CalculatorFormMenu()
		{
			menu = new MainMenu();

			MenuItem edit = menu.MenuItems.Add(Resources.MenuItemEdit);
			edit.MenuItems.Add(new MenuItem(Resources.MenuSubitemCopy));
			edit.MenuItems.Add(new MenuItem(Resources.MenuSubitemPaste));

			MenuItem exit = menu.MenuItems.Add(Resources.MenuItemExit);
			
			MenuItem help = menu.MenuItems.Add(Resources.MenuItemHelp);
			
		}
	}
}
