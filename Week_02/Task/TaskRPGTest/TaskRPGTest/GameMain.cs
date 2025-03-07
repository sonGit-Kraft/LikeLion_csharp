using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRPGTest
{
    static class GameMain // 클래스에 public이나 private 선언이 없으면 기본적으로 internal이 적용
    {
        static public Player player = new Player();

        static public void Processing()
        {
            player.SelectJob();

            while (true)
            {
                Console.Clear();
                player.ShowInfo();

                Console.WriteLine("1. 사냥터 2. 종료");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    Field.GoField(ref player);
                else if (choice == 2)
                    break;
            }
        }
    }
}