using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Monster
    {
        public Info m_tMonster; // 몬스터 데이터

        public void SetDamage(int iAttack) { m_tMonster.iHp -= iAttack; } // 들어오는 인자값으로 Hp 감소

        // Info 클래스 타입 인자로 몬스터 데이터를 넣어줌
        public void SetMonster(Info tMonster) { m_tMonster = tMonster; }

        public Info GetMonster() { return m_tMonster; }

        public void Render()
        {
            Console.WriteLine("====================");
            Console.WriteLine("몬스터 이름: " + m_tMonster.strName);
            Console.WriteLine("체력: " + m_tMonster.iHp + "\t공격력: " + m_tMonster.iAttack);
        }

        public Monster() { }

        ~Monster() { }
    }
}