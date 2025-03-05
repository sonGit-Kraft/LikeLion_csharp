using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask19
{
    // 부모 클래스
    class Champion
    {
        public string Name;
        public int Health;
        public int ATK;
        public int MP;

        public Champion()
        {
            Name = "Unknown";
            Health = 0;
            ATK = 0;
            MP = 0;
        }

        public virtual void ShowStat()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"ATK: {ATK}");
            Console.WriteLine($"MP: {MP}\n");
        }

        public virtual void Attack(Champion target)
        {
            Console.WriteLine($"{Name}이 {target.Name}에게 기본 공격을 합니다.");
        }

        public virtual void Heal(Champion target)
        {
            Console.WriteLine($"{Name}은 치료할 수 없습니다.");
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name}이 이동합니다.");
        }
    }

    // Gragas 챔피언
    class Gragas : Champion
    {
        public Gragas()
        {
            Name = "Gragas";
            Health = 500;
            ATK = 50;
            MP = 200;
        }

        public override void Attack(Champion target)
        {
            Console.WriteLine($"{Name}가 술통으로 {target.Name}을 공격합니다.");
            MP -= 20;
            target.Health -= ATK;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}가 이동합니다.");
        }
    }

    // Veigar 챔피언
    class Veigar : Champion
    {
        public Veigar()
        {
            Name = "Veigar";
            Health = 100;
            ATK = 30;
            MP = 500;
        }

        public override void Attack(Champion target)
        {
            Console.WriteLine($"{Name}가 마법으로 {target.Name}을 공격합니다.");
            MP -= 20;
            target.Health -= ATK;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}가 이동합니다.");
        }
    }

    // LeeSin 챔피언
    class LeeSin : Champion
    {
        public LeeSin()
        {
            Name = "LeeSin";
            Health = 300;
            ATK = 50;
            MP = 300;
        }

        public override void Attack(Champion target)
        {
            Console.WriteLine($"{Name}이 음파로 {target.Name}을 공격합니다.");
            MP -= 20;
            target.Health -= ATK;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}이 이동합니다.");
        }
    }

    // Soraka 챔피언
    class Soraka : Champion
    {
        public Soraka()
        {
            Name = "Soraka";
            Health = 200;
            ATK = 10;
            MP = 500;
        }

        public override void Attack(Champion target)
        {
            Console.WriteLine($"{Name}가 마법으로 {target.Name}을 공격합니다.");
            MP -= 20;
            target.Health -= ATK;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}가 이동합니다.");
        }

        public override void Heal(Champion target)
        {
            Console.WriteLine($"{Name}가 {target.Name}을 치료합니다.");
            target.Health += 20;
            MP -= 20;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Champion> team1 = new List<Champion>();

            team1.Add(new Gragas()); // 업캐스팅
            team1.Add(new Veigar()); // 업캐스팅

            List<Champion> team2 = new List<Champion>();
            team2.Add(new LeeSin()); // 업캐스팅
            team2.Add(new Soraka()); // 업캐스팅

            Console.WriteLine("<Team 1>");
            foreach (Champion champ in team1)
                champ.ShowStat();
            
            Console.WriteLine("<Team 2>");
            foreach (Champion champ in team2)
                champ.ShowStat();

            team1[0].Attack(team2[0]); // 그라가스 -> 리신 공격
            team1[0].ShowStat(); team2[0].ShowStat();

            team1[1].Attack(team2[1]); // 베이가 -> 소라카 공격
            team1[1].ShowStat(); team2[1].ShowStat();

            team2[0].Attack(team1[0]); // 리신 -> 그라가스 공격
            team2[0].ShowStat(); team1[0].ShowStat();

            team2[1].Attack(team1[1]); // 소라카 -> 베이가 공격
            team2[1].ShowStat(); team1[1].ShowStat();

            team2[1].Heal(team2[0]); // 소라카 -> 리신 힐
            team2[1].ShowStat(); team2[0].ShowStat();
        }
    }
}