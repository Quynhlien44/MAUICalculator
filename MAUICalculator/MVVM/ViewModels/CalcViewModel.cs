using Dangl.Calculator;
using PropertyChanged;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace MAUICalculator.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalcViewModel
    {
        public string Formula { get; set; }
        public string Result { get; set; } = "0";
        private bool isSquareRootActive = false;
        private bool isLastActionCalculate = false;

        public ICommand OperationCommand => new Command((number) =>
        {
            if (isLastActionCalculate)
            {
                Formula = "";
                isLastActionCalculate = false;
            }

            if (number.ToString() == "√")
            {
                if (!isSquareRootActive)
                {
                    Formula += "√";
                    isSquareRootActive = true;
                }
            }
            else
            {
                Formula += number;
            }
        });

        public ICommand ResetCommand =>
            new Command(() =>
            {
                Result = "0";
                Formula = "";
                isSquareRootActive = false;
            });

        public ICommand BackSpaceCommand =>
            new Command(() =>
            {
                if (isLastActionCalculate)
                {
                    return; // Do nothing if the last action was a calculation
                }

                if (Formula.Length > 0)
                {
                    if (Formula[Formula.Length - 1] == '√')
                    {
                        isSquareRootActive = false;
                        Formula = Formula.Substring(0, Formula.Length - 1);
                    }
                    else if (Formula.Length >= 3 && IsOperator(Formula.Substring(Formula.Length - 3)))
                    {
                        Formula = Formula.Substring(0, Formula.Length - 3);
                    }
                    else
                    {
                        Formula = Formula.Substring(0, Formula.Length - 1);
                    }
                }
            });

        public ICommand CalculateCommand =>
            new Command(() =>
            {
                if (Formula.Length == 0)
                    return;

                string processedFormula = ProcessSquareRoots(Formula);
                var calculation = Calculator.Calculate(processedFormula);
                Result = calculation.Result.ToString();
                isSquareRootActive = false;
                isLastActionCalculate = true;
            });

        private string ProcessSquareRoots(string formula)
        {
            // Regular expression to match square root expressions, including possible preceding numbers
            var regex = new Regex(@"((?<!\d)|^)(\d*√\d+(\.\d+)?)");
            return regex.Replace(formula, match =>
            {
                string fullMatch = match.Value;
                int rootIndex = fullMatch.IndexOf('√');

                if (rootIndex > 0)
                {
                    // There's a number before the square root
                    double precedingNumber = double.Parse(fullMatch.Substring(0, rootIndex));
                    double rootNumber = double.Parse(fullMatch.Substring(rootIndex + 1));
                    return (precedingNumber * Math.Sqrt(rootNumber)).ToString();
                }
                else
                {
                    // Just a square root without a preceding number
                    double rootNumber = double.Parse(fullMatch.Substring(1));
                    return Math.Sqrt(rootNumber).ToString();
                }
            });
        }

        private bool IsOperator(string str)
        {
            return str == " + " || str == " - " || str == " * " || str == " / ";
        }
    }
}