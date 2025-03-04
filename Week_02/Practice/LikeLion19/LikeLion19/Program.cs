using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LikeLion19
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열과 컬렉션
            int[] numbers = { 1, 2, 3, 4, 5 };

            foreach (var num in numbers)
                Console.WriteLine(num);

            // 리스트
            // 배열과 비슷하지만 *동적으로 크기가 변하는* 가변 길이 컬렉션
            // 배열은 고정적인 크기로 쓸 때 사용
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

            names.Add("Dave");
            names.Remove("Bob");

            foreach (var name in names)
                Console.WriteLine(name);

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach (int num in list)
                Console.WriteLine(num);

            Console.WriteLine(list[1]);
            list.Insert(1, 100); // 1번 index에 100 저장
            Console.WriteLine(list[1]);

            list[2] = 200;
            list.Remove(3); // 리스트에 있는 3 제거

            Console.WriteLine(list.Count); // 리스트에 포함된 요소의 개수
            foreach (int num in list)
                Console.WriteLine(num);

            // Stack (LIFO(Last-In, First-Out))
            // 형식 지정 X → 비제네릭 (using System.Collections;) Stack 
            Stack stack = new Stack();
            // 형식 지정 O → 제네릭 (using System.Collections.Generic;) Stack<T>
            // Stack<int> stack = new Stack<int>();  // int형만 저장 가능

            stack.Push(1);
            stack.Push("2");
            stack.Push(3);

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            // Queue (FIFO(First-In, First-Out))
            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue("2");
            queue.Enqueue(3);

            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());

            // ArrayList (비제네릭 리스트)
            // 크기가 동적으로 조정되는 배열, 다양한 형식의 데이터 저장 가능
            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.14);

            Console.WriteLine("ArrayList 요소:");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            arrayList.Remove(1); // 값이 1인 요소 제거

            Console.WriteLine("\nArrayList 요소 제거 후:");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            // Hashtable
            // 키-값 쌍을 저장하는 컬렉션
            // 키를 사용해 값을 빠르게 검색
            Hashtable hashtable = new Hashtable();

            // 키-값 쌍 추가
            hashtable["Alice"] = 25;
            hashtable["Bob"] = 30;
            hashtable["포션"] = 20;

            Console.WriteLine("Hashtable 요소:");
            foreach (DictionaryEntry entry in hashtable)
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");

            // 특정 키의 값 가져오기
            Console.WriteLine($"\nAlice의 나이: {hashtable["Alice"]}");

            // 요소 제거
            hashtable.Remove("Bob");
            Console.WriteLine("\n요소 제거 후 Hashtable:");
            foreach (DictionaryEntry entry in hashtable)
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }
}
