namespace Oni
{
    internal class WeighLink
    {
        public Neuron neuron;
        public double weight;

        public WeighLink(Neuron neuron, double weight)
        {
            this.neuron = neuron;
            this.weight = weight;
        }
    }
}
