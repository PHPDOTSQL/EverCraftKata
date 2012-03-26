using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EverCraftKata
{
    [TestFixture]
    public class When_working_with_abilities
    {
        Abilities abilities;
        Character bob;
        [SetUp]
        public void Run_once_before_each_test()
        {
            abilities = new Abilities();
            bob = new Character("Bob", Alignment.Good);
        }

        [Test]
        public void giving_no_abilities_returns_default_ten()
        {
            Assert.AreEqual(10, bob.Abilities.Strength);
            Assert.AreEqual(10, bob.Abilities.Dexterity);
            Assert.AreEqual(10, bob.Abilities.Constitution);
            Assert.AreEqual(10, bob.Abilities.Wisdom);
            Assert.AreEqual(10, bob.Abilities.Intelligence);
            Assert.AreEqual(10, bob.Abilities.Charisma);
        }

        [TestCase(21, 1, 1, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 21, 1, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 21, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 21, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 1, 21, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 1, 1, 21, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(0, 1, 1, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 0, 1, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 0, 1, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 0, 1, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 1, 0, 1, ExpectedException = (typeof(ArgumentException)))]
        [TestCase(1, 1, 1, 1, 1, 0, ExpectedException = (typeof(ArgumentException)))]
        public void cant_give_abilities_over_20_or_under_1(int s, int d, int con, int w, int i, int chr)
        {
            Abilities ab = new Abilities(s, d, con, w, i, chr);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void trying_one_silly_exception_case()
        {
            Abilities ab = new Abilities(0, 1, 1, 1, 1, 1);
        }

        [Test]
        public void strength_of_20_returns_plus_five_modifier()
        {
            abilities = new Abilities(20, 5, 5, 5, 5, 5);
            var mod = abilities.Modifier(abilities.Strength);
            Assert.AreEqual(5, mod);
        }
    }
}
