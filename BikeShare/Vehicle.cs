namespace BikeShare;

// Every vehicle in the fleet: a bike, an e-bike or a scooter.
//
// Requirements:
// - Vehicle is abstract: nobody rents a vehicle of no kind.
// - UnlockFee and PricePerMinute are abstract: every kind of vehicle sets its own.
// - RideCost(minutes) is the unlock fee, plus the price per minute for every minute.
public class Vehicle
{
    public string Id { get; }

    public Vehicle(string id)
    {
        Id = id;
    }

    public virtual decimal UnlockFee => 0m;
    public virtual decimal PricePerMinute => 0m;

    public decimal RideCost(int minutes)
    {
        return 0m;
    }
}
