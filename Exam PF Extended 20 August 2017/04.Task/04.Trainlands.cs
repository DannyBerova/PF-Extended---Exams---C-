namespace _04.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Wagon
    {
        public string Name { get; set; }

        public long Power { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<Wagon>> trains = new Dictionary<string, List<Wagon>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "It's Training Men!")
            {
                string[] currentCommand = inputLine
                    .Split(new string[] { " -> ", " : "}, StringSplitOptions.None);
                
                if (currentCommand.Length > 2)
                {
                    string trainName = currentCommand[0];
                    string wagonName = currentCommand[1];
                    long wagonPower = long.Parse(currentCommand[2]);

                    Wagon newWagon = new Wagon
                    {
                        Name = wagonName,
                        Power = wagonPower
                    };

                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new List<Wagon>();
                    }

                    trains[trainName].Add(newWagon);
                }
                else if (currentCommand.Length == 1)
                {
                    string[] equals = inputLine
                    .Split(new string[] { " = " }, StringSplitOptions.None);

                    string firstTrain = equals[0];
                    string secondTrain = equals[1];

                    if (!trains.ContainsKey(firstTrain))
                    {
                        trains[firstTrain] = new List<Wagon>();
                    }

                    List<Wagon> toAdd = trains[secondTrain];

                    trains[firstTrain].Clear();
                    trains[firstTrain].AddRange(toAdd);
                }
                else if (currentCommand.Length == 2)
                {
                    string firstTrain = currentCommand[0];
                    string secondTrain = currentCommand[1];

                    if (!trains.ContainsKey(firstTrain))
                    {
                        trains[firstTrain] = new List<Wagon>();
                    }

                    List<Wagon> toAdd = trains[secondTrain];
                    trains[firstTrain].AddRange(toAdd);
                    trains.Remove(secondTrain);
                }
                
                inputLine = Console.ReadLine();
            }

            var sortedTrains = trains
                .OrderByDescending(t => t.Value.Sum(p => p.Power))
                .ThenBy(t => t.Value.Count);

            foreach (var train in sortedTrains)
            {
                Console.WriteLine($"Train: {train.Key}");

                var wagons = train.Value;

                foreach (var wagon in wagons.OrderByDescending(w => w.Power))
                {
                    Console.WriteLine($"###{wagon.Name} - {wagon.Power}");
                }
            }
        }
    }
}