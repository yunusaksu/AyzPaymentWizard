using System;
using System.Security.Cryptography;
using System.Text;

namespace AyzPaymentWizard
{
    public class EncryptionAlgorithm
    {
        static string  hash = "Ayz";
        public static string Encrytion(string sifrelenecekIfade)
        {
            string encrytedPassword = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifrelenecekIfade);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    encrytedPassword = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return encrytedPassword;
        }

        public static string Decrytion(string sifrelenmisString)
        {
            string decryptionText = "";
            byte[] data = Convert.FromBase64String(sifrelenmisString);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    decryptionText = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return decryptionText;
        }
    }
}
