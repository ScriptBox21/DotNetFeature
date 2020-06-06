using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelViewController100
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception e)
            {
            }
        }


        static void Run()
        {
            var uri = new Uri("http://localhost/home/index?msg=Hello&num=3");
            var container = new MvcContainer();
            var result = container.Resolve(uri);
            Console.WriteLine(result.ToString());
        }
    }
}
