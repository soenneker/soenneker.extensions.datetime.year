[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.year.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.year/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.year/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.year/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.year.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.year/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.year/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.year/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Year
A collection of helpful DateTime year-based extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Year
```

## Quick start

```csharp
using Soenneker.Extensions.DateTime.Year;

DateTime dateTime = DateTime.UtcNow;
var result = dateTime.ToStartOfYear();
```

## Common operations

- `ToStartOfYear()` - Adjusts the given `dateTime` to the first moment of the current year. Returns a `DateTime` instance representing the first moment of the current year. Does not consider timezone, careful.
- `ToEndOfYear()` - Adjusts the given `dateTime` to the last moment of the current year. Returns a `DateTime` instance representing the last moment of the current year.
- `ToStartOfNextYear()` - Adjusts the given `dateTime` to the first moment of the next year. Returns a `DateTime` instance representing the first moment of the next year. Does not consider timezone, careful.
- `ToStartOfPreviousYear()` - Adjusts the provided `DateTime` value to the first moment (00:00:00) of the previous year relative to the date provided.
- `ToEndOfNextYear()` - Adjusts the given `dateTime` to the last moment of the next year. Returns a `DateTime` instance representing the last moment of the next year.
- `ToEndOfPreviousYear()` - Adjusts the given `dateTime` to the last moment of the previous year. Returns a `DateTime` instance representing the last moment of the previous year.
- `ToStartOfTzYear()` - Converts a UTC date and time to the start of the year based on a specified time zone. Returns the start of the year in UTC, adjusted for the specified time zone.
- `ToStartOfNextTzYear()` - Converts a UTC date and time to the start of the next year based on a specified time zone. Returns the start of the next year in UTC, adjusted for the specified time zone.
- `ToStartOfPreviousTzYear()` - Converts a UTC date and time to the start of the previous year based on a specified time zone. Returns the start of the previous year in UTC, adjusted for the specified time zone.
- `ToEndOfTzYear()` - Converts a UTC date and time to the last moment of the current year based on a specified time zone. Returns the last moment of the current year in UTC, adjusted for the specified time zone.
- `ToEndOfPreviousTzYear()` - Converts a UTC date and time to the last moment of the previous year based on a specified time zone. Returns the last moment of the previous year in UTC, adjusted for the specified time zone.
- `ToEndOfNextTzYear()` - Converts a UTC date and time to the last moment of the next year based on a specified time zone. Returns the last moment of the next year in UTC, adjusted for the specified time zone.
