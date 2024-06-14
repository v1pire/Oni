using System.Runtime.Serialization.Formatters.Binary;

namespace Oni
{
    internal class NeuronManager
    {
        public void SaveNeurons(List<Neuron> neurons, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, neurons);
            }
        }

        public List<Neuron> LoadNeurons(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Neuron>();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Neuron>)formatter.Deserialize(fs);
            }
        }
    }
}
