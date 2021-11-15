using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hash Table Program!");
            CountWordFrequency("Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations");
            Console.ReadLine();
        }
        public static void CountWordFrequency(string sentence)
        {
            MyHashCode<string, int> hashtable = new MyHashCode<string, int>(10);
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (hashtable.Exists(word))
                {
                    hashtable.Add(word, hashtable.get(word) + 1);

                }
                else
                {
                    hashtable.Add(word, 1);
                }
            }
            Console.WriteLine("Displaying after add operation\n");
            hashtable.Display();
            hashtable.Remove("avoidable");                                     //display after removing the key value pair with key avoidable
            Console.WriteLine("Displaying after removing avoidable.\n");
            hashtable.Display();
            Console.WriteLine("----------------------------------------");



        }
    }
}
