using System;

namespace PolishCalculator
{
    class Calculator1 : Calc
    {
        
        /// <summary>
        /// Метод для старта калькулятора
        /// </summary>
        public void CalculatorSt()
        {
            Console.WriteLine("Введите выражение, записанное в польской аннотации. Все знаки и цифры через запятую");

            string str = Console.ReadLine();

            if (base.Checking(str) == true)
            {
                var result = base.Result(str);

                Console.WriteLine(result);
            }
        }  
    }
}
