using System;
using System.Linq;
using System.Text;

namespace Cipher
{
    internal class VigenereCipher : ICipher
    {
        private const char MinUpper = (char)65;
        private const char MinLower = (char)97;
        private const char Displacement = (char)25;
        private readonly string _key;

        private string Key
        {
            get { return _key; }
            init
            {
                if (value.Any(x => !char.IsLower(x)))
                    throw new ArgumentException("Key can only hold lowercase letters");

                _key = value;
            }
        }

        public string Current { get; private set; }

        public VigenereCipher(string str, string key)
        {
            Current = str;
            Key = key;

            while (Current.Length > Key.Length)
                Key += key;
        }

        public void Encrypt()
        {
            StringBuilder sb = new();

            for (int i = 0; i < Current.Length; ++i)
            {
                char kc = Key[i];
                char c = Current[i];

                if (c == ' ')
                    continue;

                bool upper = char.IsUpper(c);
                bool lower = char.IsLower(c);

                c += (char)(kc - MinLower);

                if (upper)
                {
                    if (c > MinUpper + Displacement)
                        c -= (char)(Displacement + 1);
                }
                else if (lower)
                {
                    if (c > MinLower + Displacement)
                        c -= (char)(Displacement + 1);
                }

                sb.Append(c);
            }

            Current = sb.ToString();
        }

        public void Decrypt()
        {
            StringBuilder sb = new();

            for (int i = 0; i < Current.Length; ++i)
            {
                char kc = Key[i];
                char c = Current[i];

                if (c == ' ')
                    continue;

                bool upper = char.IsUpper(c);
                bool lower = char.IsLower(c);

                c -= (char)(kc - MinLower);

                if (upper)
                {
                    if (c < MinUpper)
                        c += (char)(Displacement + 1);
                }
                else if (lower)
                {
                    if (c < MinLower)
                        c += (char)(Displacement + 1);
                }

                sb.Append(c);
            }

            Current = sb.ToString();
        }
    }
}
