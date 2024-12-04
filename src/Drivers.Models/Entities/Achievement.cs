namespace Drivers.Models.Entities;

public class Achievement : IEntity
{
    public Guid Id { get; private set; }

    public Driver Driver { get; private set; } = default!;
    public Guid DriverId { get; private set; }
    
    public DateTimeOffset StartDateTime { get; private set; }
    public DateTimeOffset EndDateTime { get; private set; }

    public string From { get; private set; }
    public string To { get; private set; }
    
    internal Achievement(Guid driverId, DateTimeOffset startDateTime, DateTimeOffset endDateTime, string from, string to)
        => (DriverId, StartDateTime, EndDateTime, From, To) = (driverId, startDateTime, endDateTime, from, to);
}