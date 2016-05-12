using System;
using System.IO;

namespace DigitFeatureGeneration
{
	public static class Algorithm
	{
		public static string algorithmExample (string id, string path, string number = "") 
		{
			// Read single binary file
			var binaryArray = File.ReadAllBytes(path + id);

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
			if (number.Equals("")) {
				return id + "," + string.Join(",", binaryResult);
			} 
			else
			{
				return id + "," + number + "," + string.Join(",", binaryResult);
			}
		}

		public static string algorithmAllNumber (string id, string path, string number = "") 
		{
			// Read single binary file as result
			var binaryResult = File.ReadAllBytes(path + id);

			// Convert integer array to string arry and separate by "," to make it readable as csv
			if (number.Equals("")) {
				return id + "," + string.Join(",", binaryResult);
			} 
			else
			{
				return id + "," + number + "," + string.Join(",", binaryResult);
			}
		}
	}

	public static class Constants
	{
		public const int row = 28;
		public const int column = 28;
		public const string trainReferencePath = "src/train.csv";
		public const string testReferencePath = "src/sample.csv";
		public const string trainingSetPath = "src/train/";
		public const string testSetPath = "src/test/";
		public const string exportPath = "";

		public const string algorithmExampleTrainResultFileName = "algorithm-example-train-result.csv";
		public const string algorithmExampleTestResultFileName = "algorithm-example-test-result.csv";

		public const string algorithmAllNumberTrainResultFileName = "algorithm-all-number-train-result.csv";
		public const string algorithmAllNumberTestResultFileName = "algorithm-all-number-test-result.csv";

		public static void exportHelper (string resultString, string exportFileName) 
		{
			StreamWriter file = new StreamWriter(Constants.exportPath + exportFileName);
			file.WriteLine(resultString);
			file.Close();
		}

	}

	class Program
	{
		static void Main()
		{
			// 1. Read train.csv as reference
//			String[] trainReference = File.ReadAllText(Constants.trainReferencePath).Split(',', '\n');
			String[] testReference = File.ReadAllText(Constants.testReferencePath).Split(',', '\n');

			// 2. Apply different algorithms to generate features
			// Note: Original test score is -2.302585

			/* 
			 * - Example Algorithm
			 */
//			var algorithmExampleTrainResultString = "id,number,column1,column2,column3,column4,column5,column6,column7,column8,column9,column10,column11,column12,column13,column14,column15,column16,column17,column18,column19,column20,column21,column22,column23,column24,column25,column26,column27,column28,column29,column30,column31,column32,column33,column34,column35,column36,column37,column38,column39,column40,column41,column42,column43,column44,column45,column46,column47,column48,column49,column50,column51,column52,column53,column54,column55,column56";
//			var algorithmExampleTestResultString = "id,column1,column2,column3,column4,column5,column6,column7,column8,column9,column10,column11,column12,column13,column14,column15,column16,column17,column18,column19,column20,column21,column22,column23,column24,column25,column26,column27,column28,column29,column30,column31,column32,column33,column34,column35,column36,column37,column38,column39,column40,column41,column42,column43,column44,column45,column46,column47,column48,column49,column50,column51,column52,column53,column54,column55,column56";
//
//			for (var i = 0; i < trainReference.Length; i++) 
//			{
//					
//
//				if (i % 2 == 0 && i < trainReference.Length - 1) 
//				{
//					// Generating 56 features using summation for columns and rows
//					algorithmExampleTrainResultString += "\n" + Algorithm.algorithmExample (trainReference [i], Constants.trainingSetPath, trainReference [i + 1]);
//				}
//			}
//
//			for (var i = 0; i < testReference.Length; i++) 
//			{
//
//				if (i % 11 == 0 && i < testReference.Length - 1) 
//				{
//					// Generating 56 features using summation for columns and rows
//					algorithmExampleTestResultString += "\n" + Algorithm.algorithmExample (testReference [i], Constants.testSetPath);
//				}
//			}

			/*
			 * - All Number Algorithm
			 */
//			var algorithmAllNumberTrainResultString = "id,number";
			var algorithmAllNumberTestResultString = "id";

			for (var i = 0; i < Constants.row * Constants.column; i++) 
			{
//				algorithmAllNumberTrainResultString += ",column" + (i + 1).ToString();
				algorithmAllNumberTestResultString += ",column" + (i + 1).ToString();
			}

//			for (var i = 0; i < trainReference.Length; i++) 
//			{
//
//
//				if (i % 2 == 0 && i < trainReference.Length - 1) 
//				{
//					// Generating 56 features using summation for columns and rows
//					algorithmAllNumberTrainResultString += "\n" + Algorithm.algorithmAllNumber (trainReference [i], Constants.trainingSetPath, trainReference [i + 1]);
//				}
//			}

			for (var i = 0; i < testReference.Length; i++) 
			{

				if (i % 11 == 0 && i < testReference.Length - 1) 
				{
					// Generating 56 features using summation for columns and rows
					algorithmAllNumberTestResultString += "\n" + Algorithm.algorithmAllNumber (testReference [i], Constants.testSetPath);
				}
			}



			// 3. Export csv files for different algorithms
//			Constants.exportHelper(algorithmExampleTrainResultString, Constants.algorithmExampleTrainResultFileName);
//			Constants.exportHelper(algorithmExampleTestResultString, Constants.algorithmExampleTestResultFileName);

//			Constants.exportHelper(algorithmAllNumberTrainResultString, Constants.algorithmAllNumberTrainResultFileName);
			Constants.exportHelper(algorithmAllNumberTestResultString, Constants.algorithmAllNumberTestResultFileName);
		}
	}
}