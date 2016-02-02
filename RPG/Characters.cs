using System;
using System.Collections.Generic;

namespace ConsoleRPG
{
    public class Character
    {
        private string name;

        private int HP;
        private int attack;
        private int defense;

        private int speed;
        private int strength;
        private int willpower;
        private int intellect;

        private Armour armour;
        private Item main_hand;
        private Item off_hand;
        private double encumberance;

        private static int free_encumberance = 30;

        public Character(string n, int h, int a, int d)
        {
            name = n;
            HP = h;
            attack = a;
            defense = d;
            speed = 30;
            strength = 30;
            willpower = 30;
            intellect = 30;
            armour = new Armour("Clothes",0,0,0);
            main_hand = new Nothing();
            off_hand = new Nothing();
        }

        public void print_stats()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("HP: " + HP.ToString());
            Console.WriteLine("ATT: {0} DEF: {1}", attack, defense);
            Console.WriteLine("SPE: {0} STR: {1}", speed, strength);
            Console.WriteLine("INT: {0} WIL: {1}", intellect, willpower);
            Console.WriteLine("Encumberance: {0} Modified Speed: {1}", encumberance, get_speed());
            //foreach(Weapon w in weapons){ w.print_stats(); }
        }

        public void set_abilities(int s, int t, int i, int w) {
            speed = s; strength = t; intellect = i; willpower = w;
        }
        public void set_MH(Item item) { main_hand = item; set_encumberance(); }
        public void set_OH(Item item) { off_hand = item; set_encumberance(); }
        public void set_armour(Armour a) { armour = a; set_encumberance(); }
        public void set_encumberance()
        {
            encumberance = (main_hand.get_weight() + off_hand.get_weight() + armour.get_weight() - free_encumberance) / (double)strength / 4;
        }

        public int get_attack() { return attack; }
        public int get_defense() { return defense; }
        public int get_speed() {
            int modified_speed = (int)(speed * (1 - encumberance));
            return modified_speed;
        }
        public int get_base_speed() { return speed; }
        public int get_strength() { return strength; }
        public int get_intellect() { return intellect; }
        public int get_willpower() { return willpower; }
        public Item get_MH() { return main_hand; }
        public Item get_OH() { return off_hand; }
        public Armour get_armour() { return armour; }
    }

    public class Player : Character
    {
        public Player(string name, int hitpoints, int attack, int defense) : base(name, hitpoints, attack, defense)
        {
            // Sweet
        }

        public new void print_stats()
        {
            base.print_stats();
        }
    }
}