namespace BikeShare;

// An ordinary bike: $1.00 to unlock, then $0.15 a minute. It's finished: use it as an example.
public class Bike : Vehicle
{
    public Bike(string id) : base(id)
    {
    }

    public override decimal UnlockFee => 1.00m;
    public override decimal PricePerMinute => 0.15m;
}
