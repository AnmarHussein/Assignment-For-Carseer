using Assignment_For_Carseer.Domain.Dtos;
using Assignment_For_Carseer.Extension;
using CsvHelper;
using System.Globalization;

namespace Assignment_For_Carseer.Services.CarMakes
{
    public class CarMakeService: ICarMakeService
    {
        private const bool _usingBinarySearch = true; // to apply binary search algorithm

        private readonly IWebHostEnvironment _webHostEnvironment;
        public CarMakeService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Retrieves the ID of a car make based on the provided make name from a CSV file.
        /// </summary>
        /// <param name="makeName">The name of the car make to search for.</param>
        /// <returns>
        /// The ID of the car make if found; otherwise, null.
        /// </returns>
        public long? GetMakeIdByMakeName(string makeName)
        {
            // Construct the file path of the CSV file containing car makes
            string csvFilePath = $@"{_webHostEnvironment.WebRootPath}\\CarMakerCsvFile\\CarMake.csv";

            // Configure CSV reader settings
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            // Open a stream reader to read the CSV file
            using var reader = new StreamReader(csvFilePath);

            // Create a CSV reader with the specified configuration
            using var csv = new CsvReader(reader, config);

            // Read all records from the CSV file into memory
            IEnumerable<CarMakeDto> records = csv.GetRecords<CarMakeDto>();

            // If binary search is enabled, use binary search algorithm to find make ID
            if (_usingBinarySearch)
            {
                return records.BinarySearchMakeIdByFirstChar(makeName.ToUpper());
            }
            else // Otherwise, search for the make name using LINQ
            {
                // Find the first car make with the specified name
                CarMakeDto carMakeDto =  records.FirstOrDefault(x=> x.MakeName.Equals(makeName.ToUpper()));

                // Return the ID of the found car make, or null if not found
                return carMakeDto?.MakeId;
            }
        }
    }
}
