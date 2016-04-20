using System;
using System.IO;

namespace DigitFeatureGeneration
{
	public static class Algorithm
	{
		public static string algorithmExample (string id, string number) 
		{
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

	public static class Constants
	{
		public const int row = 28;
		public const int column = 28;
		public const string trainReferencePath = "src/train.csv";
		public const string trainingSetPath = "src/train/";
		public const string exportPath = "";

		public const string algorithmExampleResultFileName = "algorithm-example-result.csv";

		public static void exportHelper (string resultString, string exportFileName) 
		{
			StreamWriter file = new StreamWriter(Constants.exportPath + exportFileName);
			file.WriteLine(resultString);
			file.Close();
		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			// 1. Read train.csv as reference
			String[] trainReference = File.ReadAllText(Constants.trainReferencePath).Split(',', '\n');

			// 2. Apply different algorithms to generate features
			// Note: Original test score is -2.302585

			/* 
			 * - Example algorithm
			 */
			var algorithmExampleResultString = "";

			for (var i = 0; i < trainReference.Length; i++) 
			{
				if (i % 2 == 0 && i < trainReference.Length - 1) {
					// Generating 56 features using summation for columns and rows
					algorithmExampleResultString += Algorithm.algorithmExample (trainReference [i], trainReference [i + 1]) + "\n";
				}
			}

			// 3. Export csv files for different algorithms
			Constants.exportHelper(algorithmExampleResultString, Constants.algorithmExampleResultFileName);
		}
	}
}