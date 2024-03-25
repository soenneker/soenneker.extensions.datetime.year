using System.Diagnostics.Contracts;
using Soenneker.Enums.DateTimePrecision;

namespace Soenneker.Extensions.DateTime.Year;

/// <summary>
/// Contains extension methods for <see cref="DateTime"/> to navigate year boundaries.
/// </summary>
public static class DateTimeYearExtension
{
    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the last moment of the current year.
    /// </summary>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the last moment of the current year.</returns>
    [Pure]
    public static System.DateTime ToEndOfYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(DateTimePrecision.Year);
        return result;
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the last moment of the next year.
    /// </summary>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the last moment of the next year.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(DateTimePrecision.Year).AddYears(1);
        return result;
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the last moment of the previous year.
    /// </summary>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the last moment of the previous year.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(DateTimePrecision.Year).AddYears(-1);
        return result;
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the first moment of the current year.
    /// </summary>
    /// <remarks>Does not consider timezone, careful.</remarks>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the first moment of the current year.</returns>
    [Pure]
    public static System.DateTime ToStartOfYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOf(DateTimePrecision.Year);
        return result;
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the first moment of the next year.
    /// </summary>
    /// <remarks>Does not consider timezone, careful.</remarks>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the first moment of the next year.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOfYear().AddYears(1);
        return result;
    }

    /// <summary>
    /// Adjusts the provided <see cref="DateTime"/> value to the first moment (00:00:00) of the previous year relative to the date provided.
    /// </summary>
    /// <param name="dateTime">The date and time from which to calculate the start of the previous year.</param>
    /// <returns>A <see cref="DateTime"/> representing the first moment of the previous year based on the provided <paramref name="dateTime"/>.</returns>
    /// <remarks>
    /// This method adjusts the <paramref name="dateTime"/> to the start of the year and then subtracts one year to find the start of the previous year. 
    /// The time component is set to the first moment of the year (00:00:00). It is important to consider the time zone of the <paramref name="dateTime"/> 
    /// when using this method, as it does not perform any time zone conversions or adjustments.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfPreviousYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOfYear().AddYears(-1);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the start of the year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The start of the year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToTz(tzInfo).ToStartOfYear().ToUtc(tzInfo);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the start of the next year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The start of the next year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToTz(tzInfo).ToStartOfNextYear().ToUtc(tzInfo);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the start of the previous year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The start of the previous year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfPreviousTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfTzYear(tzInfo).AddYears(-1);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the last moment of the current year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The last moment of the current year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfNextTzYear(tzInfo).AddTicks(-1);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the last moment of the previous year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The last moment of the previous year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfTzYear(tzInfo).AddTicks(-1);
        return result;
    }

    /// <summary>
    /// Converts a UTC date and time to the last moment of the next year based on a specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date and time to convert.</param>
    /// <param name="tzInfo">The time zone to consider for the conversion.</param>
    /// <returns>The last moment of the next year in UTC, adjusted for the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextTzYear(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfTzYear(tzInfo).AddYears(1).AddTicks(-1);
        return result;
    }
}
