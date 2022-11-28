using System;

namespace Cipher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICipher ciph;

            while (true)
            {
                Console.WriteLine("Caesar (C) / Vigenère (V) / END");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();

                if (cki.Key == ConsoleKey.C)
                {
                    Console.Write("Insert phrase: ");
                    string str = Console.ReadLine();
                    int val = 0;

                    {
                        string s;

                        do
                        {
                            Console.Write("Inset valid number: ");
                            s = Console.ReadLine();
                        }
                        while (!int.TryParse(s, out val));
                    }

                    ciph = new CaesarsCipher(str, val);
                    ciph.Encrypt();
                    Console.WriteLine(ciph.Current);
                }
                else if (cki.Key == ConsoleKey.V)
                {
                    Console.Write("Insert phrase: ");
                    string str = Console.ReadLine();
                    Console.Write("Inset key (lowercase): ");
                    string s = Console.ReadLine();

                    try
                    {
                        ciph = new VigenereCipher(str, s);
                        ciph.Encrypt();
                        Console.WriteLine(ciph.Current);
                    }
                    catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                }
                else
                {
                    Console.WriteLine("Quitting");
                    break;
                }
            }
        }
    }
}
