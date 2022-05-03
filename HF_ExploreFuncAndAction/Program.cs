using System;
using System.Collections.Generic;
using System.Linq;

namespace HF_ExploreFuncAndAction
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Func<int, string> timesFour = (int i) => $"-> {i * 4} <-";

            int lineNumber = -1;
            Action<string> writeline = (string s) => Console.WriteLine($"Line {lineNumber++} is {s}");
            
            Enumerable.Range(1, 5)
                 .Select(timesFour)
                 .ToList()
                 .ForEach(writeline);

            Func<string, string> evil = (string s) => $"{s}ming t{s}";
            Func<string, string, string> kill = (string x, string y) => $"{y}{x}";
            Func<string, string> slice = (string q) => " " + q;
            Action <string> terrify = (string s) => Console.WriteLine(s);
            EventHandler <string> laugh = (object sender, string e) => terrify(e);

            var laughter = new RedNose();
            laughter.Honk += laugh;
            laughter.OnHonk(kill(evil("o"), "gers is c"), kill(slice("you"), "get"));

            //////////////
            string meet = rnd.Next(6) > 3 ? "meet" : "screw";
            string me = rnd.Next(6) > 3 ? "me" : "you";
            string task = "to grab these eggs";

            Func<string, string, string, string> yeet = (string r, string t, string e) => $"{r} {t} {e}";
            Console.WriteLine(yeet(meet, me, task));

        }
    }
    
    class RedNose
    {
        public event EventHandler<string> Honk;
        public void OnHonk(string noise, string fun)
            => Honk?.Invoke(this, $"Fin{noise} {fun}");
    }
}
