using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Oni
{
    internal class NeuronManager
    {
        public void SaveNeurons(List<Neuron> neurons, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(neurons);
            File.WriteAllText(filePath, jsonString);
        }

        public List<Neuron> LoadNeurons(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Neuron>();

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Neuron>>(jsonString);
        }
    }
}
