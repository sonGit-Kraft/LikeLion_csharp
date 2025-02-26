using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCoordinate
{
    class Player
    {
        public int xpos { get; set; }
        public int ypos { get; set; }
        public int score { get; set; }
    }

    class Apple
    {
        public int xpos { get; set; }
        public int ypos { get; set; }
    }

    class Program
    {
        static int remainingTime = 60; // 남은 시간 (초)
        static Timer timer; // Timer 변수 선언

        static void Main(string[] args)
        {
            // 콘솔 애플리케이션에서 출력 인코딩을 UTF-8로 설정 (특수 문자 출력 가능)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear(); // 화면 초기화
            Console.CursorVisible = false; // 커서 숨기기
            Console.SetWindowSize(50, 30); // 콘솔 창 크기 조정
            Console.SetBufferSize(50, 30); // 버퍼 크기 조정

            // Title 출력
            Console.WriteLine("      AAA   PPPPP  PPPPP   L      EEEEE  ");
            Thread.Sleep(300);
            Console.WriteLine("     A   A  P    P P    P  L      E      ");
            Thread.Sleep(300);
            Console.WriteLine("     AAAAA  PPPPP  PPPPP   L      EEEE   ");
            Thread.Sleep(300);
            Console.WriteLine("     A   A  P      P       L      E      ");
            Thread.Sleep(300);
            Console.WriteLine("     A   A  P      P       LLLLL  EEEEE  ");
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("     GGGGG   AAAAA  M     M EEEEE  ");
            Thread.Sleep(300);
            Console.WriteLine("    G       A     A MM   MM E      ");
            Thread.Sleep(300);
            Console.WriteLine("    G  GGG  AAAAAAA M M M M EEEE   ");
            Thread.Sleep(300);
            Console.WriteLine("    G    G  A     A M  M  M E      ");
            Thread.Sleep(300);
            Console.WriteLine("     GGGG   A     A M     M EEEEE  ");

            Thread.Sleep(3000);
            Console.Clear();

            // 테두리 크기 설정 (40 x 22)
            int width = 38;
            int height = 20;

            // 상단 테두리
            Console.SetCursorPosition(0, 0);
            Console.Write("┏" + new string('━', width) + "┓"); // new string('━', width): '━'를 width만큼 반복하여 생성

            // 중간 테두리
            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("┃" + new string(' ', width) + "┃");
            }

            // 하단 테두리
            Console.SetCursorPosition(0, height + 1);
            Console.Write("┗" + new string('━', width) + "┛");

            // 플레이어, 사과 좌표 설정
            Random rnd = new Random();
            Player user1 = new Player { xpos = 1, ypos = 1, score = 0 }; // 플레이어 객체 생성
            Apple apple = new Apple { xpos = rnd.Next(1, width), ypos = rnd.Next(1, height) }; // 사과 객체 생성

            // 사과 출력
            Console.SetCursorPosition(apple.xpos, apple.ypos);
            Console.WriteLine("🍎");

            // 타이머 시작 (1초마다 TimerCallback 함수(메서드) 실행)
            timer = new Timer(TimerCallback, null, 0, 1000); // Timer 객체 생성 (생성자 호출)

            /* Timer 생성자의 일반적인 사용 방식
             * public Timer(TimerCallback callback, object? state, int dueTime, int period);
             * callback: 주기적으로 실행할 콜백 메서드
             * state: 콜백 메서드에 전달할 데이터 (보통 null)
             * dueTime: 첫 실행 지연 시간 (0이면 즉시 실행, ms 단위)
             * period: 반복 실행 간격 (1000이면 1초마다 실행, ms 단위)
             * 참고: https://learn.microsoft.com/ko-kr/dotnet/api/system.threading.timer.-ctor?view=net-8.0
            */

            while (true)
            {
                Console.SetCursorPosition(0, height + 2);
                Console.WriteLine("점수: " + user1.score);

                Console.SetCursorPosition(user1.xpos, user1.ypos);
                Console.WriteLine("😀");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // 이전 위치 지우기
                Console.SetCursorPosition(user1.xpos, user1.ypos);
                Console.WriteLine(" ");

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: //위
                        if (user1.ypos > 1)
                            user1.ypos--;
                        break; 
                    case ConsoleKey.DownArrow: // 아래
                        if (user1.ypos < height)
                            user1.ypos++;
                        break; 
                    case ConsoleKey.LeftArrow: // 왼쪽
                        if (user1.xpos > 1)
                            user1.xpos--;
                        break; 
                    case ConsoleKey.RightArrow: // 오른쪽
                        if (user1.xpos < width)
                            user1.xpos++;
                        break; 
                    case ConsoleKey.Escape: // ESC 입력시 종료
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                }

                // 이동 후 플레이어 출력
                Console.SetCursorPosition(user1.xpos, user1.ypos);
                Console.WriteLine("😀");

                // 플레이어가 사과를 먹었을 때 = 플레이어가 사과 위치일 떄
                if (user1.xpos == apple.xpos && user1.ypos == apple.ypos)
                {
                    user1.score++; // 점수 증가

                    // 사과 위치 재설정
                    apple.xpos = rnd.Next(1, width); apple.ypos = rnd.Next(1, height);
                    Console.SetCursorPosition(apple.xpos, apple.ypos);
                    Console.WriteLine("🍎");
                }
            }
        }

        static void TimerCallback(object state) // TimerCallback 함수 선언
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"⏳ 남은 시간: {remainingTime}초 ");

            remainingTime--; // 전체 시간 감소

            if (remainingTime < 0)
            {
                timer.Dispose(); // 타이머(Timer) 객체를 정리(해제): 타이머 중지
                Console.Clear();
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