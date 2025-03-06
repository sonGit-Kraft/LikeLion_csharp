using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTask
{
    static class GameMain
    {
        static public Player player;

        static public void Init()
        {
            player = new Player();
        }

        static public void process()
        {
            player.SelectJob();

            while(true)
            {
                Console.Clear();
                player.ShowInfo();

                Console.WriteLine("1. 사냥터 2. 종료");
                Console.Write("선택: ");
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    Field.GoField(ref player);
                }
                else if (choice == 2)
                {
                    break;
                }
            }
        }
    }
}