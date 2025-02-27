using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShootingGame
{
    struct Player
    {
        public int playerX;
        public int playerY;
        public string[] player;

        public Player(bool init) // 생성자
        {
            playerX = 0;
            playerY = 12;
            player = new string[]
            {
                    "->",
                    ">>>",
                    "->"
            };
        }

        public void Move(ConsoleKeyInfo keyInfo)
        {
            // 방향키 입력에 따른 좌표 변경
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (playerY > 0) playerY--; break; // 위
                case ConsoleKey.DownArrow: if (playerY < Console.WindowHeight - 1) playerY++; break; // 아래
                case ConsoleKey.LeftArrow: if (playerX > 0) playerX--; break; // 왼쪽
                case ConsoleKey.RightArrow: if (playerX < Console.WindowWidth) playerX++; break; // 오른쪽
                case ConsoleKey.Spacebar: Console.Write("미사일키"); break; // 스페이스바 미사일
                case ConsoleKey.Escape: return; // ESC 종료
            }
        }

        public void Print()
        {
            for (int i = 0; i < player.Length; i++)
            {
                // 콘솔 좌표 설정 playerX playerY
                Console.SetCursorPosition(playerX, playerY + i);
                // 문자열 배열 출력
                Console.WriteLine(player[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); // 콘솔 창 크기 조정
            Console.SetBufferSize(80, 25); // 버퍼 크기 조정
            Console.CursorVisible = false; // 커서 제거

            ConsoleKeyInfo keyInfo;

            Player player = new Player(true);

            // 시간 1초 루프
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // 이전 시간
            long prevSecond = stopwatch.ElapsedMilliseconds; // 단위: ms

            while (true)
            {
                // 현재 시간 가져오기
                long currentSecond = stopwatch.ElapsedMilliseconds;

                if (currentSecond - prevSecond >= 100)
                {
                    Console.Clear();

                    keyInfo = Console.ReadKey(true); // 키 입력 받기 (화면 출력 X)
                    player.Move(keyInfo); // 플레이어 이동

                    player.Print(); // 플레이어 출력
                    
                    prevSecond = currentSecond; // 이전 시간 업데이트
                }
            }
        }
    }
}