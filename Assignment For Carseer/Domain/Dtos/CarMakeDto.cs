using CsvHelper.Configuration.Attributes;

namespace Assignment_For_Carseer.Domain.Dtos
{
    public class CarMakeDto
    {
        [Index(0)]
        public long MakeId { get; set; }

        [Index(1)]
        public string MakeName { get; set; }
    }
}
