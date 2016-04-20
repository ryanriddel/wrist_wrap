using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using ZedGraph;

using MathNet.Numerics;

namespace wrapdoc
{
    class DataOperator
    {
        List<object> _parameterList;
        operatorFunction _operatorFunction;
        String _name;

        public delegate object operatorFunction(List<object> parameters);

        public DataOperator(operatorFunction _operator, List<object> _parameters)
        {
            _operatorFunction = _operator;
            _parameterList = _parameters;
        }

        ~DataOperator()
        {


        }

        public object doOperation()
        {
            return _operatorFunction(_parameterList);
        }

        /// <summary>
        /// Arguments: DataRecord data, Int64 numSamples
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns>Point Pair List</returns>
        static public object FFT(List<object> parameterList)
        {
            DataRecord input = (DataRecord)parameterList[0];
            Int64 numSamples = (Int64)parameterList[1];
            double sampleRate = (double)parameterList[2];
            PointPairList returnObject = new PointPairList();

            numSamples = Math.Min(numSamples, input._data.Count);
            //Real FFT transforms for odd N is twice as slow as even N;
            //when N is large changing it by 1 won't matter, so make N even.
            if (numSamples % 2 == 1) numSamples--;

            double[] fvals = MathNet.Numerics.IntegralTransforms.Fourier.FrequencyScale((int)numSamples, sampleRate);

            System.Numerics.Complex[] output = new System.Numerics.Complex[numSamples];

            for (int i = 0; i < numSamples; i++) output[i] = input._data[input._data.Count - 1 - i].getData();

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(output);

            for (int i = 0; i < numSamples; i++)
            {
                returnObject.Add(fvals[i], output[i].Magnitude);
            }

            return returnObject;
        }

        /// <summary>
        /// Arguments: DataRecord data, Int64 numberOfBackSamples
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns>(double) The filtered output value for the most recent sample</returns>
        static public object MovingAverageLowPassFilter(List<object> parameterList)
        {
            DataRecord input = (DataRecord)parameterList[0];
            Int64 numSamples = (Int64)parameterList[1];

            double movingAverage = calculateMean(input._data, numSamples);

            return input._data[input._data.Count - 1].getData() - movingAverage;

        }

        static double calculateMean(List<DataPoint> data, Int64 numSamples)
        {
            double sum = 0;
            numSamples = Math.Min(numSamples, data.Count);

            for (int i = 0; i < numSamples; i++) sum += data[data.Count - i - 1].getData();

            return sum / numSamples;
        }



    }
}
