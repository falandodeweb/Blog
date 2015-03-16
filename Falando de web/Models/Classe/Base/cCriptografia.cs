using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;

public class cCriptografia
{
    private static byte[] chave = { };
    private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };
    static string chaveCriptografia = "chave criptográfica";

    public cCriptografia()
    {

    }
    
    public static string Criptografar(string valor)
    {
        DESCryptoServiceProvider des;
        MemoryStream ms;
        CryptoStream cs; byte[] input;

        des = new DESCryptoServiceProvider();
        ms = new MemoryStream();

        input = Encoding.UTF8.GetBytes(valor); chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

        cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
        cs.Write(input, 0, input.Length);
        cs.FlushFinalBlock();

        return Convert.ToBase64String(ms.ToArray())
                       .Replace("\\", "_a1_")
                       .Replace("/", "_b2_")
                       .Replace(":", "_c3_")
                       .Replace("*", "_d4_")
                       .Replace("?", "_e5_")
                       .Replace("\"", "_f6_")
                       .Replace("<", "_g7_")
                       .Replace(">", "_h8_")
                       .Replace("|", "_i9_");
    }

    public static string Descriptografar(string valor)
    {
        valor = valor.Replace("_a1_", "\\")
                .Replace("_b2_", "/")
                .Replace("_c3_", ":")
                .Replace("_d4_", "*")
                .Replace("_e5_", "?")
                .Replace("_f6_", "\"")
                .Replace("_g7_", "<")
                .Replace("_h8_", ">")
                .Replace("_i9_", "|");
        
        DESCryptoServiceProvider des;
        MemoryStream ms;
        CryptoStream cs; byte[] input;

        des = new DESCryptoServiceProvider();
        ms = new MemoryStream();

        input = new byte[valor.Length];
        input = Convert.FromBase64String(valor.Replace(" ", "+"));

        chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

        cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
        cs.Write(input, 0, input.Length);
        cs.FlushFinalBlock();

        return Encoding.UTF8.GetString(ms.ToArray());
    }
}