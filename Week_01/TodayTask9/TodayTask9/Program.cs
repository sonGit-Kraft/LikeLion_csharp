using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask9
{
    class Program
    {
        static void Main(string[] args)
        {
            // 문제 1
            Console.WriteLine("문제 1");

            int[] arr1 = new int[] { 10, 20, 30, 40, 50 };
            foreach (int num in arr1)
                Console.Write($"{num} ");


            Console.WriteLine("\n\n==================================\n");

            // 문제 2
            Console.WriteLine("문제 2");

            int[] arr2 = new int[5];
            int sum = 0;

            Console.Write("숫자 입력: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            for (int i = 0; i < 5; i++)
            {
                arr2[i] = int.Parse(numbers[i]);
                sum += arr2[i];
            }
            Console.WriteLine("총 합: " + sum);

            Console.WriteLine("\n==================================\n");

            // 문제 3
            Console.WriteLine("문제 3");
            int[] arr3 = new int[] { 3, 8, 15, 6, 2 };

            int max = arr3[0];
            for (int i = 1; i < 5; i++)
                if (arr3[i] > max)
                    max = arr3[i];

            Console.WriteLine("최대값: " + max);

            Console.WriteLine("\n==================================\n");

            // 문제 4
            Console.WriteLine("문제 4");
            for (int i = 1; i <= 10; i++)
                Console.Write($"{i} ");

            Console.WriteLine("\n\n==================================\n");

            // 문제 5
            Console.WriteLine("문제 5");

            int index = 1;
            while (index <= 10)
            {
                if (index % 2 == 0)
                    Console.Write($"{index} ");
                index++;
            }


            Console.WriteLine("\n\n==================================\n");

            // 문제 6
            Console.WriteLine("문제 6");

            int[] arr6 = new int[] { 1, 2, 3, 4, 5};
            foreach (int num in arr6)
                Console.Write($"{num} ");

            Console.WriteLine("\n\n==================================\n");

            // 문제 7
            Console.WriteLine("문제 7");

            Console.Write("두 수 입력: ");
            input = Console.ReadLine();
            string[] number = input.Split(' ');
            int a = int.Parse(number[0]);
            int b = int.Parse(number[1]);
            Console.WriteLine($"{a}와 {b}의 합: {a+b}");

            Console.WriteLine("\n==================================\n");

            // 문제 8
            Console.WriteLine("문제 8");

            Console.Write("문자열 입력: ");
            string str = Console.ReadLine();
            Console.Write("문자열 길이: " + str.Length);

            Console.WriteLine("\n\n==================================\n");

            // 문제 9
            Console.WriteLine("문제 9");

            int[] arr9 = new int[3];

            Console.Write("세 개의 정수 입력: ");
            input = Console.ReadLine();
            string[] inputNum = input.Split(' ');
            
            for (int i = 0; i < 3; i++)
                arr9[i] = int.Parse(inputNum[i]);

            int Max = arr9[0];

            for (int i = 1; i < 3; i++)
                if (arr9[i] > Max)
                    Max = arr9[i];

            Console.WriteLine("가장 큰 수: " + Max);
        }
    }
}