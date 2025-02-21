using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 변수 선언: 데이터 타입과 변수 이름을 지정
            int age; // 정수형 변수 선언 
            age = 25; // 변수 값 저장

            Console.WriteLine(age); // 변수에 저장된 값 출력

            // 리터럴: 코드에서 고정된 값
            // 100, 56.7, "???", 'S' 등이 리터럴
            // 리터럴은 "변하지 않는 값"으로, 변수에 할당하거나 직접 사용
            int hp = 100; // 정수형 리터럴
            double att = 56.7; // 실수형 리터럴
            string name = "???"; // 문자열 리터럴
            char grade = 'S'; // 문자형 리터럴

            Console.WriteLine("캐릭터");
            Console.WriteLine("체력: " + hp);
            Console.WriteLine("공격력: " + att);
            Console.WriteLine("이름: " + name);
            Console.WriteLine("등급: " + grade);

            // 변수 선언 후 값 저장
            string greeting; // 문자열 변수 선언
            greeting = "Hello, World!"; // 변수에 값 저장

            Console.WriteLine(greeting);

            // 변수 선언과 초기화를 한번에 수행
            int score = 100; // 정수형 변수 선언과 동시에 100으로 초기화
            double temperature = 36.5; // 실수형 변수 선언과 동시에 36.5로 초기화
            string city = "Seoul"; // 문자열 변수 선언과 동시에 초기화

            Console.WriteLine(score); Console.WriteLine(temperature); Console.WriteLine(city);

            // 같은 데이터 타입의 변수를 쉼표로 구분하여 선언
            int x = 10, y = 20, z = 30;

            Console.WriteLine(x); Console.WriteLine(y); Console.WriteLine(z);

            // 상수 선언
            const double Pi = 3.14159; // 실수형 상수 선언 및 초기화
            const int MaxScore = 100; // 정수형 상수 선언 및 초기화

            // Pi = 3.14; -> 오류 발생

            Console.WriteLine("Pi: " + Pi); Console.WriteLine("Max Score" + MaxScore);
        }
    }
}