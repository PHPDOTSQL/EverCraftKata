using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EverCraftKata
{
    [TestFixture]
    public class When_creating_a_new_character
    {
        private Character bob;
        [SetUp]
        public void Run_once_before_each_test()
        {
            this.bob = new Character("Bob", Alignment.Good);
            Assert.AreEqual("Bob", bob.Name);
        }

        [Test]
        public void it_is_alive()
        {
            Assert.IsTrue(bob.Is_alive);
        }

        [Test]
        public void can_change_name_after_creating()
        {
             bob.Name = "Stanley";
            Assert.AreEqual("Stanley", bob.Name);
        }

        [Test]
        public void can_change_alignment_after_creating()
        {
            bob.Alignment = Alignment.Evil;
            Assert.AreEqual(Alignment.Evil, bob.Alignment);
        }

        [Test]
        public void default_armor_class_is_10()
        {
            Assert.AreEqual(10, bob.Armor_class);
        }

        [Test]
        public void default_hit_points_is_5()
        {
            Assert.AreEqual(5, bob.Hit_points);
        }

        
    }
}
