using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace lab6
{
    public static class Calc
    {
        public delegate T OperationDelegate<T>(T x, T y);
        
        
        public static string GetOperation(string s)
        {
            Regex rgx = new Regex(@"[^\d-\(\),]+");
            MatchCollection mc = rgx.Matches(s);
            List<string> lm = new List<string>();
            foreach (Match m in mc)
            {
                lm.Add(m.Value);
                s = m.Value;
            }
            return s;
        }
      
        public static string DoOperation(string s)
        {          
            string[] operands;
            string operation;
            operands = GetOperands(s);
            operation = GetOperation(s);
            s = DoubleOperation[operation](double.Parse(operands[0]), double.Parse(operands[1])).ToString();          
            return s;
        }

       

        public static string[] GetOperands(string s)
        {
            Regex rgx = new Regex(@"[^\d,\.]");
            MatchCollection mc = rgx.Matches(s);
            List<string> lm = new List<string>();
            foreach (Match m in mc)
            {
                lm.Add(m.Value);
            }
            return s.Split(lm.ToArray(), StringSplitOptions.None);
        }

        public static Dictionary<string, OperationDelegate<double>> DoubleOperation =
            new Dictionary<string, OperationDelegate<double>>
        {
            //{ "+", delegate(double x, double y){ return x + y; } },
            //{ "-", delegate(double x, double y){ return x - y; } },
            //{ "*", delegate(double x, double y){ return x * y; } },
            //{ "/", delegate(double x, double y){ return x / y; } },
            { "+", (x, y) => x + y },
            { "-", (x, y) => x - y },
            { "*", (x, y) => x * y },
            { "/", (x, y) => x / y },
        };
    }
}
