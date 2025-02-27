using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask10
{
    class Program
    {
        enum WeaponType { Sword, Bow, Staff }

        static void ChooseWeapon(WeaponType Weapon)
        {
            Console.WriteLine($"{Weapon}을 선택했습니다.");
        }

        static void Main(string[] args)
        {
            ChooseWeapon(WeaponType.Sword);
            ChooseWeapon(WeaponType.Bow);
            ChooseWeapon(WeaponType.Staff);
        }
    }
}