using System;
using System.IO;

namespace com.nemesys.crypt
{
    class Program
	{	public static void TestPDF() {
			string[] files = {
				"/home/rsolano/Downloads/test/978994512514.pdf",
				"/home/rsolano/Downloads/test/978994512513.pdf"
			};
			string Key = "{\"initVector\":\"Kyw5VlE5SFApVi00MylBOQ\u003d\u003d\r\n\",\"key\":\"J#%3007v\"}";


			foreach(string f in files) {
				byte[] bytes = File.ReadAllBytes(f);
				byte[] decrypted = AESEncryptor.Decrypt(bytes, Key);
				File.WriteAllBytes(f.Replace(".pdf", ".decrypted.pdf"), decrypted);
			}

		}
        public static void Main(string[] args)
		{
			
			TestPDF();
        }
    }
}
    