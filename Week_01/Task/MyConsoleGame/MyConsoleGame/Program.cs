using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyConsoleGame
{
    class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  // c언어 함수 가져옴
        public int X; // X 좌표
        public int Y; // Y 좌표


        public Player() // 생성자
        {
            // 플레이어 좌표 위치 초기화
            X = 2;
            Y = 3;
        }

        public void KeyControl()
        {
            int pressKey; // 키 값

            if (Console.KeyAvailable) // 키가 눌렸을 때 true
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(" ");

                // _getch(): 문자 입력 함수
                pressKey = _getch(); // 아스키값으로 들어옴 (정수형 변수에 들어가기 때문)

                // 밀림 방지
                if (pressKey == 0 || pressKey == 224) // 화살표 키 또는 특수 키 감지
                    pressKey = _getch(); // 실제 키 값 읽기

                int newX = X;
                int newY = Y;

                switch (pressKey)
                {
                    case 72: // 위쪽 방향 아스키코드
                        newY--;
                        break;
                    case 75: // 왼쪽 방향 아스키코드
                        newX--;
                        break;
                    case 77: // 오른쪽 방향 아스키코드
                        newX++;
                        break;
                    case 80: // 아래쪽 방향 아스키코드
                        newY++;
                        break;
                    case 32: // 스페이스바 아스키코드
                             // 폭탄 발사 (미구현)
                        break;
                }

                // 새로운 위치가 맵 내에 있고, 그 위치가 "██"나 "░░"이 아닌지 체크
                if (IsValidMove(newX, newY))
                {
                    X = newX;
                    Y = newY;
                }
            }
        }

        private bool IsValidMove(int newX, int newY)
        {
            // 맵의 경계를 벗어나지 않는지 체크
            if (newX < 1 || newY < 1 || newX >= Map.width || newY >= Map.height)
                return false;

            // 맵에서 해당 위치가 벽인지를 확인
            string[] rows = Map.map.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string row = rows[newY];

            // 벽이 공백이 아닌 문자이면 벽으로 취급
            if (row[newX] != ' ')
            {
                return false; // 공백이 아니면 벽으로 취급
            }


            return true;
        }








        // 플레이어 그리기
        public void PlayerDraw()
        {
            string player = "😐";

            // 콘솔 좌표 설정 (X, Y)
            Console.SetCursorPosition(X, Y);

            // 문자열 배열 출력
            Console.WriteLine(player);

        }

    }

    static class Map
    {
        // 맵 크기 설정 (50 x 25)
        public static int width = 48; // 맵의 너비
        public static int height = 24; // 맵의 높이

        public static string map = @"
██████████████████████████████████████████████████
██  ██      ░░  ██  ██      ██      ░░  ██      ██
██      ██  ░░      ░░  ██      ░░      ░░  ██  ██
██  ██  ██  ██      ██      ██  ██  ██      ██  ██
██      ░░      ░░  ██      ░░      ░░      ░░  ██
██  ██  ██  ██  ██      ░░      ██  ██  ██      ██
██      ░░  ░░      ██  ██  ░░  ░░  ██      ░░  ██
██  ██  ██  ██  ██      ██  ██  ░░      ██  ██  ██
██      ░░      ░░  ░░      ██      ░░      ░░  ██
██  ██  ██      ██  ██  ██      ██  ██      ██  ██
██      ██  ░░      ░░      ░░      ░░  ██      ██
██  ██  ██  ██  ██      ██  ██  ██      ██  ██  ██
██      ░░      ░░  ██    ██      ░░      ░░██  ██
██          ██                  ░░██            ██
██  ██      ██      ██    ░░            ██      ██
████  ██  ██  ██  ██      ██  ██  ██  ██  ██  ████
██      ██          ░░              ░░        ████
██      ░░      ██       ░░       ██    ██      ██
██████████████████████████████████████████████████";



        public static void DrawMap()
        {
            // 상단 테두리
            Console.SetCursorPosition(0, 0);
            
            Console.Write(map);
        }
    }

    class Bomb
    {

    }

    class Item
    {

    }

    class Enemy
    {
        public int X;
        public int Y;

        public Enemy()
        {
            // 랜덤 좌표 생성
            Random rand = new Random();
            X = rand.Next(1, 48);
            Y = rand.Next(1, 23);
        }

        // 플레이어 그리기
        public void EnemyDraw()
        {
            string Enemy = "🤖";

            // 콘솔 좌표 설정 (X, Y)
            Console.SetCursorPosition(X, Y);

            // 문자열 배열 출력
            Console.WriteLine(Enemy);

        }
        public void EnemyMove()
        {
            string Enemy = "🤖";

            Random rand = new Random();
            int Xmove = rand.Next(0, 2) * 2 - 1; // -1 or 1
            int Ymove = rand.Next(0, 2) * 2 - 1; // -1 or 1

            X += Xmove;
            Y += Ymove;

            if (X < 1) X = 1;
            if (Y < 1) Y = 1;
            if (X > 47) X = 47;
            if (Y > 23) Y = 23;

        }
    }

    class Program
    {
        static int remainingTime = 60; // 남은 시간 (초)
        static Timer timer; // Timer 변수 선언

        static Player player = new Player(); // 플레이어 생성
        static Enemy[] enemy = new Enemy[5]; // 적 생성

        static void Main(string[] args)
        {
            // 콘솔 애플리케이션에서 출력 인코딩을 UTF-8로 설정 (특수 문자 출력 가능)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false; // 커서 비활성화
            Console.SetWindowSize(60, 40);
            Console.SetBufferSize(60, 40);

            // 타이머 시작 (1초마다 TimerCallback 함수(메서드) 실행)
            timer = new Timer(TimerCallback, null, 0, 1000); // Timer 객체 생성 (생성자 호출)

            // Enemy 객체 초기화
            for (int i = 0; i < enemy.Length; i++)
                enemy[i] = new Enemy();

            // 맵을 그려주는 부분
            Map.DrawMap();

            while (true)
            {
                // 키를 입력하는 부분
                player.KeyControl();

                // 플레이어를 그려주는 부분
                player.PlayerDraw();




            }
        }

        static void TimerCallback(object state) // TimerCallback 함수 선언
        {
            /*
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"⏳ 남은 시간: {remainingTime}초 ");
            */
            remainingTime--; // 전체 시간 감소

            /*
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].EnemyMove();
                enemy[i].EnemyDraw();
            }
            */

            if (remainingTime < 0)
            {
                timer.Dispose(); // 타이머(Timer) 객체를 정리(해제): 타이머 중지
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("  ██████   █████   ███    ███ ███████      ██████   ██    ██ ███████ ██████  ");
                Thread.Sleep(200);
                Console.WriteLine(" ██       ██   ██  ████  ████ ██          ██    ██  ██    ██ ██      ██   ██ ");
                Thread.Sleep(200);
                Console.WriteLine(" ██   ███ ███████  ██ ████ ██ █████       ██    ██  ██    ██ █████   ██████  ");
                Thread.Sleep(200);
                Console.WriteLine(" ██    ██ ██   ██  ██  ██  ██ ██          ██    ██   ██  ██  ██      ██   ██ ");
                Thread.Sleep(200);
                Console.WriteLine("  ██████  ██   ██  ██      ██ ███████      ██████     ████   ███████ ██   ██ ");
                Console.WriteLine();
                Console.WriteLine("⏳ 시간이 종료되었습니다! 게임 오버!");
                Environment.Exit(0); // 프로그램 종료
            }
        }
    }
}