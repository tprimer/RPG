using System;

namespace ConsoleRPG
{
    class RPG
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            // Player 1
            Player Jerrin = new Player("Jerrin", 3, 1, 2, 1);
            Jerrin.set_MH(new Broadsword());
            Jerrin.set_OH(new Dagger());
            Jerrin.set_armour(new Armour("Leather", 20, 2, 10));
            Jerrin.get_armour().print_stats();
            // Player 2
            Player Wodan = new Player("Wodan", 1, 3, 1, 2);
            Wodan.set_MH(new Broadsword());
            Wodan.set_OH(new Kite_Shield());
            Wodan.set_armour(new Armour("Chain", 40, 2, 10));
            // Print
            Wodan.print_stats();
            Jerrin.print_stats();
            // Attack
            Console.WriteLine("Jerrin attacks Wodan");
            Attacks.make_attack(Jerrin,Jerrin.get_MH(), Wodan);
            Attacks.make_attack(Jerrin,Jerrin.get_OH(), Wodan);
            Console.WriteLine("Wodan attacks Jerrin");
            Attacks.make_attack(Wodan,Wodan.get_MH(), Jerrin);
            while (true) { }
                
        }
    }
}
