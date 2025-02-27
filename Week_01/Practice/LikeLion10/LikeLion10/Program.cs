using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion10
{
    class Program
    {
        // 전역변수
        static int number = 20;

        // 매개변수도 반환값도 없는 함수
        static void PrintHello()
        {
            Console.WriteLine("안녕하세요.");
        }

        // 매개변수만 있는 함수
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        // 반환값만 있는 함수
        static int GetNumber()
        {
            number = 30; // 전역변수
            return 42;
        }

        // 매개변수와 반환값이 있는 함수
        static int Add(int a, int b)
        {
            return a + b;
        }

        // 기본값을 가진 매개변수 (디폴트 매개변수)
        static void Greet(string name = "손님")
        {
            Console.WriteLine($"안녕하세요, {name}");
        }

        // 함수 오버로딩(OverLoading)
        // 동일한 이름의 함수를 매개변수 타입이나 개수에 따라 정의
        
        // XML 문서 주석
        /// <summary>
        /// 두 수를 곱한 결과를 반환한다.
        /// </summary>
        /// <param name="a">첫 번째 수</param>
        /// <param name="b">두 번째 수</param>
        /// <returns>두 수를 곱한 결과</returns>
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static double Multiply(double a, double b)
        {
            return a * b;
        }

        // out 키워드 (여러 값을 반환할 때)
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;

            remainder = a % b;
        }

        // ref 키워드 (값을 '참조'하여 수정)
        static void Increase(ref int num)
        {
            num += 10;
        }

        // params 키워드 (가변 매개변수)
        static int Sum(params int[] numbers)
        {
            int total = 0;

            foreach(int num in numbers)
                total += num;

            return total;
        }

        // 재귀 함수(자기 자신을 호출)
        static int Factorial(int n)
        {
            if (n <= 1) return 1;

            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            PrintHello();
            PrintMessage("반갑습니다.");

            int num = GetNumber(); // num은 로컬변수
            Console.WriteLine(num);
            Console.WriteLine(number);

            Console.WriteLine(Add(3, 5));

            Greet();
            Greet("철수");

            Console.WriteLine(Multiply(3, 4));
            Console.WriteLine(Multiply(2.5, 3.5));

            int q, r;
            Divide(10, 3, out q, out r);

            Console.WriteLine($"몫: {q}, 나머지: {r}");

            int value = 5;
            Increase(ref value);
            Console.WriteLine(value);

            Console.WriteLine(Sum(1, 2, 3));

            Console.WriteLine($"Factorial(5): {Factorial(5)}");
        }
    }
}