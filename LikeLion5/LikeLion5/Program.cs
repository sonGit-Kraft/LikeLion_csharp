using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 변수 선언과 초기화를 한번에 수행
            int score = 100; // 정수형 변수 선언과 동시에 100으로 초기화
            double temperature = 36.5; // 실수형 변수 선언과 동시에 36.5로 초기화
            string city = "Seoul"; // 문자열 변수 선언과 동시에 초기화

            // 출력
            Console.WriteLine(score);
            Console.WriteLine(temperature);
            Console.WriteLine(city);

            // 같은 데이터 타입의 변수를 쉼표로 구분하여 선언
            int x = 10, y = 20, z = 30;

            // 출력
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            // 상수 선언
            const double Pi = 3.14159; // 실수형 상수 선언 및 초기화
            const int MaxScore = 100; // 정수형 상수 선언 및 초기화

            // Pi = 3.14; -> 오류 발생

            // 출력
            Console.WriteLine("Pi: " + Pi);
            Console.WriteLine("Max Score" + MaxScore);
        }
    }
}