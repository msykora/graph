using System;
using System.IO;
using System.Runtime.Serialization;
using DataLoader.DataService;

namespace DataLoader {
    internal class Program {
        private static void Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Incorrect input, please provide a path with xml files containing input data!");
                return;
            }
            var inputDataPath = args[0];
            Console.WriteLine($"Processing input data from directory {inputDataPath}");
            var inputFiles = Directory.GetFiles(inputDataPath);
            var serializer = new DataContractSerializer(typeof(node));
            var service = new DataServiceClient();
            var nodes = new node[inputFiles.Length];
            for (var i = 0; i < inputFiles.Length; i++)
                using (var node = File.OpenRead(inputFiles[i]))
                    nodes[i] = (node)serializer.ReadObject(node);
            Console.WriteLine($"Loaded {nodes.Length} nodes from input data. Sending to data service for storage.");
            service.Put(nodes);
            Console.WriteLine("Nodes stored, press enter to exit.");
            var readNodes = service.Get();
            Console.WriteLine($"Checked if nodes were properly stored, read {readNodes.Length} nodes from data service.");
            Console.ReadLine();
        }
    }
}