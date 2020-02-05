using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_On_Steroids_Program
{
    public class OperatorService : IOperatorService
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public int Div(int num1, int num2)
        {
            return num1 / num2;
        }

        public double Div(double num1, double num2)
        {
            return num1 / num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public int Sub(int num1, int num2)
        {
            return num1 - num2;
        }

        public double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
