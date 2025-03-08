using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTest
{
    class Monster : Unit
    {
        public void ShowInfo()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("몬스터 이름: " + Name);
            Console.WriteLine("체력: " + Hp + "\t공격력: " + Attack);
            Console.WriteLine();
        }
    }
}