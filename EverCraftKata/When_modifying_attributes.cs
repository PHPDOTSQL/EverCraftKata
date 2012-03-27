using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EverCraftKata
{
    [TestFixture]
    public class When_modifying_attributes
    {
        Character bob;

        [SetUp]
        public void Run_before_each_test()
        {
            bob = new Character("Bob", Alignment.Good);        	
        }

        [Test]
        public void Strength_of_20_adds_modifier_to_attack_roll()
        {
            bob.Abilities.Strength = 20;
            bob.Die_roll = 10;

            int modified_roll = bob.Roll_a_die();

            Assert.AreEqual(15, modified_roll);
        }

        [Test]
        public void Strength_of_1_subtracts_modifier_from_attack_roll()
        {
            bob.Abilities.Strength = 1;
            bob.Die_roll = 10;

            int modified_roll = bob.Roll_a_die();

            Assert.AreEqual(5, modified_roll);
        }

        [Test]
        public void Rolling_an_adjusted_20_doesnt_make_a_critical_hit()
        {
            bob.Abilities.Strength = 10;
            bob.Die_roll = 15;

            int damage = bob.Attack(1);

            Assert.AreEqual(1, damage);
        }

        [Test]
        public void Rolling_a_natural_20_makes_a_critical_hit()
        {
            bob.Abilities.Strength = 10;
            bob.Die_roll = 20;

            int damage = bob.Attack(1);

            Assert.AreEqual(2, damage);
        }

        [Test]
        public void Non_critical_hit_damage_includes_strength_modifier()
        {
            bob.Abilities.Strength = 20;
            bob.Die_roll = 19;

            int damage = bob.Attack(1);

            Assert.AreEqual(6, damage);
        }

        [Test]
        public void Critical_hit_shows_2x_Strength_mod_for_damage()
        {
            bob.Abilities.Strength = 20;
            bob.Die_roll = 20;

            int damage = bob.Attack(1);

            Assert.AreEqual(12, damage);
        }
    }
}