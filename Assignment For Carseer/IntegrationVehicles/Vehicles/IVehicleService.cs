using Assignment_For_Carseer.Domain;

namespace Assignment_For_Carseer.Integration.Vehicles
{
    public interface IVehicleService
    {
        Task<Response<List<string>>> GetModelsForMakeIdYear(long makeId, long makeYear);
    }
}
