namespace BikeShare;

// Starts and ends rides, and finds the vehicles that need charging.
//
// Requirements:
// - The service is given its IClock, and asks it whenever it needs the time. It never makes its own clock,
//   and never reads DateTime.Now itself.
// - StartRide remembers when a vehicle's ride started. Starting a vehicle that's already on a ride throws an
//   InvalidOperationException.
// - EndRide works out how many minutes the ride took, counting any part of a minute as a whole minute, and
//   at least 1 minute. It returns the vehicle's RideCost for those minutes, and if the vehicle is
//   IChargeable, drains its battery for those minutes. The vehicle is then no longer on a ride. Ending a ride
//   that wasn't started throws an InvalidOperationException.
// - NeedCharging returns the vehicles in the fleet that are IChargeable and have less than 20% battery,
//   in the fleet's order.
public class RideService
{
    private readonly IClock clock;

    public RideService(IClock clock)
    {
        this.clock = new SystemClock();
    }

    public void StartRide(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public decimal EndRide(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public List<Vehicle> NeedCharging(IEnumerable<Vehicle> fleet)
    {
        List<Vehicle> needCharging = new List<Vehicle>();
        return needCharging;
    }
}
