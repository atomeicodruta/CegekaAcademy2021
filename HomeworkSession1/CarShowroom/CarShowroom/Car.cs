using System;
using System.Collections.Generic;

namespace CarShowroom
{
    public enum CarBrands { Mercedes = 1, Tesla, Honda, Smart };
    public enum CarPackages { Entry = 1, Plus, Premium, Custom };
    public enum EnginePower { EntryPower = 1, PlusPower, PremiumPower, PremiumPlusPower };
    public enum FuelType { Gas = 1, Diesel, Hybrid, Electric };
    public enum CarPolish { Basic = 1, Matte, PremiumPolish };
    public class Car
    {
        private CarBrands carBrand;
        private CarPackages packageType;
        private EnginePower enginePower;
        private FuelType fuelType;
        private CarPolish polishType;

        private static int carCounter = 0;

        public Car(CarBrands carBrand, CarPackages packageType)
        {
            this.carBrand = carBrand;
            this.packageType = packageType;
            carCounter++;
        }

        public static void PrintCarBrands()
        {
            int idx = 1;
            foreach (string brand in Enum.GetNames(typeof(CarBrands)))
            {
                Console.WriteLine($"\t {idx}. {brand}");
                idx++;
            }
        }

        public static void PrintCarPackages()
        {
            int idx = 1;
            foreach (string package in Enum.GetNames(typeof(CarPackages)))
            {
                Console.WriteLine($"\t {idx}. {package}");
                if (idx != 4)
                {
                    Console.WriteLine($"\t\t EnginePower: {(EnginePower)idx - 1}");
                    Console.WriteLine($"\t\t FuelType: {(FuelType)idx - 1}");
                    Console.WriteLine($"\t\t Polish: {(CarPolish)idx - 1}");
                }
                idx++;
            }
        }

        public static void PrintEnginePowerOptions()
        {
            int idx = 1;
            foreach (string enginePwr in Enum.GetNames(typeof(EnginePower)))
            {
                Console.WriteLine($"\t {idx}. {enginePwr}");
                idx++;
            }
        }

        public static void PrintFuelTypeOptions()
        {
            int idx = 1;
            foreach (string fuel in Enum.GetNames(typeof(FuelType)))
            {
                Console.WriteLine($"\t {idx}. {fuel}");
                idx++;
            }
        }

        public static void PrintCarPolishOptions()
        {
            int idx = 1;
            foreach (string polish in Enum.GetNames(typeof(CarPolish)))
            {
                Console.WriteLine($"\t {idx}. {polish}");
                idx++;
            }
        }

        public static void EntryCar(Car car)
        {
            car.enginePower = EnginePower.EntryPower;
            car.fuelType = FuelType.Gas;
            car.polishType = CarPolish.Basic;
        }

        public static void PlusCar(Car car)
        {
            car.enginePower = EnginePower.PlusPower;
            car.fuelType = FuelType.Diesel;
            car.polishType = CarPolish.Matte;
        }

        public static void PremiumCar(Car car)
        {
            car.enginePower = EnginePower.PremiumPower;
            car.fuelType = FuelType.Hybrid;
            car.polishType = CarPolish.PremiumPolish;
        }

        public static void CustomCar(Car car)
        {
            int customOption = 0;

            // Choose custom value for engine power
            Console.WriteLine("Engine power options: ");
            PrintEnginePowerOptions();
            Console.WriteLine("Choose preffered engine power option: ");
            customOption = Convert.ToInt32(Console.ReadLine());
            car.enginePower = (EnginePower)customOption;

            // Choose custom value for fuel type
            Console.WriteLine("Fuel type options: ");
            PrintFuelTypeOptions();
            Console.WriteLine("Choose preffered fuel type option: ");
            customOption = Convert.ToInt32(Console.ReadLine());
            car.fuelType = (FuelType)customOption;

            // Choose custom value for car polish type
            Console.WriteLine("Car polish type options: ");
            PrintCarPolishOptions();
            Console.WriteLine("Choose preffered car polish option: ");
            customOption = Convert.ToInt32(Console.ReadLine());
            car.polishType = (CarPolish)customOption;

        }
        public static void PrintCarCount()
        {
            Console.WriteLine($"\tCar count: {carCounter}.");
        }

        public override string ToString()
        {
            return "\tCar brand: " + carBrand + "\n\tPackage type: " + packageType +
                "\n\tEngine power: " + enginePower + "\n\tFuel type: " + fuelType +
                "\n\tCar polish: " + polishType + "\n";
        }

        static void Main(string[] args)
        {
            int menuOption = 1, carDisplay = 0;
            int brandOption = 0, packageOption = 0;

            List<Car> carsList = new List<Car>();

            Console.WriteLine("\nWelcome to our showroom! Rest assured, we have just the thing for you!");
            Console.WriteLine("\n\tI want to...\n");

            while ((menuOption >= 1) && (menuOption <= 3))
            {
                Console.WriteLine("\t1. Create a car");
                Console.WriteLine("\t2. View the cars manufactured so far");
                Console.WriteLine("\t3. View car count");
                Console.WriteLine("\t4. Exit showroom");

                menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption)
                {
                    case 1:

                        Console.WriteLine("Choose a brand form the following options:");
                        PrintCarBrands();
                        brandOption = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Choose a package:");
                        PrintCarPackages();
                        packageOption = Convert.ToInt32(Console.ReadLine());

                        Car car = new Car((CarBrands)brandOption, (CarPackages)packageOption);

                        switch (packageOption)
                        {
                            case 1:
                                EntryCar(car);
                                Console.WriteLine("\nEntry car created.\n");
                                break;
                            case 2:
                                PlusCar(car);
                                Console.WriteLine("\nPlus car created.\n");
                                break;
                            case 3:
                                PremiumCar(car);
                                Console.WriteLine("\nPremium car created.\n");
                                break;
                            case 4:
                                CustomCar(car);
                                Console.WriteLine("\nCustom car created.\n");
                                break;
                            default:
                                break;
                        }

                        Console.WriteLine("\nDo you want to view the created car?");
                        Console.WriteLine("\tYes - 1\n\tNo - 0");
                        carDisplay = Convert.ToInt32(Console.ReadLine());

                        if (carDisplay == 1)
                        {
                            Console.WriteLine(car);
                        }
                        carsList.Add(car);

                        break;
                    case 2:
                        if (carCounter == 0)
                        {
                            Console.WriteLine("\nOops..looks like there are no cars created so far.");
                        }
                        else
                        {
                            foreach (Car individualCar in carsList)
                            {
                                Console.WriteLine(individualCar);
                            }
                        }
                        break;
                    case 3:
                        PrintCarCount();
                        break;
                    case 4:
                        Console.WriteLine("\n\tGoodbye for now...\n");
                        break;
                    default:
                        Console.WriteLine("\n\tOops..looks like you entered an undefined command.");
                        break;
                }

                Console.WriteLine("\n\tGo back to menu?");
                Console.WriteLine("\t\tYes - 1\n\t\tNo - 0");
                menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 0)
                {
                    Console.WriteLine("\n\tGoodbye for now...\n");
                }

            }
        }
    }
}
