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
        
        public PointPairList Data;
        public string Name;
        

        public DataRecord(string _name)
        {
            Name = _name;
        }

        public PointPair getLastPointPair()
        {
            PointPair obj;
            lock(Data)
            {
                obj=Data[Data.Count-1];
            }
            return obj;
        }

        public PointPair getPointPairAt(int index)
        {
            PointPair obj;
            lock (Data)
            {
                if (index < Data.Count) obj = Data[index];
                else throw new Exception("Invalid index.");
            }
            return obj;
        }

        public void addPointPair(PointPair newPoint)
        {
            lock (Data)
            {
                Data.Add(newPoint);

                if (Data.Count > MAX_LENGTH) Data.RemoveAt(0);
            }
            return;
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
            lock (Data)
            {
                Data.Clear();
            }
            return;
        }

        
        
    }
}
