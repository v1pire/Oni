namespace Oni
{
    internal class InputNeuron : Neuron
    {
        public InputNeuron() : base()
        {
        }


        public void SetValue(double value) => sum_buf = value;

        public override double GetValue() => sum_buf;
    }
}
