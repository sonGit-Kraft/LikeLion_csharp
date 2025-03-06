using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPGTask
{
    static class Field
    {
        static public Monster monster;

        static public void GoField(ref Player player)
        {
            Console.Clear();
            DrawChoiceMap();

            int input = int.Parse(Console.ReadLine());
            CreateMonster(input);

            while (input == 1 || input == 2 || input == 3)
            {
                Console.Clear();
                player.ShowInfo();
                monster.ShowInfo();

                Console.WriteLine("1. 공격 2. 도망");
                Console.Write("선택: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    player.GetDamage(monster);

                    monster.GetDamage(player);

                    if (player.Hp <= 0)
                    {
                        player.Hp = 100;
                        break;
                    }
                }

                if (choice == 2 || monster.Hp <= 0)
                {
                    monster = null;
                    break;
                }
            }
        }

        static public void CreateMonster(int choice)
        {
            monster = new Monster();

            switch (choice)
            {
                case 1:
                    monster.Name = "초급 몬스터";
                    monster.Hp = 30;
                    monster.Attack = 3;
                    break;
                case 2:
                    monster.Name = "중급 몬스터";
                    monster.Hp = 60;
                    monster.Attack = 6;
                    break;
                case 3:
                    monster.Name = "고급 몬스터";
                    monster.Hp = 90;
                    monster.Attack = 9;
                    break;
            }
        }

        static public void DrawChoiceMap()
        {
            Console.WriteLine("1. 초급 맵 2. 중수 맵 3. 고수 맵 4. 전 단계");
            Console.WriteLine("===========================================");
            Console.Write("맵을 선택하세요: ");
        }
    }
}