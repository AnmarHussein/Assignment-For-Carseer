using Assignment_For_Carseer.Domain.Dtos;

namespace Assignment_For_Carseer.Extension
{
    public static class Extensions
    {
        /// <summary>
        /// Searches for a car make in a sorted list based on the first character of the make name using binary search.
        /// </summary>
        /// <param name="carMakers">The sorted list of car makes to search.</param>
        /// <param name="makeName">The name of the car make to search for.</param>
        /// <returns>
        /// The ID of the car make if found; otherwise, null.
        /// </returns>
        public static long? BinarySearchMakeIdByFirstChar(this IEnumerable<CarMakeDto> carMakers, string makeName)
        {
            // Convert the IEnumerable to a list for efficient access
            List<CarMakeDto> carMakeList = carMakers.ToList();
            int leftIndex = 0;
            int rightIndex = carMakeList.Count - 1;

            // Perform binary search on the sorted list
            while (leftIndex <= rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
                string middleItem = carMakeList[middleIndex]?.MakeName;

                // Compare based on the first character of the strings
                int comparisonResult = string.Compare(middleItem[0].ToString(), makeName[0].ToString(), StringComparison.OrdinalIgnoreCase);

                if (comparisonResult == 0)
                {
                    // If first characters match, compare entire strings
                    comparisonResult = string.Compare(middleItem, makeName, StringComparison.OrdinalIgnoreCase);
                }

                if (comparisonResult == 0)
                {
                    return carMakeList[middleIndex]?.MakeId; // Found
                }
                else if (comparisonResult < 0)
                {
                    leftIndex = middleIndex + 1; // Search in the right half
                }
                else
                {
                    rightIndex = middleIndex - 1; // Search in the left half
                }
            }

            return null; // Not found
        }
    }
}
