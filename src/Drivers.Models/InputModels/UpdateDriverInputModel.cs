namespace Drivers.Models.InputModels;

public sealed record UpdateDriverInputModel(
	string Name,
	DateOnly DriverSince);