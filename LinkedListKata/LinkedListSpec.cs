using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListKata
{
    public class LinkedListSpec
    {
        // Test-drive your own implementation of a linked list, WITHOUT using arrays or any standard libarary classes.

        // It should be possible to:
        // - Find the index of any object in the list - DONE
        // - Add/remove objects at any point in the list - DONE
        // - Directly access any objects in the list by giving its index - DONE

        // For extra bonus points:
        // - Use generics to allow the list to contain any type of object - DONE
        // - Implement your solution without using conditionals
        // - Allow the list to be searched and filtered using some kind of matcher on the objects it contains

        // List<T> someList = new List();
        // someList.Add(x)        // Adds x to the end of the list - DONE
        // someList.Insert(0, x)  // Adds x at the given index - DONE
        // someList.Remove(x)     // Removes the first x observed - DONE
        // someList.RemoveAt(0)   // Removes the item at the given index - DONE
        // someList.Count()       // Always good to know how many elements you have! - DONE

        [TestClass]
        public class WhenTheLinkedListIsEmpty
        {
            private LinkedList<string> _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList<string>();
            }

            [TestMethod]
            public void The_item_count_is_empty()
            {
                Assert.AreEqual(0, _linkedList.Count());
            }

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
            private LinkedList<string> _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList<string>();
                _linkedList.Add("One");
            }

            [TestMethod]
            public void The_item_count_is_one()
            {
                Assert.AreEqual(1, _linkedList.Count());
            }

            [TestMethod]
            public void The_item_can_be_retrieved_by_its_index()
            {
                Assert.AreEqual("One", _linkedList.Get(0));
            }

            [TestMethod]
            public void The_index_can_be_retrieved_for_the_item()
            {
                Assert.AreEqual(0, _linkedList.IndexOf("One"));
            }
        }

        [TestClass]
        public class WhenAddingMultipleItemsToTheLinkedList
        {
            private LinkedList<string> _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList<string>();
                _linkedList.Add("One");
                _linkedList.Add("Two");
                _linkedList.Add("Three");
            }

            [TestMethod]
            public void The_item_count_reflects_this()
            {
                Assert.AreEqual(3, _linkedList.Count());
            }

            [TestMethod]
            public void The_items_can_be_retrieved_by_their_indexes()
            {
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Two", _linkedList.Get(1));
                Assert.AreEqual("Three", _linkedList.Get(2));
            }

            [TestMethod]
            public void The_indexes_can_be_retrieved_for_the_items()
            {
                Assert.AreEqual(0, _linkedList.IndexOf("One"));
                Assert.AreEqual(1, _linkedList.IndexOf("Two"));
                Assert.AreEqual(2, _linkedList.IndexOf("Three"));
            }
        }

        [TestClass]
        public class WhenInsertingItemsAtVariousPositionsInTheLinkedList
        {
            private LinkedList<string> _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList<string>();
                _linkedList.Add("One");
                _linkedList.Add("Two");
                _linkedList.Add("Three");
            }

            [TestMethod]
            public void Can_add_an_item_to_the_start_of_the_list()
            {
                _linkedList.Insert(0, "Start");

                Assert.AreEqual(4, _linkedList.Count());
                Assert.AreEqual("Start", _linkedList.Get(0));
                Assert.AreEqual("One", _linkedList.Get(1));
                Assert.AreEqual("Two", _linkedList.Get(2));
                Assert.AreEqual("Three", _linkedList.Get(3));
                Assert.AreEqual(0, _linkedList.IndexOf("Start"));
                Assert.AreEqual(1, _linkedList.IndexOf("One"));
                Assert.AreEqual(2, _linkedList.IndexOf("Two"));
                Assert.AreEqual(3, _linkedList.IndexOf("Three"));
            }

            [TestMethod]
            public void Can_add_an_item_to_the_end_of_the_list()
            {
                _linkedList.Insert(3, "End");

                Assert.AreEqual(4, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Two", _linkedList.Get(1));
                Assert.AreEqual("Three", _linkedList.Get(2));
                Assert.AreEqual("End", _linkedList.Get(3));
                Assert.AreEqual(0, _linkedList.IndexOf("One"));
                Assert.AreEqual(1, _linkedList.IndexOf("Two"));
                Assert.AreEqual(2, _linkedList.IndexOf("Three"));
                Assert.AreEqual(3, _linkedList.IndexOf("End"));
            }

            [TestMethod]
            public void Can_add_an_item_to_the_middle_of_the_list()
            {
                _linkedList.Insert(2, "Middle");

                Assert.AreEqual(4, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Two", _linkedList.Get(1));
                Assert.AreEqual("Middle", _linkedList.Get(2));
                Assert.AreEqual("Three", _linkedList.Get(3));
                Assert.AreEqual(0, _linkedList.IndexOf("One"));
                Assert.AreEqual(1, _linkedList.IndexOf("Two"));
                Assert.AreEqual(2, _linkedList.IndexOf("Middle"));
                Assert.AreEqual(3, _linkedList.IndexOf("Three"));
            }
        }

        [TestClass]
        public class WhenRemovingItemsFromTheLinkedList
        {
            private LinkedList<string> _linkedList;

            [TestInitialize]
            public void Setup()
            {
                _linkedList = new LinkedList<string>();
                _linkedList.Add("One");
                _linkedList.Add("Two");
                _linkedList.Add("Three");
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_start_of_the_list_using_the_item()
            {
                _linkedList.Remove("One");

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("Two", _linkedList.Get(0));
                Assert.AreEqual("Three", _linkedList.Get(1));
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_middle_of_the_list_using_the_item()
            {
                _linkedList.Remove("Two");

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Three", _linkedList.Get(1));
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_end_of_the_list_using_the_item()
            {
                _linkedList.Remove("Three");

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Two", _linkedList.Get(1));
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_start_of_the_list_using_its_index()
            {
                _linkedList.RemoveAt(0);

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("Two", _linkedList.Get(0));
                Assert.AreEqual("Three", _linkedList.Get(1));
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_middle_of_the_list_using_its_index()
            {
                _linkedList.RemoveAt(1);

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Three", _linkedList.Get(1));
            }

            [TestMethod]
            public void Can_remove_an_item_from_the_end_of_the_list_using_its_index()
            {
                _linkedList.RemoveAt(2);

                Assert.AreEqual(2, _linkedList.Count());
                Assert.AreEqual("One", _linkedList.Get(0));
                Assert.AreEqual("Two", _linkedList.Get(1));
            }
        }

        [TestClass]
        public class TheLinkedListSupportsMultipleTypes
        {
            [TestMethod]
            public void Int_is_supported()
            {
                var linkedList = new LinkedList<int>();
                linkedList.Add(1);
                linkedList.Add(2);

                Assert.AreEqual(2, linkedList.Count());
                Assert.AreEqual(1, linkedList.Get(0));
                Assert.AreEqual(2, linkedList.Get(1));
            }

            [TestMethod]
            public void String_is_supported()
            {
                var linkedList = new LinkedList<string>();
                linkedList.Add("One");

                Assert.AreEqual(1, linkedList.Count());
                Assert.AreEqual("One", linkedList.Get(0));
            }

            [TestMethod]
            public void Complex_types_are_supported()
            {
                var linkedList = new LinkedList<Test>();
                linkedList.Add(new Test("One", "Two"));

                Assert.AreEqual(1, linkedList.Count());
                Assert.AreEqual(new Test("One", "Two"), linkedList.Get(0));
            }

            public class Test
            {
                private readonly string _valueOne;
                private readonly string _valueTwo;

                public Test(string valueOne, string valueTwo)
                {
                    _valueOne = valueOne;
                    _valueTwo = valueTwo;
                }

                public override bool Equals(object obj) => obj is Test temp && temp._valueOne == _valueOne && temp._valueTwo == _valueTwo;

                public override int GetHashCode() => _valueOne.GetHashCode() ^ _valueTwo.GetHashCode();
            }
        }
    }

    public class LinkedList<T>
    {
        private Item<T> _firstItem;

        public int Count()
        {
            var count = 0;

            Iterate((currentItem, currentIndex) => count++);

            return count;
        }

        public T Get(int value)
        {
            Item<T> foundItem = null;

            Iterate((currentItem, currentIndex) =>
            {
                if (currentIndex == value)
                    foundItem = currentItem;
            });

            if (foundItem == null) throw new IndexOutOfRangeException();

            return foundItem.GetValue();
        }

        public int IndexOf(T value)
        {
            var foundIndex = -1;

            Iterate((currentItem, currentIndex) =>
            {
                if (currentItem.GetValue().Equals(value))
                    foundIndex = currentIndex;
            });

            return foundIndex;
        }

        public void Add(T value)
        {
            if (IsEmpty())
            {
                _firstItem = Item<T>.From(value);
                return;
            }

            Iterate((currentItem, currentIndex) =>
            {
                if(currentItem.IsLast())
                    currentItem.SetNextItem(Item<T>.From(value));
            });
        }

        public void Insert(int index, T value)
        {
            Item<T> previousItem = null;
            var newItem = Item<T>.From(value);

            if (index == 0)
            {
                newItem.SetNextItem(_firstItem);
                _firstItem = newItem;
                return;
            }

            Iterate((currentItem, currentIndex) =>
            {
                if (currentIndex == index - 1)
                    previousItem = currentItem;
            });

            if (!previousItem.IsLast())
                newItem.SetNextItem(previousItem.Next());

            previousItem.SetNextItem(newItem);
        }

        public void Remove(T item)
        {
            var foundIndex = -1;

            Iterate((currentItem, currentIndex) =>
            {
                if (currentItem.GetValue().Equals(item))
                    foundIndex = currentIndex;
            });

            RemoveAt(foundIndex);
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                _firstItem = _firstItem.Next();
                return;
            }

            Item<T> previousItem = null;
            Item<T> specifiedItem = null;

            Iterate((currentItem, currentIndex) =>
            {
                if (currentIndex == index) specifiedItem = currentItem;
                if (currentIndex == index - 1) previousItem = currentItem;
            });

            previousItem.SetNextItem(specifiedItem.Next());
        }

        private void Iterate(Action<Item<T>, int> onNextItem)
        {
            var currentItem = _firstItem;
            var currentIndex = 0;

            while (currentItem != null)
            {
                var isLast = currentItem.IsLast();

                onNextItem(currentItem, currentIndex);

                if (isLast) break;

                currentItem = currentItem.Next();
                currentIndex++;
            }
        }

        private bool IsEmpty() => _firstItem == null;
    }

    public class Item<T>
    {
        private readonly T _value;
        private Item<T> _nextItem;

        private Item(T value)
        {
            _value = value;
        } 

        public T GetValue() => _value;

        public bool IsLast() => _nextItem == null;

        public Item<T> Next() => _nextItem;

        public void SetNextItem(Item<T> item) => _nextItem = item;

        public override string ToString() => _value.ToString();

        public static Item<T> From(T value) => new Item<T>(value);
    }
}
