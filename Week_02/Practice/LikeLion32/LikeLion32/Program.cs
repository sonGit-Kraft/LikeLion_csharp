using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello; // 네임스페이스를 편하게 사용 가능

// 네임스페이스
namespace Hello
{
    class Say
    {
        public void SayHello()
        {
            Console.WriteLine("안녕하세요!");
        }
    }
}

namespace LikeLion32
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello.Say say1 = new Hello.Say();
            say1.SayHello();

            Say say2 = new Say(); // using Hello; 사용시 Hello 생략 가능
            say2.SayHello();
        }
    }
}
