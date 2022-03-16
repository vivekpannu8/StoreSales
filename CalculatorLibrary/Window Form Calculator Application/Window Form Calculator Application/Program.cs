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
        private TextBox DisplayField;
        
        private Button[] Button0 = new Button[20];
        

        public CalculatorForm()
        {
            // Set the form's caption, which will appear in the title bar.
            Font DisplayFont = new Font("Arial", 32);
            Font ButtonFont = new Font("Microsoft Sans Serif", 13);
            this.Text = "Calculator";
            this.MinimumSize = new Size(328, 400);
            this.BackColor = Color.White;
            
            DisplayField = new TextBox();
            {
                //Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                DisplayField.Location = new Point(3, 12);
                DisplayField.Size = new Size(306, 49);
                DisplayField.Font = DisplayFont;
                DisplayField.BorderStyle = BorderStyle.None;
                DisplayField.RightToLeft = RightToLeft.Yes;
            };
            this.Controls.Add(DisplayField);

            Panel Numbers = new Panel()
            {
                Size = new Size(230,186),
                //BackColor = Color.Green,
                Location = new Point(3,174),
                TabIndex = 1,
                BorderStyle = BorderStyle.None,
            };
            Panel DeleteSet = new Panel()
            {
                Size = new Size(230,92),
                //BackColor= Color.Cyan,
                Location = new Point(3,82)
            };
            Panel Operators = new Panel()
            {
                Size = new Size(75, 280),
                //BackColor = Color.Green,
                Location = new Point(231, 82),
                TabIndex = 0,
                
            };


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

            Button buttonC = new Button();
            Button buttonCE = new Button();
            Button buttonPercentage = new Button();
            Button buttonInverse = new Button();
            Button buttonRoot = new Button();
            Button buttonSquare = new Button();

            Button buttonEquals = new Button();
            Button buttonPlus = new Button();
            Button buttonMinus = new Button();
            Button buttonMultiply = new Button();
            Button buttonDivide = new Button();
            Button buttonX = new Button();

            void AddButtonsToPanels()
            {
                Numbers.Controls.Add(button7);
                Numbers.Controls.Add(button4);
                Numbers.Controls.Add(button1);
                Numbers.Controls.Add(buttonSign);
                Numbers.Controls.Add(button8);
                Numbers.Controls.Add(button5);
                Numbers.Controls.Add(button2);
                Numbers.Controls.Add(button0);
                Numbers.Controls.Add(button9);
                Numbers.Controls.Add(button6);
                Numbers.Controls.Add(button3);
                Numbers.Controls.Add(buttonDot);

                DeleteSet.Controls.Add(buttonC);
                DeleteSet.Controls.Add(buttonSquare);
                DeleteSet.Controls.Add(buttonCE);
                DeleteSet.Controls.Add(buttonRoot);
                DeleteSet.Controls.Add(buttonX);
                DeleteSet.Controls.Add(buttonInverse);

                Operators.Controls.Add(buttonPercentage);
                Operators.Controls.Add(buttonDivide);
                Operators.Controls.Add(buttonMultiply);
                Operators.Controls.Add(buttonMinus);
                Operators.Controls.Add(buttonPlus);
                Operators.Controls.Add(buttonEquals);
            }
            AddButtonsToPanels();

            SetCommonProperties(4,Numbers);
            SetCommonProperties(2,DeleteSet);
            SetCommonProperties(0,Operators);

            void SetCommonProperties(int j, Panel panel)
            {
                int check = j;
                if(j == 0)
                {
                    check = 10;
                }
                j = 0;
                int i = 0;
                foreach (Button button in panel.Controls)
                {
                    button.Size = new Size(75, 45);
                    button.Location = new Point(75 * j + 1 * j, 45 * i + 1 * i);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.Silver;
                    button.FlatAppearance.MouseOverBackColor = Color.LightGray;
                    if(check != 4)
                    {
                        button.BackColor = Color.WhiteSmoke;
                        button.ForeColor = Color.SteelBlue;
                    }
                    i++;
                    if (i == check)
                    {
                        i = 0;
                        j++;
                    }
                }
            }


            SetButtonsText();
            void SetButtonsText()
            {
                button0.Text = "0";
                button1.Text = "1";
                button2.Text = "2";
                button3.Text = "3";
                button4.Text = "4";
                button5.Text = "5";
                button6.Text = "6";
                button7.Text = "7";
                button8.Text = "8";
                button9.Text = "9";
                buttonDot.Text = "∙";
                buttonSign.Text = "+/-";
                buttonC.Text = "C";
                buttonCE.Text = "CE";
                buttonPercentage.Text = "%";
                buttonInverse.Text = "1/x";
                buttonRoot.Text = "√x";
                buttonSquare.Text = "x²";
                buttonEquals.Text = "=";
                buttonPlus.Text = "+";
                buttonMinus.Text = "-";
                buttonMultiply.Text = "×";
                buttonDivide.Text = "÷";
                buttonX.Text = "X";
            }

            Panel KeyPad = new Panel()
            {
                Size = new Size(310,400),
                //BackColor = Color.Green,
            };
            KeyPad.Controls.Add(Operators);
            KeyPad.Controls.Add(Numbers);
            KeyPad.Controls.Add(DeleteSet);
            this.Controls.Add(KeyPad);

            foreach (Panel button in KeyPad.Controls)
            {
                button.Font = ButtonFont;
                
            }

            AddEventHandlers();
            void AddEventHandlers()
            {
                foreach (Button button in Numbers.Controls)
                {
                    button.Click += new EventHandler(NumberHandler);
                }
            }

        }

        private void button1_Click(Object sender, EventArgs e)
        {
            DisplayField.Text += "1";
        }
        private void NumberHandler(Object sender, EventArgs e)
        {
            Button bttn = sender as Button;
            DisplayField.Text += bttn.Text;
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
