using NUnit.Framework;
using System;

namespace Program.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new LinkedList<int>();
        }

        [Test]
        public void Add_OneElement_ShouldBeRetrievable()
        {
            list.Add(10);

            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list.Get(0), Is.EqualTo(10));
        }

        [Test]
        public void Add_MultipleElements_ShouldKeepOrder()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.That(list.Count(), Is.EqualTo(3));
            Assert.That(list.Get(0), Is.EqualTo(1));
            Assert.That(list.Get(1), Is.EqualTo(2));
            Assert.That(list.Get(2), Is.EqualTo(3));
        }

        [Test]
        public void Get_InvalidIndex_ShouldThrow()
        {
            list.Add(42);

            Assert.That(() => list.Get(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => list.Get(1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Remove_ExistingElement_ShouldReturnTrueAndDecreaseCount()
        {
            list.Add(5);
            list.Add(10);

            bool removed = list.Remove(5);

            Assert.That(removed, Is.True);
            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list.Get(0), Is.EqualTo(10));
        }

        [Test]
        public void Remove_NonExistingElement_ShouldReturnFalse()
        {
            list.Add(7);

            bool removed = list.Remove(100);

            Assert.That(removed, Is.False);
            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list.Get(0), Is.EqualTo(7));
        }

        [Test]
        public void Remove_FromEmptyList_ShouldReturnFalse()
        {
            bool removed = list.Remove(1);

            Assert.That(removed, Is.False);
            Assert.That(list.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Clear_ShouldMakeListEmpty()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Clear();

            Assert.That(list.Count(), Is.EqualTo(0));
            Assert.That(() => list.Get(0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Add_Remove_Add_Again_ShouldWorkCorrectly()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(2);

            list.Add(4);

            Assert.That(list.Count(), Is.EqualTo(3));
            Assert.That(list.Get(0), Is.EqualTo(1));
            Assert.That(list.Get(1), Is.EqualTo(3));
            Assert.That(list.Get(2), Is.EqualTo(4));
        }
    }
}
