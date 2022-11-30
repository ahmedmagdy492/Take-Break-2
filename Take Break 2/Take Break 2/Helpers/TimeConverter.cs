using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Break_2.Helpers
{
    public static class TimeConverter
    {
        public static string ConvertSecondsToReadableFormat(long seconds)
        {
            float hours = seconds / 60 / 60;
            float mins = seconds / 60;
            float secs = seconds % 60;
            return $"{(long)hours}:{(long)mins}:{(long)secs}";
        }
    }
}
