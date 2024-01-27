using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //gereftan string avalie
            Console.WriteLine("lotfan jomle khod ra vared konid");
            string line = Console.ReadLine()+" ";
            //farakhani shi garaii
            Spamm s = new Spamm();
            s.Str_spam = line;
            s.spam_barghashti();

        }


    }
    class Spamm
    {
        //fild
        private string str_spam;
        //khososiat
        public string Str_spam
        {
            get { return str_spam; }
            set { str_spam = value; }
        }
        //mokhareb
        public Spamm() { }
        //sazande 
        public Spamm(string Str_spam)
        {
            str_spam = Str_spam;
        }
        public void spam_barghashti()
        {
            Regex regex = new Regex(" +"); // regex ke tedad bishtar mosavi az 1 space ro mikhoone

            int counter = 0; // shomarande tedad spam haye khat dade shode
            foreach (var item in regex.Split(str_spam)) // halghe rooye khat voroodi gerefte shode va boride shode tavasote regex => mitoone space ezafe ham beine harf haye voroodi bashe
            {
                if (isSpam(item))
                    counter++;
            }

            Console.WriteLine(counter);
        }

        static bool isSpam(string str) // in tabe yek kalame vorudi migire va agar spam bood 1 mide dar gheir in soorat 0 mide
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int numUpperCase = 0;
            int numVowel = 0;
            foreach (var chr in str)
            {
                CharType charType = getCharType(chr);
                switch (charType)
                {
                    case CharType.LowerCase:
                        if (isVowel(chr)) numVowel++;
                        if (charCount.ContainsKey(chr)) charCount[chr] += 1;
                        else charCount.Add(chr, 1);
                        break;
                    case CharType.UpperCase:
                        if (isVowel(chr)) numVowel++;
                        numUpperCase++;
                        if (numUpperCase > 1) return true; // bish az 1 harf bozorg
                        break;
                    case CharType.Other:
                        return true; // horoofe namarboot darim
                }
            }
            if (numVowel == 0) return true; // hame horoof bi seda hastan
            foreach (var item in charCount)
            {
                if (item.Value >= 3) return true; // harf tekrari
            }
            return false; // reshte addi
        }

        static CharType getCharType(char chr)
        {
            if (Char.IsLower(chr)) return CharType.LowerCase;
            if (Char.IsUpper(chr)) return CharType.UpperCase;
            return CharType.Other;
        }
        static bool isVowel(char chr)
        {
            chr = Char.ToLower(chr);
            return (chr == 'o' || chr == 'i' || chr == 'e' || chr == 'a' || chr == 'u');
        }

        enum CharType
        {
            LowerCase,
            UpperCase,
            Other
        }
    }
}