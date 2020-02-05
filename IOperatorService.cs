using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_On_Steroids_Program
{
    public interface IOperatorService
    {
        int Add(int num1, int num2);
        Double Add(Double num1, Double num2);
        int Sub(int num1, int num2);
        Double Sub(Double num1, Double num2);
        int Multiply(int num1, int num2);
        Double Multiply(Double num1, Double num2);
        int Div(int num1, int num2);
        Double Div(Double num1, Double num2);


    }
}
