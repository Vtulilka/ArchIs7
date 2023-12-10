using Lab6.Controllers;
using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        private static Controllers.ViewController VC = new Controllers.ViewController();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите 1, чтобы вывести всех покемонов");
                Console.WriteLine("Нажмите 2, чтобы вывести всех владельцев покемонов");
                Console.WriteLine("Нажмите 3, чтобы вывести владельца определенного покемона");
                Console.WriteLine("Нажмите ESC для выхода");
                Console.WriteLine();
                var btn = Console.ReadKey(true).Key;
                switch (btn)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        VC.PrintPokemons();
                        break;
                    case ConsoleKey.D2:
                        VC.PrintOwners();
                        break;
                    case ConsoleKey.D3:
                        VC.PrintPokemonOwners();
                        break;
                    default:
                        Console.Write("Неизвестный ввод");
                        Console.WriteLine();
                        break;
                }
            }


        }
    }
}
