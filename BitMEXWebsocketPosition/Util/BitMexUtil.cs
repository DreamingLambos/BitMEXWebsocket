using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace BitMEXWebsocketPosition.Util
{
    class BitMexUtil
    {


        public static long GetNonce()
        {
            long nonce = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return nonce;
        }

        public static string GetSignature(string secret, long nonce)
        {
            string payload = "GET/realtime" + nonce;
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var payloadBytes = Encoding.UTF8.GetBytes(payload);
            var hmacsha256 = new HMACSHA256(secretBytes);

            byte[] signatureInBytes = hmacsha256.ComputeHash(payloadBytes);
            StringBuilder signatureStringBuilder = new StringBuilder(signatureInBytes.Length * 2);
            foreach (byte b in signatureInBytes)
                signatureStringBuilder.AppendFormat("{0:x2}", b);
            string signatureAsString = signatureStringBuilder.ToString();

            return signatureAsString;

        }

        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(uint esFlags);


        //Encryption / Decryption taken from
        //https://github.com/paulmowat/EncryptDecrypt/blob/master/c%23/EncryptDecrypt/Program.cs
        public static string Encrypt(string str, string key)
        {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();

            byte[] byteBuff;

            try
            {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);

                aesCryptoProvider.GenerateIV();
                aesCryptoProvider.IV = aesCryptoProvider.IV;
                byteBuff = Encoding.UTF8.GetBytes(str);

                byte[] encoded = aesCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length);

                string ivHexString = ToHexString(aesCryptoProvider.IV);
                string encodedHexString = ToHexString(encoded);


                return ivHexString + ':' + encodedHexString;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static string Decrypt(string encodedStr, string key)
        {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();

            byte[] byteBuff;

            try
            {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);


                string[] textParts = encodedStr.Split(':');
                byte[] iv = FromHexString(textParts[0]);
                aesCryptoProvider.IV = iv;
                byteBuff = FromHexString(textParts[1]);

                string plaintext = Encoding.UTF8.GetString(aesCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

                return plaintext;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static string ToHexString(byte[] str)
        {
            var sb = new StringBuilder();

            var bytes = str;
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        public static byte[] FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
        //End of code taken from
        //https://github.com/paulmowat/EncryptDecrypt/blob/master/c%23/EncryptDecrypt/Program.cs

    }
}
