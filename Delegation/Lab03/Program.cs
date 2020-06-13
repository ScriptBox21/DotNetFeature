using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    delegate double DoubleOp(double x);

    class MathOperation
    {
        public static double MultipleByTwo(double value)
        {
            return value * 2;
        }

        public static double Square(double value)
        {
            return value * value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             //Delegate를 배열로 지정
            DoubleOp[] operation = 
                    {
                            new DoubleOp(MathOperation.MultipleByTwo),
                            new DoubleOp(MathOperation.Square)
                    };

            Console.WriteLine(operation[0](5.0));
            Console.WriteLine(operation[1](5.0));

            for(int i=0; i < operation.Length; i++)
            {
                Console.WriteLine("operation[{0}] 호출:", i);
                CallDelegate(operation[i], 5.0);  //Delegate를 다른 메소드의 인자로 넘긴다.
                Console.WriteLine();
            }
        }
        static void CallDelegate(DoubleOp func, double value)
        {
            //넘겨받은 Delegate를 실행 한다.
            double ret = func(value);
            Console.WriteLine("입력된 값은 {0}이고 결과는 {1} 이다", value, ret);
        }
    }
}
