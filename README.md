[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.year.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.year/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.year/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.year/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.year.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.year/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.year/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.year/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Year

Computes current, previous, and next calendar-year boundaries for `DateTime`, with optional time-zone-aware UTC results.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Year
```

## Calendar-field boundaries

```csharp
using Soenneker.Extensions.DateTime.Year;

System.DateTime value = new(2026, 8, 29, 16, 42, 30, DateTimeKind.Utc);

System.DateTime start = value.ToStartOfYear();
System.DateTime end = value.ToEndOfYear();
System.DateTime previousStart = value.ToStartOfPreviousYear();
System.DateTime nextEnd = value.ToEndOfNextYear();
```

| Method pair | Selected year |
| --- | --- |
| `ToStartOfYear()` / `ToEndOfYear()` | Current |
| `ToStartOfPreviousYear()` / `ToEndOfPreviousYear()` | Previous |
| `ToStartOfNextYear()` / `ToEndOfNextYear()` | Next |

Starts are January 1 at midnight. Ends are one tick before January 1 of the following year. These methods operate on the input calendar fields, preserve `Kind`, and use `DateTime` calendar arithmetic, including leap years. They do not perform time-zone conversion.

## Time-zone-aware boundaries

```csharp
TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
System.DateTime utc = new(2026, 8, 29, 18, 0, 0, DateTimeKind.Utc);

System.DateTime localYearStartUtc = utc.ToStartOfTzYear(eastern);
System.DateTime localYearEndUtc = utc.ToEndOfTzYear(eastern);
```

Time-zone variants cover the current, previous, and next local calendar year and return boundaries as UTC `DateTime` values. Their names follow the same pattern, including `ToStartOfPreviousTzYear()` and `ToEndOfNextTzYear()`.

If the input `Kind` is not `Utc`, its fields are treated as UTC rather than converted from the machine's local zone. Supply an actual UTC value to avoid ambiguity.

Year ends are one tick before the following valid local January 1 boundary. If a local year begins in a daylight-saving gap, the boundary advances to the first valid local minute; if it is ambiguous, the earlier UTC instant is selected.
