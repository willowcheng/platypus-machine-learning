using System;
using System.IO;

namespace DigitFeatureGeneration
{
	public static class Constants
	{
		public const int row = 28;
		public const int column = 28;
		public const string trainReferencePath = "src/train.csv";
		public const string trainingSetPath = "src/train/";
		public const string exportPath = "";

		public const string algorithmExampleResultFileName = "algorithm-example-result.csv";

		public static void exportHelper (string resultString, string exportFileName) {
			StreamWriter file = new StreamWriter(Constants.exportPath + exportFileName);
			file.WriteLine(resultString);
			file.Close();
		}

	}
}

