using System;
using System.Security.Cryptography;
using System.Text;
namespace com.nemesys.crypt
{
	public class AESEncryptor
    {

		public static RijndaelManaged  GetRijndaelManaged(byte[] KeyBytes, byte[] SecretBytes)
        {
			
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC, //CBC
				Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
				Key = KeyBytes, // Con mayúsculas, minúsclas, números y caracteres especiales entre 8 y 16 caracteres ASCII.
				IV = SecretBytes
            };
        }

		public static  RijndaelManaged GetRijndaelManaged(string json) {
			AESEncryptorParams parameters = AESEncryptorParams.createFromJSON(json);
			return GetRijndaelManaged(parameters.Key, parameters.InitVector);
		}

		public static  byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

		public static  byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

		public static byte[] Decrypt(byte[] encryptedData, string Key) //La que está en uso en el ejemplo.
        {
			return GetRijndaelManaged(Key).CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

		public static  String Encrypt(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key)));
        }

		public static  String Decrypt(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }



    }


  
}
