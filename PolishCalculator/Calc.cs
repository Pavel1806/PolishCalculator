using System;
using System.Collections.Generic;
using System.Text;

namespace PolishCalculator
{
    public class Calc : Check
    {
        /// <summary>
        /// Метод бизнес логики калькулятора
        /// </summary>
        /// <param name="str1">выражение в польской аннотации</param>
        /// <returns>результат вычисления</returns>
        protected double Result(string str1)
        {
            double a = 0;
            double b ;

            string str = str1 + ", ,";
            var array = str.Trim().Split(',');

            Stack<double> number = new Stack<double>();
            Stack<string> action = new Stack<string>();

            foreach (var item in array)
            {
                if (@"+-*/".IndexOf(item) > -1)
                {
                    action.Push(item);
                    continue;
                }

                if (number.Count == 2)
                {
                    a = number.Pop();
                    b = number.Pop();
                    string operation = action.Pop();

                    switch (operation)
                    {
                        case "+":
                            number.Push(b + a);
                            break;
                        case "-":
                            number.Push(b - a);
                            break;
                        case "*":
                            number.Push(b * a);
                            break;
                        case "/":
                            if(a==0)
                            {
                                Console.WriteLine("Делить на ноль нельзя");
                                break;
                            }
                            else
                            {
                                number.Push(b / a);
                            }
                            
                            break;
                    }

                    
                    if (double.TryParse(item, out double i))
                    {
                        if (a != 0) 
                        {
                            number.Push(i);
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (double.TryParse(item, out double j))
                    {
                        number.Push(j);
                        continue;
                    }
                }
            }
            if(a==0)
            {
                
                return 0;
            }
            else
            {
                return number.Pop();
            }
            
        }
        /// <summary>
        /// Общая проверка 
        /// </summary>
        /// <param name="str">проверяемое выражение в польсой аннотации</param>
        /// <returns>наличие ошибок</returns>
        protected new bool Checking(string str)
        {
            return base.Checking(str);
        }
    }
}
