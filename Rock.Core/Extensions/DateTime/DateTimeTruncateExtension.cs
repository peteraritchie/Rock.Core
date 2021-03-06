﻿using System;

namespace Rock.Extensions.DateTime
{
    /// <summary>
    /// Defines a <see cref="Truncate"/> extension method for the <see cref="DateTime"/> struct.
    /// </summary>
    public static class DateTimeTruncateExtension
    {
        /// <summary>
        /// Truncates the indicated time section to truncate. Useful when trying to remove the millisecond part of a date time. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to truncate.</param>
        /// <param name="timeSectionToTruncate">A <see cref="TimeSection"/> that defines which component of the DateTime will be truncated.</param>
        /// <returns>A truncated <see cref="DateTime"/>.</returns>
        public static System.DateTime Truncate(this System.DateTime dateTime, TimeSection timeSectionToTruncate)
        {
            long ticks;

            switch (timeSectionToTruncate)
            {
                case TimeSection.Millisecond:
                    ticks = TimeSpan.TicksPerSecond;
                    break;
                case TimeSection.Second:
                    ticks = TimeSpan.TicksPerMinute;
                    break;
                case TimeSection.Minute:
                    ticks = TimeSpan.TicksPerHour;
                    break;
                case TimeSection.Hour:
                    ticks = TimeSpan.TicksPerDay;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("timeSectionToTruncate", "Invalid TimeSection value.");

            }

            return dateTime.AddTicks(-(dateTime.Ticks % ticks));
        }
    }
}
