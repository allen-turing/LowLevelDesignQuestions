using ParkingLot.Model.Vehicles;

namespace ParkingLot.Model.Parking;

public class ParkingLotSetup
{
    public List<ParkingLevel> Levels { get; set; }

    public ParkingLotSetup(int numberOfLevels, int spotsPerLevel, VehicleType[][] spotTypesPerLevel)
    {
        Levels = new List<ParkingLevel>();
        for (int i = 0; i < numberOfLevels; i++)
        {
            Levels.Add(new ParkingLevel(i, spotsPerLevel, spotTypesPerLevel[i]));
        }
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        foreach (var level in Levels)
        {
            var spot = level.FindAvailableSpot(vehicle);
            if (spot != null)
            {
                spot.ParkVehicle(vehicle);
                Console.WriteLine($"Parked {vehicle.Type} at level {level.LevelId}, spot {spot.SpotId}");
                return true;
            }
        }
        Console.WriteLine("No available spot for the vehicle.");
        return false;
    }

    public bool ReleaseVehicle(int levelId, int spotId)
    {
        var level = Levels.FirstOrDefault(l => l.LevelId == levelId);
        if (level != null)
        {
            var spot = level.Spots.FirstOrDefault(s => s.SpotId == spotId);
            if (spot != null && !spot.IsAvailable)
            {
                spot.RemoveVehicle();
                Console.WriteLine($"Released vehicle from level {levelId}, spot {spotId}");
                return true;
            }
        }
        Console.WriteLine("No vehicle found at the given spot.");
        return false;
    }

    public int GetAvailableSpots()
    {
        return Levels.Sum(level => level.Spots.Count(s => s.IsAvailable));
    }
}