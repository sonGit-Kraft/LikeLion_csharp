using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion6
{
    class Program
    {
        static void Main(string[] args)
        {
            int att = 16755;
            int life = 78103;
            int fatal = 36;
            int specialization = 1017;
            int subdue = 41;
            int swiftness = 611;
            int patience = 22;
            int skill = 39;

            // 기본 특성 출력
            Console.WriteLine("<기본 특성>");
            Console.WriteLine("공격력: " + att);
            Console.WriteLine("최대 생명력: " + life);

            Console.WriteLine(); // 개행

            // 전투 특성 출력
            Console.WriteLine("<전투 특성>");
            Console.WriteLine("치명: " + fatal);
            Console.WriteLine("특화: " + specialization);
            Console.WriteLine("제압: " + subdue);
            Console.WriteLine("신속: " + swiftness);
            Console.WriteLine("인내: " + patience);
            Console.WriteLine("숙련: " + skill);
        }
    }
}