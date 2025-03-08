using BricksGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame
{
    // Bar 클래스
    public class Bar
    {
        public BARDATA m_tBar = new BARDATA(); // 바의 데이터를 담는 객체
        int m_nCatch; // 공을 잡았는지 여부 체크

        const int LEFTKEY = 75; // 왼쪽 화살표 키 값 (상수로 정의)

        // 바 초기화
        public void Initialize()
        {
            // 공을 잡지 않은 상태로 초기화
            m_nCatch = 0;

            // 바의 Y 좌표 (화면에서 수직 위치)
            m_tBar.nY = 18;

            // 바의 X 좌표
            m_tBar.nX[0] = 12; m_tBar.nX[1] = 14; m_tBar.nX[2] = 16;
        }

        // 바의 움직임과 공의 상태를 처리
        public void Progress(ref Ball pBall)
        {
            int nKey = 0; // 사용자 입력 키 값

            if (Console.KeyAvailable) // 키 입력이 있을 때
            {
                nKey = Program._getch(); // 키 값을 가져옴

                switch (nKey)
                {
                    case LEFTKEY: // 왼쪽 키
                        m_tBar.nX[0]--; // 바의 X 좌표를 왼쪽으로 이동
                        m_tBar.nX[1]--;
                        m_tBar.nX[2]--;

                        if (pBall.GetBall().nReady == 1 && m_nCatch == 1) // 공이 바에 의해 잡혀있는 상태
                            pBall.SetX(-1); // 공을 왼쪽으로 이동시킴
                        break;
                    case 77: // 오른쪽 키
                        m_tBar.nX[0]++; // 바의 X 좌표를 오른쪽으로 이동
                        m_tBar.nX[1]++;
                        m_tBar.nX[2]++;

                        if (pBall.GetBall().nReady == 1 && m_nCatch == 1) // 공이 바에 의해 잡혀있는 상태
                            pBall.SetX(1); // 공을 오른쪽으로 이동시킴
                        break;
                    case 'a': // a 키를 눌렀을 때 (공 놓기)
                        pBall.SetReady(0); // 공이 다시 움직이게 설정
                        m_nCatch = 0; // 공을 놓은 상태로 설정
                        break;
                    case 's': // s 키를 눌렀을 때 (공을 잡는 동작)
                        if (pBall.GetBall().nX >= m_tBar.nX[0] &&
                            pBall.GetBall().nX <= m_tBar.nX[2] + 1 &&
                            pBall.GetBall().nY == (m_tBar.nY - 1))
                        {
                            pBall.SetReady(1); // 공을 잡은 상태로 설정
                            m_nCatch = 1; // 공을 잡았다고 설정
                        }
                        break;
                }
            }
        }

        // 바를 화면에 출력
        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Program.gotoxy(m_tBar.nX[i], m_tBar.nY); // 바의 각 X, Y 좌표로 커서를 이동
                Console.Write("▥"); // 바를 화면에 출력
            }
        }

        // 리소스 해제 함수 (구현 X)
        public void Release() { }
    }
}