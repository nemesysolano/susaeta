using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.nemesys.crypt
{
	public class AESEncryptorParams
	{ 
		

		public byte[] Key;
		public byte[] InitVector;
		private string JSONString; //*****A00he8$DOG#

		private AESEncryptorParams(Dictionary<string, string> dictionary, string JSONString) {
			string _key = dictionary["key"];
			string _initVector = dictionary["initVector"];

			this.JSONString = JSONString;
			this.Key = StringToKey(_key);
			this.InitVector = System.Convert.FromBase64String(_initVector);
		}

		private static String Pad(string str)
        {
			if (str.Length > 16)
            {
				return str.Substring(0, 17);
            }
			return str.PadLeft(16,'*');
        }

		public static byte[] StringToKey(string key) 
		{
			string trimmed = key.Trim();
			string padded = trimmed.Length < 16 ? AESEncryptorParams.Pad(trimmed) : trimmed;

			return System.Text.Encoding.UTF8.GetBytes(padded);
		}

		public override string ToString() {
			return this.JSONString;
		}
		public static AESEncryptorParams createFromJSON (string JSONString) { //
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSONString);
			//{"initVector":"Kyw5VlE5SFApVi00MylBOQ\u003d\u003d\r\n\","key":"J#%3007v"}";

			return new AESEncryptorParams(dictionary, JSONString);
		}
	}
}