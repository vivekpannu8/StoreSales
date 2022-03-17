using CalcLibrary;

namespace WinForms_Calculator
{
    public class CalculatorForm : Form
    {
        private TextBox DisplayField;
        private TextBox DisplayEquation;
        
        private Button button0 = new Button();
        private Button button1 = new Button();
        private Button button2 = new Button();
        private Button button3 = new Button();
        private Button button4 = new Button();
        private Button button5 = new Button();
        private Button button6 = new Button();
        private Button button7 = new Button();
        private Button button8 = new Button();
        private Button button9 = new Button();
        private Button buttonDot = new Button();
        private Button buttonSign = new Button();

        private Button buttonC = new Button();
        private Button buttonCE = new Button();
        private Button buttonPercentage = new Button();
        private Button buttonInverse = new Button();
        private Button buttonRoot = new Button();
        private Button buttonSquare = new Button();

        private Button buttonEquals = new Button();
        private Button buttonPlus = new Button();
        private Button buttonMinus = new Button();
        private Button buttonMultiply = new Button();
        private Button buttonDivide = new Button();
        private Button buttonX = new Button();

        //private Button[] Button0 = new Button[20];
        private List<Button> KeyPadButtons = new List<Button>();
        private string? Equation;
        private bool OperationPerformed;
        private CalculatorOperations Operation = new CalculatorOperations();

        public CalculatorForm()
        {
            // Set the form's caption, which will appear in the title bar.
            this.Text = "Calculator";
            Font DisplayFont = new Font("Arial", 25);
            Font AnswerFont = new Font("Arial", 15);
            Font ButtonFont = new Font("Microsoft Sans Serif", 13);
            this.MinimumSize = new Size(325, 414);
            this.BackColor = Color.White;

            DisplayField = new TextBox();
            {
                //Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                DisplayField.Location = new Point(3, 12);
                DisplayField.Size = new Size(303, 49);
                DisplayField.Font = DisplayFont;
                DisplayField.BorderStyle = BorderStyle.None;
                DisplayField.TextAlign = HorizontalAlignment.Right;
                //DisplayField.BackColor = Color.Red;
            };
            DisplayEquation = new TextBox();
            {
                //Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                DisplayEquation.Location = new Point(3, DisplayField.Bounds.Bottom + 5);
                DisplayEquation.Size = new Size(303, 49);
                DisplayEquation.Font = AnswerFont;
                DisplayEquation.BorderStyle = BorderStyle.None;
                DisplayEquation.TextAlign = HorizontalAlignment.Right;
                DisplayEquation.ForeColor = SystemColors.InactiveCaption;
            };
            this.Controls.Add(DisplayField);
            this.Controls.Add(DisplayEquation);

            Panel Numbers = new Panel()
            {
                Size = new Size(230, 186),
                //BackColor = Color.Green,
                Location = new Point(3, 174),
                //TabIndex = 1,
                BorderStyle = BorderStyle.None,
            };
            Panel DeleteSet = new Panel()
            {
                Size = new Size(230, 92),
                //BackColor= Color.Cyan,
                Location = new Point(3, 82)
            };
            Panel Operators = new Panel()
            {
                Size = new Size(75, 280),
                //BackColor = Color.Green,
                Location = new Point(231, 82),
                //TabIndex = 0,

            };


            void AddButtonsToPanels()
            {
                Numbers.Controls.AddRange(new Control[] 
                { button7, button4, button1, buttonSign, 
                    button8, button5, button2, button0, 
                    button9, button6, button3, buttonDot});

                DeleteSet.Controls.AddRange(new Control[] { buttonC, buttonSquare, buttonCE, buttonRoot, buttonX, buttonInverse });

                Operators.Controls.AddRange((Control[])new Control[] 
                {buttonPercentage, buttonDivide, buttonMultiply, 
                    buttonMinus, buttonPlus, buttonEquals});
            }
            AddButtonsToPanels();

            SetCommonProperties(4, Numbers);
            SetCommonProperties(2, DeleteSet);
            SetCommonProperties(0, Operators);

            void SetCommonProperties(int j, Panel panel)
            {
                int check = j;
                if (j == 0)
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
                    if (check != 4)
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
                buttonDot.Text = ".";
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
                Size = new Size(303, 275),
                BackColor = Color.Green,
                Location = new Point(DisplayEquation.Bounds.X, DisplayEquation.Bounds.Bottom + 3),
            };
                CreateButtons();
            //KeyPad.Controls.Add(Operators);
            //KeyPad.Controls.Add(Numbers);
            //KeyPad.Controls.Add(DeleteSet);
            this.Controls.Add(KeyPad);
            
            foreach (Button button in KeyPadButtons)
            {
                KeyPad.Controls.Add(button);

            }
            buttonPlus.Name = "+";
            buttonMinus.Name = "-";
            buttonMultiply.Name = "*";
            buttonDivide.Name = "/";
            //this.Controls.Add(button0);

            List<Button> NumericButtons = new List<Button>
            { button0, button1, button2, button3,
                button4, button5, button6, button7,
                button8, button9 };
            List<Button> KeypadOperators = new List<Button> {buttonPlus, buttonMinus,
                buttonMultiply, buttonDivide };
            AddEventHandlers();
            void AddEventHandlers()
            {
                int i = 0;
                foreach (Button button in NumericButtons)
                {
                    button.Click += new EventHandler(Numbers_Click);
                    button.Name = Convert.ToString(i);
                    i++;
                }
                foreach (Button button in KeypadOperators)
                {
                    button.Click += new EventHandler(OperatorHandler);
                }
                buttonEquals.Click += new EventHandler(buttonEquals_Click);
                buttonDot.Click += new EventHandler(buttonDot_Click);
            }
            //CreateButtons();
        }

        private void buttonEquals_Click(Object sender, EventArgs e)
        {
            DisplayField.Text = Convert.ToString(Operation.SolveEquation(Equation));
            //DisplayField.Text += "Result";
            DisplayEquation.Text = "";
            Equation = null;
            OperationPerformed = true;
        }
        private void buttonDot_Click(Object sender, EventArgs e)
        {
            Equation += ".";
            DisplayField.Text += ".";
        }
        private void Numbers_Click(Object sender, EventArgs e)
        {
            if(OperationPerformed == true)
            {
                DisplayField.Text = "";
                OperationPerformed = false;
            }
            Button bttn = sender as Button;
            Equation += bttn.Name;
            DisplayField.Text += bttn.Name;
            //DisplayEquation.Text = Equation;
        }
        private void OperatorHandler(Object sender, EventArgs e)
        {
            Button CurrentOperator = sender as Button;
            DisplayField.Text = Convert.ToString(Operation.SolveEquation(Equation));
            Equation += CurrentOperator.Name;
            DisplayEquation.Text = Equation.Replace('/', '÷');
            OperationPerformed = true;
        }
        private void Numbers_KeyPress(Object sender, EventArgs e)
        {

        }

        private void CreateButtons()
        {
            //this.BackColor = Color.Green;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(75, 45);
                    button.Location = new Point(75 * j + 1 * j, 45 * i + 1 * i);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.Silver;
                    button.FlatAppearance.MouseOverBackColor = Color.LightGray;
                    button.Text = "btton" + i + j;
                    //button.Visible = true;
                    KeyPadButtons.Add(button);
                }
            }
        }
        
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}