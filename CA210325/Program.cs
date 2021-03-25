using System;
using System.Linq;

namespace CA210325
{
    class Program
    {
        static int[] tomb = new int[100];
        static Random rnd = new Random();
        const int elfogadhatoFizu = 3800;
        static int[] masikTomb = new int[100];
        const int szulEv = 1990;
        static void Main()
        {
            F02();
            F0304();
            F05();
            F06();
            F07();
            F08();
            F09();
            F10();
            F11();
            F12();
            Console.ReadKey();
        }

        private static void F02()
        {
            for (int i = 0; i < tomb.Length; i++)
                tomb[i] = rnd.Next(200, 2000) * 5;
        }
        private static void F0304()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if ((i + 1) % 7 == 0) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{tomb[i]} ");
                Console.ResetColor();
                if ((i + 1) % 10 == 0) Console.Write('\n');
            }
            Console.Write('\n');
        }
        private static void F05() =>
            Console.WriteLine($"Sum: {tomb.Sum()}");
        private static void F06()
        {
            int pSum = 0;
            int pC = 0;
            foreach (var e in tomb)
            {
                if (e >= 4000 && e < 5000)
                {
                    pSum += e;
                    pC++;
                }
            }
            Console.WriteLine($"Avg[4000; 5000): {pSum/(float)pC}");
        }
        private static void F07()
        {
            int i = 0;
            while (i < tomb.Length && tomb[i] % 65 != 0) i++;
            Console.WriteLine("n65: " + 
                (i < tomb.Length ? 
                $"tomb[{i}] = {tomb[i]};" : 
                "nincs 65 többszöröse"));
        }
        private static void F08()
        {
            int c3k = 0;
            foreach (var e in tomb) if (e / 3000 == 1 && e % 3000 < 1000) c3k++;
            Console.WriteLine($"Count(3___): {c3k}");
        }

        private static void F09()
        {
            int i = 0;
            while (i < tomb.Length && tomb[i] < elfogadhatoFizu) i++;
            Console.WriteLine(
                "Elfogadható kezdőfizetés indexe: " +
                (i < tomb.Length ? $"{i}" : 
                "nincs számomra elfogadható órabér a tömbben."));
        }

        private static void F10()
        {
            int j = 0;
            foreach (var e in tomb)
            {
                if(e % 100 == 0)
                {
                    masikTomb[j] = e;
                    j++;
                }
            }
            Array.Resize(ref masikTomb, j);
        }
        private static void F11()
        {
            Console.Write('\n');
            for (int i = 0; i < masikTomb.Length; i++)
            {
                if (masikTomb[i].ToString()[0] == masikTomb[i].ToString()[1])
                    Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{masikTomb[i]}");
                Console.ResetColor();
                Console.Write(' ');
                if ((i + 1) % 10 == 0) Console.Write('\n');
            }
            Console.Write('\n');
        }

        private static void F12()
        {
            int szulKer = szulEv;
            int szulMod = szulEv % 10;
            if (new int[] { 1, 2 }.Contains(szulMod)) szulKer = szulEv - szulMod;
            else if (new int[] { 3, 4, 6, 7 }.Contains(szulMod)) szulKer = szulEv - (szulMod - 5);
            else if (new int[] { 8, 9 }.Contains(szulMod)) szulKer = szulEv - (szulMod - 10);

            int i = 0;
            while (i < tomb.Length && tomb[i] != szulKer) i++;
            Console.WriteLine("\nA 'kerekített' születési évem " + 
                (i < tomb.Length ? "benne van" : "nincs benne") +
                " a tömbben.");
        }
    }
}
