using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRPGTest
{
    /*
    Player 클래스가 internal로 되어 있고, Field 클래스가 public일 때 오류가 발생하는 이유:
    Player 클래스가 internal이기 때문에, Field 클래스에서 그 Player 객체를 ref로 받으려면 Player 클래스가 외부에서 참조할 수 있어야 하므로 문제가 발생할 수 있다. 
    이 경우 Player 클래스가 internal이면 외부에서 ref로 접근할 수 없다.

    Field 클래스와 Player 클래스가 모두 internal로 선언되어 있으면, 동일한 프로젝트 내에서는 ref로 문제없이 객체를 전달할 수 있다.
    */
    static class Field // 클래스에 public이나 private 선언이 없으면 기본적으로 internal이 적용
    {
        static private Monster monster;
        static public void GoField(ref Player player)
        {
            Console.Clear();

            player.ShowInfo();


            if (monster == null)
            {
                monster = new Monster();
            }

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