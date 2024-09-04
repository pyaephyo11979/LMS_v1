using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_v1.MiddleWares
{
    public class TimeHelper
    {
        public static string GetTimeAgo(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan.TotalDays > 365)
                return $"{(int)timeSpan.TotalDays / 365} years ago";
            if (timeSpan.TotalDays > 30)
                return $"{(int)timeSpan.TotalDays / 30} months ago";
            if (timeSpan.TotalDays > 7)
                return $"{(int)timeSpan.TotalDays / 7} weeks ago";
            if (timeSpan.TotalDays > 1)
                return $"{(int)timeSpan.TotalDays} days ago";
            if (timeSpan.TotalHours > 1)
                return $"{(int)timeSpan.TotalHours} hr ago";
            if (timeSpan.TotalMinutes > 1)
                return $"{(int)timeSpan.TotalMinutes} min ago";
            if (timeSpan.TotalSeconds >= 1)
                return $"{(int)timeSpan.TotalSeconds} s ago";

            return "just now";
        }
    }
}