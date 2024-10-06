using System.Diagnostics;

namespace Oni
{
    internal class Program
    {
        //1.Создаем базовую структуру
        static InputLayer inputLayer;
        static HiddenLayer hiddenLayer;
        static HiddenLayer hiddenLayer2;
        static OutputLayer outputLayer;

        public static void Main(string[] args)
        {
            //1.Создаем базовую структуру
            inputLayer = new InputLayer(3);
            hiddenLayer = new HiddenLayer(5, inputLayer);
            hiddenLayer2 = new HiddenLayer(5, hiddenLayer);
            outputLayer = new OutputLayer(1, hiddenLayer2);

            Stopwatch stopwatch = new Stopwatch();

            // Запуск таймера
            stopwatch.Start();
            ////
            Train(100000);
            // Остановка таймера
            stopwatch.Stop();

            // Вывод времени выполнения в миллисекундах
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            ///

            Test();//3. Тест
        }

        private static void Test()
        {
            inputLayer.SetData(new float[] { 0, 1, 0 });
            Console.WriteLine(" 1: " + outputLayer.neurons[0].GetValue());
            inputLayer.SetData(new float[] { 0, 0, 1 });
            Console.WriteLine(" 1: " + outputLayer.neurons[0].GetValue());
            inputLayer.SetData(new float[] { 0, 0, 0 });
            Console.WriteLine(" 0: " + outputLayer.neurons[0].GetValue());

        }

        private static void TrainIteration(float[] inputData, float[] targetValues)
        {
            inputLayer.SetData(inputData);
            outputLayer.SetNeedValues(targetValues);

            outputLayer.Train();
            hiddenLayer2.Train(outputLayer);
            hiddenLayer.Train(hiddenLayer2);
        }

        private static void Train(int epoch)
        {
            for (int i = 0; i < epoch; i++)
            {
                TrainIteration(new float[] { 1, 0, 1 }, new float[] { 1 });
                TrainIteration(new float[] { 0, 0, 0 }, new float[] { 0 });
                TrainIteration(new float[] { 1, 1, 0 }, new float[] { 1 });
                TrainIteration(new float[] { 1, 1, 1 }, new float[] { 1 });
                TrainIteration(new float[] { 2, 3, 5 }, new float[] { 1 });
                TrainIteration(new float[] { 2, 0, 5 }, new float[] { 1 });
                TrainIteration(new float[] { 1, 0, 0 }, new float[] { 1 });
                TrainIteration(new float[] { 5, 0, 0 }, new float[] { 1 });
                TrainIteration(new float[] { 0, 0, 1 }, new float[] { 1 });
            }
        }
    }
}