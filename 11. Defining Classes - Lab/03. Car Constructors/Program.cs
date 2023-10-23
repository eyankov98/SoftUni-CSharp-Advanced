namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car("BMW", "X3", 2006, 100, 2);
            
            car.Drive(10);
            car.Drive(50);

            Console.WriteLine(car.WhoAmI());
        }
    }
}