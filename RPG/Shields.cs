using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Shield : Item
    {
        protected string type;
        protected int block_chance;
        protected int block_value;

        public Shield(string n, string t, int bc, int bv, int w ) : base(n, w)
        {
            type = t;
            block_chance = bc;  block_value = bv;

        }

        public virtual void print_stats()
        {
            Console.WriteLine("{0} - {1}", name, type);
            Console.WriteLine("Block chance: {0} Value: {1}", block_chance, block_value);
        }
        public string get_type() { return type; }
        public int get_block_chance() { return block_chance; }
        public int get_block_value() { return block_value; }

    }

    public class Buckler : Shield
    {
        public Buckler() : base("Buckler", "light shield", 10, 10, 20) { }
    }

    public class Kite_Shield : Shield
    {
        public Kite_Shield() : base("Kite Shield", "medium shield", 20, 20, 30) { }
    }

    public class Tower_Shield : Shield
    {
        public Tower_Shield() : base("Tower Shield", "heavy shield", 30, 30, 40) { }
    }
}
