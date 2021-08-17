using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.BusinessLayer
{
    public static class SessionInfo
    {
        private static string Name;

        public static string LoginName
        {
            get ; 
            set ; 
        }
    }
}