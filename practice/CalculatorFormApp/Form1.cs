using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorFormApp
{
    public partial class Form1 : Form
    {
        Button btn;
        TextBox inputTextBox;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Onclick(object sender, EventArgs e)
        {
            inputTextBox.Text += btn.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

            inputTextBox = new TextBox();
            this.Controls.Add(inputTextBox);

            inputTextBox.Size = new Size(500,50);
            inputTextBox.Location = new Point(0, 10);
            inputTextBox.Text = "0";
            inputTextBox.SelectionStart = 0;
            inputTextBox.SelectionLength = 1;
            inputTextBox.ReadOnly = true;
            inputTextBox.TabIndex = 0;
            inputTextBox.BorderStyle = BorderStyle.None;
         

            for(int i=0; i<10; i++)
            {
                ToolTip toolTip1 = new ToolTip();

                btn = new Button();
                btn.Text = i.ToString();
                btn.Size = new Size(50,50);
                btn.Location = new Point(50*i+1,100);
                this.Controls.Add(btn); 

                btn.Click += new EventHandler(Onclick);

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 3000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;

                toolTip1.SetToolTip(this.btn, "Digits"+i);
            }


            string[] operators = new string[] { "+", "-", "*", "/", "%", "x^2", "x^3", "1/x", "sqrt", "+/-", ".", "sin", "cos", "=" };
            
            for(int i=0; i< operators.Length; i++)
            {
                Button button = new Button();
                this.Controls.Add(button);
                button.Text = operators[i];
                button.Size = new Size(50, 50);
                button.Location = new Point(50 * i + 1, 200);
            }
        }

        
    }
}
