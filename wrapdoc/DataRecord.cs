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
        public PointPairList  Data;
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
            }
            return;
        }

        public static double getXDateNow()
        {
            return (double)(new XDate(DateTime.Now));
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
