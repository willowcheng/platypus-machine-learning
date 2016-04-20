using System;
using System.IO;

namespace DigitFeatureGeneration
{
	public static class Algorithm
	{
		public static string algorithmExample (string id, string number) {
			// Read single binary file
			var binaryArray = File.ReadAllBytes(Constants.trainingSetPath + id);

			// Initial array with feature number as row + column
			int[] binaryResult = new int[Constants.row + Constants.column];

			// Loop through binary file array to get total amount for each row and column which generates binResult
			for (int i = 0; i < binaryArray.Length; i++)
			{
				if (binaryArray[i] > 0)
				{
					// Calculate total amount for single column
					binaryResult[(i % Constants.row)] += binaryArray[i];

					// Calculate total amount for signle row
					binaryResult[Constants.column + (i / Constants.row)] += binaryArray[i];
				}
			}

			// Convert integer array to string arry and separate by "," to make it readable as csv
			return id + "," + number + "," + string.Join(",", binaryResult);
		}
	}
}

