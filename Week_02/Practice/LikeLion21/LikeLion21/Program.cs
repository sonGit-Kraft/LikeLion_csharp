using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion21
{
    //  IEnumerable<T> 를 구현하여 커스텀 컬렉션을 만들 수 있음
    class SimpleCollection : IEnumerable<int>
    {
        private int[] data = { 1, 2, 3, 4, 5 };
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new SimpleCollection();

            foreach (var i in collection)
                Console.WriteLine(i);
        }
    }
}