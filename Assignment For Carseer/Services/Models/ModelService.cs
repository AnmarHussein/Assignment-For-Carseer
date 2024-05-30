using Assignment_For_Carseer.Domain;
using Assignment_For_Carseer.Integration.Vehicles;
using Assignment_For_Carseer.Services.CarMakes;

namespace Assignment_For_Carseer.Services.Models
{
    public class ModelService: IModelService
    {
        private readonly ICarMakeService _carMakeService;
        private readonly IVehicleService _vehicleService;

        public ModelService(ICarMakeService carMakeService, IVehicleService vehicleService)
        {
            _carMakeService = carMakeService;
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Retrieves a list of models for a specific model year and car make.
        /// </summary>
        /// <param name="modelYear">The model year for which to retrieve models.</param>
        /// <param name="makeName">The name of the car make for which to retrieve models.</param>
        /// <returns>
        /// A response containing either the list of models for the given year and make if successful,
        /// or an error response if the input parameters are invalid or if no data is found.
        /// </returns>
        public async Task<Response<List<string>>> GetModels(int modelYear, string makeName)
        {
            // Validate input: modelYear and makeName
            // Note: validation depend on business
            if (modelYear > DateTime.Now.Year || modelYear <= 1900)
            {
                return Response<List<string>>.Error($"Please provide a year between 1900 and {DateTime.Now.Year}.");
            }    
            
            if (string.IsNullOrWhiteSpace(makeName))
            {
                return Response<List<string>>.Error("Make name is required.");
            }

            // Get the ID for the provided car make name
            long? makeId = _carMakeService.GetMakeIdByMakeName(makeName);

            // If no matching make ID is found, return an error response
            if (makeId is null)
            {
                return Response<List<string>>.Error("No Data Found.");
            }

            // Retrieve the list of models for the specified make ID and model year
            Response<List<string>> modelsResponse = await _vehicleService.GetModelsForMakeIdYear(makeId.Value, modelYear);

            // Return a success response containing the list of models
            return modelsResponse;
        }
    }
}
