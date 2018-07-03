using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListKata
{
    public class LinkedListSpec
    {
        // Test-drive your own implementation of a linked list, WITHOUT using arrays or any standard libarary classes.
        
        // It should be possible to:
        // - Find the index of any object in the list
        // - Add/remove objects at any point in the list
        // - Directly access any objects in the list by giving its index

        // For extra bonus points:
        // - Use generics to allow the list to contain any type of object
        // - Implement your solution without using conditionals
        // - Allow the list to be searched and filtered using some kind of matcher on the objects it contains

        [TestClass]
        public class WhenTheLinkedListIsEmpty
        {
            private LinkedList _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList();
            }

            [TestMethod]
            public void The_item_count_is_empty()
            {
                Assert.AreEqual(0, _linkedList.Count());
            }

            //[TestMethod]
            //public void The_item_count_is_zero()
            //{
            //}

            [TestMethod]
            [ExpectedException(typeof(IndexOutOfRangeException))]
            public void Retrieving_an_item_by_index_results_in_an_exception()
            {
                _linkedList.Get(0);
            }

        }

        [TestClass]
        public class WhenTheLinkedListHasOneItem
        {
            private LinkedList _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList();
                _linkedList.Add("One");
            }

            [TestMethod]
            public void The_item_count_is_one()
            {
                Assert.AreEqual(1, _linkedList.Count());
            }

            //[TestMethod]
            //public void The_item_can_be_retrieved_by_its_index()
            //{
            //}

            //[TestMethod]
            //public void The_index_can_be_retrieved_for_the_item()
            //{
            //}

            //[TestMethod]
            //public void The_list_is_not_empty()
            //{
            //}
        }

        [TestClass]
        public class WhenTheLinkedListHasMultipleItems
        {
            //[TestMethod]
            //public void The_item_count_reflects_this()
            //{
            //}

            //[TestMethod]
            //public void The_items_can_be_retrieved_by_their_indexes()
            //{
            //}

            //[TestMethod]
            //public void The_indexes_can_be_retrieved_for_the_items()
            //{
            //}

            //[TestMethod]
            //public void Can_add_an_item_to_the_start_of_the_list()
            //{
            //}

            //[TestMethod]
            //public void Can_add_an_item_to_the_end_of_the_list()
            //{
            //}

            //[TestMethod]
            //public void Can_add_an_item_to_the_middle_of_the_list()
            //{
            //}

            //[TestMethod]
            //public void The_list_is_not_empty()
            //{
            //}
        }

        [TestClass]
        public class TheLinkedListSupportsMultipleTypes
        {
            //[TestMethod]
            //public void Int_is_supported()
            //{
            //}

            //[TestMethod]
            //public void String_is_supported()
            //{
            //}

            //[TestMethod]
            //public void Complex_types_are_supported()
            //{
            //}

            //public class DummyClass
            //{
            //    private readonly int _id;
            //    private readonly string _name;

            //    public DummyClass(int id, string name)
            //    {
            //        _id = id;
            //        _name = name;
            //    }

            //    public override bool Equals(object obj) => obj is DummyClass other && other._id == _id && other._name == _name;
            //}
        }
    }

    public class LinkedList
    {
        private Item _item;

        public int Count()
        {
            if (_item == null)
                return 0;

            return 1;
        }

        public string Get(int index)
        {
            throw new IndexOutOfRangeException();
        }

        public void Add(string value)
        {
            _item = new Item(value);
        }
    }

    public class Item
    {
        private readonly string _value;

        public Item(string value) => _value = value;

        public string GetValue() => _value;
    }
}
