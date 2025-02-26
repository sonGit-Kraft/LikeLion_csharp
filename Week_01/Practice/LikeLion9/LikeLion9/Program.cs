using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LikeLion9
{
    class Program
    {
        // 메모리 영역
        // 스택 stack
        // 힙 heap
        // 정적 메모리 static memory

        // static int count = 0; // 정적 메모리에 저장
        // 프로그램 종료 전까지 유지

        /*
        C#에서 Main 메서드에 static 키워드를 사용하는 이유
        Main 메서드는 프로그램의 진입점이며, 실행을 위해 객체를 먼저 생성하면 안 된다.
        따라서 static을 사용하여 클래스의 인스턴스를 만들지 않고 바로 실행할 수 있도록 한다.
        ※ Unity에서는 Main 옆에 static 안씀
        */

        /*
        함수 기본형
        반환형 함수이름 (매개변수)
        {
        }
        */

        static void Loading()
        {
            Console.WriteLine("로딩 중.");
            Thread.Sleep(1000);
            Console.WriteLine("로딩 중..");
            Thread.Sleep(1000);
            Console.WriteLine("로딩 중...");
            Thread.Sleep(1000);
            Console.Clear();
        }

        static void AttackFunction(int att)
        {
            Console.WriteLine("공격력: " + att);
        }

        static int BaseAttack()
        {
            int baseAtt = 10;

            return baseAtt;
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            // 함수
            Loading();

            int Attack = 0;
            Console.Write("공격력 입력: ");
            Attack = int.Parse(Console.ReadLine());
            AttackFunction(Attack);

            Attack += BaseAttack();
            AttackFunction(Attack);

            int result = Add(10, 20);
            Console.WriteLine($"10 + 20 = {result}");

            // foreach문
            string[] fruits = { "사과", "바나나", "체리" };

            foreach (string fruit in fruits)
                Console.WriteLine(fruit);
        }
    }
}