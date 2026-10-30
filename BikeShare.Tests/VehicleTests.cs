namespace BikeShare.Tests;

[TestClass]
public class VehicleTests
{
    [TestMethod]
    public void Vehicle_IsAbstract_WithAbstractPrices()
    {
        Assert.IsTrue(typeof(Vehicle).IsAbstract, "Vehicle should be abstract");
        Assert.IsTrue(typeof(Vehicle).GetProperty(nameof(Vehicle.UnlockFee))!.GetMethod!.IsAbstract, "UnlockFee should be abstract");
        Assert.IsTrue(typeof(Vehicle).GetProperty(nameof(Vehicle.PricePerMinute))!.GetMethod!.IsAbstract, "PricePerMinute should be abstract");
    }

    [TestMethod]
    public void RideCost_Bike_IsUnlockFeePlusEveryMinute()
    {
        Assert.AreEqual(2.50m, new Bike("B1").RideCost(10));
    }

    [TestMethod]
    public void RideCost_EBike_IsUnlockFeePlusEveryMinute()
    {
        Assert.AreEqual(4.50m, new EBike("E1").RideCost(10));
    }

    [TestMethod]
    public void RideCost_Scooter_IsUnlockFeePlusEveryMinute()
    {
        Assert.AreEqual(3.50m, new Scooter("S1").RideCost(10));
    }

    [TestMethod]
    public void IChargeable_OnlyEBikesAndScooters_AreChargeable()
    {
        Assert.IsInstanceOfType<IChargeable>(new EBike("E1"), "an EBike should be IChargeable");
        Assert.IsInstanceOfType<IChargeable>(new Scooter("S1"), "a Scooter should be IChargeable");
        Assert.IsNotInstanceOfType<IChargeable>(new Bike("B1"), "a Bike has no battery");
    }

    [TestMethod]
    public void BatteryPercent_NewVehicle_IsFull()
    {
        Assert.AreEqual(100, ((IChargeable)new EBike("E1")).BatteryPercent);
        Assert.AreEqual(100, ((IChargeable)new Scooter("S1")).BatteryPercent);
    }

    [TestMethod]
    public void Drain_EBike_UsesOnePercentAMinute()
    {
        IChargeable ebike = (IChargeable)new EBike("E1");

        ebike.Drain(30);

        Assert.AreEqual(70, ebike.BatteryPercent);
    }

    [TestMethod]
    public void Drain_Scooter_UsesTwoPercentAMinute()
    {
        IChargeable scooter = (IChargeable)new Scooter("S1");

        scooter.Drain(30);

        Assert.AreEqual(40, scooter.BatteryPercent);
    }

    [TestMethod]
    public void Drain_LongerThanTheBatteryLasts_StopsAtZero()
    {
        IChargeable ebike = (IChargeable)new EBike("E1");
        IChargeable scooter = (IChargeable)new Scooter("S1");

        ebike.Drain(130);
        scooter.Drain(80);

        Assert.AreEqual(0, ebike.BatteryPercent);
        Assert.AreEqual(0, scooter.BatteryPercent);
    }

    [TestMethod]
    public void Charge_AfterARide_FillsTheBattery()
    {
        IChargeable scooter = (IChargeable)new Scooter("S1");
        scooter.Drain(25);

        scooter.Charge();

        Assert.AreEqual(100, scooter.BatteryPercent);
    }
}
