import java.security.NoSuchAlgorithmException;

//this is a simple security cipher meant to mimic how an actual cipher might work
//given this is my first attempt at it, it's only reversing the string
//for simplicity's sake
public class RSACipher {

    public String encryptData(String data) {
        return new StringBuilder(data).reverse().toString();
    }

    public String decryptData(String encryptedData) {
        return new StringBuilder(encryptedData).reverse().toString();
    }

    public RSACipher() throws NoSuchAlgorithmException {
        //for simplicity purposes, I have not initialized any keys here

    }
}
