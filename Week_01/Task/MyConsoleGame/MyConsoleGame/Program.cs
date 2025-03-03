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
        static extern int _getch(); // 문자 입력 함수 (c언어 함수 가져옴)

        public int X, Y; // 플레이어 좌표
        public int Life = 3; // 목숨
        public bool isInvincible = false; // 무적 상태 여부
        private int invincibleTime = 2000; // 무적 지속 시간 (2초)

        public Player() { X = 2; Y = 2; } // 생성자 (플레이어 시작 좌표 초기화)

        public void KeyControl()
        {
            if (Console.KeyAvailable)
            {
                int pressKey = _getch(); // 키 값
                // 키 밀림 방지
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
                if (Program.map.IsValid(newX, newY)) { X = newX; Y = newY; }
            }

            // 충돌 체크 한 번만 실행
            if (!isInvincible)
                foreach (Enemy enemy in Program.enemies.Where(e => X == e.X && Y == e.Y)) // Where() 메서드를 통해 적 리스트에서 플레이어와 좌표가 같은 적만 필터링
                    TakeDamage();
        }

        public void TakeDamage()
        {
            if (!isInvincible)
            {
                Life--;
                if (Life <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // 텍스트 색 변경

                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("❤️");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("💔 남은 목숨이 없습니다...\n");
                    Thread.Sleep(500);

                    // Game Over 아스키아트 출력
                    foreach (var line in Program.GAME_OVER)
                    {
                        Console.WriteLine(line);
                        Thread.Sleep(200); // 200ms 대기
                    }

                    Environment.Exit(0); // 프로그램 종료
                }

                isInvincible = true; // 무적 시작

                // 비동기 작업
                Task.Run(async () =>
                {
                    await Task.Delay(invincibleTime); // 2초 대기
                    isInvincible = false; // 무적 해제
                });
            }
        }
    }

    class Map
    {
        public int width = 50, height = 20; // 맵 크기 저장 (50 x 20)

        public StringBuilder mapData = new StringBuilder(@"██████████████████████████████████████████████████
██                                              ██
██  ██  ░░  ██  ██  ██  ██  ██  ██  ░░  ██  ██  ██
██  ░░      ██      ██      ██      ██      ██  ██
██  ██  ██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██  ██
██      ██      ██      ░░      ██      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ░░      ░░      ██      ░░      ██      ░░  ██
██  ██  ░░  ██  ██  ░░  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ░░      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ██      ██      ░░      ██      ░░      ██  ██
██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ██      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ░░      ░░      ██      ░░      ██      ░░  ██
██  ██  ░░  ██  ██  ░░  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ░░      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██████████████████████████████████████████████████");
        // C#에서 string은 한 번 생성되면 변경할 수 없음 (문자열을 수정할 때마다 새로운 문자열 객체가 생성)
        // StringBuilder: 기존 문자열 수정 가능

        // 버퍼 (더블 버퍼링 방식 사용)
        public string[,] Buffer;

        public Map()
        {
            // 한 칸당 2칸 차지
            Buffer = new string[height, width / 2]; // width / 2 -> 블럭 하나가 2칸을 차지 하기 때문
        }

        // 버퍼 초기화
        public void InitMapBuffer()
        {
            string[] rows = mapData.ToString().Split(new[] { '\n' }); // mapData를 개행을 기준으로 나눔

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width / 2; x++)
                {
                    if (Buffer[y, x] == "💣" || Buffer[y, x] == "🔥") // 폭탄이나 불꽃이면 이번 loop 넘어감
                        continue;

                    Buffer[y, x] = rows[y].Substring(x * 2, 2); // 2칸씩 잘라서 버퍼에 저장 (블럭 하나 당 2칸 차지)
                    // string Substring(int startIndex, int length)
                    // startIndex : 문자열에서 시작 위치 (0부터 시작)
                    // length: 잘라낼 문자 개수
                }
            }

            // Buffer에 폭탄 저장
            foreach (var bomb in Program.Bombs)
                Buffer[bomb.Y, bomb.X / 2] = "💣";
        }

        // 플레이어와 적 이동 또는 적 생성시 유효한 위치인지 검사
        public bool IsValid(int x, int y)
        {
            // 맵 테두리가 아니고 공백일 시
            return (x >= 2 && y >= 1 && x < width - 2 && y < height - 1 && Buffer[y, x / 2] == "  ");
        }

        public void Draw()
        {
            // Buffer 출력 
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width / 2; x++)
                    Console.Write(Buffer[y, x]);
                Console.WriteLine();
            }

            // 현재 남아있는 생명 출력
            Console.SetCursorPosition(width + 1, 0);
            Console.Write("┏━━━━━━━┓");
            Console.SetCursorPosition(width + 1, 1);
            Console.Write("┃       ┃");
            Console.SetCursorPosition(width + 2, 1);
            Console.Write($"❤️ x {Program.player.Life}");
            Console.SetCursorPosition(width + 1, 2);
            Console.Write("┗━━━━━━━┛");

            // 현재 남아있는 적 출력
            Console.SetCursorPosition(width + 1, 3);
            Console.Write("┏━━━━━━━┓");
            Console.SetCursorPosition(width + 1, 4);
            Console.Write("┃       ┃");
            Console.SetCursorPosition(width + 2, 4);
            Console.Write($"😈 x {Program.enemies.Count}");
            Console.SetCursorPosition(width + 1, 5);
            Console.Write("┗━━━━━━━┛");

            // 현재 남아있는 시간 출력
            Console.SetCursorPosition(width + 1, 6);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(width + 1, 7);
            Console.Write("┃                   ┃");
            Console.SetCursorPosition(width + 2, 7);
            Console.WriteLine($"⏳ 남은 시간: {Program.remainingTime}초 ");
            Console.SetCursorPosition(width + 1, 8);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━┛");

            /*
            // Enemy 위치 좌표 출력 (테스트용)
            int i = 0;
            foreach (Enemy enemy in Program.enemies)
            {
                Console.SetCursorPosition(Program.map.width + 1, 9 + i++);
                Console.WriteLine($"적 위치: {enemy.X}, {enemy.Y} | 플레이어 위치: {Program.player.X}, {Program.player.Y}");
            }
            */
        }

        public void RemoveBlock(int y, int x)
        {
            // mapData에서 제거할 블럭 인덱스 계산
            // 각 문자열 끝에 \r \n 이 있으므로 width 값이 50이면 각 줄은 52개의 index로 이루어짐
            // 크기가 50인 문자열이 있다면 0 ~ 49번 인덱스는 문자, 50번 인덱스는 \r(캐리지 리턴: 커서를 현재 줄의 맨 앞으로 이동), 51번 인덱스는 \n(개행)
            int index = y * (width + 2) + x;
            mapData.Remove(index, 2);
            mapData.Insert(index, "  ");
            Buffer[y, x / 2] = "  ";
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
            Program.Bombs.Add(bomb); // 폭탄 리스트에 새 폭탁 추가

            // 비동기 작업 (별도의 스레드에서 실행되며, 현재 코드 흐름과 독립적으로 실행)
            Task.Run(async () =>
            {
                await Task.Delay(3000); // 3초 대기
                lock (Program.Bombs) // 멀티 스레드 충돌 방지
                {
                    if (Program.Bombs.Contains(bomb))
                        Program.Bombs.Remove(bomb); // 리스트에서 삭제

                    // 리스트에서 먼저 삭제 후 폭발 메서드 호출하는 이유:
                    // 리스트에서 먼저 삭제 하지 않으면 메인 Loop에서 
                    // InitMapBuffer를 호출할 때 Bomb 리스트에 있는 폭탄이 출력된다
                }

                bomb.Explode(); // 폭발 메서드 호출
            });
        }

        public async Task Explode()
        {
            int[][] ranges =
            {
                new int[] { 0, 0 },   // 폭탄 위치
                new int[] { 0, -1 },  // 위쪽
                new int[] { 0, 1 },   // 아래쪽
                new int[] { -2, 0 },  // 왼쪽
                new int[] { 2, 0 }    // 오른쪽
            };

            // tasks는 각 range에 대해 비동기 작업을 실행하는 Task들의 컬렉션 (각 비동기 작업에 해당하는 Task 객체들이 즉시 저장)
            // 비동기 방식으로 작업을 처리하는 경우, 각 range에 대한 작업이 동시에 진행
            // 비동기 작업의 완료 시점은 Task 객체 자체가 관리하며, 작업이 완료되면 해당 Task의 상태가 완료됨으로 바뀝
            // ranges.Select(...): ranges 컬렉션에 대해 각 항목에 대해 변환 작업을 수행
            // async range => {...}: 각 range 항목마다 비동기 작업을 처리하는 람다 함수를 정의 (이 람다는 비동기 작업을 수행하고 결과를 반환하는 역할)
            // 참고 URL: https://learn.microsoft.com/ko-kr/dotnet/csharp/asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete
            // 참고 URL: https://learn.microsoft.com/ko-kr/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model?utm_source=chatgpt.com
            var tasks = ranges.Select(async range => // 비동기 작업을 통해 동시 처리
            {
                int ex = X + range[0];
                int ey = Y + range[1];

                // 부서지는 벽이면
                if (Program.map.Buffer[ey, ex / 2] == "░░")
                    Program.map.RemoveBlock(ey, ex); // 벽 제거

                // 불꽃 생성
                if (Program.map.Buffer[ey, ex / 2] != "██")
                    Program.map.Buffer[ey, ex / 2] = "🔥";

                // 플레이어가 맞았는지 체크
                if (Program.player.X == ex && Program.player.Y == ey)
                    Program.player.TakeDamage();
                // 버그: 비동기 방식 때문에 폭탄에 맞아서 죽으면 GameOver 타이틀 이상하게 나옴
                // TakeDamage() 로 넘어가도 비동기 작업은 계속 진행되기 때문

                // 적 처리 (폭탄 범위 내의 적을 제거)
                foreach (var enemy in Program.enemies.Where(enemy => enemy.X == ex && enemy.Y == ey).ToList()) // foreach 루프에서 Program.enemies.Remove(enemy)를 실행하면 원본 컬렉션이 변경되면서 오류가 발생 -> ToList()를 호출하면 새로운 리스트를 만들어서 foreach가 이 리스트를 순회
                {
                    Program.enemies.Remove(enemy); // 리스트에서 제거
                    Program.map.Buffer[enemy.Y, enemy.X / 2] = "💥";
                    await Task.Delay(500); // 500ms 후 버퍼에서 적 제거 표시 제거
                    Program.map.Buffer[enemy.Y, enemy.X / 2] = "  ";
                }

                // 불꽃 제거 (500ms 후)
                await Task.Delay(500);
                if (Program.map.Buffer[ey, ex / 2] == "🔥")
                    Program.map.Buffer[ey, ex / 2] = "  ";
            });

            await Task.WhenAll(tasks); // 모든 비동기 작업이 끝날 때까지 대기
            // 비동기 작업을 사용하지 않는다면 동시 처리가 이루어지지 않을 가능성이 있음
            // 한 작업이 끝나야 다음 작업이 진행되기 때문에, 여러 작업이 동시에 진행되지 않고 하나씩 차례대로 처리 때문
            // 기존 동기 코드에서는 플레이어 → 적 순서로 실행되므로 동시 처리가 불가능
        }
    }

    class Enemy
    {
        public int X, Y;
        private static Random rand = new Random();

        public void Initialize()
        {
            do
            {
                X = rand.Next(2, Program.map.width - 2); Y = rand.Next(2, Program.map.height - 1); // 랜덤한 좌표 생성

                if (X % 2 != 0) X--; // 좌표 보정 (짝수 좌표만 생성)
            }
            while (!Program.map.IsValid(X, Y)); // 맵에 생성 가능할 때까지 반복
        }

        public void Move(Player player)
        {
            int newX = X, newY = Y;

            // 플레이어 쪽으로 움직임
            if (player.X > X) newX += 2;
            else if (player.X < X) newX -= 2;
            if (player.Y > Y) newY++;
            else if (player.Y < Y) newY--;

            bool canMove = true;

            // 이동하려는 좌표에 적이 있는지 검사 (적 겹침 방지)
            foreach (var enemy in Program.enemies)
            {
                if (enemy != this && enemy.X == newX && enemy.Y == newY)
                {
                    canMove = false;
                    break;
                }
            }

            if (canMove && Program.map.IsValid(newX, newY) && Program.map.IsValid(newX, Y) && Program.map.IsValid(X, newY)) // 길이 막혔을 때 대각선으로 이동 금지
            {
                X = newX;
                Y = newY;
            }
            else if (canMove && Program.map.IsValid(newX, Y)) // X축만 이동 가능하면 이동
            {
                X = newX;
            }
            else if (canMove && Program.map.IsValid(X, newY)) // Y축만 이동 가능하면 이동
            {
                Y = newY;
            }
        }
    }

    class Program
    {
        public static Map map = new Map(); // 맵 객체 생성
        public static Player player = new Player(); // 플레이어 객체 생성
        public static List<Enemy> enemies = new List<Enemy>(); // 적 리스트 생성
        public const int MAX_ENEMY = 8; // 적 생성 숫자
        public static List<Bomb> Bombs = new List<Bomb>(); // 폭탄 리스트
        public static int remainingTime = 60; // 남은 시간 (초)
        static int enemyMoveTime = Environment.TickCount;

        public static string[] MAIN_TITLE = new string[]
        {
            "______                    _                                     ",
            "| ___ \\                  | |                                    ",
            "| |_/ /  ___   _ __ ___  | |__     __ _   __ _  _ __ ___    ___ ",
            "| ___ \\ / _ \\ | '_ ` _ \\ | '_ \\   / _` | / _` || '_ ` _ \\  / _ \\",
            "| |_/ /| (_) || | | | | || |_) | | (_| || (_| || | | | | ||  __/",
            "\\____/  \\___/ |_| |_| |_||_.__/   \\__, | \\__,_||_| |_| |_| \\___|",
            "                                   __/ |                        ",
            "                                  |___/                           "
        };

        public static string[] GAME_CLEAR = new string[]
        {
            " d888b   .d8b.  .88b  d88. d88888b    .o88b. db      d88888b  .d8b.  d8888b. ",
            "88' Y8b d8' `8b 88'YbdP`88 88'       d8P  Y8 88      88'     d8' `8b 88  `8D ",
            "88      88ooo88 88  88  88 88ooooo   8P      88      88ooooo 88ooo88 88oobY' ",
            "88  ooo 88~~~88 88  88  88 88~~~~~   8b      88      88~~~~~ 88~~~88 88`8b   ",
            "88. ~8~ 88   88 88  88  88 88.       Y8b  d8 88booo. 88.     88   88 88 `88. ",
            " Y888P  YP   YP YP  YP  YP Y88888P    `Y88P' Y88888P Y88888P YP   YP 88   YD "
        };

        public static string[] GAME_OVER = new string[]
        {
            " d888b   .d8b.  .88b  d88. d88888b    .d88b.  db    db d88888b d8888b. ",
            "88' Y8b d8'  8b 88'YbdP 88 88'       .8P  Y8. 88    88 88'     88  `8D ",
            "88      88ooo88 88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY' ",
            "88  ooo 88~~~88 88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b   ",
            "88. ~8~ 88   88 88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88. ",
            " Y888P  YP   YP YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD "
        };

        public static string[] TIME_OVER = new string[]
        {
            "d888888b d888888b .88b  d88. d88888b    .d88b.  db    db d88888b d8888b. ",
            "`~~88~~'   `88'   88'YbdP`88 88'       .8P  Y8. 88    88 88'     88  `8D ",
            "   88       88    88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY' ",
            "   88       88    88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b   ",
            "   88      .88.   88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88. ",
            "   YP    Y888888P YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD "
        };

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // 콘솔 애플리케이션에서 출력 인코딩을 UTF-8로 설정 (특수 문자 출력 가능)
            Console.CursorVisible = false; // 커서 숨기기
            Console.SetWindowSize(80, 40); // 콘솔 창 크기 조정
            Console.SetBufferSize(80, 40); // 버퍼 크기 조정
            Console.ForegroundColor = ConsoleColor.Green; // 텍스트 색 변경

            Console.Clear();

            // Main Title 아스키아트 출력
            foreach (var line in MAIN_TITLE)
            {
                Console.WriteLine(line);
                Thread.Sleep(200); // 일정 시간 대기
            }
            Console.WriteLine("\n\n                        Press any key...");

            Console.ReadKey(); // 키 입력시

            Console.ForegroundColor = ConsoleColor.White; // 텍스트 색 변경

            map.InitMapBuffer(); // 맵 초기화

            for (int i = 0; i < MAX_ENEMY; i++)
            {
                enemies.Add(new Enemy()); // 객체 할당
                enemies[i].Initialize(); // 적 객체 위치 초기화
            }

            while (true)
            {
                Console.Clear();
                map.InitMapBuffer(); // 맵 초기화
                player.KeyControl();

                // 폭탄 리스트를 통해 폭탄을 버퍼에 저장
                foreach (var bomb in Program.Bombs)
                    map.Buffer[bomb.Y, bomb.X / 2] = "💣";

                // 플레이어 버퍼에 저장
                if (!player.isInvincible)
                    map.Buffer[player.Y, player.X / 2] = "😳";
                else
                    map.Buffer[player.Y, player.X / 2] = "🤕";

                // Enemy 이동 (1초마다 이동)
                if (enemyMoveTime + 1000 < Environment.TickCount) // 1초가 지났을 때
                {
                    remainingTime--; // 전체 시간 감소

                    foreach (var enemy in enemies)
                        enemy.Move(player); // Enemy 이동 (좌표 변경)

                    enemyMoveTime = Environment.TickCount; // 현재 시간으로 초기화
                }

                // Enemy 버퍼에 저장
                foreach (var enemy in enemies)
                    map.Buffer[enemy.Y, enemy.X / 2] = "😈";

                // 게임 클리어 이벤트
                if (enemies.Count == 0) // 적이 0일 때
                {
                    remainingTime = 0;
                    Console.ForegroundColor = ConsoleColor.Green; // 텍스트 색 변경
                    Thread.Sleep(50);
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("🥳 모든 적을 처치하였습니다!\n");
                    Thread.Sleep(500);
                    // Game Clear 아스키아트 출력
                    foreach (var line in GAME_CLEAR)
                    {
                        Console.WriteLine(line);
                        Thread.Sleep(200);
                    }
                    Environment.Exit(0);
                }

                // 시간 초과 이벤트
                if (remainingTime < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // 텍스트 색 변경
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("⏳ 시간이 종료되었습니다! 게임 오버!\n");
                    // Time Over 아스키아트 출력
                    foreach (var line in TIME_OVER)
                    {
                        Console.WriteLine(line);
                        Thread.Sleep(500);
                    }
                    
                    Environment.Exit(0); // 프로그램 종료
                }

                map.Draw(); // 버퍼 출력

                Thread.Sleep(50); // 게임 프레임 조정 (1000/50 FPS -> 20 FPS)
            }
        }
    }
}