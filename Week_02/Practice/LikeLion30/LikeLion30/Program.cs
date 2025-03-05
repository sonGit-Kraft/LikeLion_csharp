using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion30
{
    // 부모 클래스 (기본 유닛)
    class Unit
    {
        public string Name;
        public int Health;
        
        public Unit()
        {
            Name = "Unknown";
            Health = 0;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name}이 기본 공격을 합니다.");
        }

        public virtual void Heal(Unit target)
        {
            Console.WriteLine($"{Name}은 치료할 수 없습니다.");
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name}이 이동합니다.");
        }
    }

    // SCV유닛 (건설과 수리 가능)
    class SCV : Unit
    {
        public SCV()
        {
            Name = "SCV";
            Health = 60;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name}가 용접기로 공격합니다. (공격력이 약함)");
        }

        public override void Heal(Unit target)
        {
            Console.WriteLine($"{Name}가 {target.Name}을 수리합니다. (기계 유닛만 가능)");
        }
    }

    // Marine유닛 (총기 공격 가능)
    class Marine : Unit
    {
        public Marine()
        {
            Name = "Marine";
            Health = 40;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name}이 소총으로 공격합니다.");
        }
    }

    // Medic유닛 (치료 가능)
    class Medic : Unit
    {
        public Medic()
        {
            Name = "Medic";
            Health = 50;
        }

        public override void Heal(Unit target)
        {
            Console.WriteLine($"{Name}이 {target.Name}을 치료합니다. (생명 유닛만 가능)");
        }
    }

    // Tank유닛 (강력한 공격 가능)
    class Tank : Unit
    {
        public Tank()
        {
            Name = "Tank";
            Health = 150;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name}가 시즈 모드로 강력한 포격!");
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}가 천천히 움직입니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Unit> units = new List<Unit>();

            units.Add(new SCV()); // 업캐스팅
            units.Add(new Marine()); // 업캐스팅
            units.Add(new Medic()); // 업캐스팅
            units.Add(new Tank()); // 업캐스팅

            // 모든 유닛을 순회하며 다형성 적용
            foreach(var unit in units)
            {
                unit.Move();
                unit.Attack();
                Console.WriteLine();
            }

            // SCV가 탱크 수리
            SCV scv = new SCV();
            scv.Heal(units[3]);

            units[0].Heal(units[3]);

            Console.WriteLine();

            // Medic이 Marine 치료
            Medic medic = new Medic();
            medic.Heal(units[1]);

            units[2].Heal(units[1]);
        }
    }
}