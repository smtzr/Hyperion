using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    static class TextBuffer
    {
        private static string outputBuffer;

        public static void Add(string text)
        {
            outputBuffer += text + "\n";

        }

        public static void Display()
        {
            Console.Clear();
            Console.Write(TextUtils.WordWrap(outputBuffer,Console.WindowWidth));
            Console.WriteLine("\nWhat shall I do?");
            Console.Write(">");

            outputBuffer = "";

        }
        
    }
}
