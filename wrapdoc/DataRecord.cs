using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZedGraph;

namespace wrapdoc
{
    public class DataRecord
    {
        public static UInt32 MAX_LENGTH = 1000;
        
        /*   Naming convention:
         *   ADC records are named "Channel N"
         *   Operator records are named "{Operation Name} N", where N is the Nth operation of that kind
         *   Serial input is the name of the port i.e. "COM4"
         * */

        public string  _name;
        public List<DataPoint> _data;

        public DataRecord(string name)
        {
            _name = name;
        }

        public PointPair getLastPointPair(byte channel=0)
        {
            PointPair obj;
            lock (_data)
            {
                obj = new PointPair(_data[_data.Count - 1].getTimeStamp(), _data[_data.Count - 1].getData(channel));
            }
            return obj;
        }

        public PointPair getPointPairAt(int index, byte channel=0)
        {
            PointPair obj;
            lock (_data)
            {
                if (index < _data.Count) obj = new PointPair(_data[index].getTimeStamp(), _data[index].getData(channel));
                else throw new Exception("Invalid index.");
            }
            return obj;
        }

        public void addDataPoint(DataPoint dataPoint)
        {
            lock (_data)
            {
                _data.Add(dataPoint);

                if (_data.Count > MAX_LENGTH) _data.RemoveAt(0);
            }
            return;
        }

        public DataPoint getDataPoint(int index)
        {
            //a test to see if we need locking
            return _data[index].getDataPoint();
        }

        public static double getXDateNow()
        {
            return (double)(new XDate(DateTime.Now));
        }

        public static double getXDateMillisecondsAgo(int milliseconds)
        {
            DateTime tempTime = DateTime.Now;
            tempTime.Subtract(new TimeSpan(0, 0, 0, 0, milliseconds));

            return (double)(new XDate(tempTime));
        }

        public void clearRecord()
        {
            lock (_data)
            {
                _data.Clear();
            }
            return;
        }

        //add an "onupdate" event

        
    }

    public class DataPoint
    {
        double _timestamp;

        UInt16[] _data;

        public DataPoint(double timestamp)
        {
            _timestamp = timestamp;
            _data=new UInt16[16];
        }

        public void setData(UInt16 data, byte channel=0)
        {
            _data[channel]=data;
        }

        public UInt16 getData(byte channel=0)
        {
            return _data[channel];
        }

        public DataPoint getDataPoint()
        {
            return this;
        }

        public double getTimeStamp()
        {
            return _timestamp;
        }

        public void setTimestamp(double timestamp)
        {
            _timestamp = timestamp;
        }
    }
}
