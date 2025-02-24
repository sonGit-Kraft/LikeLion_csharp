using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TodayTask6
{
    class Program
    {
        static void Main(string[] args)
        {
            // 문제 1
            Console.Write("세 개의 정수 입력: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' '); // 공백을 기준으로 끊어서 문자열 배열 생성
            int[] num = new int[3];

            for (int i = 0; i < 3; i++)
                num[i] = int.Parse(numbers[i]);

            // 최댓값 찾기
            int max = num[0];
            for (int i = 1; i < 3; i++)
                if (max < num[i])
                    max = num[i];

            Console.WriteLine("최댓값: " + max);

            Console.WriteLine();

            // 문제 2
            Console.Write("점수 입력: ");
            int score = int.Parse(Console.ReadLine());

            if (score >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else if (score < 90 && score >= 80)
            {
                Console.WriteLine("B 학점");
            }
            else if (score < 80 && score >= 70)
            {
                Console.WriteLine("C 학점");
            }
            else if (score < 70 && score >= 60)
            {
                Console.WriteLine("D 학점");
            }
            else if (score < 60)
            {
                Console.WriteLine("F 학점");
            }

            Console.WriteLine();

            // 문제 3
            Console.Write("수식입력: ");

            string exinput = Console.ReadLine();
            string[] ex = exinput.Split(' ');

            int a = int.Parse(ex[0]);
            char operation = char.Parse(ex[1]);
            int b = int.Parse(ex[2]);

            int result = 0;
            if (operation == '+')
            {
                result = a + b;
            }
            else if (operation == '-')
            {
                result = a - b;
            }
            else if (operation == '*')
            {
                result = a * b;
            }
            else if (operation == '/')
            {
                if (b == 0)
                {
                    Console.WriteLine("결과: X");
                    return; // 프로그램 종료
                }
                else
                    result = a / b;
            }

            Console.WriteLine($"{a} {operation} {b} = {result}");
        }
    }
}