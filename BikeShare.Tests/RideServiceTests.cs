namespace BikeShare.Tests;

[TestClass]
public class RideServiceTests
{
    // A fake clock: it stays at the same time until a test moves it forward.
    private class FakeClock : IClock
    {
        public DateTime Now { get; private set; } = new DateTime(2026, 5, 1, 9, 0, 0);

        public void Advance(TimeSpan time)
        {
            Now += time;
        }
    }

    [TestMethod]
    public void EndRide_After12Minutes_ChargesFor12Minutes()
    {
        FakeClock clock = new FakeClock();
        RideService rides = new RideService(clock);
        Bike bike = new Bike("B1");

        rides.StartRide(bike);
        clock.Advance(TimeSpan.FromMinutes(12));
        decimal cost = rides.EndRide(bike);

        Assert.AreEqual(2.80m, cost);
    }

    [TestMethod]
    public void EndRide_PartOfAMinute_CountsAsAWholeMinute()
    {
        FakeClock clock = new FakeClock();
        RideService rides = new RideService(clock);
        Bike bike = new Bike("B1");

        rides.StartRide(bike);
        clock.Advance(TimeSpan.FromSeconds(10 * 60 + 30));
        decimal cost = rides.EndRide(bike);

        Assert.AreEqual(2.65m, cost);
    }

    [TestMethod]
    public void EndRide_UnderAMinute_ChargesForOneMinute()
    {
        FakeClock clock = new FakeClock();
        RideService rides = new RideService(clock);
        Scooter scooter = new Scooter("S1");

        rides.StartRide(scooter);
        clock.Advance(TimeSpan.FromSeconds(20));
        decimal cost = rides.EndRide(scooter);

        Assert.AreEqual(0.80m, cost);
    }

    [TestMethod]
    public void EndRide_ChargeableVehicle_DrainsTheBattery()
    {
        FakeClock clock = new FakeClock();
        RideService rides = new RideService(clock);
        EBike ebike = new EBike("E1");

        rides.StartRide(ebike);
        clock.Advance(TimeSpan.FromMinutes(25));
        rides.EndRide(ebike);

        Assert.AreEqual(75, ((IChargeable)ebike).BatteryPercent);
    }

    [TestMethod]
    public void StartRide_AlreadyOnARide_Throws()
    {
        RideService rides = new RideService(new FakeClock());
        Bike bike = new Bike("B1");
        rides.StartRide(bike);

        Assert.ThrowsExactly<InvalidOperationException>(() => rides.StartRide(bike));
    }

    [TestMethod]
    public void EndRide_NotStarted_Throws()
    {
        RideService rides = new RideService(new FakeClock());

        Assert.ThrowsExactly<InvalidOperationException>(() => rides.EndRide(new Bike("B1")));
    }

    [TestMethod]
    public void StartRide_AfterTheLastRideEnded_StartsANewRide()
    {
        FakeClock clock = new FakeClock();
        RideService rides = new RideService(clock);
        Bike bike = new Bike("B1");
        rides.StartRide(bike);
        clock.Advance(TimeSpan.FromMinutes(5));
        rides.EndRide(bike);

        rides.StartRide(bike);
        clock.Advance(TimeSpan.FromMinutes(2));
        decimal cost = rides.EndRide(bike);

        Assert.AreEqual(1.30m, cost);
    }

    [TestMethod]
    public void NeedCharging_Fleet_ListsOnlyLowBatteries()
    {
        RideService rides = new RideService(new FakeClock());
        EBike tired = new EBike("E1");
        EBike fresh = new EBike("E2");
        Scooter flat = new Scooter("S1");
        Bike bike = new Bike("B1");
        ((IChargeable)tired).Drain(85);
        ((IChargeable)fresh).Drain(80);
        ((IChargeable)flat).Drain(50);

        List<Vehicle> needCharging = rides.NeedCharging(new List<Vehicle> { bike, tired, fresh, flat });

        CollectionAssert.AreEqual(new List<Vehicle> { tired, flat }, needCharging);
    }
}
