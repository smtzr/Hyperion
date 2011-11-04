using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    static class TextUtils
    {
        public static string ExtractCommand(string line)
        {
            int index = line.IndexOf(' ');
            if (index == -1)
            {
                return line;
            }
            else
            {
                return line.Substring(0, index);
            }
        }

        public static string ExtractArguments(string line)
        {
            int index = line.IndexOf(' ');
            if (index == -1)
                return "";
            else
                return line.Substring(index + 1, line.Length - index - 1);
                // return line.Substring(index+1);
        }

        public static string WordWrap(string text, int bufferWidth)
        {
            return text;
        }
    }
}
