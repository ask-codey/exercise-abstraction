# Exercise: Abstraction

Exercise code for the lesson **Exercise: Abstraction** in the C# Full-Stack Bootcamp on [ask-codey.com](https://www.ask-codey.com).

A city bike share rents out three kinds of vehicle: bikes, e-bikes and scooters. Each kind has its own prices, and the electric ones have batteries. You'll finish the vehicles and the `RideService` that starts and ends rides.

## What's here

- `BikeShare/Vehicle.cs`: every kind of vehicle. For you to finish.
- `BikeShare/Bike.cs`: a finished kind of vehicle, to use as an example.
- `BikeShare/EBike.cs`, `BikeShare/Scooter.cs`: for you to finish.
- `BikeShare/IChargeable.cs`: the contract for anything with a battery. Ready to use.
- `BikeShare/IClock.cs`, `BikeShare/SystemClock.cs`: tell the time. Ready to use.
- `BikeShare/RideService.cs`: for you to finish.
- `BikeShare.Tests`: tests for all of it, with a fake clock. You don't need to change these.

The requirements are in the comment at the top of each file you finish.

## What to do

1. **Make `Vehicle` abstract**, with abstract `UnlockFee` and `PricePerMinute`, and write `RideCost`.
2. **Finish `EBike` and `Scooter`:** their prices, and the `IChargeable` contract.
3. **Fix the `RideService` constructor.** It's given an `IClock`, but it ignores it and makes its own.
4. **Write `StartRide`, `EndRide` and `NeedCharging`.**

Run the program with **Ctrl+F5**, and the tests with **Test > Run All Tests** (or `dotnet test`).

## Tips

- Once `Vehicle` is abstract, `EBike` and `Scooter` won't compile until they override its abstract members. Let the compiler's errors guide you, or press **Ctrl+.** on the red line and choose **Implement abstract class**.
- A class lists its base class first, then its interfaces: `class EBike : Vehicle, IChargeable`.
- `vehicle is IChargeable battery` checks for a battery, and gives you a variable to use it.
- A `Dictionary<string, DateTime>` keyed by the vehicle's `Id` can remember when each ride started. `TryAdd` and `Remove` return whether they did anything.
- To refuse, stop the method with `throw new InvalidOperationException("B1 is already on a ride.");`. Exceptions are covered properly in the next chapter.
- `(end - start).TotalMinutes` is a `double`; `Math.Ceiling` rounds any part of a minute up.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
