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
        private Button[] Button0 = new Button[12];
        

        public CalculatorForm()
        {
            // Set the form's caption, which will appear in the title bar.
            this.Text = "Calculator";
            int i = 1;
            // Create a Button control and set its properties.
            for(int j = 0; j < 11; j++)
            {

                Button0[i] = new Button();
                Button0[i].Location = new Point(89+80*i, 12+50*i);
                Button0[i].Name = "btnHello";
                Button0[i].Size = new Size(80, 50);
                Button0[i].Text = "Say Hello"+i;
                i++;
            this.Controls.Add(Button0[j]);
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
