using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRPGTest
{
    class Player : Unit
    {
        public int InitHp;
        public void ShowInfo()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("직업: " + Name);
            Console.WriteLine("체력: " + Hp + "\t공격력: " + Attack);
            Console.WriteLine();
        }

        public void SelectJob()
        {
            Console.WriteLine("직업을 선택하세요 -> 1. 기사 2. 마법사 3. 도적");
            Console.Write("선택: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Name = "기사";
                    Attack = 10;
                    Hp = 100;
                    break;
                case 2:
                    Name = "마법사";
                    Attack = 13;
                    Hp = 90;
                    break;
                case 3:
                    Name = "도적";
                    Attack = 16;
                    Hp = 80;
                    break;
            }
            InitHp = Hp;
        }
    }
}