using ParkingLot.Model.Parking;
using ParkingLot.Model.Vehicles;

class ParkingLotDemo
{
    static void Main(string[] args)
    {
        // Initialize parking lot with 2 levels, 3 spots each
        var parkingLot = new ParkingLotSetup(
            2, 
            3, 
            new VehicleType[][]
            {
                new VehicleType[] { VehicleType.Car, VehicleType.Motorcycle, VehicleType.Car },
                new VehicleType[] { VehicleType.Truck, VehicleType.Car, VehicleType.Motorcycle }
            }
        );

        // Simulate Parking
        var car = new Vehicle(VehicleType.Car);
        var motorcycle = new Vehicle(VehicleType.Motorcycle);
        var truck = new Vehicle(VehicleType.Truck);

        Console.WriteLine("Parking vehicles...");
        parkingLot.ParkVehicle(car);       
        parkingLot.ParkVehicle(motorcycle);
        parkingLot.ParkVehicle(truck);     
        parkingLot.ParkVehicle(truck);     
        parkingLot.ParkVehicle(truck);     
        parkingLot.ParkVehicle(truck);     
        parkingLot.ParkVehicle(truck);     

        // Show available spots
        Console.WriteLine($"Available spots: {parkingLot.GetAvailableSpots()}");

        // Simulate Vehicle Exit
        Console.WriteLine("Releasing a car from Level 0, Spot 0...");
        parkingLot.ReleaseVehicle(0, 1);

        // Show available spots again
        Console.WriteLine($"Available spots: {parkingLot.GetAvailableSpots()}");

        // Try to park another vehicle
        var anotherCar = new Vehicle(VehicleType.Car);
        parkingLot.ParkVehicle(anotherCar);   // Parks another car
    }
}
