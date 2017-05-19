using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Program
    {
        static void Main(string[] args)
        {
            string wejscie;
            bool flag;
            do
            {
                Console.Clear();
                Console.Write("Podaj wyrażenie:");

                wejscie = Console.ReadLine();
                Onp onp = new Onp(wejscie);

                List<char> wyjscie = onp.ToOnp();
                for (int i = 0; i < wyjscie.Count; i++)
                {
                    Console.Write(wyjscie[i]);
                }

                Console.WriteLine("\n");
                Console.WriteLine("Jeżeli chcesz kontynuować wciśnij \"T\"");
                wejscie = Console.ReadLine();
                flag = wejscie.ToLower().Equals("t");
            } while (flag);
        }
    }
}
