using System;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CaesarsCipher cc = new("Toto je nejaka tajna zprava", 2);

            cc.Encrypt();
            Console.WriteLine(cc.Current);
            cc.Decrypt();
            Console.WriteLine(cc.Current);
            Console.ReadKey();

            //for (int i = char.MinValue; i < 500; i++)
            //{
            //    Console.WriteLine("{0}: {1}", i, (char)i);
            //}

            // upper = 65 - 90
            // lower = 97 - 122
        }
    }
}
