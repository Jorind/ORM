using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloLinqSDA
{
    /// <summary>
    /// https://www.mockaroo.com/
    /// https://json2csharp.com/
    /// 
    /// </summary>
    public class CarRepository
    {
        public static void CarsWithAtLeastFourDoors(IEnumerable<CarData> cars)
        {
            cars.Where(car => car.NumberOfDoors >= 4)
                .Select(car => $"{car.CarMake} {car.CarModel}")
                .ToList()
                .ForEach(car => Console.WriteLine(car));

        }
        public static void MazdaCarsWithAtLeastFourDoors(IEnumerable<CarData> cars)
        {
            cars.Where(car => car.CarMake == "Mazda")
                .Where(car => car.NumberOfDoors >= 4)
                .Select(car => $"{car.CarMake} {car.CarModel}")
                .ToList()
                .ForEach(car => Console.WriteLine(car));
        }
        public static void MakesThatStartWithM(IEnumerable<CarData> cars)
        {
            //Print Make +Model for all Makes that start with "M"
           cars.Where(car => car.CarMake.StartsWith("M"))
           .Select(car => $"{car.CarMake} {car.CarModel}")
           .ToList()
           .ForEach(car => Console.WriteLine(car));
        }
        public static void MostPowerfulCars(IEnumerable<CarData> cars, int take)
        {
            // Display a list of the 10 most powerful cars (in terms of hp)
            cars.OrderByDescending(car => car.Hp)
                .Take(take)
                .Select(car => $"{car.CarMake} {car.CarModel}")
                .ToList()
                .ForEach(car => Console.WriteLine(car));
        }
        public static void MakesWithAtLeastTwoModelsWithHigherHorsePower(IEnumerable<CarData> cars, int hp)
        {
            cars.GroupBy(g => g.CarMake)
                .Select(s => new { s.Key, NumberOfModels = s.Count(c => c.Hp > hp) })
                .Where(p=>p.NumberOfModels>2)
                .Select(s => $"{s.Key} : {s.NumberOfModels}")
                .ToList()
                .ForEach(item => Console.WriteLine(item));
        }

        public static void ModelsPerMakeAfter(IEnumerable<CarData> cars,int yearAfter)
        {
            // Display the number of models per make that appeared after 2008.
            // Makes should be displayed with a number of zero if there are no models after 2008.
            cars.GroupBy(car => car.CarMake)
                .Select(c => new
                {
                    c.Key,
                    NumberOfModels = c.Count(car => car.CarYear >= yearAfter)
                })
                .ToList()
                .ForEach(item => Console.WriteLine($"{item.Key}: {item.NumberOfModels}"));
        }
        public static void AverageHpPerMake(IEnumerable<CarData> cars)
        {
            // Display there average hp per make
            cars.GroupBy(car => car.CarMake)
                .Select(car => new { Make = car.Key, AverageHP = car.Average(c => c.Hp) })
                .ToList()
                .ForEach(make => Console.WriteLine($"{make.Make}: {make.AverageHP}"));
        }

        //ADVANCED
        public static void MakesWithHPRange(IEnumerable<CarData> cars)
        {
            //group by key might not be that trivial
            cars.GroupBy(g => g.Hp switch
                                    {
                                        <=100 =>"0...100",
                                        <=200 =>"101...200",
                                        <=300 => "201...300",
                                        <=400 => "301...400",           
                                         _    => "401...500" 
                                    })
           .Select(s=>new {HpCategory=s.Key, NumberOfMakes= s.Select(s=>new {s.CarMake}).Distinct().Count() })
           .ToList()
                .ForEach(item => Console.WriteLine($"{item.HpCategory}: {item.NumberOfMakes}"));
        }
    }
}