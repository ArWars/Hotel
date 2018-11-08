using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hoteles.Models
{
    public static class Helper
    {
        public static class Convertir
        {
            public static DateTime aTimeStamp(double unixTime)
            {
                var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(unixTime / 10000d)).ToLocalTime();
                return dt;
            }
        }
        public static DateTime cambiarFecha(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
    }
}