namespace BikeShare;

// An electric scooter: $0.50 to unlock, then $0.30 a minute.
//
// Requirements:
// - A Scooter is a Vehicle, and it's IChargeable.
// - Its battery starts full, at 100%. Drain uses 2% for every minute of riding, and the battery never
//   goes below 0%. Charge fills it back to 100%.
public class Scooter : Vehicle
{
    public Scooter(string id) : base(id)
    {
    }
}
