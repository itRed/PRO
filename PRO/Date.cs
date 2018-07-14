using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRO
{
    class Date
    {
        private string p;

        public Date(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

    }
}
