using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion4
{
    class Program
    {
        static void Main(string[] args)
        {
            // char 형식: 단일 문자를 표현
            char letter = 'A'; // 문자 'A' 저장
            char symbol = '#'; // 특수 기호 저장
            char number = '9'; // 숫자 형태의 문자 저장 (숫자 9가 아닌 문자 '9')

            Console.WriteLine(letter);
            Console.WriteLine(symbol);
            Console.WriteLine(number);

            // string 형식: 여러 문자를 저장
            string greeting = "Hello World"; // 문자열 저장
            string name = "Alice"; // 이름 저장

            Console.WriteLine(greeting);
            Console.WriteLine(name);
            Console.WriteLine($"{greeting} {name}"); // "Hello World Alice" 출력

            // bool 형식: 참(True) 또는 거짓(False)
            bool isRunning = true;
            bool isFinished = false;

            Console.WriteLine(isRunning);
            Console.WriteLine(isFinished);

            // const: 변하지 않는 값을 정의
            const double Pi = 3.14159; // Pi = 1234; -> error (상수는 변경 할 수 없음)
            const int MaxScore = 100;

            Console.WriteLine(Pi);
            Console.WriteLine(MaxScore);

            // 닷넷 형식: 기본 형식의 닷넷 표현
            System.Int32 DotNumber = 123; // int의 닷넷 형식
            System.String DotText = "Hello"; // string의 닷넷 형식
            System.Boolean DotFlag = true; // bool의 닷넷 형식

            Console.WriteLine(DotNumber);
            Console.WriteLine(DotText);
            Console.WriteLine(DotFlag);

            // int 래퍼 형식의 메서드 활용
            int Number = 123;
            string NumberAsString = Number.ToString(); // 정수를 문자열로 변환

            bool flag = true; // bool 래퍼 형식의 메서드 활용
            string flagAsString = flag.ToString(); // 논리값을 문자열로 변환

            Console.WriteLine(NumberAsString);
            Console.WriteLine(flagAsString);
        }
    }
}