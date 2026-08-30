using System.Diagnostics.Contracts;
using Soenneker.Enums.UnitOfTime;

namespace Soenneker.Extensions.DateTime.Year;

/// <summary>
/// Contains extension methods for <see cref="DateTime"/> to navigate year boundaries.
/// </summary>
public static class DateTimeYearExtension
{
    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the first moment of the current year.
    /// </summary>
    /// <remarks>Does not consider timezone, careful.</remarks>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the first moment of the current year.</returns>
    [Pure]
    public static System.DateTime ToStartOfYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToStartOf(UnitOfTime.Year);
        return result;
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTime"/> to the last moment of the current year.
    /// </summary>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the last moment of the current year.</returns>
    [Pure]
    public static System.DateTime ToEndOfYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOf(UnitOfTime.Year);
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
    /// Adjusts the given <paramref name="dateTime"/> to the last moment of the next year.
    /// </summary>
    /// <param name="dateTime">The date time to adjust.</param>
    /// <returns>A <see cref="DateTime"/> instance representing the last moment of the next year.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextYear(this System.DateTime dateTime)
    {
        System.DateTime result = dateTime.ToEndOfYear().AddYears(1);
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
        System.DateTime result = dateTime.ToEndOfYear().AddYears(-1);
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
        return GetStartOfTzYear(utcNow, tzInfo, 0);
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
        return GetStartOfTzYear(utcNow, tzInfo, 1);
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
        return GetStartOfTzYear(utcNow, tzInfo, -1);
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
        return GetStartOfTzYear(utcNow, tzInfo, 1).AddTicks(-1);
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
        return GetStartOfTzYear(utcNow, tzInfo, 0).AddTicks(-1);
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
        return GetStartOfTzYear(utcNow, tzInfo, 2).AddTicks(-1);
    }

    private static System.DateTime GetStartOfTzYear(System.DateTime utc, System.TimeZoneInfo timeZoneInfo, int yearOffset)
    {
        System.DateTime utcInstant = utc.Kind == System.DateTimeKind.Utc
            ? utc
            : System.DateTime.SpecifyKind(utc, System.DateTimeKind.Utc);
        System.DateTime local = System.TimeZoneInfo.ConvertTimeFromUtc(utcInstant, timeZoneInfo);
        var boundary = new System.DateTime(local.Year, 1, 1, 0, 0, 0, System.DateTimeKind.Unspecified).AddYears(yearOffset);

        while (timeZoneInfo.IsInvalidTime(boundary))
            boundary = boundary.AddMinutes(1);

        if (timeZoneInfo.IsAmbiguousTime(boundary))
        {
            System.TimeSpan[] offsets = timeZoneInfo.GetAmbiguousTimeOffsets(boundary);
            System.TimeSpan chosenOffset = offsets[0] >= offsets[1] ? offsets[0] : offsets[1];
            return System.DateTime.SpecifyKind(boundary - chosenOffset, System.DateTimeKind.Utc);
        }

        return System.TimeZoneInfo.ConvertTimeToUtc(boundary, timeZoneInfo);
    }
}
