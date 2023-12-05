using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.General
{
    public class StringFormatter
    {
        public string FormatToLength(string str, int length)
        {
            if (str.Length > length)
            {
                return FormatToSmallerLength(str, length);
            }
            else if (str.Length < length)
            {
                return FormatToBiggerLength(str, length);
            }
            else
            {
                return str;
            }
        }

        private string FormatToSmallerLength(string str, int length)
        {
            StringBuilder formatedString = new StringBuilder();

            string strPart;

            for (int i = 0; i < str.Length; i++)
            {
                if (i + length > str.Length)
                {
                    strPart = str.Substring(i, i + str.Length - 1);
                    formatedString.Append(strPart);
                }
                else
                {
                    strPart = str.Substring(i, i + length - 1);
                    formatedString.Append(strPart + '-' + '\n');
                }
            }

            return formatedString.ToString();
        }

        private string FormatToBiggerLength(string str, int length)
        {
            return str + new String(' ', str.Length - length);
        }
    }
}
