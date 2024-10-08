﻿namespace Oni
{
    [Serializable]
    internal class Neuron
    {
        public List<WeighLink> Weights = new List<WeighLink>();
        protected double sum_buf;

        public Neuron() { }
        public Neuron(Layer topLayer)
        {
            Random rnd = new Random();
            for (int i = 0; i < topLayer.neurons.Count; i++)
            {
                Neuron neuron = topLayer.neurons[i];
                Weights.Add(new WeighLink(neuron, rnd.NextDouble() * 2 - 1));
            }
        }

        public virtual double GetValue()//-1...1
        {
            CalcSum();
            return 1f / (1f + Math.Exp(-sum_buf));
        }

        public virtual void Train(Layer nextLayer)
        {
            double error = 0;
           
            foreach (var nextNeuron in nextLayer.neurons)
            {
                double value = nextNeuron.GetValue() * (1 - nextNeuron.GetValue());

                foreach (var link in nextNeuron.Weights)
                {
                    if (link.neuron == this)
                    {
                        error += link.weight * value * (value - link.neuron.GetValue());
                    }
                }
            }

            // // // // //
            double gradient = error * GetValue() * (1 - GetValue());
            double mult = Settings.errorAlfa * gradient;

           
            foreach (var weightLink in Weights)
            {
                weightLink.weight += mult * weightLink.neuron.GetValue();
            }
        }

        internal void RemoveNear0Weights(float power)
        {
            List<WeighLink> remove = new List<WeighLink>();
            foreach (WeighLink T in Weights)
            {
                if (Math.Abs(T.weight) < power) remove.Add(T);
            }
            foreach (WeighLink T in remove)
            {
                Weights.Remove(T);
            }
            throw new NotImplementedException();
        }

        public void CalcSum()
        {
            double sum = 0;
            foreach (WeighLink T in Weights)
            {
                sum += T.neuron.GetValue() * T.weight;
            }
            sum_buf = sum;
        }

        internal void RemoveSimilarWeights(float power)
        {
            throw new NotImplementedException();
        }
    }
}
