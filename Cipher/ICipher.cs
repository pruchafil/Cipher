namespace Cipher
{
    internal interface ICipher
    {
        public string Current
        {
            get;
        }

        public void Encrypt();

        public void Decrypt();
    }
}
