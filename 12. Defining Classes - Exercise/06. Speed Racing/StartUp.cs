namespace SpeedRacing;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int countOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCars; i++)
        {
            string[] carsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = carsInfo[0];
            double fuelAmount = double.Parse(carsInfo[1]);
            double fuelConsumptionFor1km = double.Parse(carsInfo[2]);

            Car car = new Car()
            {
                Model = model,
                FuelAmount = fuelAmount,
                FuelConsumptionPerKilometer = fuelConsumptionFor1km,
                TravelledDistance = 0
            };

            cars.Add(car);
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandInfo = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            string carModel = commandInfo[1];
            double amountOfKm = double.Parse(commandInfo[2]);

            Car car = cars.FirstOrDefault(c => c.Model == carModel);

            car.DriveCar(amountOfKm);

            command= Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}