using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    delegate void DelX1();
    delegate void DelX2(int x);
    class Test
    {
        public void X1()
        {
            Console.WriteLine("Test.X1() Method()");
        }

        public void X2(int x)
        {
            Console.WriteLine("Test.X2() Method() ==> {0}", x);
        }
    }

    class Program
    {
        private delegate string GetString();

        static void Main(string[] args)
        {
            int x = 30;
            GetString myMethod = new GetString(x.ToString);
            Console.WriteLine("문자열 : {0}", myMethod());

            Test t = new Test();
            t.X1();
            t.X2(3);

            DelX1 x1 = new DelX1(t.X1);
            DelX2 x2 = new DelX2(t.X2);

            x1();
            x2(3);
        }
    }
}
