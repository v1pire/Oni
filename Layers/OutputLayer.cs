namespace Oni
{
    internal class OutputLayer : Layer
    {
       

        public OutputLayer(int size, Layer prevLayer)
        {
            for (int i = 0; i < size; i++)
            {
                neurons.Add(new OutPutNeuron(prevLayer));
            }
        }

        public override void Train()
        {
            foreach (OutPutNeuron T in neurons)
            {
                T.Train(null);
            }
        }

        internal void SetNeedValues(float[] values)
        {
            for (int i = 0; i < neurons.Count; i++)
            {
                OutPutNeuron T = (OutPutNeuron)neurons[i];
                T.SetNeedValue(values[i]);
            }
        }
    }
}
