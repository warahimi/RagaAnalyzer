using System;

namespace RagaAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RagaAnalysis ragaAnalyzer = new RagaAnalysis();

            // Raga notes input with missing notes
            string ragaNotes = "S R₂ G₃ P D₂";

            // Analyzing the raga notes
            int[] analysisResult = ragaAnalyzer.AnalyzeRagaNotes(ragaNotes);

            // Displaying the analysis result
            Console.WriteLine("Raga Notes Analysis:");
            Console.Write("[");
            for(int i = 0; i < analysisResult.Length; i++)
            {
                if(i == analysisResult.Length - 1)
                {
                    Console.Write(analysisResult[i]);
                }
                else
                {
                    Console.Write(analysisResult[i] +", ");
                }
            }
            Console.Write("]");

        }
    }
}