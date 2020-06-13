using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02
{
    delegate void doMath(int value);

    class Math
    {
        public int number;

        public void Plus(int value)
        {
            number += value;
        }

        public void Minus(int value)
        {
            number -= value;
        }

        public void Multiply(int value)
        {
            number *= value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Math m = new Math();
            doMath math = new doMath(m.Plus);
            math += new doMath(m.Minus);
            math += new doMath(m.Multiply);

            m.number = 10;
            math(10);
            Console.WriteLine("Result ==> {0}", m.number);


            math -= new doMath(m.Multiply);
            m.number = 5;
            math(10);
            Console.WriteLine("Result ==> {0}", m.number);

        }
    }
}
