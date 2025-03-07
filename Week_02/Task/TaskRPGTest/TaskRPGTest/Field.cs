using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRPGTest
{
    static class Field
    {
        static private Monster monster;
        static public void GoField(ref Player player)
        {
            Console.Clear();

            player.ShowInfo();

            monster = new Monster();

            int choice = SelectMap();

            while (choice == 1 || choice == 2 || choice == 3)
            {
                Console.Clear();

                player.ShowInfo();
                monster.ShowInfo();

                Console.WriteLine("1. 공격 2. 도망");
                Console.Write("선택: ");

                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    player.GetDamage(monster);
                    monster.GetDamage(player);

                    if (player.Hp <= 0)
                    {
                        player.Hp = player.InitHp;
                        break;
                    }
                }

                if (input == 2 || monster.Hp <= 0)
                {
                    monster = null;
                    break;
                }
            }
        }

        static private int SelectMap()
        {
            Console.WriteLine("1. 초보 맵\n2. 중수 맵\n3. 고수 맵\n4. 전 단계");
            Console.WriteLine("==========================");
            Console.Write("맵을 선택하세요: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    monster.Name = "초보 몬스터";
                    monster.Attack = 5;
                    monster.Hp = 50;
                    break;
                case 2:
                    monster.Name = "중수 몬스터";
                    monster.Attack = 7;
                    monster.Hp = 60;
                    break;
                case 3:
                    monster.Name = "고수 몬스터";
                    monster.Attack = 9;
                    monster.Hp = 70;
                    break;
            }
            return choice;
        }
    }
}