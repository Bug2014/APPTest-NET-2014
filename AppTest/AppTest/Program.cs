using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppTest.TestCase;

namespace AppTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApkTestCase apktest = new ApkTestCase();
            //一个APP的例子          
            apktest.RunAppCase();
        }
    }
}
