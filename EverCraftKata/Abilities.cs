using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EverCraftKata
{
    public class Abilities
    {
        const int MAX = 20;
        const int MIN = 1;
        const int DEFAULT = 10;
        int strength;
        int dexterity;
        int constitution;
        int wisdom;
        int intelligence;
        int charisma;

        Hashtable modifications = new Hashtable
        {
            { 1, -5 },
            { 2, -4 },
            { 3, -4 },
            { 4, -3 },
            { 5, -3 },
            { 6, -2 },
            { 7, -2 },
            { 8, -1 },
            { 9, -1 },
            { 10, 0 },
            { 11, 0 },
            { 12, 1 },
            { 13, 1 },
            { 14, 2 },
            { 15, 2 },
            { 16, 3 },
            { 17, 3 },
            { 18, 4 },
            { 19, 4 },
            { 20, 5 }
        };

        public Abilities()
        {
            Strength = DEFAULT;
            Dexterity = DEFAULT;
            Constitution = DEFAULT;
            Wisdom = DEFAULT;
            Intelligence = DEFAULT;
            Charisma = DEFAULT;
        }

        public Abilities(int strength,
            int dexterity,
            int constitution,
            int wisdom,
            int intelligence,
            int charisma)
        {
            Check_for_valid_ability_values(strength, dexterity, constitution, wisdom, intelligence, charisma);
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Wisdom = wisdom;
            Intelligence = intelligence;
            Charisma = charisma;
        }
  
        private void Check_for_valid_ability_values(int strength, 
            int dexterity, 
            int constitution, 
            int wisdom, 
            int intelligence, 
            int charisma)
        {
            if (
                Anything_is_too_big(strength, dexterity, constitution, wisdom, intelligence, charisma) ||
                Anything_is_too_small(strength, dexterity, constitution, wisdom, intelligence, charisma)
            )
            {
                throw new ArgumentException("Can't have abilities over 20 or under zero!");
            }
        }
  
        private bool Anything_is_too_small(int strength, int dexterity, int constitution, int wisdom, int intelligence, int charisma)
        {
            return strength < MIN ||
                   dexterity < MIN ||
                   constitution < MIN ||
                   wisdom < MIN ||
                   intelligence < MIN ||
                   charisma < MIN;
        }
  
        private static bool Anything_is_too_big(int strength, int dexterity, int constitution, int wisdom, int intelligence, int charisma)
        {
            return strength > MAX ||
                   dexterity > MAX ||
                   constitution > MAX ||
                   wisdom > MAX ||
                   intelligence > MAX ||
                   charisma > MAX;
        }

        public int Modifier(int ability)
        {
            return (int)modifications[ability];
        }

        public int Charisma
        {
            get
            {
                return this.charisma;
            }
            set
            {
                this.charisma = value;
            }
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        public int Wisdom
        {
            get
            {
                return this.wisdom;
            }
            set
            {
                this.wisdom = value;
            }
        }

        public int Constitution
        {
            get
            {
                return this.constitution;
            }
            set
            {
                this.constitution = value;
            }
        }

        public int Dexterity
        {
            get
            {
                return this.dexterity;
            }
            set
            {
                this.dexterity = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }
    }
}