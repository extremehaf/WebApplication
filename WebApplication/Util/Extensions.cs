using System;

namespace WebApplication.Util
{
   public static class Extensions    
    {
        public static String ToBase64(this byte[] bt)
        {
            return Convert.ToBase64String(bt);
        }
    }
}
