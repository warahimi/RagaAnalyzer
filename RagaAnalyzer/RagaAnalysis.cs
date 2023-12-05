using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagaAnalyzer
{
    internal class RagaAnalysis
    {
        // Function to analyze the notes of a Raga with missing notes handled
        public int[] AnalyzeRagaNotes(string ragaNotesString)
        {
            // The full set of notes in order
            List<string>[] fullNotes = {
            new List<string> { "S"},
            new List<string> { "R₁", "R₂", "R₃" },
            new List<string> {"G₁", "G₂", "G₃" },
            new List<string> {"M₁", "M₂", "M₃" },
            new List<string> {"P" },
            new List<string> {"D₁", "D₂", "D₃"},
            new List<string> {"N₁", "N₂", "N₃" }
        };

            List<string> processedNotes = new List<string>();

            // Split the input string into an array of notes
            string[] inputNotes = ragaNotesString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate over the full set of notes
            foreach (var noteGroup in fullNotes)
            {
                // Check if any note from the group is in the input notes
                var foundNote = noteGroup.FirstOrDefault(note => inputNotes.Contains(note));

                if (foundNote != null)
                {
                    // Add the found note to processedNotes
                    processedNotes.Add(foundNote);
                }
                else
                {
                    // If the note group is missing, add " x "
                    processedNotes.Add(" x ");
                }
            }

            // Now analyze the notes with the missing notes handled
            int[] noteAnalysis = new int[processedNotes.Count];

            for (int i = 0; i < processedNotes.Count; i++)
            {
                switch (processedNotes[i])
                {
                    case "S":
                    case "R₁":
                    case "G₁":
                    case "M₁":
                    case "P":
                    case "D₁":
                    case "N₁":
                        noteAnalysis[i] = 1; // Basic form of the note
                        break;
                    case "R₂":
                    case "G₂":
                    case "M₂":
                    case "D₂":
                    case "N₂":
                        noteAnalysis[i] = 2; // Higher variant of the note
                        break;
                    case "R₃":
                    case "G₃":
                    case "M₃":
                    case "D₃":
                    case "N₃":
                        noteAnalysis[i] = 3; // Even higher variant of the note
                        break;
                    default:
                        noteAnalysis[i] = 0; // Note is absent
                        break;
                }
            }

            return noteAnalysis;
        }
    }
}
