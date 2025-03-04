using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion20
{
    class Program
    {
        class Cup<T>
        {
            public T Content { get; set; }
        }

        static void Main(string[] args)
        {
            // 제네릭 사용하기(Generics)
            // <T> 제네릭 클래스를 사용하면 특정 타입에 종속되지 않는 범용 클래스를 만들 수 있음
            Cup<string> cupOfString = new Cup<string> { Content = "Coffee" };
            Cup<int> cupOfInt = new Cup<int> { Content = 42 };

            Console.WriteLine($"cupOfString: {cupOfString.Content}");
            Console.WriteLine($"cupOfInt: {cupOfInt.Content}");

            // Stack 제네릭 클래스
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            // List<T> 제네릭 클래스
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            names.Add("Dave");

            foreach (var name in names)
                Console.WriteLine(name);

            // IEnumerator
            // C# 컬렉션 순회 반복할 수 있는 인터페이스
            // IEnumerator를 사용하는 이유:
            // - 컬렉션을 직접 제어하며 순회할 수 있음
            // - foreach 없이도 컬렉션 순회 가능
            // - LINQ나 커스텀 컬렉션을 만들 때 유용함
            ArrayList list = new ArrayList { "Apple", "Banana", "Cherry" };
            IEnumerator enumerator = list.GetEnumerator(); // 열거자 가져오기

            while (enumerator.MoveNext()) // 다음 요소가 있는지 확인
                Console.WriteLine(enumerator.Current); // 현재 요소 출력

            // Dictionary〈T, T〉 제네릭 클래스
            Dictionary<string, int> ages = new Dictionary<string, int>();

            ages["금도끼"] = 10;
            ages["은도끼"] = 5;
            ages["돌도끼"] = 1;

            foreach (var pair in ages)
                Console.WriteLine($"{pair.Key}: {pair.Value}");

            // null
            // 참조형식 null을 가질 수 있으며, 값 형식은 기본적으로 null을 가질 수 업음
            string str1 = null;

            if (str1 == null)
                Console.WriteLine("str1 is null");

            // Nullable<T> 형식
            // int? 와 같은 형식으로 값 형식에 null을 허용할 수 있음
            int? nullableInt = null;
            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");
            
            nullableInt = 10;
            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");

            // null 값을 다루는 연산자 (??, ?. 연산자)
            // ?? 연산자를 사용해 null인 경우 대체값을 제공
            // ?. 은 null 안전 접근 (null 체크)
            string str2 = null;
            Console.WriteLine(str2 ?? "DefaultValue"); // str2가 null이면 "DefaultValue"
            /*
            if(str2 != null)
                Console.WriteLine(str2);
            else
                 Console.WriteLine("DefaultValue");               
            */

            str2 = "Hello";
            Console.WriteLine(str2?.Length); // str2가 null이 아니면 길이 출력
            /*
            if(str2 != null)
                Console.WriteLine(str2.Length);
            */

            // LINQ(Language Integrated Query)
            // LINQ를 사용해 컬렉션을 쿼리할 수 있음
            int[] numbers = { 1, 2, 3, 4, 5 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);

            foreach (var num in evenNumbers)
                Console.WriteLine(num);
        }
    }
}
