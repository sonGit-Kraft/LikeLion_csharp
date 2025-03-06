using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion34
{
    class Person
    {
        public string Name;
        public int Age;

        public Person() // 생성자 오버로딩
        {
            Name = "Unknown";
            Age = 0;
        }

        public Person(string name) // 생성자 오버로딩
        {
            Name = name;
            Age = 0;
        }

        public Person(string name, int age) // 생성자 오버로딩
        {
            Name = name;
            Age = age;
        }

        ~Person() // 소멸자
        {
            Console.WriteLine("삭제될 때 호출");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(); // 생성자 호출
            Console.WriteLine(p1.Name + ' ' + p1.Age);

            Person p2 = new Person("손도현"); // 매개변수가 1개 있는 생성자 호출
            Console.WriteLine(p2.Name + ' ' + p2.Age);

            Person p3 = new Person("손도현", 22); // 매개변수가 2개 있는 생성자 호출
            Console.WriteLine(p3.Name + ' ' + p3.Age);

            // GC(Garbage Collector)에 의해 나중에 소멸자 호출
            // Garbage Collector: 더 이상 참조되지 않는 객체를 찾아서 메모리 해제
        }
    }
}