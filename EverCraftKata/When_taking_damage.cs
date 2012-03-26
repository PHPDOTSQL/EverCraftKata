using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EverCraftKata
{
    [TestFixture]
    public class When_taking_damage
    {
        private Character bob;
        [SetUp]
        public void Run_once_before_each_test()
        {
            this.bob = new Character("Bob", Alignment.Good);
            Assert.AreEqual("Bob", bob.Name);
        }

        [Test]
        public void taking_damage_decrements_hit_points()
        {
            bob.Take_damage(2);
            Assert.AreEqual(3, bob.Hit_points);
        }

        [Test]
        public void taking_five_points_damage_kills_bob_oh_noes()
        {
            bob.Take_damage(5);
            Assert.IsFalse(bob.Is_alive);
        }
    }
}
