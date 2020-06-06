using System;
using System.Collections.Generic;
using System.Text;

namespace ModelViewController100
{
    public abstract class Controller
    {
    }

    public class HomeController : Controller
    {
        public string Index(int num, string msg)
        {
            return $"HomeController - msg: {msg}, num: {num}";
        }

        public string Test()
        {
            return "HomeController - Test...";
        }
    }

    public class TestController : Controller
    {
        public string Index()
        {
            return "TestController - Index";
        }

        public string Test()
        {
            return "TestController - Test...";
        }
    }
}
