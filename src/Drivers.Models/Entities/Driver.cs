namespace Drivers.Models.Entities;

public class Driver : IEntity
{
    private Driver()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = default!;
    
    public DateOnly DriverSince { get; private set; }
    
    public DateTimeOffset CreatedOn { get; private set; }
    
    private readonly ICollection<Achievement> _achievements = new HashSet<Achievement>();
    
    public IReadOnlyCollection<Achievement> Achievements
        => _achievements.ToList().AsReadOnly();

    public static Driver Create(string name, DateOnly driverSince)
        => new() { Id = Guid.NewGuid(), CreatedOn = DateTimeOffset.UtcNow, Name = name, DriverSince = driverSince };

    public bool/*Result*/ AddAchievement(
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        string from,
        string to)
    {
        _achievements.Add(new(
                            Id,
                            startDateTime,
                            endDateTime,
                            from,
                            to));

        return true;
    }

    public void/*Result*/ SetName(string name)
    {
        Name = name;
    }

	public void/*Result*/ SetDriverSince(DateOnly driverSince)
	{
		DriverSince = driverSince;
	}
}