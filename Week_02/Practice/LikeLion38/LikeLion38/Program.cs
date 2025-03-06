using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion38
{
    // 부모 클래스
    class Parent
    {
        protected string name;
        public Parent(string name)
        {
            this.name = name;
            Console.WriteLine("부모 생성자 호출 " + "이름: " + name);
        }
    }

    // 자식 클래스
    class Child : Parent
    {
        private int age;

        public Child(string name, int age)
            : base(name) // 부모 클래스의 생성자 호출 (name 전달)
        {
            this.age = age;
            Console.WriteLine("자식 생성자 호출 " + "나이: " + age);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}, 나이: {age}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child("손도현", 22);
            child.ShowInfo();
        }
    }
}