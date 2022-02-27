using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    internal static class ErrorPrefix
    {
        private static string[] ErrorPrefixes = new string[]
        {
            "Well, that does not look correct.",
            "That ain't right.",
            "Butter finger?",
            "Hmm, that's incorrect."
        };

        public static string GetRandomErrorPrefix()
        {
            var randomNumber = new Random().Next(ErrorPrefixes.Length);
            return ErrorPrefixes[randomNumber];
        }
    }
}
