using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_On_Steroids_Program
{
    public partial class Calculator : Form
    {
        double val = 0;
        string functionOpt = "";
        bool functOptPressed = false;
        double _number = 0;

        //For MC, MR, MS, M+, M-
        decimal MemoryStore = 0;
        decimal EndResult = 0;

        OperatorService operatorService = new OperatorService();

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                if ((ansResult.Text == "0") || (functOptPressed))
                    ansResult.Clear();

                functOptPressed = false;
                Button btn = (Button)sender;
                if (btn.Text == ".")
                {
                    if (!(ansResult.Text.Contains(".")))
                    {
                        ansResult.Text = ansResult.Text + btn.Text;
                    }
                }
                else
                {
                    ansResult.Text = ansResult.Text + btn.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            ansResult.Text = "0";
            equation.Text = "";
        }

        private void mathOperation_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (val != 0)
                {
                    btnEqual.PerformClick();
                    functOptPressed = true;
                    functionOpt = btn.Text;
                    equation.Text = $"{val} {functionOpt}";
                }
                else
                {
                    functionOpt = btn.Text;
                    val = Double.Parse(ansResult.Text);
                    functOptPressed = true;
                    equation.Text = $"{val} {functionOpt}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
           
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                equation.Text = "";
                switch (functionOpt)
                {
                    case "+":
                        ansResult.Text = operatorService.Add(val, Double.Parse(ansResult.Text)).ToString();
                        break;
                    case "-":
                        ansResult.Text = operatorService.Sub(val, Double.Parse(ansResult.Text)).ToString();
                        break;
                    case "*":
                        ansResult.Text = operatorService.Multiply(val, Double.Parse(ansResult.Text)).ToString();
                        break;
                    case "/":
                        ansResult.Text = operatorService.Div(val, Double.Parse(ansResult.Text)).ToString();
                        break;
                    default:
                        break;
                }

                //reset the value
                val = double.Parse(ansResult.Text);
                functionOpt = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ansResult.Text = "0";
            val = 0;
            equation.Text = "";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            int lastCharPostion = ansResult.TextLength - 1;
            if (ansResult.TextLength == 1 || (ansResult.Text.Length == 2 && ansResult.Text.Contains("-")))
            {
                ansResult.Text = "0";
            }
            else
            {
                ansResult.Text = ansResult.Text.Remove(lastCharPostion, 1);
            }
        }

        private void buttonNegate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ansResult.Text.StartsWith("-"))
                {
                    ansResult.Text = ansResult.Text.Substring(1);
                }
                else if (!string.IsNullOrEmpty(ansResult.Text) && decimal.Parse(ansResult.Text) != 0)
                {
                    ansResult.Text = $"-{ansResult.Text}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        private void digitCalculate_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
            string ButtonText = btnPressed.Text;

            if (ButtonText == "MC")
            {
                //Memory Clear
                MemoryStore = 0;
                return;
            }

            if (ButtonText == "MR")
            {
                //Memory Recall
                ansResult.Text = MemoryStore.ToString();
                return;
            }

            if (ButtonText == "MS")
            {
                MemoryStore = Decimal.Parse(ansResult.Text);
                return;
            }

            if (ButtonText == "M-")
            {
                // Memory subtract
                MemoryStore -= EndResult;
                ansResult.Text = MemoryStore.ToString();
                return;
            }

            if (ButtonText == "M+")
            {
                // Memory add 
                MemoryStore += EndResult;
                ansResult.Text = MemoryStore.ToString();
                return;
            }
        }

        private void buttonFnctn_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
            string ButtonText = btnPressed.Text;

            if (ButtonText == "%")
                ansResult.Text = (val * (Double.Parse(ansResult.Text) / 100)).ToString();

            if (ButtonText == "1/x")
            {
                _number = Double.Parse(ansResult.Text);
                if (_number != 0.0)
                {
                    _number = 1 / _number;
                }
                ansResult.Text = _number.ToString();
            }

            if (ButtonText == "sqrt")
            {
                ansResult.Text = Math.Sqrt(Double.Parse(ansResult.Text)).ToString();
                val = Math.Sqrt(Double.Parse(ansResult.Text));
            }
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    btnZero.PerformClick();
                    break;
                case "1":
                    btnOne.PerformClick();
                    break;
                case "2":
                    btnTwo.PerformClick();
                    break;
                case "3":
                    btnThree.PerformClick();
                    break;
                case "4":
                    btnFour.PerformClick();
                    break;
                case "5":
                    btnFive.PerformClick();
                    break;
                case "6":
                    btnSix.PerformClick();
                    break;
                case "7":
                    btnSeven.PerformClick();
                    break;
                case "8":
                    btnEight.PerformClick();
                    break;
                case "9":
                    btnNine.PerformClick();
                    break;
                case "+":
                    btnPlus.PerformClick();
                    break;
                case "-":
                    btnMinus.PerformClick();
                    break;
                case "*":
                    btnMultiply.PerformClick();
                    break;
                case "/":
                    btnDivide.PerformClick();
                    break;
                case ".":
                    btnDecimal.PerformClick();
                    break;
                case "%":
                    btnPercentage.PerformClick();
                    break;
                case "=":
                    btnEqual.PerformClick();
                    break;
                case "ENTER":
                    btnEqual.PerformClick();
                    break;
                case "BACKSPACE":
                    btnBackspace.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ansResult.Text = "0";
            val = 0;
            equation.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ansResult.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                ansResult.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (ansResult.SelectionLength > 0)
                {
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        ansResult.SelectionStart = ansResult.SelectionStart + ansResult.SelectionLength;
                }
                ansResult.Paste();
            }
        }
    }
}
