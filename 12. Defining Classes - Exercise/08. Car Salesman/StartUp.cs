namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Engine> engines = new List<Engine>();

        int countEngine = int.Parse(Console.ReadLine());

        for (int i = 0; i < countEngine; i++)
        {
            string[] engineInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);
            int displacement = 0;
            string efficiency = string.Empty;

            if (engineInfo.Length > 2)
            {
                bool isDisplacement = int.TryParse(engineInfo[2], out displacement);

                if (isDisplacement && engineInfo.Length == 4)
                {
                    efficiency = engineInfo[3];
                }
                else if ((!isDisplacement) && engineInfo.Length == 3)
                {
                    efficiency = engineInfo[2];
                }
            }

            Engine engine = new Engine()
            {
                Model = model,
                Power = power,
                Displacement = displacement,
                Efficiency = efficiency
            };

            engines.Add(engine);
        }

        List<Car> cars = new List<Car>();

        int countOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCars; i++)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = carInfo[0];
            Engine engine = engines.FirstOrDefault(e => e.Model == carInfo[1]);
            int weight = 0;
            string color = string.Empty;

            if (carInfo.Length > 2)
            {
                bool isWeight = int.TryParse(carInfo[2], out weight);

                if (isWeight && carInfo.Length == 4)
                {
                    color = carInfo[3];
                }
                else if ((!isWeight) && carInfo.Length == 3)
                {
                    color = carInfo[2];
                }
            }        

            Car car = new Car()
            {
                Model = model,
                Engine = engine,
                Weight = weight,
                Color = color
            };

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"{car.Engine.Model}:");
            Console.WriteLine($"Power: {car.Engine.Power}");

            if (car.Engine.Displacement == 0)
            {
                Console.WriteLine($"Displacement: n/a");
            }
            else
            {
                Console.WriteLine($"Displacement: {car.Engine.Displacement}");
            }

            if (car.Engine.Efficiency == string.Empty)
            {
                Console.WriteLine($"Efficiency: n/a");
            }
            else
            {
                Console.WriteLine($"Efficiency: {car.Engine.Efficiency}");
            }

            if (car.Weight == 0)
            {
                Console.WriteLine($"Weight: n/a");
            }
            else
            {
                Console.WriteLine($"Weight: {car.Weight}");
            }

            if (car.Color == string.Empty)
            {
                Console.WriteLine($"Color: n/a");
            }
            else
            {
                Console.WriteLine($"Color: {car.Color}");
            }
        }
    }
}