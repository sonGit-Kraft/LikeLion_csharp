using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion26
{
    // 업캐스팅(Upcasting)
    // 자식 클래스 -> 부모 클래스 타입으로 변환
    // 암시적 변환이 가능 (컴파일러가 자동 변환)
    // 안전: 데이터 손실 없이 변환 가능

    // 다운캐스팅
    // 부모 클래스 -> 자식 클래스 타입으로 변환
    // 명시적 변환이 필요 (타입)
    // 업캐스팅된 객체만 가능
    // 불안정함 -> 실행 중 InvalidCastException 발생 가능
    // is, as 키워드로 안전하게 변환 가능

    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog1 = new Dog(); // 자식 클래스 객체 생성
            Animal myAnimal1 = myDog1; // 업캐스팅 (Dog -> Animal)

            myAnimal1.Speak(); // 부모 클래스 메서드 사용 가능
            // myAnimal.Bark(); // 오류: 업캐스팅 후 자식 클래스의 메서드는 접근 불가

            Animal myAnima2 = new Dog(); // 업캐스팅
            Dog myDog2 = (Dog)myAnima2; // 다운캐스팅 (명시적 변환) -> 안정성 낮음

            myDog2.Bark();

            // myAnima2이 Dog 타입인지 검사 후
            // 검사에 성공하면 dog 변수에 자동으로 다운캐스팅된 객체를 할당(Dog dog = (Dog)myAnima2;)
            if (myAnima2 is Dog dog)
                dog.Bark();
            else
                Console.WriteLine("변환할 수 없습니다.");

            /*
            Animal myAnima3 = new Animal();
            // 업캐스팅된 객체만 가능
            Dog myDog3 = (Dog)myAnima3; // Error: Can't assign a variable of a higher type to a variable of a lower type

            // 업캐스팅: 자식 클래스(Dog)를 부모 클래스(Animal)라는 큰 상자에 담는 것
            // 다운캐스팅: 그 상자에서 원래 Dog 객체를 다시 꺼내는 것
            // 업캐스팅 없이 다운캐스팅:	큰 상자(Animal)에 물건이 없는데 Dog를 꺼내려는 것 (불가능)
            */

            Animal myAnima4 = new Dog(); // 업캐스팅
            Dog myDog4 = myAnima4 as Dog; // 성공 시 다운캐스팅, 실패 시 null 반환

            if (myDog4 != null) // null이 아니면 성공한 것으로 판단
                myDog4.Bark();
            else
                Console.WriteLine("변환할 수 없습니다.");
        }
    }
}