using System;
using MarcovEntryLibrary;
using MySymbolTableLibrary;
using System.Diagnostics;
using System.Collections.Generic;

namespace MarcovStories
{
    class Program
    {
        static void Main(string[] args)
        {

            // INITIALIZATION:

            string text = "";
            try
            {
                text = System.IO.File.ReadAllText($"{args[0]}");
            }
            catch
            {
                throw new ArgumentException($"Invalid filename.");
            }


            text = text.Replace("\n", " ");


            int n = 0;
            try
            {
                n = Int32.Parse(args[2]);
            }
            catch
            {
                throw new ArgumentException($"Incorrect input: {args[1]} is not a number");
            }


            int L = 0;
            try
            {
                L = Int32.Parse(args[2]);
            }
            catch
            {
                throw new ArgumentException($"Incorrect input: {args[2]} is not a number");
            }


            int stopper = 500; //how many chars of text to parse, can be text.Length




            

            // LIST SYMBOL TABLE BELOW

            Console.WriteLine("Parsing list symbol table...");

            Stopwatch list_watch = new Stopwatch();
            list_watch.Start();

            ListSymbolTable<string, MarcovEntry> list_entries = new ListSymbolTable<string, MarcovEntry>();

            for (int i = 0; i < stopper; i++)
            {
                string token = text.Substring(i, n);

                try
                {
                    MarcovEntry marcov = new MarcovEntry(token);
                    marcov.Add(text[i + n]);
                    list_entries.Add(token, marcov);
                }
                catch
                {
                    char ch = text[i + n];
                    MarcovEntry marcov = list_entries[token];
                    marcov.Add(ch);
                }
            }


            string list_story = text.Substring(0, n);
            int list_idx = 0;
            while (list_story.Length < L)
            {
                string token = list_story.Substring(list_idx, n);
                list_story += list_entries[token].RandomLetter();

                list_idx++;
            }



            // to ensure complete sentence
            char last = list_story[list_story.Length - 1];
            while (!last.Equals('.') && !last.Equals('!') && !last.Equals('?'))
            {
                string token = list_story.Substring(list_story.Length - n, n);
                list_story += list_entries[token].RandomLetter();
                last = list_story[list_story.Length - 1];
            }




            list_watch.Stop();
            TimeSpan list_ts = list_watch.Elapsed;
            string list_time = String.Format("{0:00}:{1:00}.{2:00}",
                list_ts.Minutes, list_ts.Seconds, list_ts.Milliseconds/10);


            Console.WriteLine($"List Symbol Table Story: (Runtime {list_time})");
            Console.WriteLine(list_story);
            Console.WriteLine("---------------------");
            Console.WriteLine();











            // BINARY SEARCH TREE BELOW

            Console.WriteLine("Parsing binary search tree...");

            Stopwatch tree_watch = new Stopwatch();

            tree_watch.Start();

            MyTreeTable<string, MarcovEntry> tree_entries = new MyTreeTable<string, MarcovEntry>();

            for (int i = 0; i < stopper; i++)
            {
                string token = text.Substring(i, n);

                try
                {
                    MarcovEntry marcov = new MarcovEntry(token);
                    marcov.Add(text[i + n]);
                    tree_entries.Add(token, marcov);
                }
                catch
                {
                    char ch = text[i + n];
                    MarcovEntry marcov = tree_entries[token];
                    marcov.Add(ch);
                }
            }

            string tree_story = text.Substring(0, n);
            int tree_idx = 0;
            while(tree_story.Length < L)
            {
                string token = tree_story.Substring(tree_idx, n);
                tree_story += tree_entries[token].RandomLetter();

                tree_idx++;
            }




            // to ensure complete sentence
            last = tree_story[tree_story.Length - 1];
            while (!last.Equals('.') && !last.Equals('!') && !last.Equals('?'))
            {
                string token = tree_story.Substring(tree_story.Length - n, n);
                tree_story += tree_entries[token].RandomLetter();
                last = tree_story[tree_story.Length - 1];
            }




            tree_watch.Stop();
            TimeSpan tree_ts = tree_watch.Elapsed;
            string tree_time = String.Format("{0:00}:{1:00}.{2:00}",
                tree_ts.Minutes, tree_ts.Seconds, tree_ts.Milliseconds/10) ;

            Console.WriteLine($"Binary Search Tree Story: (Runtime {tree_time})");
            Console.WriteLine(tree_story);
            Console.WriteLine("---------------------");
            Console.WriteLine();



            




            // SortedDictionary Class BELOW

            Console.WriteLine("Parsing SortedDictionary...");

            Stopwatch dict_watch = new Stopwatch();
            dict_watch.Start();

            SortedDictionary<string, MarcovEntry> dict_entries = new SortedDictionary<string, MarcovEntry>();

            for (int i = 0; i < stopper; i++)
            {
                string token = text.Substring(i, n);

                try
                {
                    MarcovEntry marcov = new MarcovEntry(token);
                    marcov.Add(text[i + n]);
                    dict_entries.Add(token, marcov);
                }
                catch
                {
                    char ch = text[i + n];
                    MarcovEntry marcov = dict_entries[token];
                    marcov.Add(ch);
                }
            }

            string dict_story = text.Substring(0, n);
            int dict_idx = 0;
            while (dict_story.Length < L)
            {
                string token = dict_story.Substring(dict_idx, n);
                dict_story += dict_entries[token].RandomLetter();

                dict_idx++;
            }

            // to ensure complete sentence
            last = dict_story[dict_story.Length - 1];
            while (!last.Equals('.') && !last.Equals('!') && !last.Equals('?'))
            {
                string token = dict_story.Substring(dict_story.Length - n, n);
                dict_story += dict_entries[token].RandomLetter();
                last = dict_story[dict_story.Length - 1];
            }


            dict_watch.Stop();
            TimeSpan dict_ts = dict_watch.Elapsed;
            string dict_time = String.Format("{0:00}:{1:00}.{2:00}",
                dict_ts.Minutes, dict_ts.Seconds, dict_ts.Milliseconds / 10);

            Console.WriteLine($"SortedDictionary Story: (Runtime {dict_time})");
            Console.WriteLine(dict_story);
            Console.WriteLine("---------------------");
            Console.WriteLine();





            // Comparisons
            Console.WriteLine($"Program ran through {stopper} characters of the original text.");
            Console.WriteLine("Results of each class were as follows:");
            Console.WriteLine($">> Linked List Symbol Table: {list_time}");
            Console.WriteLine($">> Binary Search Tree: {tree_time}");
            Console.WriteLine($">> Sorted Dictionary: {dict_time}");
        }
    }
}
