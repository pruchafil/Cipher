using System.Linq;
using System.Text;

namespace Cipher
{
    internal class CaesarsCipher : ICipher
    {
        private const char MinUpper = (char)65;
        private const char MinLower = (char)97;
        private const char Displacement = (char)25;
        private readonly int _advance;

        public string Current { get; private set; }

        public int Advance
        {
            get { return _advance; }
            private init
            {
                if (value > Displacement)
                    throw new System.ArgumentException("Advance is too big");

                _advance = value;
            }
        }

        public CaesarsCipher(string str, int advance)
        {
            this.Current = str;
            this._advance = advance;
        }

        public void Encrypt()
        {
            StringBuilder sb = new();

            foreach (var item in Current)
            {
                if (item == ' ')
                {
                    continue;
                }

                bool lower = char.IsLower(item);
                bool upper = char.IsUpper(item);
                bool alph = char.IsLetter(item);

                if (!alph)
                {
                    throw new System.ArgumentOutOfRangeException($"Character is not alphabetical: {item}");
                }

                int i = item + Advance;

                if (lower)
                {
                    if (i > (MinLower + Displacement))
                    {
                        i -= Displacement;
                    }
                }
                else if (upper)
                {
                    if (i > (MinUpper + Displacement))
                    {
                        i -= Displacement;
                    }
                }

                sb.Append((char)i);
            }

            Current = sb.ToString();
        }

        public void Decrypt()
        {
            Current = new System.String(Current.Select(x => (System.Char)(x - _advance)).ToArray());
        }
    }
}
