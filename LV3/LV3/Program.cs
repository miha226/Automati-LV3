using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> code = new List<string>();
            Dictionary<string, int> identifikator = new Dictionary<string, int>();
            Dictionary<string, int> kljucneRijeci = new Dictionary<string, int>();
            int separatori = 0;
            Dictionary<string, int> operatori = new Dictionary<string, int>();
            Dictionary<string, int> konstante = new Dictionary<string, int>();
            Dictionary<string, int> komentari = new Dictionary<string, int>();
            bool flag;
            string rijeci = ("a b c d = + - * / for ");
            string[] words;
            string line;

            do
            {
                line = Console.ReadLine();

                code.Add(line);

            } while (!line.Contains('?'));

            code.RemoveAt(code.Count - 1);

            for (int i = 0; i < code.Count; i++)
            {
                words = code[i].Split(' ');
                foreach (var word in words)
                {
                    if (word == "if" || word == "else" || word == "int" || word == "for" || word == "while") kljucneRijeci[word] = kljucneRijeci.ContainsKey(word) ? kljucneRijeci[word] + 1 : 1;
                    else if (word == "+" || word == "-" || word == "*" || word == "/" || word == "=") operatori[word] = operatori.ContainsKey(word) ? operatori[word] + 1 : 1;
                    else if (word == "/*" || word == "*/" || word == "//") komentari[word] = komentari.ContainsKey(word) ? komentari[word] + 1 : 1;
                    else
                    {
                        flag = true;
                        foreach (var symbol in word)
                        {
                            if (symbol < 'a' || symbol > 'z') { flag = false; }
                        }
                        if (flag == true) identifikator[word] = identifikator.ContainsKey(word) ? identifikator[word]+1 : 1;
                        flag = true;
                        foreach (var symbol in word)
                        {
                            if (symbol < '0' || symbol > '9') { flag = false; }
                        }
                        if (flag == true) konstante[word] = konstante.ContainsKey(word) ? konstante[word]+1 : 1; ;
                    }
                }
                separatori += words.Length - 1;
                Console.WriteLine("Line " + (i + 1) + ": " + code[i]);
                Console.Write("Identifikatori [" + identifikator.Count + "]:");
                foreach (var pair in identifikator)
                {
                    Console.Write("'" + pair.Key + "'[" + pair.Value + "]', ");
                }
                Console.Write("\nKljucne rijeci [" + kljucneRijeci.Count + "]:");
                foreach (var pair in kljucneRijeci)
                {
                    Console.Write("'" + pair.Key + "'[" + pair.Value + "]', ");
                }
                Console.Write("\nOperatori[" + operatori.Count + "]:");
                foreach (var pair in operatori)
                {
                    Console.Write("'" + pair.Key + "'[" + pair.Value + "]', ");
                }
                Console.Write("\nKonstante [" + konstante.Count + "]:");
                foreach (var pair in konstante)
                {
                    Console.Write("'" + pair.Key + "'[" + pair.Value + "]', ");
                }
                Console.Write("\nKomentari [" + komentari.Count + "]:");
                foreach (var pair in komentari)
                {
                    Console.Write("'" + pair.Key + "'[" + pair.Value + "]', ");
                }


            }
            Console.ReadLine();


        }
    }
}
