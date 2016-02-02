using System;

namespace ConsoleRPG
{
    public class Weapon : Item
    {
        protected string type;
        protected Damage_Die damage;
        protected double dodge_mod;
        protected double parry_mod;             

        public Weapon(string n, string t, int w, Damage_Die d) : base( n, w){
            name = n;           type = t;
            weight = w;         damage = d;
            dodge_mod = 1.0;    parry_mod = 1.0;
        }

        public virtual void print_stats(){
            Console.WriteLine("{0} - {1}", name, type);
            Console.WriteLine("Damage: ({0}) {1}", damage.toString(), damage.Roll().ToString());
        }

        public virtual int get_parry(Character ch)
        { int parry = (int)(0.3 * ch.get_strength() + 0.3 * ch.get_speed()); return parry; }

        public virtual double get_dodge_mod() { return dodge_mod; }
        public virtual double get_parry_mod() { return parry_mod; }
        public string get_type() { return type; }

    }

    // Light weapon class
    public class Light_Melee_Weapon : Weapon
    {
        public Light_Melee_Weapon(string n, Damage_Die d) : base(n, "light melee", 10, d) { }
        public override double get_dodge_mod() { return 0.8; }
        public override double get_parry_mod() { return 1.2; }
    }

    // Medium Weapon class
    public class Medium_Melee_Weapon : Weapon
    {
        public Medium_Melee_Weapon(string n, Damage_Die d) : base(n, "medium melee", 20, d) { }
        public override double get_dodge_mod() { return 1.0; }
        public override double get_parry_mod() { return 1.0; }
    }

    // Heavy Weapon class
    public class Heavy_Melee_Weapon : Weapon
    {
        public Heavy_Melee_Weapon(string n, Damage_Die d) : base(n, "heavy melee", 40, d) { }
        public override double get_dodge_mod() { return 1.2; }
        public override double get_parry_mod() { return 0.8; }
    }

    public class Dagger : Light_Melee_Weapon
    {
        public Dagger() : base("Dagger", new Damage_Die(1, 4)) { weight = 5; }
    }

    public class Short_Sword : Light_Melee_Weapon
    {
        public Short_Sword() : base("Short Sword", new Damage_Die(1, 6)) { weight = 10; }
    }

    public class Broadsword : Medium_Melee_Weapon
    {
        public Broadsword() : base("Broadsword", new Damage_Die(2, 4)) { weight = 15; }
    }

    public class Greataxe : Heavy_Melee_Weapon
    {
        public Greataxe() : base("Greataxe", new Damage_Die(1, 12)) { weight = 40; }
    }

    public class Damage_Die
    {
        private int count;
        private int size;
        private Random rand;

        public Damage_Die(int c, int s)
        {
            count = c;
            size = s;
            rand = new Random();
        }

        public int Roll()
        {
            int result=0;
            for(int i=0; i< count; i++)
            {
                result =+ rand.Next(1, size);
            }
            return result;
        }

        public string toString()
        {
            string Dstring = count.ToString() + "d" + size.ToString();
            return Dstring;
        }

    }
}
