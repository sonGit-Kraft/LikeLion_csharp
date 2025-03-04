using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("사과");
            list.Add("바나나");
            list.Add("포도");

            foreach (string value in list)
                Console.WriteLine(value);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("첫 번째 작업");
            queue.Enqueue("두 번째 작업");
            queue.Enqueue("세 번째 작업");

            foreach (string value in queue)
                Console.WriteLine(value);

            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            foreach (int value in stack)
                Console.WriteLine(value);
        }
    }
}
