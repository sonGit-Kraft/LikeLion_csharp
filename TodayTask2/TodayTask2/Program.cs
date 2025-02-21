using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 로스트 아크 활동창 입력후 출력
            float ruin;
            float card;
            float awakening;
            int manaMax;
            int manaHF;
            int manaHNF;
            float speed_m;
            float speed_v;
            float speed_c;
            float skill;

            Console.WriteLine("<활동 내역 입력>");
            Console.Write("루인 스킬 피해(%): ");
            ruin = float.Parse(Console.ReadLine());
            Console.Write("카드 게이지 획득량(%): ");
            card = float.Parse(Console.ReadLine());
            Console.Write("각성기 피해(%): ");
            awakening = float.Parse(Console.ReadLine());
            Console.Write("최대 마나: ");
            manaMax = int.Parse(Console.ReadLine());
            Console.Write("전투 중 마나 회복량: ");
            manaHF = int.Parse(Console.ReadLine());
            Console.Write("비전투 중 마나 회복량: ");
            manaHNF = int.Parse(Console.ReadLine());
            Console.Write("이동 속도(%): ");
            speed_m = float.Parse(Console.ReadLine());
            Console.Write("탈 것 속도(%): ");
            speed_v = float.Parse(Console.ReadLine());
            Console.Write("운반 속도(%): ");
            speed_c = float.Parse(Console.ReadLine());
            Console.Write("스킬 재사용 대기시간 감소(%): ");
            skill = float.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("<활동 내역 출력>");
            Console.WriteLine("루인 스킬 피해: " + ruin + '%');
            Console.WriteLine("카드 게이지 획득량: " + card + '%');
            Console.WriteLine("각성기 피해: " + awakening + '%');
            Console.WriteLine("최대 마나: " + manaMax);
            Console.WriteLine("전투 중 마나 회복량: " + manaHF);
            Console.WriteLine("비전투 중 마나 회복량: " + manaHNF);
            Console.WriteLine("이동 속도: " + speed_m + '%');
            Console.WriteLine("탈 것 속도: " + speed_v + '%');
            Console.WriteLine("운반 속도: " + speed_c + '%');
            Console.WriteLine("스킬 재사용 대기시간 감소: " + skill + '%');
        }
    }
}