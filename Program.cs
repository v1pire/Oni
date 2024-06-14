namespace Oni
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1.Создаем базовую структуру
            InputLayer inputLayer = new InputLayer(3);
            HiddenLayer hiddenLayer = new HiddenLayer(3, inputLayer);
            HiddenLayer hiddenLayer2 = new HiddenLayer(5, hiddenLayer);
            OutputLayer outputLayer = new OutputLayer(1, hiddenLayer2);


            //2. Обучаем
            int epoch = 120000;
            for(int i = 0; i < epoch; i++)
            {
                inputLayer.SetData(new float[] { 1, 0, 1 });
                outputLayer.SetNeedValues(new float[] { 1 });

                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                /// /// ///

                inputLayer.SetData(new float[] { 0, 0, 0 });
                outputLayer.SetNeedValues(new float[] { 0 });

          
                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                // // // // //
                
                inputLayer.SetData(new float[] { 1, 1, 0 });
                outputLayer.SetNeedValues(new float[] { 1 });

                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                // // //
                
                inputLayer.SetData(new float[] { 1, 1, 1 });
                outputLayer.SetNeedValues(new float[] { 1 });


                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                /// /// ///
                
                inputLayer.SetData(new float[] { 2, 3, 5 });
                outputLayer.SetNeedValues(new float[] { 1 });


                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                /// /// ///

                inputLayer.SetData(new float[] { 2, 0, 5 });
                outputLayer.SetNeedValues(new float[] { 0 });


                outputLayer.Train();
                hiddenLayer2.Train(outputLayer);
                hiddenLayer.Train(hiddenLayer2);
                /// /// ///
            }

            //3. Тест
            inputLayer.SetData(new float[] { 0, 1, 0 });
            Console.WriteLine(" 1: " + outputLayer.neurons[0].GetValue());
            inputLayer.SetData(new float[] { 0, 0, 1 });
            Console.WriteLine(" 1: " + outputLayer.neurons[0].GetValue());
            inputLayer.SetData(new float[] { 0, 0, 0 });
            Console.WriteLine(" 0: " + outputLayer.neurons[0].GetValue());
        }

    }
}