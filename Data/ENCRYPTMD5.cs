using System;
using System.Security.Cryptography;
using System.Text;
namespace Portafolio.Data
{
    public class ENCRYPTMD5
    {
        public string Encrypt(string pass)
        {
            string hash = "Password Encrypt Pepo";
            byte[] data = UTF8Encoding.UTF8.GetBytes(pass);
            
            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);  
        }

        public string Descrypt(string passen)
        {
            string hash = "*";
            byte[] data = Convert.FromBase64String(passen);

            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
