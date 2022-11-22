using System.Linq;
using System.Text;

namespace Cipher
{
    class VigenereCipher
    {
        private const char MinUpper     = (char) 65;
        private const char MinLower     = (char) 97;
        private const char Displacement = (char) 25;

        private string _str;
        private readonly string _key;

        private string Key
        {
            get { return _key; }
            init
            {
                if (value.Any(x => !char.IsUpper(x)))
                    throw new System.ArgumentException("Key can only hold lowercase letters");

                _key = value;
            }
        }

        public string Current
        {
            get { return _str; }
            private set { _str = value; }
        }

        public VigenereCipher(string str, string key)
        {
            this._str = str;
            this._key = key;

            while (str.Length < _key.Length)
                _key += key;
        }

        public void Encrypt()
        {
            StringBuilder sb = new();

            for (int i = 0; i < Current.Length; ++i)
            {
                char kc = _key[i];
                char c = Current[i];

                if (c == ' ')
                    continue;

                bool kupper = char.IsUpper(kc);
                bool klower = char.IsLower(kc);
                bool kalp   = char.IsLetter(kc);
                bool upper  = char.IsUpper(c);
                bool lower  = char.IsLower(c);
                bool alp    = char.IsLetter(c);

                c += kc;

                if (upper)
                {
                    if (c > MinUpper + Displacement)
                        c -= Displacement;
                }
                else if (lower)
                {
                    if (c > MinLower + Displacement)
                        c -= Displacement;
                }

                sb.Append(c);
            }

            Current = sb.ToString();
        }

        public void Decrypt()
        {
            Current = new System.String(_str.Select(x =>  (System.Char)( x - _advance )).ToArray());
        }
    }
}
