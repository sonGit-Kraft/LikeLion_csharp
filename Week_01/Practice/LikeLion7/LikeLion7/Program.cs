using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LikeLion7
{
    class Program
    {
        static void Main(string[] args)
        {
            // if-else문
            int score = 85;

            if (score >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else
            {
                Console.WriteLine("B 학점");
            }

            string GameID = "멋사";

            if (string.Compare(GameID, "멋사") == 0) // 문자열 비교 함수 string.Compare()
            {
                Console.WriteLine("아이디가 일치합니다.");
            }
            else
            {
                Console.WriteLine("아이디가 일치하지 않습니다.");
            }

            // else if문
            score = 75;

            if (score >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else if (score >= 80)
            {
                Console.WriteLine("B 학점");
            }
            else if (score >= 70)
            {
                Console.WriteLine("C 학점");
            }
            else
            {
                Console.WriteLine("F 학점");
            }

            // switch-case문
            int day = 3;
            switch (day)
            {
                case 1:
                    Console.WriteLine("월요일");
                    break;
                case 2:
                    Console.WriteLine("화요일");
                    break;
                case 3:
                    Console.WriteLine("수요일");
                    break;
                case 4:
                    Console.WriteLine("목요일");
                    break;
                case 5:
                    Console.WriteLine("금요일");
                    break;
                default:
                    Console.WriteLine("유효하지 않은 요일");
                    break;
            }

            int att = 0, def = 0;
            string job = default;
            bool isCorrect = false;

            Console.Write("캐릭터를 선택하세요 (1. 검사 2. 마법사 3. 도적): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    job = "검사";
                    att = 100;
                    def = 90;
                    isCorrect = true;
                    break;
                case 2:
                    job = "마법사";
                    att = 110;
                    def = 80;
                    isCorrect = true;
                    break;
                case 3:
                    job = "도적";
                    att = 115;
                    def = 70;
                    isCorrect = true;
                    break;
                default:
                    Console.WriteLine("잘못된 입력!");
                    isCorrect = false;
                    break;
            }

            if (isCorrect)
            {
                Console.WriteLine();
                Console.WriteLine("[캐릭터 특성]");
                Console.WriteLine("직업: " + job);
                Console.WriteLine("공격력: " + att);
                Console.WriteLine("방어력: " + def);
            }

            // 꿀팁!
            // 여러줄 복사: alt + 드래그 후 ctrl + c

            // for문 (반복문)
            for (int i = 1; i <= 5; i++)
                Console.WriteLine($"숫자: {i}");

            /*
            // for문을 활용한 무한 반복
            for (; ; ) 
                Console.WriteLine("무한 반복");
            */

            // for문을 활용한 0 ~ 9 출력
            for (int i = 0; i <= 9; i++)
                Console.WriteLine(i);

            // for문을 활용한 1 ~ 10 까지의 합 출력
            int result = 0;

            for (int i = 1; i <= 10; i++)
                result += i;

            Console.WriteLine(result);

            // while문
            int count = 1;

            while (count <= 5) // 조건식
            {
                Console.WriteLine("Count: " + count);
                count++;

                // 3일 때 반복문 강제 종료
                if (count == 3)
                {
                    Console.WriteLine("3일 때 반복문 종료");
                    break; // 반복문 종료
                }
            }

            Console.WriteLine("Count: " + count);

            // 랜덤
            Random rand = new Random(); // Random 객체 생성

            // 0 이상 10 미만 랜덤 정수 생성
            int radomNumber = rand.Next(0, 10); // 0 ~ 9
            Console.WriteLine("램던 정수: " + radomNumber);

            // 램덤을 활용한 확률 구현
            Console.WriteLine("[대장장이 키우기]");

            int rnd = 0;

            for (int i = 0; i < 20; i++)
            {
                rnd = rand.Next(1, 101); // 1 ~ 100

                if (rnd >= 1 && rnd <= 10) // 1 ~ 10 (10%)
                    Console.WriteLine("도끼 등급 SSS");
                else if (rnd >= 11 && rnd <= 40) // 11 ~ 40 (30%)
                    Console.WriteLine("도끼 등급 SS");
                else
                    Console.WriteLine("도끼 등급 S");

                Thread.Sleep(500); // 0.5s 딜레이
            }

            // do-while문
            // 1회 무조건 실행 후 while문과 같이 조건 진행
            int x = 5;
            do
            {
                Console.WriteLine("최소 한번은 실행됩니다.");
                x--;
            } while (x > 0);

            // break
            // 반복문 탈출 가능
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                    break;

                Console.WriteLine(i);
            }

            // continue
            // 현재 반복을 건너뛰고 다음 반복으로 넘어감
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0) // 짝수일 때
                    continue; // 이번 반복 넘어감

                Console.WriteLine(i);
            }

            // goto
            int n = 1;

            start:

            if (n <= 5)
            {
                Console.WriteLine(n);
                n++;

                goto start; // 레이블로 이동
            }
        }
    }
}