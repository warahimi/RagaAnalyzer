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
            new List<string> { "R1", "R2", "R3" },
            new List<string> {"G1", "G2", "G3" },
            new List<string> {"M1", "M2", "M3" },
            new List<string> {"P" },
            new List<string> {"D1", "D2", "D3"},
            new List<string> {"N1", "N2", "N3" }
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
                    case "R1":
                    case "G1":
                    case "M1":
                    case "P":
                    case "D1":
                    case "N1":
                        noteAnalysis[i] = 1; // Basic form of the note
                        break;
                    case "R2":
                    case "G2":
                    case "M2":
                    case "D2":
                    case "N2":
                        noteAnalysis[i] = 2; // Higher variant of the note
                        break;
                    case "R3":
                    case "G3":
                    case "M3":
                    case "D3":
                    case "N3":
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
