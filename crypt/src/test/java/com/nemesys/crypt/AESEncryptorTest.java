package com.nemesys.crypt;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;
import org.junit.Test; 

public class AESEncryptorTest {
	String json = "{\"initVector\":\"KEQySyRSLUMqQTVNK1tVMg\\u003d\\u003d\\r\\n\",\"key\":\"A00he8$DOG#\"}";
	AESEncryptorParams params = AESEncryptorParams.createFromJSON(json);
	String sourceString = "The quick fox jumps over the lazy job";
	byte[] source = sourceString.getBytes();
	
	@Test	
	public void encryptBytes( ) {
		byte[] encrypted = AESEncryptor.encrypt(params, source);
		byte[] decrypted = AESEncryptor.decrypt(params, encrypted);
		
		System.out.println(json);
		assert(new String(source)).compareTo(new String(decrypted)) == 0;		
		
	}
	
	@Test
	public void encryptStrings( ) {
		String encrypted = AESEncryptor.encrypt(params, sourceString);
		String decrypted = AESEncryptor.decrypt(params, encrypted);
		
		System.out.print(encrypted);
		assert(sourceString.compareTo(decrypted)) == 0;
	}
	
	@Test
	public void encryptFile( ) throws IOException { //REMARK: Caso java.
		String filePath = "/home/rsolano/Downloads/test/source.txt";
		String cryptedPath = "/home/rsolano/Downloads/test/crypted.txt";
		String decryptedPath = "/home/rsolano/Downloads/test/decrypted.txt";
		
		byte[] data = AESEncryptor.encryptFile(json, filePath);
		FileUtils.writeByteArrayToFile(new File(cryptedPath), data);
		
		byte encryptedData[] = AESEncryptor.decryptFile(json, cryptedPath);
		FileUtils.writeByteArrayToFile(new File(decryptedPath), encryptedData);				
	}	
}
