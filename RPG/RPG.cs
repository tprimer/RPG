using System;

namespace ConsoleRPG
{
    class RPG
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            // Player 1
            Player PC = new Player("Jerrin", 49, 18, 15);
            PC.set_abilities(60, 30, 30, 30);
            PC.set_MH(new Broadsword());
            PC.set_OH(new Dagger());
            PC.set_armour(new Armour("Leather", 20, 2, 10));
            PC.get_armour().print_stats();
            // Player 2
            Player PC2 = new Player("Wodan", 32, 18, 18);
            PC2.set_abilities(40, 50, 30, 30);
            PC2.set_MH(new Broadsword());
            //PC2.set_OH(new Kite_Shield());
            PC2.set_armour(new Armour("Chain", 40, 2, 10));
            // Print
            PC2.print_stats();
            PC.print_stats();
            // Attack
            Console.WriteLine("Jerrin attacks Wodan");
            Attacks.make_attack(PC,PC.get_MH(), PC2);
            Attacks.make_attack(PC,PC.get_OH(), PC2);
            Console.WriteLine("Wodan attacks Jerrin");
            Attacks.make_attack(PC2,PC2.get_MH(), PC);
            while (true) { }
                
        }
    }
}
