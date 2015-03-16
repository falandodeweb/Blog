using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Dynamic;
using System.Web.Mvc;
using System.Text;

public class cUtil
{
    public cUtil()
    {

    }

    public static string RemoverHtml(string texto, int quantidade, bool reticencias)
    {
        string txt = Regex.Replace(texto, @"<(.|\n)*?>", string.Empty).Replace("&nbsp;", " ");

        if (txt.Length > quantidade)
            txt = txt.Substring(0, quantidade);

        if (reticencias)
            txt += "...";

        return txt;
    }

    public static string RemoverAcento(string texto, bool pontoHtml)
    {
        string[] acentos = new string[] 
        { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", 
          "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì",
          "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ",
          "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î",
          "ô", "û", "Â", "Ê", "Î", "Ô", "Û" 
        };

        string[] semAcento = new string[] 
        { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", 
          "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I",
          "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y",
          "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i",
          "o", "u", "A", "E", "I", "O", "U" 
        };

        for (int i = 0; i < acentos.Length; i++)
            texto = texto.Replace(acentos[i], semAcento[i]);

        string[] caracteresEspeciais = 
        { "\\.", ",", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "?", 
          "!", "@", "#", "$", "%", "¨", "&", "*", "(", ")", "_", "+", 
          "=", "|", "<", ">", ";", "[", "]", "{", "}", "´", "`", "^",
          "~", "º", "¬", "¹", "²", "³", "£", "¢", "æ", "Æ", "»", "«" 
        };
        string[] caracteresEspeciais1 = { "/", "--", "^\\s+", "\\s+$", "\\s+", ".", "\\)", "%20", "  ", " " };

        for (int i = 0; i < caracteresEspeciais.Length; i++)
            texto = texto.Replace(caracteresEspeciais[i], string.Empty);

        for (int i = 0; i < caracteresEspeciais1.Length; i++)
            texto = texto.Replace(caracteresEspeciais1[i], "-");

        texto = texto.ToLower();

        if (pontoHtml)
            texto += ".html";

        return texto;
    }

    public static bool ValidarCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty);

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    public static bool ValidarCNPJ(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);

        if (cnpj.Length != 14)
            return false;

        tempCnpj = cnpj.Substring(0, 12);
        soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCnpj = tempCnpj + digito;
        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }

    public static DataTable RetornarEndereco(string cep)
    {
        DataSet ds = new DataSet();
        ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty) + "&formato=xml");

        DataTable dt = ds.Tables[0].Copy();
        return dt;
    }

    public static string RetornarUrl()
    {
        return HttpContext.Current.Request.Url.AbsolutePath.ToLower();
    }

    public static string FormatarNome(string nome)
    {
        if (nome.Contains(" "))
            return nome.Split(' ')[0];
        else
            return nome;
    }

    public static string FormatarTempo(DateTime data)
    {
        StringBuilder rv = new StringBuilder();
        TimeSpan ts = DateTime.Now - data;

        if (ts.TotalDays >= 1.0)
            rv.AppendFormat("{0} dia(s)", (int)ts.TotalDays);
        else if (ts.TotalHours > 1.0)
            rv.AppendFormat("{0} hora(s)", (int)ts.TotalHours);
        else if (ts.TotalMinutes > 1.0)
            rv.AppendFormat("{0} min(s)", (int)ts.TotalMinutes);
        else
            rv.AppendFormat("{0} seg(s)", (int)ts.TotalSeconds);

        return rv.ToString();
    }
}