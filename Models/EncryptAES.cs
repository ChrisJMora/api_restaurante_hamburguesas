using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;

namespace api_restaurante_hamburguesas.Models
{
    public class EncryptAES
    {
        private readonly Aes _myAes =  Aes.Create();
        private byte[] _key { get => _myAes.Key; }
        private byte[] _iv { get => _myAes.IV; }
        public byte[] Encriptar(string password)
        {
            // Check arguments.
            if (password == null || password.Length <= 0)
                throw new ArgumentNullException("password");
            if (_key == null || _key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (_iv == null || _iv.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(password);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        public string Desencriptar(byte[] passwordEncriptado)
        {
            // Check arguments.
            if (passwordEncriptado == null || passwordEncriptado.Length <= 0)
                throw new ArgumentNullException("passwordEncriptado");
            if (_key == null || _key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (_iv == null || _iv.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string password = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _key;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(passwordEncriptado))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            password = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return password;
        }
    }
}
