using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace OOPAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("tr-TR");

                Surface surface = CreateSurface();

                Car[] cars = new Car[2];
                string[] carCommands = new string[cars.Length];
                IStringCommand[] carCommandExecutors = new CarStringCommandExecutor[cars.Length];

                for (int i = 0; i < cars.Length; i++)
                {
                    // Create car on surface
                    cars[i] = CreateCar(surface: surface);

                    // Attach observer surface
                    cars[i].Attach(surface);

                    // Get command for the car
                    carCommands[i] = GetCarCommand();

                    // This executor will perform console commands on given car
                    // You can create new executors for different input types like json, xml, C# instance etc
                    carCommandExecutors[i] = new CarStringCommandExecutor(cars[i]);
                }

                for (int i = 0; i < cars.Length; i++)
                {
                    try
                    {
                        carCommandExecutors[i].ExecuteCommand(carCommands[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata: " + ex.Message);

                        break;
                    }

                    // Output the car's current status
                    Car car = cars[i];

                    Console.WriteLine(string.Concat("X: " + car.Coordinates.X, " ", "Y: " + car.Coordinates.Y, " ", car.Direction));
                }

                Console.WriteLine("Oyun bitti!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

        static Surface CreateSurface()
        {
            long surfaceWidth, surfaceHeight;

            do
            {
                Console.Write("Oyun alanı uzunluk ve yüksekliğini girin [örn: '5 5']: ");
                string[] surfaceDimension = Console.ReadLine().Split(" ");

                // Input string format must be like "5 5"
                if (surfaceDimension.Length != 2)
                {
                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!long.TryParse(surfaceDimension[0], out surfaceWidth) || surfaceWidth < 1)
                {
                    Console.WriteLine("Uzunluk hatalı girildi veya desteklenen aralığın dışında. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!long.TryParse(surfaceDimension[1], out surfaceHeight) || surfaceHeight < 1)
                {
                    Console.WriteLine("Yükseklik hatalı girildi veya desteklenen aralığın dışında. Lütfen tekrar deneyin.");
                    continue;
                }

                break;
            } while (true);

            return new Surface(surfaceWidth, surfaceHeight);
        }

        static Car CreateCar(ISurface surface)
        {
            long X, Y;
            Direction direction;

            do
            {
                Console.Write("Aracın başlangıç X, Y ve yön değerini girin [örn: '1 2 N']: ");
                string[] carParams = Console.ReadLine().Split(" ");

                // Input string format must be like "1 2 N"
                if (carParams.Length != 3)
                {
                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!long.TryParse(carParams[0], out X) || X < 0)
                {
                    Console.WriteLine("X hatalı girildi veya desteklenen aralığın dışında. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!long.TryParse(carParams[1], out Y) || Y < 0)
                {
                    Console.WriteLine("Y hatalı girildi veya desteklenen aralığın dışında. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!Enum.TryParse(carParams[2].ToUpper(), out direction))
                {
                    Console.WriteLine("Yön hatalı girildi. Lütfen tekrar deneyin.");
                    continue;
                }

                break;
            } while (true);

            // speed sets how many cells car will advance
            return new Car(new Coordinates(X, Y), direction, surface);
        }

        static string GetCarCommand()
        {
            do
            {
                Console.Write("Araç komutu girin. [örn: 'LMLMLMLMM']: ");
                string command = Console.ReadLine().ToUpper();

                if (!Regex.IsMatch(command, "^[L R M]*$"))
                {
                    Console.WriteLine("Komut hatalı girildi. Lütfen tekrar deneyin.");
                    continue;
                }

                return command;
            } while (true);
        }
    }
}
