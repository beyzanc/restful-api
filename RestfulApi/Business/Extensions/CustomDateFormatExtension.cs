using RestfulApi.Models;
using System;

namespace RestfulApi.Business.Extensions
{
    public static class CustomDateFormatExtension
    {
        public static string ToCustomDateFormat(this Mission mission)
        {
            return mission.Deadline.ToString("d MMMM yyyy");

        }
    }
}
