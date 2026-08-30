using System;
using System.Threading.Tasks;
using Soenneker.Tests.Unit;

namespace Soenneker.Extensions.DateTime.Year.Tests;

public class DateTimeYearExtensionTests : UnitTest
{
    [Test]
    public async Task ToEndOfYear_includes_leap_day()
    {
        var value = new System.DateTime(2024, 2, 29, 12, 0, 0, DateTimeKind.Utc);

        System.DateTime result = value.ToEndOfYear();

        await Assert.That(result).IsEqualTo(new System.DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddTicks(-1));
    }

    [Test]
    public async Task Time_zone_next_year_start_is_utc()
    {
        var value = new System.DateTime(2026, 8, 29, 12, 0, 0, DateTimeKind.Utc);

        System.DateTime result = value.ToStartOfNextTzYear(TimeZoneInfo.Utc);

        await Assert.That(result).IsEqualTo(new System.DateTime(2027, 1, 1, 0, 0, 0, DateTimeKind.Utc));
    }
}
