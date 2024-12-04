using Drivers.Infrastructure.DataAccess;
using Drivers.Models.Mappers;
using Microsoft.EntityFrameworkCore;
using Drivers.Models.Dtos;
using Drivers.Models.Entities;
using Drivers.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Drivers.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapDriversEndpoints(this IEndpointRouteBuilder app,
        IConfiguration configuration)
    {
        var group = app.MapGroup("api/drivers");
        
        group.MapGet(string.Empty, GetDriversHandler)
            .WithName("GetDrivers")
            .WithOpenApi()
            .Produces<List<DriverDto>>(StatusCodes.Status200OK);

		group.MapPost(string.Empty, PostDriverHandler)
            .WithName("PostDriver")
            .WithOpenApi()
            .Produces<DriverDto>(StatusCodes.Status201Created);

		group.MapPut("{id:Guid}", PutDriverHandler)
			.WithName("PutDriver")
			.WithOpenApi()
            .Produces<DriverDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

		group.MapGet("{id:Guid}", GetDriverByIdHandler)
            .WithName("GetDriverById")
            .WithOpenApi()
			.Produces<DriverDto>(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status404NotFound);

		group.MapDelete("{id:Guid}", DeleteDriverHandler)
			.WithName("DeleteDriver")
			.WithOpenApi()
			.Produces(StatusCodes.Status204NoContent)
			.Produces(StatusCodes.Status404NotFound);

		return app;
    }
    
    private static Delegate GetDriversHandler
        =>	async (DriversDbContext dbContext, CancellationToken cancellationToken) =>
        {
            var drivers = await dbContext.Drivers.ToListAsync(cancellationToken);

            if ((!drivers?.Any()) ?? false)
                TypedResults.NotFound(Enumerable.Empty<DriverDto>());
            
            return TypedResults.Ok(drivers!.Select(d => d.ToDriverDto(AchievementMapper.ToAchievementDto)));
        };
    
    private static Delegate PostDriverHandler
        =>	async (AddDriverInputModel model, DriversDbContext dbContext, CancellationToken cancellationToken) =>
        {
            var newDriver = model.ToEntity();
            
            await dbContext.Set<Driver>().AddAsync(newDriver, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return TypedResults.CreatedAtRoute(
                newDriver.ToDriverDto(AchievementMapper.ToAchievementDto),
                "GetDriverById",
                new { newDriver.Id });
        };
    
    private static Delegate GetDriverByIdHandler
        =>	async ([FromRoute] Guid id, DriversDbContext dbContext, CancellationToken cancellationToken) =>
        {
            var driver = await dbContext.Set<Driver>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            return TypedResults.Ok(driver?.ToDriverDto(AchievementMapper.ToAchievementDto));
        };

	private static Delegate PutDriverHandler
		=> async ([FromRoute] Guid id, UpdateDriverInputModel model, DriversDbContext dbContext, CancellationToken cancellationToken) =>
		{
			var driver = await dbContext.Set<Driver>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (driver is null)
                return Results.NotFound();

			driver.SetName(model.Name);
			driver.SetDriverSince(model.DriverSince);

			await dbContext.SaveChangesAsync(cancellationToken);

			return Results.Ok(driver?.ToDriverDto(AchievementMapper.ToAchievementDto));
		};

	private static Delegate DeleteDriverHandler
		=> async ([FromRoute] Guid id, DriversDbContext dbContext, CancellationToken cancellationToken) =>
		{
			var driver = await dbContext.Set<Driver>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (driver is null)
				return Results.NotFound();

            dbContext.Remove(driver);
			await dbContext.SaveChangesAsync(cancellationToken);

			return Results.NoContent();
		};
}