using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0); // 짝수만 저장

            Console.WriteLine("짝수 출력: ");
            // 짝수 출력
            foreach (var num in evenNumbers)
                Console.WriteLine(num);

            Console.WriteLine("\n모든 수의 합 출력: ");
            // 모든 수의 합 출력
            Console.WriteLine(numbers.Sum());
        }
    }
}