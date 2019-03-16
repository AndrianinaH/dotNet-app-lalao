using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetService.Utils
{
    public class Util
    {
        //------------- cryptage sha1
        public static string Sha1(string input)
        {
            return String.Join("", (new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input))).Select(x => x.ToString("x2")).ToArray());
        }

        //    public static String uploadUrl = "C:/UwAmp/www/grails_app_lalao_image/";
        public static String uploadUrl = "D:/Serveur Web/UwAmp/www/grails_app_lalao_image/";

    }
}
