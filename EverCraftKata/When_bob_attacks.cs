using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EverCraftKata
{
    [TestFixture]
    public class When_bob_attacks
    {
        Character bob;

        [SetUp]
        public void Run_once_before_each_test()
        {
            bob = new Character("Bob", Alignment.Good);
            bob.Die_roll = 10;
        }

        [Test]
        public void rolling_ten_against_ac_five_hits()
        {
            Assert.IsTrue(bob.Is_a_hit(10, 5));
        }

        [Test]
        public void hit_deals_one_point_damage()
        {
            int damage_points = bob.Attack(5);
            Assert.AreEqual(1, damage_points);
        }

        [Test]
        public void natural_20_deals_double_damage()
        {
            bob.Die_roll = 20;
            int damage_points = bob.Attack(5);
            Assert.AreEqual(2, damage_points);
        }
    }
}
