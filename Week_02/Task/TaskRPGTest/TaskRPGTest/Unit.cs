using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRPGTest
{
    class Unit
    {
        public string Name;
        public int Attack;
        public int Hp;

        public void GetDamage(Unit target)
        {
            Hp -= target.Attack;
        }
    }
}