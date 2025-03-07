using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame
{
    public class Block
    {
        public BLOCKDATA[] blocks = new BLOCKDATA[100]; // 벽돌 개수는 100개

        public void Initialize()
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new BLOCKDATA();

                // 한 줄에 20개씩 배치
                blocks[i].nX = (i % 20) * 3 + 10; // x 간격 3 (왼쪽에서 10칸부터 시작)
                blocks[i].nY = (i / 20) * 2 + 2; // y 간격 2 (상단에서 2칸 아래부터 시작)
            }
        }

        public void Render()
        {
            foreach (var block in blocks)
            {
                if (block.isActive) // 벽돌이 남아 있을 때만 출력
                {
                    Program.gotoxy(block.nX, block.nY);
                    Console.Write("■");
                }
            }
        }

        public void Progress(ref Ball ball)
        {
            foreach (var block in blocks)
            {
                if (block.isActive &&
                    ball.GetBall().nX == block.nX &&
                    ball.GetBall().nY == block.nY)
                {
                    block.isActive = false; // 벽돌 제거

                    // 공의 반사 처리 (방향을 바꾸는 예시)
                    switch (ball.GetBall().nDirect)
                    {
                        case 0: // 위
                            ball.GetBall().nDirect = 3; // 아래로 반사
                            break;
                        case 1: // 오른쪽 위
                            ball.GetBall().nDirect = 2; // 오른쪽 아래로 반사
                            break;
                        case 2: // 오른쪽 아래
                            ball.GetBall().nDirect = 1; // 오른쪽 위로 반사
                            break;
                        case 3: // 아래
                            ball.GetBall().nDirect = 0; // 위로 반사
                            break;
                        case 4: // 왼쪽 아래
                            ball.GetBall().nDirect = 5; // 왼쪽 위로 반사
                            break;
                        case 5: // 왼쪽 위
                            ball.GetBall().nDirect = 4; // 왼쪽 아래로 반사
                            break;
                    }
                    break;
                }
            }
        }

        // 리소스 해제 함수 (구현 X)
        public void Release() { }
    }
}