using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion29
{
    class Player
    {
        protected string Name; // protected: 상속 관계에서만 사용할 때
        
        public Player() // 생성자
        {
            Name = "플레이어";
            Console.WriteLine("부모 클래스 생성자입니다.");
        }

        public void Show()
        {
            Console.WriteLine(Name);
        }
    }

    class Wizard : Player
    {
        public Wizard() // 생성자
        {
            Name = "마법사";
            Console.WriteLine("자식 클래스 생성자입니다.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            p.Show();

            Wizard w = new Wizard(); // 부모 클래스 생성자 실행 후 자식 클래스 생성자 실행
            w.Show();
        }
    }
}