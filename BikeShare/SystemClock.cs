namespace BikeShare;

// The real clock. It's finished.
public class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}
