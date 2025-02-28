using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask12
{
    // 스타크래프트 클래스화
    class Marin
    {
        public string Name;
        public int Mineral;

        public Marin()
        {
            Name = "마린";
            Mineral = 50;
        }

        public Marin(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"미네랄: {Mineral}");
        }
    }

    class SCV
    {
        public string Name;
        public int Mineral;

        public SCV()
        {
            Name = "SCV";
            Mineral = 50;
        }

        public SCV(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"미네랄: {Mineral}");
        }
    }

    class Barracks
    {
        public string Name;
        public int Mineral;

        public Barracks()
        {
            Name = "Barracks";
            Mineral = 150;
        }

        public Barracks(string Name, int Mineral)
        {
            // this 자기 자신을 가르키는 키워드
            // (멤버변수) = (매개변수)
            this.Name = Name;
            this.Mineral = Mineral;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"미네랄: {Mineral}");
        }
    }

    class Mineral
    {
        // public string Name;
        public int Count;

        public Mineral()
        {
            Count = 1500;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"현재 미네랄: {Count}");
        }
    }

    // Game 클래스
    class Game
    {
        public static int Mineral;
        public static int Gas;
        public static int CharCount;

        public static void ShowInfo()
        {
            Console.WriteLine($"미네랄: {Mineral}");
            Console.WriteLine($"가스: {Gas}");
            Console.WriteLine($"인구: {CharCount}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Marin marin1 = new Marin();
            Marin marin2 = new Marin("불꽃 마린", 100);

            marin1.ShowInfo();
            marin2.ShowInfo();

            SCV scv1 = new SCV();
            SCV scv2 = new SCV("열받은 SCV", 70);

            scv1.ShowInfo();
            scv2.ShowInfo();

            Barracks barracks1 = new Barracks();
            Barracks barracks2 = new Barracks("차가운 Barracks", 200);

            barracks1.ShowInfo();
            barracks2.ShowInfo();

            // Mineral 클래스 배열 생성
            Mineral[] mineral = new Mineral[7];

            // 각 배열 요소에 Mineral 객체 생성 및 할당
            for (int i = 0; i < mineral.Length; i++)
            {
                mineral[i] = new Mineral();
                mineral[i].ShowInfo();
            }

            // static 멤버는 객체 생성 없이 사용 가능
            Game.Mineral = 50;
            Game.Gas = 50;
            Game.CharCount = 4;

            Game.ShowInfo();
        }
    }
}
