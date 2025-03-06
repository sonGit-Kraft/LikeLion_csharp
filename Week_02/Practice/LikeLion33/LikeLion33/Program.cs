using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion33
{
    class Person
    {
        // 필드: 클래스의 데이터를 저장하는 멤버
        // private -> 외부 접근 불가
        private string name = "이름 없음"; // 선언과 동시에 초기화 가능
        public void SetName(string name) // 멤버 변수 초기화 함수
        {
            this.name = name;
        }
        public string GetName() // 멤버 변수 반환 함수
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(); // 객체 생성 (인스턴스)

            p.SetName("Alice");
            // p.name = "Alice"; // 필드에 값 넣기

            Console.WriteLine(p.GetName());
        }
    }
}