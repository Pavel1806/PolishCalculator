using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PolishCalculator
{
    public class Check
    {
        /// <summary>
        /// Метод объединяющий все проверки
        /// </summary>
        /// <param name="str">проверяемое выражение в польской аннотации</param>
        /// <returns>наличие ошибок</returns>
        protected bool Checking(string str)
        {

            var a = CheckingCommaEnd(str);

            var b = NumberComma(str);

            var c = CheckingStartWith(str);

            var d = CheckingContains(str);

            if (a == false || b == false || c == false || d == false)
            {
                a = false;
            }

            return a;
        }
        bool CheckingCommaEnd(string str)
        {
            bool a = true;
            if (str.EndsWith(',') == true)
            {
                Console.WriteLine("Запятую после последней цифры не нужно ставить");
                Console.WriteLine("");
                a = false;

            }
            return a;
        }

        bool NumberComma(string str)
        {
            bool a = true;
            var array = str.Trim().Split(',');

            foreach (var item in array)
            {
                if (item == "")
                {
                    Console.WriteLine("У вас в выражении стоит две запятые подряд");
                    Console.WriteLine("");
                    a = false;
                    break;
                }
            }

            return a;

        }

        bool CheckingStartWith(string str)
        {
            bool a = true;
            var array = str.Trim().Split(',');

            if (array[0] != "/" && array[0] != "*" && array[0] != "-" && array[0] != "+")
            {
                Console.WriteLine("Выражение должно начинаться на знаки /, *, -, +");
                Console.WriteLine("");
                a = false;

            }
            return a;
        }

        bool CheckingContains(string str)
        {
            bool a = true;
            bool b = true;
            bool c = true;

            var array = str.Trim().Split(',');

            List<string> symbols = new List<string>();
            List<string> numbers = new List<string>();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == "/" || array[i - 1] == "*" || array[i - 1] == "-" || array[i - 1] == "+")
                {
                    continue;
                }
                else
                {
                    for (int y = 0; y < i - 1; y++)
                    {
                        symbols.Add(array[y]);
                    }
                    for (int z = i - 1; z < array.Length; z++)
                    {
                        numbers.Add(array[z]);
                    }
                    break;
                }
            }
            bool symbol;
            bool number;
            foreach (var item in numbers)
            {

                number = Regex.IsMatch(item, "^[0-9]+$");

                if (number == false)
                {
                    Console.WriteLine("В части где расположены цифры, должны располагаться только цифры через запятую");
                    Console.WriteLine("");
                    a = false;
                    break;
                }
            }

            foreach (var item in symbols)
            {
                symbol = Regex.IsMatch(item, "^[*-/+]+$");

                if (symbol == false)
                {
                    Console.WriteLine("В части где расположены математические знаки, должны располагаться только математические знаки '/ * - +' через запятую");
                    Console.WriteLine("");
                    b = false;
                    break;
                }
            }

            if (symbols.Count + 1 != numbers.Count)
            {
                Console.WriteLine("Количество математических знаков должно быть на один меньше, чем цифр");
                Console.WriteLine("");
                c = false;
            }

            if (a == false || b == false || c == false)
            {
                a = false;
            }
            return a;
        }

    }
}
