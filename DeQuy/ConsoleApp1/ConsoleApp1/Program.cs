using System;

namespace ConsoleApp1
{
    class Program
    {
       int n = 3;
        static void Main(string[] args)
        {
            #region Hello region
            //Console.WriteLine("Hello region");
            #endregion
            
            n = n * 3;
            Console.WriteLine(n);
            
        }
    }
}
