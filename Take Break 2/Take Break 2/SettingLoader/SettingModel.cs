using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Break_2.SettingLoader
{
    public class SettingModel
    {
        public bool? Startup { get; set; }
        public long? TotalSeconds { get; set; }
        public long? WaitingTimeInSeconds { get; set; }
    }
}
