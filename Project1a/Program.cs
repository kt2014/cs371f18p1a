using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Program
    {
        public static string GetUserTextInput()
        {
            Console.WriteLine("Please enter the text to search within:");
            //string words = Console.ReadLine();
            string lines = "";
            string words;
            while ((words = Console.ReadLine()) != null)
            {
                if (words == "EOF")
                    break;
                lines += words.ToLower();

            }
            return lines;
        }

        public static int GetUserHowManyInput()
        {
            Console.WriteLine("Please enter howmany:");
            if (!int.TryParse(Console.ReadLine(), out int howmany))
            {
                howmany = 10;
            }

            return howmany;
        }


        public static int GetUserMinLengthInput()
        {

            Console.WriteLine("Please enter minlength:");
            if (!int.TryParse(Console.ReadLine(), out int minlength))
            {
                minlength = 6;
            }

            return minlength;
        }

        public static void Main(string[] args)
        {
            string textToSearch = GetUserTextInput();
            int wordsMinLength = GetUserMinLengthInput();
            int howManyWords = GetUserHowManyInput();

            var orderedWords = textToSearch
              .Split(' ')
              .Where(w => w.Length >= wordsMinLength)
              .GroupBy(x => x)
              .Select(x => new
              {
                  Word = x.Key,
                  Freq = x.Count()
              })
              .OrderByDescending(x => x.Freq)
              .Take(howManyWords);

            Console.WriteLine(string.Join(",", orderedWords));
            Console.ReadLine();
        }
    }
}
