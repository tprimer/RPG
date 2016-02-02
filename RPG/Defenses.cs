using System;

namespace ConsoleRPG
{
    class Defenses
    {
        public static bool debug = false;

        public static int get_dodge(Character target, Weapon weapon)
        {
            int dodge_bonus = (int)((target.get_speed() * 0.5 + target.get_defense() * 0.5) * weapon.get_dodge_mod());
            if (debug) { Console.WriteLine("dodge_bonus: {0}", dodge_bonus); }
            return dodge_bonus;
        }

        public static int get_deflection(Character target, Weapon weapon)
        {

            int armour_def = target.get_armour().get_deflection();
            int parry_def = Defenses.get_parry(target, weapon);
            int parry_bonus = (int)((armour_def * 0.5 + target.get_defense() * 0.5 + 0.5 * parry_def * weapon.get_parry_mod()));
            if (debug) { Console.WriteLine("Armour Defl: {0} Parry Defl: {1} Parry Bonus: {2}", armour_def, parry_def, parry_bonus); }
            return parry_bonus;
        }

        public static int get_block(Character target, Item oh)
        {
            int block_bonus;
            if(oh is Shield)
            {
                Shield shield = (Shield)oh;
                int base_block = shield.get_block_chance();
                switch (shield.get_type())
                {
                    case "light shield":
                        block_bonus = (int)(0.5 * target.get_defense() + 0.3 * target.get_speed()); break;
                    case "medium shield":
                        block_bonus = (int)(0.5 * target.get_defense() + 0.2 * target.get_speed() + 0.3 * target.get_strength()); break;
                    case "heavy shield":
                        block_bonus = (int)(0.5 * target.get_defense() + 0.5 * target.get_strength()); break;
                    default:
                        block_bonus = (int)(0.5 * target.get_defense() + 0.2 * target.get_speed() + 0.3 * target.get_strength()); break;
                }
                block_bonus += base_block;
                return block_bonus;
            }
            else { return 0; }
        }

        public static int get_parry(Character target, Weapon weapon)
        {
            int parry = (int)((0.3 * target.get_strength() + 0.3 * target.get_speed()) * weapon.get_parry_mod());
            return parry;
        }

    }
}
