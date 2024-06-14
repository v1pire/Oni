namespace Oni
{
    internal class HiddenLayer : Layer
    {
        public HiddenLayer() { }
        public HiddenLayer(int size, Layer topLayer)
        {
            for (int i = 0; i < size; i++)
            {
                neurons.Add(new Neuron(topLayer));
            }
        }

        public void MutaionGrow()
        {
            //add new neuron	and his links
        }

        public void MutationGrowSpecial(Neuron neuron)
        {
            //add special neuron an his links
        }

        public void MutationDigradation(float power)
        {
            foreach (Neuron T in neurons)
            {
                T.RemoveNear0Weights(power);
                T.RemoveSimilarWeights(power);
            }
        }

        public void MutationCut()
        {
            int min = 999;
            Neuron cacndidateToRemove = null;
            foreach (Neuron T in neurons)
            {
                if (T.Weights.Count < min)
                {
                    min = T.Weights.Count;
                    cacndidateToRemove = T;
                }
            }
            RemoveNeuronFromList(cacndidateToRemove);
        }

        private void RemoveNeuronFromList(Neuron? cacndidateToRemove)
        {
            throw new NotImplementedException();
        }

        internal void Train(Layer nextLayer)
        {
            foreach(Neuron T in nextLayer.neurons)
            {
                T.Train(nextLayer);
            }
        }
    }
}
