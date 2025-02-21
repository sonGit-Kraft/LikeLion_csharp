using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TodayTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            string loading = "□□□□□□□□□□";
            char[] loadingArray = loading.ToCharArray(); // 문자열을 문자 배열로 변환

            for (int i=0;i<10;i++)
            {
                Console.WriteLine(loadingArray);
                Console.WriteLine("Loading~");
                Thread.Sleep(1000); // 1초 딜레이 (1000 밀리초)
                Console.Clear(); // 콘솔 화면 지우기
                loadingArray[i] = '■';
            }

            Console.Clear();
            Console.WriteLine("아무 키나 입력하세요...");
            Console.ReadKey(); // 키 입력 대기
            Console.Clear();

            Console.WriteLine("멋사고등학교는 오래된 역사와 전통을 자랑하는 명문 사립학교다.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("그러나 이 학교에는 \"1년마다 한 명의 학생이 사라진다.\"라는 기묘한 소문이 떠돌고 있다.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("쉬는 시간 중, 주인공은 우연히 학교의 오래된 기숙사 건물에 관한 이야기를 듣게 되는데...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[재원]\n \"야, 이번 주말에 학교 뒤쪽에 있는 폐기숙사 탐방 갈래?\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[서연]\n \"뭐?! 너 미쳤어? 거기 출입 금지라고!\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[민석]\n \"근데 왜 갑자기 거길 가자는 거야?\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[재원]\n \"몰랐어? 우리 학교 전설 중에 제일 유명하잖아.\n 옛날에 어떤 학생이 기숙사에서 사라졌는데, 지금도 그 학생이 밤마다 돌아다닌다는 소문이 있어.\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[서연]\n \"완전 소름 돋는데... 나 진짜 안 갈래.\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[재원]\n \"에이~ 겁쟁이. 너는 어떡할 거야?\" (장난스럽게 주인공을 바라보며)");
            Console.WriteLine("1) 재밌겠는데? 나도 갈래!\n2) 음… 좀 무서울 것 같아. 안 갈래.");

            Console.Write("선택: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choice == 1)
                Console.WriteLine("[민석]\n \"오, 그래? 그럼 나도 갈래!\"");
            else if(choice == 2)
                Console.WriteLine("[재원]\n \"에이~ 겁쟁이들. 그래도 나랑 몇 명 더 가기로 했으니까, 너희도 궁금하면 언제든 말해!\"");
            
            Console.ReadKey();
            Console.Clear();
        }
    }
}