using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame
{
    class Program
    {
        // C언어의 _getch() 함수를 외부 DLL에서 가져와 사용
        [DllImport("msvcrt.dll")]
        public static extern int _getch(); // 키 입력 함수

        // 특정 위치로 커서를 이동
        public static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            // GameManager 객체 생성 및 초기화
            GameManager gm = new GameManager();
            gm.Initialize();

            // 현재 시간을 저장
            int Curr = Environment.TickCount;

            // 게임 루프 시작
            while (true)
            {
                // 50ms마다 게임 진행
                if (Curr + 50 < Environment.TickCount)
                {
                    Curr = Environment.TickCount; // 현재 시간으로 업데이트
                    gm.Progress(); // 게임 상태 업데이트
                    gm.Render(); // 게임 화면 렌더링
                }
            }
        }
    }
}
