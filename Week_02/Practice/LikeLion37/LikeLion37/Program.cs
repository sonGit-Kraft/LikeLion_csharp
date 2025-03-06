using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion37
{
    // 부모 클래스
    class Parent
    {
        public Parent(string message)
        {
            Console.WriteLine("부모 생성자 " + message);
        }
    }

    // 자식 클래스
    class Child : Parent
    {
        public Child() 
            : base("호출") // 부모 클래스의 생성자 호출
        {
            Console.WriteLine("자식 생성자 호출");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
        }
    }
}