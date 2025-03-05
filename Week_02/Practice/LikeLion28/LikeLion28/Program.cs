using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion28
{
    // base: 부모 클래스 호출
    
    class Parent
    {
        public virtual void ShowMessage()
        {
            Console.WriteLine("부모 클래스의 메세지");
        }
    }

    class Child : Parent
    {
        public override void ShowMessage()
        {
            Console.WriteLine("자식 클래스의 메세지");
            base.ShowMessage(); // 부모 메서드 실행
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();

            child.ShowMessage(); // Parent.ShowMessage() (virtual) -> Child.ShowMessage() (override)
        }
    }
}