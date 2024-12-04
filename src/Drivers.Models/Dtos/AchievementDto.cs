namespace Drivers.Models.Dtos;

public sealed record AchievementDto(
    Guid Id,
    DateTimeOffset StartDateTime,
    DateTimeOffset EndDateTime,
    string From,
    string To 
);