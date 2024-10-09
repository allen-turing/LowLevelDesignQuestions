namespace ParkingLot.Model.Vehicles;

public class Vehicle
{
    public VehicleType Type { get; set; }

    public Vehicle(VehicleType type)
    {
        this.Type = type;
    }
}