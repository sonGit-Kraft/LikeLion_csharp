using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 문제 1
            Console.Write("국어 점수 입력: ");
            int iKor = int.Parse(Console.ReadLine());
            Console.Write("영어 점수 입력: ");
            int iEng = int.Parse(Console.ReadLine());
            Console.Write("수학 점수 입력: ");
            int iMath = int.Parse(Console.ReadLine());

            int Sum = 0;
            float Average = 0.0f;

            Sum = iKor + iEng + iMath; // 총점
            Average = (float)Sum / 3; // 평균

            Console.WriteLine("총점 : " + Sum);
            Console.WriteLine("평균 : " + Average.ToString("F2")); // ToString("F2"): 소수점 2번째 자리까지 표시

            Console.WriteLine();

            // 문제 2
            Console.Write("정수 입력: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("원래 값: " + number);
            Console.WriteLine("비트 반전 값: " + ~number);
        }
    }
}