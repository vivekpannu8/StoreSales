using CalcLibrary;

namespace WinForms_Calculator
{
    public class CalculatorForm : Form
    {
        private TextBox DisplayField;
        private TextBox DisplayEquation;
        
        private List<Button> KeyPadButtons = new List<Button>();
        private List<Button> MemoryButtons = new List<Button>();
        private string? Equation;
        private string CurrentEntry;
        private bool OperationPerformed;
        private CalculatorOperations Operation = new CalculatorOperations();

        public CalculatorForm()
        {
            this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "Calculator";
            Font DisplayFont = new Font("Arial", 25);
            Font AnswerFont = new Font("Arial", 15);
            this.MinimumSize = new Size(325, 460);
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
            KeyPadButtons = CreateButtons(28,4,new Size(75,45),11);
            MemoryButtons = CreateButtons(5,5,new Size(60,30),8);
            //CreateMemoryButtons();

            SetButtonsText();
            void SetButtonsText()
            {
                KeyPadButtons[25].Text = "0";
                KeyPadButtons[20].Text = "1";
                KeyPadButtons[21].Text = "2";
                KeyPadButtons[22].Text = "3";
                KeyPadButtons[16].Text = "4";
                KeyPadButtons[17].Text = "5";
                KeyPadButtons[18].Text = "6";
                KeyPadButtons[12].Text = "7";
                KeyPadButtons[13].Text = "8";
                KeyPadButtons[14].Text = "9";
                KeyPadButtons[26].Text = ".";
                KeyPadButtons[24].Text = "+/-";
                KeyPadButtons[8].Text = "(";
                KeyPadButtons[9].Text = ")";
                KeyPadButtons[10].Text = "Log";
                KeyPadButtons[6].Text = "1/x";
                KeyPadButtons[5].Text = "√x";
                KeyPadButtons[4].Text = "x²";
                KeyPadButtons[27].Text = "=";
                KeyPadButtons[23].Text = "+";
                KeyPadButtons[19].Text = "-";
                KeyPadButtons[15].Text = "×";
                KeyPadButtons[11].Text = "÷";
                KeyPadButtons[7].Text = "Exp";
                KeyPadButtons[3].Text = "X";
                KeyPadButtons[2].Text = "CE";
                KeyPadButtons[1].Text = "C";
                KeyPadButtons[0].Text = "%";

                MemoryButtons[0].Text = "MC";
                MemoryButtons[1].Text = "MR";
                MemoryButtons[2].Text = "M+";
                MemoryButtons[3].Text = "M-";
                MemoryButtons[4].Text = "MS";
            }
            //KeyPadButtons[27].Name = "buttonEquals";
            KeyPadButtons[26].BackColor = SystemColors.InactiveCaption;
            KeyPadButtons[24].BackColor = SystemColors.InactiveCaption;
            Panel MemoryButton = new Panel()
            {
                //BackColor = Color.Green,
                Size = new Size(304, 30),
                Location = new Point(DisplayEquation.Bounds.X, DisplayEquation.Bounds.Bottom + 3),
            };
            Panel KeyPad = new Panel()
            {
                Size = new Size(304, 321),
                Location = new Point(MemoryButton.Bounds.X, MemoryButton.Bounds.Bottom + 1),
            };
            
            this.Controls.Add(KeyPad);
            this.Controls.Add(MemoryButton);

            foreach(Button button in MemoryButtons)
            {
                button.BackColor = Color.White;
                MemoryButton.Controls.Add(button);
            }

            foreach (Button button in KeyPadButtons)
            {
                KeyPad.Controls.Add(button);

            }
            KeyPadButtons[23].Tag = "+";
            KeyPadButtons[19].Tag = "-";
            KeyPadButtons[15].Tag = "*";
            KeyPadButtons[11].Tag = "/";
            //this.Controls.Add(button0);

            List<Button> NumericButtons = new List<Button>
            { KeyPadButtons[25],
            KeyPadButtons[20], KeyPadButtons[21], KeyPadButtons[22],
            KeyPadButtons[16], KeyPadButtons[17], KeyPadButtons[18],
            KeyPadButtons[12], KeyPadButtons[13], KeyPadButtons[14] };
            List<Button> KeypadOperators = new List<Button> {KeyPadButtons[23], KeyPadButtons[19],
                KeyPadButtons[15], KeyPadButtons[11] };
            AddEventHandlers();
            void AddEventHandlers()
            {
                int i = 0;
                foreach (Button button in NumericButtons)
                {
                    button.Click += new EventHandler(Numbers_Click);
                    button.BackColor = SystemColors.InactiveCaption;
                    button.Tag = Convert.ToString(i);
                    i++;
                }
                foreach (Button button in KeypadOperators)
                {
                    button.Click += new EventHandler(OperatorHandler);
                }
                KeyPadButtons[27].Click += new EventHandler(buttonEquals_Click);
                KeyPadButtons[26].Click += new EventHandler(buttonDot_Click);
                KeyPadButtons[3].Click += new EventHandler(buttonBackspace_Click);
                KeyPadButtons[2].Click += new EventHandler(buttonCE_Click);
                KeyPadButtons[1].Click += new EventHandler(buttonC_Click);
                KeyPadButtons[8].Click += new EventHandler(AddBracketsToEquation);
                KeyPadButtons[9].Click += new EventHandler(AddBracketsToEquation);
                KeyPadButtons[24].Click += new EventHandler(ValueSignChange);
                DisplayField.TextChanged += new EventHandler(DisplayField_TextChanged);

            }
        }
        private void ValueSignChange(Object sender, EventArgs e)
        {
            if(DisplayField.Text != "")
            DisplayField.Text = Convert.ToString(-Convert.ToDouble(DisplayField.Text));
        }
        private void AddBracketsToEquation(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Equation += button.Text;
            DisplayEquation.Text = Equation;
        }
        private void UpdateAnswer()
        {
            try
            {
                DisplayField.Text = Convert.ToString(Operation.SolveEquation(Equation));
            }
            catch (Exception ex)
            {
                DisplayEquation.Text = ex.Message;
            }
        }
        private void buttonEquals_Click(Object sender, EventArgs e)
        {
            Equation += DisplayField.Text;
            UpdateAnswer();
            //DisplayField.Text += "Result";
            DisplayEquation.Text = "";
            Equation = null;
            OperationPerformed = true;
        }
        private void DisplayField_TextChanged(Object sender, EventArgs e)
        {
            CurrentEntry = DisplayField.Text;
        }
        private void buttonDot_Click(Object sender, EventArgs e)
        {
            if (!DisplayField.Text.Contains('.'))
            {
                Equation += ".";
                DisplayField.Text += ".";
            }
        }
        private void Numbers_Click(Object sender, EventArgs e)
        {
            if(OperationPerformed == true)
            {
                DisplayField.Text = "";
                OperationPerformed = false;
            }
            Button bttn = sender as Button;
            DisplayField.Text += bttn.Tag;
            //DisplayEquation.Text = Equation;
        }
        private void OperatorHandler(Object sender, EventArgs e)
        {
            Button CurrentOperator = sender as Button;
            Equation += DisplayField.Text;
            UpdateAnswer();
            Equation += CurrentOperator.Tag;
            DisplayEquation.Text = Equation.Replace('/', '÷');
            OperationPerformed = true;
        }
        private void Numbers_KeyPress(Object sender, EventArgs e)
        {

        }
        private void buttonBackspace_Click(Object sender, EventArgs e)
        {
            if(DisplayField.Text != "")
            {
                DisplayField.Text = DisplayField.Text.Remove(DisplayField.Text.Length - 1,1);
            }
        }
        private void buttonCE_Click(object sender, EventArgs e)
        {
            DisplayField.Text = "";
        }
        private void buttonC_Click(Object sender, EventArgs e)
        {
            DisplayField.Text = "";
            DisplayEquation.Text = "";
            Equation = "";
        }
        private List<Button> CreateButtons( int NumberOfButtons, int ButtonsInOneLine, Size size, int FontSize)
        {
            Font ButtonFont = new Font("Arial", FontSize);
            List<Button> Buttons = new List<Button>();
            for (int i = 0; i < NumberOfButtons/ButtonsInOneLine; i++)
            {
                for (int j = 0; j < ButtonsInOneLine; j++)
                {
                    Button button = new Button();
                    button.Size = size;
                    button.Location = new Point(button.Size.Width * j + 1 * j, button.Size.Height * i + 1 * i);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.Silver;
                    button.FlatAppearance.MouseOverBackColor = Color.LightGray;
                    //button.AutoSize = true;
                    //button.AutoSizeMode = AutoSizeMode.GrowOnly;
                    button.BackColor = Color.Gray;
                    button.Font = ButtonFont;
                    Buttons.Add(button);
                }
            }
            return Buttons;
        }
       
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}