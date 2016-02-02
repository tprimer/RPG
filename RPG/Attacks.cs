using System;

namespace ConsoleRPG
{
    class Attacks
    {
        static public void make_attack(Character attacker, Item item, Character target)
        {
            Weapon weapon;
            if( item is Weapon) { weapon = (Weapon)item; }
            else { return; }
            // Print attack weapon and defense armour
            weapon.print_stats();
            target.get_armour().print_stats();
            // Calculate attack bonus
            int attack_bonus = Attacks.get_attack(attacker,weapon);
            // Calculate dodge chance
            double dodge_chance = 0.5 + (double)(Defenses.get_dodge(target, weapon) - attack_bonus) / 100;
            // Calculate deflection chance
            double deflection_chance = 0.5 + (double)(Defenses.get_deflection(target, weapon) - attack_bonus) / 100;
            // Calculate block chance
            double block_chance = (double)(Defenses.get_block(target, target.get_OH()))/100;
            double hit_chance = (1 - dodge_chance) * (1 - deflection_chance)*(1- block_chance);
            Console.WriteLine("Attack: {0} Dodge: {1} Deflect: {2} Block: {3} Hit: {4}", attack_bonus, dodge_chance, deflection_chance, block_chance, hit_chance);
            Random rand = new Random();
            //try attacks
            for (int i = 0; i < 10; i++)
            {
                if (rand.Next(1, 100)/100.0 <= dodge_chance) Console.WriteLine("DODGED!!");
                else if (rand.Next(1, 100)/100.0 <= deflection_chance)
                {
                    if (rand.Next(1, 100)/100.0 <= Defenses.get_parry(target, weapon) + 0.25) Console.WriteLine("PARRIED!!");
                    else Console.WriteLine("DEFLECTED OFF ARMOUR!!");
                }
                else if (rand.Next(1, 100)/100.0 <= block_chance) Console.WriteLine("BLOCKED!!");
                else Console.WriteLine("HIT!!");
            }
        }

        static public int get_attack(Character attacker, Weapon weapon)
        {
            int attack;
            string weapon_type = weapon.get_type();
            switch (weapon_type)
            {
                case "light melee":
                    attack = (int)(0.5 * attacker.get_attack() + 0.6 * attacker.get_speed()); break;
                case "medium melee":
                    attack = (int)(0.5 * attacker.get_attack() + 0.35 * attacker.get_speed() + 0.35 * attacker.get_strength()); break;
                case "heavy melee":
                    attack = (int)(0.5 * attacker.get_attack() + 0.6 * attacker.get_strength()); break;
                default:
                    attack = (int)(0.5 * attacker.get_attack() + 0.3 * attacker.get_speed() + 0.3 * attacker.get_strength()); break;
            }
            return attack;
    }
    }
}
