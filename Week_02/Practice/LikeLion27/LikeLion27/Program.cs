using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion27
{
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }
    
    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("멍멍!");
        }
        public void WagTail()
        {
            Console.WriteLine("꼬리를 흔든다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal1 = new Dog(); // 업캐스팅
            myAnimal1.Speak(); // 오버라이드된 메서드 실행 Animal.Speak() (virtual) -> Dog.Speak() (override)
            // myAnimal1.WagTail(); // 오류 발생

            Dog d = (Dog)myAnimal1; // 다운캐스팅
            d.WagTail();

            Animal myAnimal2 = new Animal();
            myAnimal2.Speak();
        }
    }
}