using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion16
{
    // get/set 방식의 함수
    class Person
    {
        // 객체의 값을 읽고(get) 설정(set)하는 방식

        private string Name; // 내부 변수 (클래스 내부에서만 사용 가능)

        // private 값 설정하기 (Setter)
        public void SetName(string Name)
        {
            this.Name = Name;
        }

        // private 값 가져오기 (Getter)
        public string GetName()
        {
            return Name;
        }
    }

    // 프로퍼티 property
    class Person1
    {
        private string name; // 내부 변수
        public string Name // 프로퍼티
        {
            get { return name; }
            set { name = value; }
        }
    }

    // 프로퍼티 property 자동 구현
    class Person2
    {
        private int count = 100;
        public string Name { get; set; } // 프로퍼티 자동 구현

        public int Count
        {
            get { return count; } // 읽기만 가능
        }

        // 정보 은닉 + 읽기 전용 프로퍼티 패턴
        public float Balance { get; private set; } // 읽기: 외부에서 가능, 쓰기: 내부에서만 가능

        public void AddBal()
        {
            Balance += 100;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // get/set 방식의 함수 사용
            Person p = new Person();

            // p.Name = "손도현"; // 에러 발생
            p.SetName("손도현");

            Console.WriteLine(p.GetName());

            // 프로퍼티 property 사용
            Person1 p1 = new Person1();

            p1.Name = "손도현";
            Console.WriteLine(p1.Name);

            // 프로퍼티 property 자동 구현 사용
            Person2 p2 = new Person2();
            p2.Name = "손도현";
            Console.WriteLine(p2.Name);

            Console.WriteLine(p2.Count); // 읽기만 가능
            // p2.Count = 200; // 에러 발생

            Console.WriteLine(p2.Balance); // 읽기만 가능
            // p2.Balance = 12.2; // 에러 발생
        }
    }
}