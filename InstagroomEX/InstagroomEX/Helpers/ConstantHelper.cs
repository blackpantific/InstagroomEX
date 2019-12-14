using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InstagroomEX.Helpers
{
    public class ConstantHelper
    {
        public static Regex emailPattern = new Regex(@"^[0-9a-z\.]+@\w+.\w+$");
        public static string PasswordIncorrectAlert { get => "Incorrect password. Try re-entering your credentials"; }
    }
}
