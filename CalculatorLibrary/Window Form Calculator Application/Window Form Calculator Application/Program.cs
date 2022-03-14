using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Window_Form_Calculator_Application
{
    public class CalculatorForm : Form
    {
        private Button[] Button0 = new Button[20];
        

        public CalculatorForm()
        {
            // Set the form's caption, which will appear in the title bar.
            this.Text = "Calculator";
            this.MinimumSize = new Size(328, 400);
            this.BackColor = Color.White;

            GroupBox Numbers = new GroupBox()
            {
                Size = new Size(1000,1000),
                BackColor = Color.Green,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Red,
                Location = new Point(0,60)
            };
            GroupBox Operators = new GroupBox();
            GroupBox DeleteSet = new GroupBox();

            Font DisplayFont = new Font("Arial", 32);
            TextBox DisplayField = new TextBox()
            {
                //Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                Location = new Point(0, 0),
                Size = new Size(306, 49),
                Font = DisplayFont,
                Margin = new Padding(3),
                BorderStyle = BorderStyle.None,
                RightToLeft = RightToLeft.Yes,
            };
            
            this.Controls.Add(DisplayField);
            
            
            // Create a Button control and set its properties.

            //int index = 0;
            //for(int i = 0; i < 3; i++)
            //{
            //    for(int j = 2; j <= 5; j++)
            //    {

            //        Button0[index] = new Button();
            //        //Button0[index].Location = new Point(75*i+2*i, 45*j+2*j);

            //        Button0[index].Left = 75*i+2*i;
            //        Button0[index].Top =  45*i+2*j;
            //        Button0[index].Name = "Button" + index;
            //        Button0[index].Size = new Size(75, 45);
            //        Button0[index].Text = ""+index;
            //        Button0[index].FlatStyle = FlatStyle.Flat;
            //        Button0[index].FlatAppearance.BorderSize = 0;
            //        Button0[index].BackColor = Color.WhiteSmoke;
            //        Numbers.Controls.Add(Button0[index]);
            //        index++;
            //    }
            //}
            Button button0 = new Button();
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();
            Button button4 = new Button();
            Button button5 = new Button();
            Button button6 = new Button();
            Button button7 = new Button();
            Button button8 = new Button();
            Button button9 = new Button();
            Button buttonDot = new Button();
            Button buttonSign = new Button();

            //button9.Location = new Point(0, 0);
            //button6.Location = new Point(0, 45+2);
            //button3.Location = new Point(0, 45 + 2 * 2);
            //button8.Location = new Point(75 + 2, 0);
            //button5.Location = new Point(75 + 2, 45 + 2);
            //button2.Location = new Point(75 + 2, 45 + (2 * 2));
            //button7.Location = new Point(75 + 2*2, 0);
            //button4.Location = new Point(75 + 2*2, 45 + 2);
            //button1.Location = new Point(75 + 2*2, 45 + (2 * 2));
            
            Numbers.Controls.Add(button0);
            Numbers.Controls.Add(button1);
            Numbers.Controls.Add(button2);
            Numbers.Controls.Add(button3);
            Numbers.Controls.Add(button4);
            Numbers.Controls.Add(button5);
            Numbers.Controls.Add(button6);
            Numbers.Controls.Add(button7);
            Numbers.Controls.Add(button8);
            Numbers.Controls.Add(button9);
            Numbers.Controls.Add(buttonDot);
            Numbers.Controls.Add(buttonSign);

            int i = 0;
            int j = 0;
            foreach(Button button in Numbers.Controls)
            {
                button.Size = new Size(75,45);
                button.BackColor = Color.Gray;
                button.Location = new Point(75*j + 1*j, 45*i + 1*i);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = SystemColors.InactiveBorder;
                button.Text = i.ToString();

                i++;
                if (i == 4)
                {
                    i = 0;
                    j++;
                }
            }

            this.Controls.Add(Numbers);
            //Label label1 = new Label()
            //{
            //    Text = "&First Name",
            //    Location = new Point(10, 10),
            //    TabIndex = 10
            //};


            //Controls.Add(label1);
            //Controls.Add(field1);
        }


        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
