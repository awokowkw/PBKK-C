using System.Globalization;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        double secondNumber = 0;
        double result = 0;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text == "0" || txtDisplay.Text == "")
                txtDisplay.Text = button.Text;
            else
                txtDisplay.Text += button.Text;
        }

        private double Calculate(double a, double b, string op)
        {
            switch (op)
            {
                case "+":
                    return a + b;

                case "−":
                    return a - b;

                case "×":
                    return a * b;

                case "÷":
                    if (b == 0)
                        throw new DivideByZeroException();
                    return a / b;

                default:
                    return b;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                if (operation != "" && txtDisplay.Text != "")
                {
                    secondNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                    result = Calculate(firstNumber, secondNumber, operation);
                    txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
                    firstNumber = result;
                }
                else if (txtDisplay.Text != "")
                {
                    firstNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                }

                operation = button.Text;
                txtDisplay.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                btnClear_Click(sender, e);
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                secondNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                result = Calculate(firstNumber, secondNumber, operation);

                txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);

                firstNumber = result;
                operation = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = "";
            txtDisplay.Text = "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
                txtDisplay.Text += ".";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            else
                txtDisplay.Text = "0";
        }
    }
}
