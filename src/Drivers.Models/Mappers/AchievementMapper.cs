using Drivers.Models.Dtos;
using Drivers.Models.Entities;

namespace Drivers.Models.Mappers;

public static class AchievementMapper
{
    public static AchievementDto ToAchievementDto(this Achievement achievement)
        => new
        (
            achievement.Id,
            achievement.StartDateTime,
            achievement.EndDateTime,
            achievement.From,
            achievement.To
        );
}