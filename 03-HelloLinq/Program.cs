
using System.Threading.Tasks;

namespace HelloLinqSDA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Linq queries
            var mockarooData = await DataContext.MockarooCarData();

            //CarRepository.CarsWithAtLeastFourDoors(mockarooData);
            //CarRepository.MazdaCarsWithAtLeastFourDoors(mockarooData);
            //CarRepository.MakesThatStartWithM(mockarooData);
            //CarRepository.MostPowerfulCars(mockarooData,10);
            //CarRepository.MakesWithAtLeastTwoModelsWithHigherHorsePower(mockarooData, 400);
            //CarRepository.ModelsPerMakeAfter(mockarooData,2008);

            //CarRepository.MakesWithAtLeastTwoModelsWithHigherHorsePower(mockarooData);
            //CarRepository.MakesWithHPRange(mockarooData);
        }
    }
}
