using BikeShare;

List<Vehicle> fleet = new List<Vehicle>
{
    new Bike("B1"),
    new EBike("E1"),
    new Scooter("S1")
};

foreach (Vehicle vehicle in fleet)
{
    Console.WriteLine($"{vehicle.Id}: a 20-minute ride costs {vehicle.RideCost(20):C}");

    if (vehicle is IChargeable battery)
    {
        battery.Drain(45);
        Console.WriteLine($"{vehicle.Id}: {battery.BatteryPercent}% left after 45 minutes");
    }
}

RideService rides = new RideService(new SystemClock());
foreach (Vehicle vehicle in rides.NeedCharging(fleet))
{
    Console.WriteLine($"Needs charging: {vehicle.Id}");
}
