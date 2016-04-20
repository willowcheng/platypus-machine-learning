using System;
using System.IO;

namespace DigitFeatureGeneration
{

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
			string algorithmExampleResultString = "";

			for (int i = 0; i < trainReference.Length; i++) {
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