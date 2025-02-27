using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion12
{
    // 열거형 Enumeration enum
    // 숫자 값에 이름을 부여하는 자료형
    // 가독성을 높이고, 의미 있는 값으로 표현 가능
    // 기본적으로 첫 번째 값은 0부터 시작하여 1씩 증가
    enum DayOfWeek
    {
        Sunday, // 0
        Monday, // 1
        Tuesday, // 2
        Wednesday, // 3
        Thursday, // 4
        Friday, // 5
        Saturday // 6
    }

    // enum 값 변경 (0부터 시작하지 않기)
    // 열거형 항목에 숫자 값을 지정
    enum StatusCode { Success = 200, NotFound = 404, ServerError = 500 }

    class Program
    {
        static void Main(string[] args)
        {
            // Math 클래스 사용
            // 수학적 계산
            Console.WriteLine($"Pi: {Math.PI}"); // 원주율
            Console.WriteLine($"Square root of 25: {Math.Sqrt(25)}"); // 루트
            Console.WriteLine($"Power (2^3): {Math.Pow(2, 3)}"); // 제곱
            Console.WriteLine($"Round(3.75): {Math.Round(3.75)}"); // 반올림

            // enum (숫자를 직접 사용하지 않고, 의미 있는 이름으로 관리 가능)
            DayOfWeek today = DayOfWeek.Wednesday;
            Console.WriteLine(today);
            Console.WriteLine((int)today);

            StatusCode status = StatusCode.NotFound;
            Console.WriteLine(status);
            Console.WriteLine((int)status);
        }
    }
}