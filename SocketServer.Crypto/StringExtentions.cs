﻿using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;

namespace SocketServer.Crypto
{
    public static class StringExtentions
    {
        /// <summary>
        /// Encrypts the specified secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns></returns>
        public static byte[] Encrypt(this string secret, byte[] key, out byte[] iv)
        {
            throw new NotImplementedException();

            //using( TripleDES des = new TripleDESCryptoServiceProvider())
            //{
            //    var db = new Rfc2898DeriveBytes(key, des.IV, 50);
            //    des.Key = db.GetBytes(des.KeySize / 8);
            //    iv = des.IV;

            //    // Encrypt the message
            //    byte[] plaintextMessage = Encoding.UTF8.GetBytes(secret);

            //    using (var ciphertext = new MemoryStream())
            //    {
            //        using (var cs = new CryptoStream(ciphertext, des.CreateEncryptor(), CryptoStreamMode.Write))
            //        {
            //            cs.Write(plaintextMessage, 0, plaintextMessage.Length);
            //        }

            //        return ciphertext.ToArray();
            //    }
            //}
        }

        /// <summary>
        /// Decrypts the specified cipher.
        /// </summary>
        /// <param name="cipher">The cipher.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The iv.</param>
        /// <returns></returns>
        public static string Decrypt(this byte[] cipher, byte[] key, byte[] iv)
        {
            throw new NotImplementedException();

            //using (TripleDES aes = new TripleDESCryptoServiceProvider())
            //{
            //    var db = new Rfc2898DeriveBytes(key, iv, 50);
            //    aes.Key = db.GetBytes(aes.KeySize / 8);
            //    aes.IV = iv;

            //    // Encrypt the message
            //    using (var plainText = new MemoryStream())
            //    {
            //        using (var cs = new CryptoStream(plainText, aes.CreateDecryptor(), CryptoStreamMode.Write))
            //        {
            //            cs.Write(cipher, 0, cipher.Length);
            //        }
                    
            //        return Encoding.UTF8.GetString(plainText.ToArray());
            //    }
            //}
        }
    }
}
