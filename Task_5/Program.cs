using System;
using System.IO;

class FileProcessor{
    static void Main(string[] args){
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        try{
            // Check if the input file exists
            if (!File.Exists(inputFile)){
                throw new FileNotFoundException("The input file was not found", inputFile);
            }

            // Read all lines from the input file
            string[] lines = File.ReadAllLines(inputFile);

            int lineCount = lines.Length;
            int wordCount = 0;

            // Count words in each line
            foreach (string line in lines){
                wordCount += line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }

            // Write the results to the output file
            using (StreamWriter writer = new StreamWriter(outputFile)){
                writer.WriteLine($"Total Lines: {lineCount}");
                writer.WriteLine($"Total Words: {wordCount}");
            }

            Console.WriteLine("Processing complete");
        }
        catch (FileNotFoundException ex){
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (IOException ex){
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex){
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
