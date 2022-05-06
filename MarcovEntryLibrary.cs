using System;
using MyListLibrary;

namespace MarcovEntryLibrary
{
    public class MarcovEntry
    {
        private LinkedList<char> suffixes;
        private string substring;
        private int count;

        public MarcovEntry(string entry)
        {
            substring = entry;
            count = 0;
            suffixes = new LinkedList<char>();
        }

        public int Count
        { get { return count; } }

        public void Add(char ch)
        {
            suffixes.Add(ch);
            count++;
        }

        public override string ToString()
        {
            return $"MarcovEntry: '{substring}' ({count}): {suffixes}";
        }

        public char RandomLetter()
        {
            char[] suffix_arr = suffixes.ToArray();
            Random rnd = new Random();

            int idx = rnd.Next(0, suffix_arr.Length);

            return suffix_arr[idx];
        }
    }
}
