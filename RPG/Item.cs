using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Item
    {
        protected string name;
        protected int weight;

        public Item(string n, int w) { name = n; weight = w; }
        public virtual string get_name() { return name; }
        public virtual int get_weight() { return weight; }
    }
    public class Nothing : Item
    {
        public Nothing() : base("Nothing", 0) { }
    }
}
