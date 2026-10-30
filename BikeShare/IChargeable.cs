namespace BikeShare;

// Anything with a battery. It's finished.
public interface IChargeable
{
    // How full the battery is, from 0 to 100.
    int BatteryPercent { get; }

    // Uses up the battery for a ride of this many minutes.
    void Drain(int minutes);

    // Fills the battery.
    void Charge();
}
