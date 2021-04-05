using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Back;


namespace CarAndGo.Encog
{
    public class Neural_Network
    {

        public static double Encog_Neural(double CarPrice)
        {
            double[][] x =
            {
                new double[]{0.0, CarPrice},
            };

            double[][] y =
            {
                new double[]{1.0}
            };

            //////////CREATE NETWORK/////////
            BasicNetwork network = new BasicNetwork();
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 5));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 1));
            network.Structure.FinalizeStructure();
            network.Reset();

            IMLDataSet dataset = new BasicMLDataSet(x, y);

            ITrain learner = new Backpropagation(network, dataset);

            for (int i = 0; i < 100; i++)
            {
                learner.Iteration();
            }

            //// Testing /////
            foreach (BasicMLDataPair pair in dataset)
            {
                IMLData neuralResult = network.Compute(pair.Input);

                // Divided Cost by result
                var priceResult = CarPrice / neuralResult[0];

                return priceResult;
            }
            return 0;
        }
    }
}
