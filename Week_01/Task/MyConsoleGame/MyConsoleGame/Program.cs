using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyConsoleGame
{
    class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch(); // c언어 함수 가져옴

        public int X, Y; // 플레이어 좌표
        public int Life = 3; // 목숨
        public bool isInvincible = false; // 무적 상태 여부
        private int invincibleTime = 2000; // 무적 지속 시간 (2초)

        public Player() { X = 2; Y = 2; } // 생성자 (시작 좌표 초기화)

        public void KeyControl()
        {
            if (Console.KeyAvailable)
            {
                int pressKey = _getch(); // 키 값
                // 밀림 방지
                if (pressKey == 0 || pressKey == 224) // 화살표 키 또는 특수 키 감지
                    pressKey = _getch(); // 실제 키 값 읽기

                int newX = X, newY = Y;
                switch (pressKey)
                {
                    case 72: newY--; break; // 위
                    case 75: newX -= 2; break; // 왼쪽
                    case 77: newX += 2; break; // 오른쪽
                    case 80: newY++; break; // 아래
                    case 32: Bomb.PlantBomb(X, Y); break; // 스페이스바 (폭탄 설치)
                }
                if (Map.IsValidMove(newX, newY)) { X = newX; Y = newY; }
            }

            // 충돌 체크 한 번만 실행
            if (!isInvincible)
            {
                foreach (Enemy enemy in Program.enemies)
                {
                    if (X == enemy.X && Y == enemy.Y && enemy.isAlive)
                    {
                        TakeDamage(); // 데미지 받고 바로 루프 탈출
                        break;
                    }
                }
            }

        }

        public void TakeDamage()
        {
            if (!isInvincible)
            {
                Life--;
                if (Life <= 0)
                {
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    Console.WriteLine("🤢");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("🤮");
                    Thread.Sleep(200);
                    Console.WriteLine(" d888b   .d8b.  .88b  d88. d88888b    .d88b.  db    db d88888b d8888b. ");
                    Thread.Sleep(200);
                    Console.WriteLine("88' Y8b d8' `8b 88'YbdP`88 88'       .8P  Y8. 88    88 88'     88  `8D ");
                    Thread.Sleep(200);
                    Console.WriteLine("88      88ooo88 88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY' ");
                    Thread.Sleep(200);
                    Console.WriteLine("88  ooo 88~~~88 88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b   ");
                    Thread.Sleep(200);
                    Console.WriteLine("88. ~8~ 88   88 88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88. ");
                    Thread.Sleep(200);
                    Console.WriteLine(" Y888P  YP   YP YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD ");

                    Environment.Exit(0);
                }
                isInvincible = true; // 무적 시작
                Task.Run(async () =>
                {
                    await Task.Delay(invincibleTime); // 2초 대기
                    isInvincible = false; // 무적 해제
                });
            }
        }
    }

    static class Map
    {
        public static int width = 46, height = 15; // 맵 크기 저장 (50 x 13)

        public static string[,] Buffer = new string[height, width / 2]; // width / 2: 공백과 각 객체의 이모티콘들이 2칸을 차지 하기 때문

        // 맵 문자열
        public static string mapData = @"██████████████████████████████████████████████
██                                          ██
██  ██  ░░  ██  ██  ██  ██  ██  ██  ░░  ██  ██
██  ░░      ██      ██      ██      ██      ██
██  ██  ██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██
██      ██      ██      ░░      ██      ██  ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ░░  ██
██  ░░      ░░      ██      ░░      ██      ██
██  ██  ░░  ██  ██  ░░  ██  ██  ██  ██  ░░  ██
██      ██      ██      ██      ░░      ██  ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ██      ██      ░░      ██      ░░      ██
██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██  ██  ██
██                                          ██
██████████████████████████████████████████████";

        public static void InitMapBuffer()
        {
            string[] rows = mapData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width / 2; x++)
                {
                    if (Buffer[y, x] == "💣" || Buffer[y, x] == "🔥")
                        continue;

                    if (x * 2 < rows[y].Length)
                        Buffer[y, x] = rows[y].Substring(x * 2, Math.Min(2, rows[y].Length - x * 2));
                    else
                        Buffer[y, x] = "  ";
                }
            }

            foreach (var bomb in Program.Bombs)
                Buffer[bomb.Y, bomb.X / 2] = "💣";

        }

        public static bool IsValidMove(int x, int y)
        {
            return (x > 0 && y >= 0 && x < width - 2 && y < height && Buffer[y, x / 2] == "  ");
        }

        // Buffer 출력
        public static void Draw()
        {
            // Buffer 출력 
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width / 2; x++)
                    Console.Write(Buffer[y, x]);
                Console.WriteLine();
            }

            // 생명 출력
            Console.SetCursorPosition(width + 1, 0);
            Console.Write("┏━━━━━━━┓");
            Console.SetCursorPosition(width + 1, 1);
            Console.Write("┃       ┃");
            Console.SetCursorPosition(width + 2, 1);
            Console.Write($"❤️ x {Program.player.Life}");
            Console.SetCursorPosition(width + 1, 2);
            Console.Write("┗━━━━━━━┛");

            int count = 0;
            foreach (var enemy in Program.enemies)
            {
                if (enemy.isAlive)
                {
                    count++;
                }
            }

            // 현재 남아있는 적 출력
            Console.SetCursorPosition(width + 1, 3);
            Console.Write("┏━━━━━━━┓");
            Console.SetCursorPosition(width + 1, 4);
            Console.Write("┃       ┃");
            Console.SetCursorPosition(width + 2, 4);
            Console.Write($"😈 x {count}");
            Console.SetCursorPosition(width + 1, 5);
            Console.Write("┗━━━━━━━┛");
        }
    }

    class Bomb
    {
        public int X, Y;

        public Bomb(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static void PlantBomb(int x, int y)
        {
            Bomb bomb = new Bomb(x, y);
            Program.Bombs.Add(bomb);

            Task.Run(async () =>
            {
                await Task.Delay(3000); // 3초 대기
                lock (Program.Bombs) // 멀티 스레드 충돌 방지
                {
                    if (Program.Bombs.Contains(bomb))
                        Program.Bombs.Remove(bomb); // 리스트에서 삭제

                    // 리스트에서 먼저 삭제 후 폭발 메서드 호출하는 이유
                    // 리스트에서 먼저 삭제 하지 않으면 메인 Loop에서 
                    // InitMapBuffer를 호출할 때 Bomb 리스트에 있는 폭탄이 출력된다
                }

                bomb.Explode(); // 폭발 메서드 호출


            });
        }


        public void Explode()
        {
            // 폭탄 범위
            int[][] offsets =
            {
                 new int[] { 0, 0 }, // 폭탄 위치 (가운데)
                 new int[] { 0, -1 }, // 위쪽
                 new int[] { 0, 1 }, // 아래쪽
                 new int[] { -2, 0 }, // 왼쪽
                 new int[] { 2, 0 } // 오른쪽
            };

            /*
            foreach (var offset in offsets)
            {
                int ex = X + offset[0];
                int ey = Y + offset[1];

                // 무조건 불꽃 그리기 (벽만 아니면)
                if (Map.Buffer[ey, ex / 2] != "██")
                {
                    Map.Buffer[ey, ex / 2] = "🔥";
                }

                // 플레이어가 맞았는지 체크
                if (Program.player.X == ex && Program.player.Y == ey)
                {
                    Program.player.TakeDamage();
                }
            }
            */

            //Thread.Sleep(500);

            Task.Run(async () =>
            {
                foreach (var offset in offsets)
                {
                    int ex = X + offset[0];
                    int ey = Y + offset[1];
                    // 무조건 불꽃 그리기 (벽만 아니면)
                    if (Map.Buffer[ey, ex / 2] != "██" && Map.Buffer[ey, ex / 2] != "░░")
                    {
                        Map.Buffer[ey, ex / 2] = "🔥";
                    }

                    // 플레이어가 맞았는지 체크
                    if (Program.player.X == ex && Program.player.Y == ey)
                    {
                        Program.player.TakeDamage();
                    }
                    // 적 맞았는지 먼저 체크
                    foreach (Enemy enemy in Program.enemies)
                    {
                        if (!enemy.isAlive) continue; // 이미 죽은 적은 넘김

                        if (enemy.isAlive)
                        {
                            int distanceX = Math.Abs(enemy.X - ex);
                            int distanceY = Math.Abs(enemy.Y - ey);

                            // 폭탄 불꽃 범위 안에 들어오면 죽게 함
                            if (distanceX <= 1 && distanceY <= 1)
                            {
                                enemy.isAlive = false;
                                Map.Buffer[enemy.Y, enemy.X / 2] = "💥";
                                await Task.Delay(200);
                                Map.Buffer[enemy.Y, enemy.X / 2] = "  ";
                            }
                        }
                    }
                }
            });


            Thread.Sleep(500);

            // 불꽃 제거
            foreach (var offset in offsets)
            {
                int ex = X + offset[0];
                int ey = Y + offset[1];

                if (Map.Buffer[ey, ex / 2] == "🔥")
                {
                    Map.Buffer[ey, ex / 2] = "  ";
                }
            }
        }
    }

    class Enemy
    {
        public int X, Y;
        private static Random rand = new Random();
        public bool isAlive = true;

        public void Initialize()
        {
            do { X = rand.Next(2, Map.width - 2); Y = rand.Next(0, Map.height); }
            while (!Map.IsValidMove(X, Y));
        }

        public void Move(Player player)
        {
            int newX = X, newY = Y;

            if (player.X > X) newX += 2;
            else if (player.X < X) newX -= 2;

            // 다른 적들과 겹치는지 검사
            bool canMoveX = true;
            foreach (var enemy in Program.enemies)
            {
                if (enemy != this && enemy.X == newX && enemy.Y == Y && enemy.isAlive)
                {
                    canMoveX = false;
                    break; // 다른 적이 있으면 멈춤
                }
            }
            if (canMoveX && Map.IsValidMove(newX, Y)) X = newX;

            if (player.Y > Y) newY++;
            else if (player.Y < Y) newY--;

            // Y 방향 충돌 검사
            bool canMoveY = true;
            foreach (var enemy in Program.enemies)
            {
                if (enemy != this && enemy.X == X && enemy.Y == newY && enemy.isAlive)
                {
                    canMoveY = false;
                    break;
                }
            }
            if (canMoveY && Map.IsValidMove(X, newY)) Y = newY;
        }

    }

    class Program
    {
        public static Player player = new Player();
        public static Enemy[] enemies = new Enemy[5];
        public static List<Bomb> Bombs = new List<Bomb>(); // 폭탄 리스트
        public static int DeadCount = 0;
        static int enemyMoveTime = Environment.TickCount;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 40);
            Console.SetBufferSize(60, 40);
            Map.InitMapBuffer();

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy();
                enemies[i].Initialize();
            }

            while (true)
            {
                Console.Clear();
                Map.InitMapBuffer(); // 맵 초기화
                player.KeyControl();

                foreach (var bomb in Program.Bombs)
                {
                    Map.Buffer[bomb.Y, bomb.X / 2] = "💣";
                }

                // 플레이어 그리기
                if (!player.isInvincible)
                    Map.Buffer[player.Y, player.X / 2] = "😳";
                else
                    Map.Buffer[player.Y, player.X / 2] = "🤕";

                // 적 이동 및 그리기
                if (enemyMoveTime + 1000 < Environment.TickCount)
                {
                    foreach (var enemy in enemies)
                    {
                        if (enemy.isAlive)
                            enemy.Move(player);
                    }

                    enemyMoveTime = Environment.TickCount;
                }
                foreach (var enemy in enemies)
                {
                    if (enemy.isAlive)
                    {
                        Map.Buffer[enemy.Y, enemy.X / 2] = "😈";
                    }
                    else
                    {
                        DeadCount++;
                    }
                }
                if (DeadCount == 5)
                {
                    Thread.Sleep(50);
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("🥳");
                    Thread.Sleep(200);
                    Console.WriteLine(" d888b   .d8b.  .88b  d88. d88888b    .o88b. db      d88888b  .d8b.  d8888b. db ");
                    Thread.Sleep(200);
                    Console.WriteLine("88' Y8b d8' `8b 88'YbdP`88 88'       d8P  Y8 88      88'     d8' `8b 88  `8D 88 ");
                    Thread.Sleep(200);
                    Console.WriteLine("88      88ooo88 88  88  88 88ooooo   8P      88      88ooooo 88ooo88 88oobY' YP ");
                    Thread.Sleep(200);
                    Console.WriteLine("88  ooo 88~~~88 88  88  88 88~~~~~   8b      88      88~~~~~ 88~~~88 88`8b   db ");
                    Thread.Sleep(200);
                    Console.WriteLine("88. ~8~ 88   88 88  88  88 88.       Y8b  d8 88booo. 88.     88   88 88 `88.    ");
                    Thread.Sleep(200);
                    Console.WriteLine(" Y888P  YP   YP YP  YP  YP Y88888P    `Y88P' Y88888P Y88888P YP   YP 88   YD YP ");

                    Environment.Exit(0);
                }
                else
                    DeadCount = 0;

                Map.Draw();
                Thread.Sleep(50);
            }
        }
    }
}