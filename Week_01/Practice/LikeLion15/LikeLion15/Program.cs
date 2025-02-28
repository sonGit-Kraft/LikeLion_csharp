using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion15
{
    // 클래스
    class Person
    {
        public string Name;
        public int Age;

        // 기본 생성자
        // 클래스가 객체로 생성될 때 자동으로 실행되는 메서드(함수)
        // 클래스와 같은 이름, 반환형이 없음 (void도 사용하지 않음)
        // 객체를 만들 때 필요한 초기값을 설정할 때 사용
        // 기본 생성자는 매개변수가 없는 생성자
        public Person()
        {
            Name = "이름 없음";
            Age = 0;
            Console.WriteLine("기본 생성자 실행");
        }

        // 매개변수 생성자
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("매개변수 생성자 실행");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"나이: {Age}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(); // 객체 생성 (instance) -> 생성자 자동 호출
            p1.ShowInfo();

            Person p2 = new Person("손도현", 22); // 객체 생성 -> 매개변수 생성자 호출
            p2.ShowInfo();
        }
    }
}