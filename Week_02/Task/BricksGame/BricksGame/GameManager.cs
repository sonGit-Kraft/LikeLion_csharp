using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame
{
    class GameManager
    {
        Ball m_pBall = null;
        Bar m_pBar = null;
        Block m_pBlock = null;

        // 객체 생성 및 초기화
        public void Initialize()
        {
            if (m_pBall == null)
            {
                m_pBall = new Ball();
                m_pBall.Initalize();
            }

            if (m_pBar == null)
            {
                m_pBar = new Bar();
                m_pBar.Initialize();
            }

            if (m_pBlock == null)
            {
                m_pBlock = new Block();
                m_pBlock.Initialize();
            }

            // Ball 객체에 Bar 객체를 연결 (Ball이 Bar와 상호작용 할 수 있도록 설정)
            m_pBall.SetBar(m_pBar);
        }

        // 상태 업데이트
        public void Progress()
        {
            m_pBall.Progress();
            m_pBar.Progress(ref m_pBall);
            m_pBlock.Progress(ref m_pBall);
        }

        // 화면 렌더링
        public void Render()
        {
            Console.Clear();
            m_pBall.Render();
            m_pBar.Render();
            m_pBlock.Render();
        }

        // 리소스 해제
        public void Release()
        {
            m_pBall.Release();
            m_pBar.Release();
            m_pBlock.Release();
        }
    }
}