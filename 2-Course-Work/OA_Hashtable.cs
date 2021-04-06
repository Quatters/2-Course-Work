using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Hashtable
{
    public class OA_Hashtable<T>
    {
        private T[] hashtable;
        private int size;
        public OA_Hashtable(int size = 100)
        {
            this.size = size;
            hashtable = new T[size];
        }
    }
}
