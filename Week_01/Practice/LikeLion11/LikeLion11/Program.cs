using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 네임스페이스
// 클래스, 함수, 변수 이름이 충돌하는 것을 방지하기 위해 사용
namespace MyNamespace
{
    class MyClass
    {
        public static void SayHello()
        {
            Console.WriteLine("안녕하세요! MyNamespace의 MyClass입니다.");
        }
    }
}

namespace LikeLion11
{
    class Program
    {
        static void SayHello()
        {
            Console.WriteLine("안녕하세요!");
        }

        // 화살표 함수
        // C#에서 화살표 함수 => 람다 표현식
        // 간결한 방식으로 함수를 정의
        // {} return 생략 가능
        static int Add(int a, int b) => a + b;
        static void PrintMessage() => Console.WriteLine("안녕하세요");
        
        static void Main(string[] args)
        {
            SayHello();
            MyNamespace.MyClass.SayHello();

            Console.WriteLine(Add(1, 2));
            PrintMessage();
        }
    }
}