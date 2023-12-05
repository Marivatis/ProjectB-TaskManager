using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.General
{
    public class StringFormatter
    {
        public static string FormatToLength(string str, int maxLength)
        {
            StringBuilder formatedString = new StringBuilder();

            string strPart;

            for (int i = 0; i < str.Length; i++)
            {                
                if (i + maxLength > str.Length)
                {
                    strPart = str.Substring(i, i + str.Length - 1);
                    formatedString.Append(strPart);
                }
                else
                {
                    strPart = str.Substring(i, i + maxLength - 1);
                    formatedString.Append(strPart + '-' + '\n');
                }
            }

            return formatedString.ToString();
        }
    }
}
