using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTask
{
    class Player : Unit
    {
        public void ShowInfo()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("플레이어 이름: " + Name);
            Console.WriteLine("체력: " + Hp + "\t공격력: " + Attack);
            Console.WriteLine();
        }

        public void SelectJob()
        {
            Console.Clear();
            Console.WriteLine("1. 기사 2. 마법사 3. 도적");
            Console.Write("선택: ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Name = "기사";
                    Hp = 100;
                    Attack = 10;
                    break;
                case 2:
                    Name = "마법사";
                    Hp = 90;
                    Attack = 15;
                    break;
                case 3:
                    Name = "도둑";
                    Hp = 85;
                    Attack = 18;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    SelectJob();
                    break;
            }
        }
    }
}