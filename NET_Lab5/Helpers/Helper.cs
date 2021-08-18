using NET_Lab5.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Lab5.Helpers
{
    static class Helper
    {
        public static bool AreAllEqual(object[] objs)
        {
            for(int i = 1; i < objs.Length; i++)
            {
                if (!objs[i].Equals(objs[0]))
                    return false;
            }

            return true;
        }

    }
}
