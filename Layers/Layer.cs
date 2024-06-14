namespace Oni
{
    internal class Layer
    {
        public List<Neuron> neurons = new List<Neuron>();

        public virtual void Train() => throw new NotImplementedException();

        internal void Calc()
        {
            foreach (Neuron T in neurons)
            {
                T.CalcSum();
            }
        }

    }
}
