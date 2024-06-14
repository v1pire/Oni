namespace Oni
{
    internal class InputLayer : Layer
    {

        public InputLayer(int size)
        {
            for (int i = 0; i < size; i++)
            {
                neurons.Add(new InputNeuron());
            }
        }

        public void SetData(float[] values)
        {
            for (int i = 0; i < neurons.Count; i++)
            {
                (neurons[i] as InputNeuron).SetValue(values[i]);
            }
        }

    }
}
