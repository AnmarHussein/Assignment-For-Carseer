namespace Assignment_For_Carseer.IntegrationVehicles.Dto
{
    public class VehicleResponse<T>
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public T Results { get; set; }
    }
}
