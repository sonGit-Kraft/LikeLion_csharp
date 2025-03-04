using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask15
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("정수 입력: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(number);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("올바른 숫자를 입력하세요!");
            }
        }
    }
}