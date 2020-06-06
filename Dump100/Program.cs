using System;
using System.Collections.Generic;
using System.Linq;

namespace Dump100
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            "Hello".Dump();
            List<string> list = new List<string>();
            list.Add("abc");
            list.Add("111");
            list.Dump();
        }
    }
}
