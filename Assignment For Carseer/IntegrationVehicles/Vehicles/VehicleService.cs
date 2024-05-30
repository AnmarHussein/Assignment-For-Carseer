using Assignment_For_Carseer.Domain;
using Assignment_For_Carseer.IntegrationVehicles.Dto;

namespace Assignment_For_Carseer.Integration.Vehicles
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleApi _vehicleApi;

        public VehicleService(IVehicleApi vehicleApi)
        {
            _vehicleApi = vehicleApi;
        }


        /// <summary>
        /// Retrieves a list of models for a specific car make ID and model year.
        /// </summary>
        /// <param name="makeId">The ID of the car make for which to retrieve models.</param>
        /// <param name="makeYear">The model year for which to retrieve models.</param>
        /// <returns>
        /// A list of model names for the specified car make ID and model year.
        /// </returns>
        public async Task<Response<List<string>>> GetModelsForMakeIdYear(long makeId, long makeYear)
        {
            // Call an external API to get models for the specified make ID and year
            VehicleResponse<List<VehicleDto>> vehicleResponse = await _vehicleApi.GetModelsForMakeIdYear(makeId, makeYear);

            if(vehicleResponse?.Count > 0)
            {
                // Extract model names from the response and return as a list
                List<string> modelNames = vehicleResponse.Results.Select(x => x.ModelName).ToList();
                return Response<List<string>>.Success(modelNames);
            }

            return Response<List<string>>.Error($"No Data Found For This Search Criteria {vehicleResponse.SearchCriteria}");
        }
    }
}
