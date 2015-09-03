using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiApp.Models.Core
{
    public static class Db
    {
        public static CoreContext core = new CoreContext();
    }
}