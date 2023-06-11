using System;

namespace Demo
{
    public static class DateUtils
    {
        public static string CurrentDate()
        {
            string date = DateTime.Now.ToLongDateString();
            return date;
        }
    }
}