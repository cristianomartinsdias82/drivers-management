using Drivers.Models.Dtos;
using Drivers.Models.Entities;
using Drivers.Models.InputModels;

namespace Drivers.Models.Mappers;

public static class DriverMapper
{
    public static DriverDto ToDriverDto(this Driver driver, Func<Achievement,AchievementDto> achievementMapperFunc)
        => new
        (
            driver.Id,
            driver.Name,
            driver.DriverSince,
            driver.CreatedOn,
            driver.Achievements.Select(achievementMapperFunc)?.ToList() ?? new()
        );

    public static Driver ToEntity(this AddDriverInputModel addModel)
        => Driver.Create(addModel.Name, addModel.DriverSince);
}