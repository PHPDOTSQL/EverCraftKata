using System;

namespace EverCraftKata
{
    public class Character
    {
        const int DEFAULT = 10;
        const int MIN_DAMAGE = 1;

        public Character(string name, Alignment alignment)
        {
            Is_alive = true;
            Alignment = alignment;
            Name = name;
            Armor_class = 10;
            Hit_points = 5;
            Initialize_default_abilities();
        }

        public Abilities Abilities { get; set; }
        public Alignment Alignment { get; set; }
        public int Armor_class { get; set; }
        public int Hit_points { get; private set; }
        public string Name { get; set; }

        public int Die_roll { get; set; }

        public bool Is_alive { get; private set; }

        private void Initialize_default_abilities()
        {
            Abilities = new Abilities();
            Abilities.Strength = DEFAULT;
            Abilities.Dexterity = DEFAULT;
            Abilities.Constitution = DEFAULT;
            Abilities.Wisdom = DEFAULT;
            Abilities.Intelligence = DEFAULT;
            Abilities.Charisma = DEFAULT;
        }

        public void Take_damage(int damage)
        {
            Hit_points -= damage;
            if (Hit_points <= 0)
            {
                Is_alive = false;
            }
        }

        private bool isCritical = false;

        public int Attack(int armor_class)
        {
            int modifier = Abilities.Modifier(Abilities.Strength);
            int roll = Roll_a_die();

            if (Is_a_hit(roll, armor_class))
            {
                return Compute_damages(modifier);
            }
            else
            {
                return 0;
            }
        }
  
        private int Compute_damages(int modifier)
        {
            int damage = MIN_DAMAGE;

            if (isCritical)
            {
                damage *= 2;
                damage += (modifier * 2);
            }
            else
            {
                damage += modifier;
            }
            if (damage < MIN_DAMAGE)
            {
                damage = MIN_DAMAGE;
            }
            return damage;
        }

        public bool Is_a_hit(int roll, int armor_class)
        {
            if (roll > armor_class)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
  
        public int Roll_a_die()
        {
            int modifier = Abilities.Modifier(Abilities.Strength);
            if (Die_roll == 0)
            {
                var die = new System.Random();
                int roll = die.Next(20);
                if (roll == 20)
                {
                    isCritical = true;
                }
                return roll + modifier;
            }
            if (Die_roll == 20)
            {
                isCritical = true;
            }

            return Die_roll + modifier;
        }
    }
}