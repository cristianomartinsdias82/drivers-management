namespace Drivers.Models.Dtos;

public sealed record DriverDto (
    Guid Id,
    string Name,
    DateOnly DriverSince,
    DateTimeOffset CreatedOn,
    List<AchievementDto> Achievements
);