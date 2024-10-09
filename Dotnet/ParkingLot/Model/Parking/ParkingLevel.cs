using ParkingLot.Model.Vehicles;

namespace ParkingLot.Model.Parking;

public class ParkingLevel
{
    public int LevelId { get; set; }
    public List<ParkingSpot> Spots { get; set; }

    public ParkingLevel(int levelId, int numSpots, VehicleType[] spotTypes)
    {
        LevelId = levelId;
        Spots = new List<ParkingSpot>();
        for (int i = 0; i < numSpots; i++)
        {
            Spots.Add(new ParkingSpot(i, spotTypes[i]));
        }
    }

    public ParkingSpot FindAvailableSpot(Vehicle vehicle)
    {
        return Spots.FirstOrDefault(spot => spot.CanFitVehicle(vehicle));
    }
}