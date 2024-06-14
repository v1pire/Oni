namespace Oni
{
    internal class OutPutNeuron : Neuron
    {
        double NeedValue = 1;

        public OutPutNeuron(Layer topLayer) : base(topLayer){}

        public void SetNeedValue(float needVal) => NeedValue = needVal;

        public override void Train(Layer nextLayer)
        {
            double v = GetValue();
            foreach (WeighLink T in Weights)
            {
                double error = v - NeedValue;
                double gradient = error * v * (1 - v);
                double W_new = T.weight - Settings.errorAlfa * gradient * T.neuron.GetValue();

                T.weight = W_new;//обновляем на новый вес
            }
        }
    }
}
