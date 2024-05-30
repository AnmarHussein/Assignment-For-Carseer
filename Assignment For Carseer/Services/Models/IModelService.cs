using Assignment_For_Carseer.Domain;

namespace Assignment_For_Carseer.Services.Models
{
    public interface IModelService
    {
        Task<Response<List<string>>> GetModels(int modelYear, string makeName);
    }
}
