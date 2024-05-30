using Assignment_For_Carseer.IntegrationVehicles.Dto;
using Refit;

namespace Assignment_For_Carseer.Integration
{
    public interface IVehicleApi
    {
        [Get("/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelyear}?format=json")]
        Task<VehicleResponse<List<VehicleDto>>> GetModelsForMakeIdYear([AliasAs("makeId")] long makeId, [AliasAs("modelyear")] long modelYear);
    }
}
