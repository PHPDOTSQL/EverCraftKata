using System;

namespace EverCraftKata
{
    public class Character
    {
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
        public int Armor_class { get;set; }
        public int Hit_points { get;private set; }
        public string Name { get;set; }

        public int Die_roll { get; set; }

        public bool Is_alive
        {
            get;
            private set;
        }

        private void Initialize_default_abilities()
        {
            Abilities = new Abilities();
            Abilities.Strength = 10;
            Abilities.Dexterity = 10;
            Abilities.Constitution = 10;
            Abilities.Wisdom = 10;
            Abilities.Intelligence = 10;
            Abilities.Charisma = 10;
        }

        public void Take_damage(int damage)
        {
            Hit_points -= damage;
            if (Hit_points <= 0)
            {
                Is_alive = false;
            }
        }

        public int Attack(int armor_class)
        {
            int damage = 0;
            int roll = Roll_a_die();
            bool is_critical = false;
            if (roll == 20)
            {
                is_critical = true;
            }
            if (Is_a_hit(Die_roll, armor_class))
            {
                damage = 1;
            }
            if (is_critical)
            {
                damage *= 2;
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
            if (Die_roll > 0)
            {
                return Die_roll;
            }
            var die = new System.Random();
            int roll = die.Next(20);
            return roll;
        }
    }
}