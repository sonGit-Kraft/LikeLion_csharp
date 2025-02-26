using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("[대장장이 키우기]");

            int money = 100;
            int input;
            int rnd;

            Thread.Sleep(500); // 0.5s delay

            while (true)
            {
                Console.Clear(); // 화면 지우기

                Console.WriteLine("1. 나무 캐기");
                Console.WriteLine("2. 장비 뽑기");
                Console.WriteLine("3. 나가기");

                Console.Write("입력: ");
                input = int.Parse(Console.ReadLine());

                if (input == 1) // 나무 캐기
                {
                    while (true)
                    {
                        Console.WriteLine("나무 캐기(Enter)");
                        Console.WriteLine("뒤로 가기 (x)\n");
                        Console.WriteLine("소지금: " + money);

                        string str = Console.ReadLine();

                        if (string.Compare(str, "x") == 0)
                        {
                            Console.WriteLine("뒤로 가기");
                            break;
                        }

                        money += 100;
                    }
                }
                else if (input == 2) // 장비 뽑기
                {
                    if (money >= 1000) // 돈이 1000 이상 있는지 확인
                    {
                        money -= 1000;

                        for (int i = 1; i <= 20; i++)
                        {
                            rnd = rand.Next(1, 101); // 1 ~ 100

                            if (rnd == 1) // 1%
                            {
                                Console.WriteLine("도끼 등급 SSS");
                            }
                            else if (rnd >= 2 && rnd <= 6) // 5%
                            {
                                Console.WriteLine("도끼 등급 SS");
                            }
                            else if (rnd >= 7 && rnd <= 17) // 10%
                            {
                                Console.WriteLine("도끼 등급 S");
                            }
                            else if (rnd >= 18 && rnd <= 38) // 20%
                            {
                                Console.WriteLine("도끼 등급 A");
                            }
                            else if (rnd >= 39 && rnd <= 69) // 30%
                            {
                                Console.WriteLine("도끼 등급 B");
                            }
                            else
                            {
                                Console.WriteLine("도끼 등급 C");
                            }
                            Thread.Sleep(500); // 0.5s delay
                        }
                    }
                    else
                    {
                        Console.WriteLine("돈이 부족합니다.\n");
                        Thread.Sleep(1000);
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("나갑니다.");
                    Environment.Exit(0);
                }
            }
        }
    }
}