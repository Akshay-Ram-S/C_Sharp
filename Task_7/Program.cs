using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program{
    static async Task Main(string[] args){
        List<Task<string>> tasks = new List<Task<string>>(){
            SimulateCall("Source 1", 2000),
            SimulateCall("Source 2", 1500),
            SimulateCall("Source 3", 3000),
            SimulateCall("Source 4", 1000)
        };

        try{
            // Await all tasks concurrently
            string[] results = await Task.WhenAll(tasks);

            // Aggregate results
            Console.WriteLine("Aggregated Results:");
            foreach (var result in results){
                Console.WriteLine(result);
            }
        }
        catch (Exception ex){
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task<string> SimulateCall(string sourceName, int delay){
        try{
            await Task.Delay(delay); // Simulate delay
            return $"{sourceName} data fetched in {delay} ms";
        }
        catch (Exception ex){
            Console.WriteLine($"Error from {sourceName}: {ex.Message}");
            throw; // Re-throw to be caught in Main
        }
    }
}
