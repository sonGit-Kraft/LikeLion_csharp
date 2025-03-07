using BricksGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame
{
    public class Ball
    {
        // 공에 대한 데이터를 저장
        BALLDATA m_tBall = new BALLDATA();

        // 공의 방향에 대한 배열 정의
        int[,] g_WallCollision = new int[4, 6]
        {
            {  3,  2, -1, -1, -1, 4 },
            { -1, -1, -1, -1,  2, 1 },
            { -1,  5,  4, -1, -1,-1 },
            { -1, -1,  1,  0,  5,-1 }
        };

        Bar m_pBar;

        // Bar 클래스의 객체를 설정
        public void SetBar(Bar bar) { m_pBar = bar; }

        // 공 객체를 반환
        public BALLDATA GetBall() { return m_tBall; }

        // 공의 X 좌표를 수정
        public void SetX(int x) { m_tBall.nX += x; }

        // 공의 Y 좌표를 수정
        public void SetY(int y) { m_tBall.nY += y; }

        // 공의 데이터를 설정
        public void SetBall(BALLDATA tBall) { m_tBall = tBall; }

        // 공의 상태를 설정
        public void SetReady(int Ready) { m_tBall.nReady = Ready; }

        // 테두리 그림
        public void ScreenWall()
        {
            Program.gotoxy(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Program.gotoxy(0, 1);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 2);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 3);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 4);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 5);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 6);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 7);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 8);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 9);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 10);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 11);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 12);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 13);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 14);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 15);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 16);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 17);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 18);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 19);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 20);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 21);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 22);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 23);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }

        // 벽과 바에 충돌하는지 체크, 충돌 시 방향을 변경
        public int Collision(int x, int y)
        {
            // 벽 충돌 처리
            if (y == 0)  // 상단 벽
            {
                m_tBall.nDirect = g_WallCollision[0, m_tBall.nDirect];
                return 1; // 공의 방향이 바뀌면 1을 리턴
            }

            if (x == 1)  // 왼쪽 벽
            {
                m_tBall.nDirect = g_WallCollision[1, m_tBall.nDirect];
                return 1;
            }

            if (x == 77)  // 오른쪽 벽
            {
                m_tBall.nDirect = g_WallCollision[2, m_tBall.nDirect];
                return 1;
            }

            if (y == 23)  // 하단 벽
            {
                m_tBall.nDirect = g_WallCollision[3, m_tBall.nDirect];
                return 1;
            }

            // 바 충돌 처리
            // 바 위쪽에서 충돌 처리
            if (x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] + 1 &&
                y == (m_pBar.m_tBar.nY))
            {
                // 공의 방향에 따라 바운스
                if (m_tBall.nDirect == 1)
                    m_tBall.nDirect = 2;
                else if (m_tBall.nDirect == 2)
                    m_tBall.nDirect = 1;
                else if (m_tBall.nDirect == 5)
                    m_tBall.nDirect = 4;
                else if (m_tBall.nDirect == 4)
                    m_tBall.nDirect = 5;

                return 1; // 방향 변경
            }

            // 바 아래쪽에서 충돌 처리
            if (x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] + 1 &&
                y == (m_pBar.m_tBar.nY + 1))
            {
                // 공의 방향에 따라 바운스
                if (m_tBall.nDirect == 1)
                    m_tBall.nDirect = 2;
                else if (m_tBall.nDirect == 2)
                    m_tBall.nDirect = 1;
                else if (m_tBall.nDirect == 5)
                    m_tBall.nDirect = 4;
                else if (m_tBall.nDirect == 4)
                    m_tBall.nDirect = 5;

                return 1; // 방향 변경
            }

            return 0; // 충돌이 없으면 0을 리턴
        }

        // 공 초기화
        public void Initalize()
        {
            m_tBall.nReady = 0; // 0 움직는 상태, 1 대기 상태
            m_tBall.nDirect = 1; // 공의 초기 방향 (오른쪽 위)
            m_tBall.nX = 30;  // 공의 초기 X 좌표
            m_tBall.nY = 10;  // 공의 초기 Y 좌표
        }

        // 공의 움직임 처리
        public void Progress()
        {
            if (m_tBall.nReady == 0)
            {
                // 공의 방향에 따라 움직임 처리
                switch (m_tBall.nDirect)
                {
                    case 0: // 위로
                        if (Collision(m_tBall.nX, m_tBall.nY - 1) == 0)
                            m_tBall.nY--;  // 벽 충돌이 없으면 위로 이동
                        break;
                    case 1: // 오른쪽 위로
                        if (Collision(m_tBall.nX + 1, m_tBall.nY - 1) == 0)
                        {
                            m_tBall.nX++;
                            m_tBall.nY--;  // 벽 충돌이 없으면 오른쪽 위로 이동
                        }
                        break;
                    case 2: // 오른쪽 아래로
                        if (Collision(m_tBall.nX + 1, m_tBall.nY + 1) == 0)
                        {
                            m_tBall.nX++;
                            m_tBall.nY++;  // 벽 충돌이 없으면 오른쪽 아래로 이동
                        }
                        break;
                    case 3: // 아래로
                        if (Collision(m_tBall.nX, m_tBall.nY + 1) == 0)
                            m_tBall.nY++;  // 벽 충돌이 없으면 아래로 이동
                        break;
                    case 4: // 왼쪽 아래로
                        if (Collision(m_tBall.nX - 1, m_tBall.nY + 1) == 0)
                        {
                            m_tBall.nX--;
                            m_tBall.nY++;  // 벽 충돌이 없으면 왼쪽 아래로 이동
                        }
                        break;
                    case 5: // 왼쪽 위로
                        if (Collision(m_tBall.nX - 1, m_tBall.nY - 1) == 0)
                        {
                            m_tBall.nX--;
                            m_tBall.nY--;  // 벽 충돌이 없으면 왼쪽 위로 이동
                        }
                        break;
                }
            }
        }

        // 공을 화면에 그리는 함수
        public void Render()
        {
            ScreenWall();  // 벽을 그린다
            Program.gotoxy(m_tBall.nX, m_tBall.nY);  // 공의 위치로 커서를 이동
            Console.Write("●");  // 공을 출력
        }

        // 리소스 해제 함수 (구현 X)
        public void Release() { }
    }
}