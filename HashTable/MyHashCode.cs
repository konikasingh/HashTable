using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{         
    //described globally as it is used in multiple methods and classes
    public struct KeyValue<K, V>                                           //structure is used as a generics data type as it can hold any kind of data.
    {
        public K Key { get; set; }                                         //key and value are the members of the class (structure)
        public V Value { get; set; }
    }
    class MyHashCode<K, V>
    {
        private readonly int size;                                       // size is the readonly local variabl declaration
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyHashCode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];         //creating items object and declaring the size

        }

        protected int getArrayPosition(K key)                               // the get array position is the main starting point of using hashtables
        {
            int position = key.GetHashCode() % size;                        //it uses the in-built GetHasshCode() and returns a longint which can be modified to fit the array index range
            return Math.Abs(position);
        }
        public V get(K key)
        { 
            int position = getArrayPosition(key);                          //gives us the postion of key value using hashing function
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))                                 //return the value of that item if it matches with the key.
                {
                    return item.Value;

                }
            }
            return default(V);
        }

        public void Add(K key, V value)                                //adding the key and value pairs to the linked list
        {
            int position = getArrayPosition(key);                     // same use first getting the postion of the array using hashing and then obtaining the linked list obj.
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            if (linkedlist.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedlist)          //this checks whether there exist any duplicate keys. if yes, then remove one with its repective value.
                {
                    if (item1.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }
                }

            }
            linkedlist.AddLast(item);
        }

        public void Remove(K key)                                          //it will remove the item in the key list
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedlist)                   //check weather the key is present or not
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;                                 //if yes, change the boolean to false 
                    founditem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(founditem);
            }

        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)                     //this class takes the input as the integer position in range of array items indexes.
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];                         //checks whether there exist any value in that psoition. assigned to linkedlist obj.
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();                              // if there isn't any value, then create the linked list obj in that respective position
                items[position] = linkedlist;

            }
            return linkedlist;                                                              //return the linkeddlist obj.

        }

        public bool Exists(K key)                                            //check if a key exist in the array's linked list.
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return true;

                }
            }
            return false;
        }

        public void Display()                                  //simple display method that displays the linked lsit object variables inside of the item array.
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " = " + element.Value);
                    }

                }

            }

        }

    }
}