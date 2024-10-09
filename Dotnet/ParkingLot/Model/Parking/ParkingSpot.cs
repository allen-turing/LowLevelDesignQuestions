using ParkingLot.Model.Vehicles;

namespace ParkingLot.Model.Parking;

public class ParkingSpot
{
    public int SpotId { get; set; }
    public VehicleType SpotType { get; set; }
    public bool IsAvailable { get; set; }
    public Vehicle CurrentVehicle { get; set; }

    public ParkingSpot(int spotId, VehicleType spotType)
    {
        SpotId = spotId;
        SpotType = spotType;
        IsAvailable = true;
    }

    public bool CanFitVehicle(Vehicle vehicle)
    {
        return IsAvailable && vehicle.Type == SpotType;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        IsAvailable = false;
        CurrentVehicle = vehicle;
    }

    public void RemoveVehicle()
    {
        IsAvailable = true;
        CurrentVehicle = null;
    }
}
