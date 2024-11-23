using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{
    // CLOCK FORMAT TRANSLATION, STRING INTERPOLATION, STRING CONCATENATION, GET (OR OBTAIN) ASCII VALUE OF A CHARACTER FROM A STRING



/* 
    Given a time in -hour AM/PM format, convert it to military (24-hour) time.

    Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
    - 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.

    Example:
    Return '12:01:00'.
    Return '00:01:00'.


    FUNCTION DESCRIPTION

    Complete the timeConversion function in the editor below. It should return a new string representing the input time in 24 hour format.

    timeConversion has the following parameter(s):

    string s: a time in  hour format
    Returns

    string: the time in  hour format
    Input Format

    A single string  that represents a time in -hour clock format (i.e.:  or ).

    CONSTRAINTS

    All input times are valid

    Sample Input
    07:05:45PM

    Sample Output
    19:05:45

*/

    /*
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        string period = $"{s[8]}{s[9]}";

/*      Bu işlem STRING INTERPOLATION (dize iç içe geçirme) olarak adlandırılır. 
        Bu özellik, C# 6.0 ve sonrasında eklenmiştir ve bir dizeye değişkenleri
        veya ifadeleri doğrudan yerleştirmenin daha okunabilir bir yoludur.
        Bu yöntemde, ${} içinde bir ifade belirtilir ve bu ifade bir 
        dizeye dönüştürülerek doğrudan yerine yazılır.

        Nasıl Çalışır?
        s[8] ve s[9]:

        s bir string olduğu için, s[8] stringin 8. indeksindeki karakteri (yani 9. karakter) alır.
        s[9] ise stringin 9. indeksindeki karakteri (yani 10. karakter) alır 

        $"{s[8]}{s[9]}" ifadesi, s[8] ve s[9] değerlerini alıp birleştirir.
        Sonuç bir string olur: "PM".

        Bu, şu şekilde manuel birleştirmenin kısa bir alternatifi olarak çalışır:
            string period = s[8].ToString() + s[9].ToString();   
            YA DA 
            string period = s[8] + s[9];


*/


/* Aşağıdaki ASCII DEĞERİ ALMA İŞLEMİNE (OBTAIN ASCII VALUE OPERATION) Verilen Diğer İsimler
    -Character Code Extraction (Karakter Kodu Çıkartma):
            ASCII veya Unicode değerini almak için kullanılan genel bir terimdir.
    -Numeric Representation of a Character (Bir Karakterin Sayısal Temsili):
            Karakterin dahili olarak nasıl saklandığını açıklayan bir terimdir.
    -Code Point Lookup (Kod Noktası Bulma):
            Unicode terminolojisinde bir karakterin kod noktasını bulma işlemine verilen isimdir.
*/
        int hours = (s[0] - '0') * 10 + (s[1] - '0');
        int minutes = (s[3] - '0') * 10 + (s[4] - '0');
        int seconds = (s[6] - '0') * 10 + (s[7] - '0');

        if (period == "AM")
        {
            if (hours == 12) // 12:xx:xx AM -> 00:xx:xx
                hours = 0;
        }
        else
        {
            if (hours != 12) // 01:xx:xx PM -> 13:xx:xx
                hours += 12;
        }

        string result = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();
        string result = Result.timeConversion(s);
        Console.WriteLine(result);
    }
}

