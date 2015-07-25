using System;

namespace SmhiNet.Services
{
    public static class Converter
    {
        /// <summary>
        /// Converts Unix Timestamp to DateTime
        /// </summary>
        /// <param name="unixTime">Unixtime as long</param>
        /// <returns>DateTime</returns>
        public static DateTime? UnixTimeToDateTime(long? unixTime)
        {
            if (unixTime == null)
                return null;
            try
            {
                var unixTimeAsLong = (long) unixTime;
                DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return unixStart.AddMilliseconds(unixTimeAsLong).ToLocalTime();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary>
        /// Converts wind directions in degree to compass point
        /// </summary>
        /// <param name="degree">float degree</param>
        /// <returns>Enum compass point</returns>
        public static Enum DegreeToCompassPoint(float degree)
        {
            //Checks for unvalid input
            if (degree < 0 || degree > 360)
            {
                throw new ArgumentOutOfRangeException("degree");
                
            }

            //Array with enums
            var dir = new Enum[]
            {
                Direction.N,
                Direction.NNE,
                Direction.NE,
                Direction.ENE,
                Direction.E,
                Direction.ESE,
                Direction.SE,
                Direction.SSE,
                Direction.S,
                Direction.SSW,
                Direction.SW,
                Direction.WSW,
                Direction.W,
                Direction.WNW,
                Direction.NW,
                Direction.NNW,
                
            };

            //360 degrees / 16 direction = 22.5. Add 0.5 to compensate truncated value
            var value =degree / 22.5 + 0.5;
            //16 values in array.
            int index = (int)value%16;

            
            return dir[index];
        }


        /// <summary>
        /// Extension method. Converts wind directions in degree to compass point
        /// </summary>
        /// <param name="degree">None</param>
        /// <returns>Enum compass point</returns>
        public static Enum ToCompassPoint(this float degree)
        {
            if (degree < 0 || degree > 360)
            {
                throw new ArgumentOutOfRangeException("degree");

            }
            var dir = new Enum[]
            {
                Direction.N,
                Direction.NNE,
                Direction.NE,
                Direction.ENE,
                Direction.E,
                Direction.ESE,
                Direction.SE,
                Direction.SSE,
                Direction.S,
                Direction.SSW,
                Direction.SW,
                Direction.WSW,
                Direction.W,
                Direction.WNW,
                Direction.NW,
                Direction.NNW,
                
            };

            var value = degree / 22.5 + 0.5;
            int index = (int)value % 16;


            return dir[index];
        }

        internal enum Direction
        {
            N,
            NNE,
            NE,
            ENE,
            E,
            ESE,
            SE,
            SSE,
            S,
            SSW,
            SW,
            WSW,
            W,
            WNW,
            NW, 
            NNW
        }

        
    }
}
