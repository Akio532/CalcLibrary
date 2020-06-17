using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculationWPF
{
   
    public partial class MainWindow : Window
    {
        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            int num;
            if (textBlock.Text == "0" && leftop != "0") textBlock.Text = "";           
            textBlock.Text += s;
            if (Int32.TryParse(s, out num))
            {
                if (operation == "")
                    leftop += s;
                rightop += s;
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "0";
                }
                else if (s == "DEL")
                {
                    if (operation == "" && !leftop.Equals(""))
                    {
                        leftop = leftop.Remove(leftop.Length - 1);
                        textBlock.Text = leftop;
                    }
                    else if (!rightop.Equals(""))
                    {
                        rightop = rightop.Replace(rightop.Last(), ' ');
                        textBlock.Text = leftop + operation + rightop;
                    }
                    if (leftop.Equals("") || leftop.Equals(""))
                        textBlock.Text = "";
                }
                else if (s == "+/-")
                {
                    try
                    {
                        if (operation == "")
                        {
                            if (leftop[0] != '-') leftop = leftop.Insert(0, "-");
                            else leftop = leftop.Replace("-", " ");
                            textBlock.Text = leftop;
                        }
                        else
                        {
                            if (rightop[0] != '-') rightop = rightop.Insert(0, "-");
                            else rightop = rightop.Replace("-", " ");
                            textBlock.Text = leftop + operation + '(' + rightop + ')';
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Чтобы сменить знак, сначала введите число!");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "1/x")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        if (number != 0)
                        {
                            leftop = Math.Pow(number, -1).ToString();
                            textBlock.Text = leftop;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Введите число!");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "x!")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        int digit = 1;
                        for (int i = 2; i <= number; i++) digit *= i;
                        if (digit < int.MaxValue)
                            leftop = digit.ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Сначала введите x!");
                        textBlock.Text = "0";
                    }
                }
                else if (s == "√")
                {
                    try
                    {
                        double n = double.Parse(leftop);
                        if (n >= 0)
                        {
                            leftop = Math.Sqrt(n).ToString();
                            textBlock.Text = leftop;
                        }
                        else
                        {
                            MessageBox.Show("Только для положительных чисел");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Сначала введите число из которого хотите извлечь корень!");
                        textBlock.Text = "0";
                    }
                }
                else if (s == "x^2")
                {
                    try
                    {
                        if (rightop == "")
                        {
                            int number = int.Parse(leftop);
                            int digit = number * number;
                            if (digit < int.MaxValue)
                                leftop = digit.ToString();
                            textBlock.Text = leftop;
                        }
                        else
                        {
                            int number = int.Parse(rightop);
                            int digit = number * number;
                            if (digit < int.MaxValue)
                                rightop = digit.ToString();
                            textBlock.Text = rightop;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Сначала введите число которое хотите возвести в квадрат!");
                        textBlock.Text = "0";
                    }
                }
                else if (s == "sin")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Sin(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        if (leftop == "" || leftop == "0")
                        {
                            MessageBox.Show("Сначала введите число!");
                            textBlock.Text = "0";
                        }
                    }
                }
                else if (s == "cos")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Cos(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        if (leftop == "" || leftop == "0")
                        {
                            MessageBox.Show("Сначала введите число!");
                            textBlock.Text = "0";
                        }
                    }
                }
                else if (s == "tan")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Tan(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        if (leftop == "" || leftop == "0")
                        {
                            MessageBox.Show("Сначала введите число!");
                            textBlock.Text = "0";
                        }
                    }
                }
                else if (s == "e")
                {
                    if (leftop == "")
                    {
                        leftop = Math.Exp(1).ToString();
                        textBlock.Text = leftop;
                    }
                    else
                    {
                        rightop = Math.Exp(1).ToString();
                        textBlock.Text = rightop;
                    }
                }
                else if (s == "e^x")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Exp(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        if (leftop == "" || leftop == "0")
                        {
                            MessageBox.Show("Сначала введите степень в которую хотите возвести e!");
                            textBlock.Text = "0";
                        }
                    }
                }
                else if (s == "П")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "0";
                    leftop = Math.PI.ToString();
                    textBlock.Text = leftop;
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            double num1 = Double.Parse(leftop);
            double num2 = Double.Parse(rightop);
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    if (num2 != 0)
                        rightop = (num1 / num2).ToString();
                    break;
                case "MOD":
                    if (num2 != 0)
                        rightop = (num1 % num2).ToString();
                    break;
                case "DIV":
                    if (num2 != 0)
                        rightop = Math.Truncate((double)num1 / num2).ToString();
                    break;
                case "^":
                    rightop = Math.Pow(num1, num2).ToString();
                    break;
            }
        }
    }
    }

