namespace BikeShare;

// An electric bike: $1.00 to unlock, then $0.35 a minute.
//
// Requirements:
// - An EBike is a Vehicle, and it's IChargeable.
// - Its battery starts full, at 100%. Drain uses 1% for every minute of riding, and the battery never
//   goes below 0%. Charge fills it back to 100%.
public class EBike : Vehicle
{
    public EBike(string id) : base(id)
    {
    }
}
