using System;

namespace ConsoleRPG
{
    public class Armour : Item
    {
        private int deflection;
        private int DR;

        public Armour(string n, int d, int r, int w) : base(n,w)
        {
            name = n;
            deflection = d;
            DR = r;
            weight = w;
        }

        public virtual void print_stats()
        {
            Console.WriteLine("Armour:" + name);
            Console.Write("Defl: {0} DR: {1} Weight: {2} \n",deflection,DR,weight);
        }

        public int get_deflection()  { return deflection; }
        public int get_DR()          { return DR; }
    }      
}
