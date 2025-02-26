using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TodayTask8
{
    class Program
    {

        static void Main(string[] args)
        {
            // 콘솔 애플리케이션에서 출력 인코딩을 UTF-8로 설정 (특수 문자 출력 가능)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rand = new Random();

            int gold = 500;
            int health = 100;
            int power = 10;
            int input;
            bool isAlive = true;

            Console.WriteLine("⚔️ 모험가 키우기 ⚔️");
            Thread.Sleep(1000);

            while (isAlive)
            {
                Console.Clear();
                Console.WriteLine($"현재 상태: 체력 {health} | 골드 {gold} | 공격력 {power}\n");
                Console.WriteLine("1. 탐험하기 🏕️");
                Console.WriteLine("2. 장비 뽑기 🎲 (1000골드)");
                Console.WriteLine("3. 휴식하기 💤 (체력 +20)");
                Console.WriteLine("4. 게임 종료");

                Console.Write("입력: ");
                input = int.Parse(Console.ReadLine());

                Console.Clear();

                if (input == 1)
                {
                    Console.WriteLine("탐험을 떠납니다.");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다..");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다...");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다....");
                    Thread.Sleep(500);
                    Console.WriteLine();

                    int eventChance = rand.Next(1, 101);

                    if (eventChance <= 30) // 30%
                    {
                        int damage = rand.Next(5, 21);
                        Console.WriteLine($"⚔️ 몬스터를 만났습니다! (체력 -{damage})");
                        health -= damage;
                    }
                    else if (eventChance <= 70) // 40%
                    {
                        int reward = rand.Next(100, 301);
                        Console.WriteLine($"💰 보물을 발견했습니다! (골드 +{reward})");
                        gold += reward;
                    }
                    else // 30%
                    {
                        int heal = rand.Next(10, 31);
                        Console.WriteLine($"🌿 신비한 약초를 발견했습니다! (체력 +{heal})");
                        health += heal;
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("💀 체력이 0이 되어 사망했습니다... Game Over...");
                        isAlive = false;
                    }
                }
                else if (input == 2)
                {
                    if (gold >= 1000)
                    {
                        gold -= 1000;
                        Console.WriteLine("");
                        Console.WriteLine("🎲 장비를 뽑습니다...");
                        Thread.Sleep(1000);

                        int rnd = rand.Next(1, 101);

                        if (rnd == 1)
                        {
                            Console.WriteLine("SSS급 전설의 검 획득! (공결력 +50)");
                            power += 50;
                        }
                        else if (rnd <= 10)
                        {
                            Console.WriteLine("SS급 희귀한 검 획득! (공격력 +30)");
                            power += 30;
                        }
                        else if (rnd <= 30)
                        {
                            Console.WriteLine("S급 강철 검 획득! (공격력 +20)");
                            power += 20;
                        }
                        else
                        {
                            Console.WriteLine("녹슨 칼 획득! (공격력 +5)");
                            power += 5;
                        }
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다. (1000 골드 필요)");
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("휴식을 취합니다... (체력 + 20)");
                    health += 20;
                }
                else if (input == 4)
                {
                    Console.WriteLine("게임을 종료합니다.");
                    Environment.Exit(1); // 프로그램 종료
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                }
                Thread.Sleep(3000);
            }
        }
    }
}