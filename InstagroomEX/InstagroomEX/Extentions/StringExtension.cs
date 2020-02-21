using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Extentions
{
    static class StringExtension
    {
        public static string TruncateLongStringAtWord(this string inputString, int maxChars, string postfix = "...")
        {
            if (maxChars <= 0)
                throw new ArgumentOutOfRangeException("maxChars");
            if (inputString == null || inputString.Length < maxChars)
                return inputString;

            var lastSpaceIndex = inputString.LastIndexOf(" ", maxChars);
            var substringLength = (lastSpaceIndex > 0) ? lastSpaceIndex : maxChars;
            var truncatedString = inputString.Substring(0, substringLength).Trim() + postfix;

            return truncatedString;
        }
    }
}
