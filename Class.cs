using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpImplementation
{
    public class TryList 
    {
        public List<int> ?list;
        public void setList() 
        {
            list = new List<int>();
        }

        public void addValue(int value) 
        {
           list!.Add(value);
        }

        public int[] getList() 
        {
            int[] res = new int[list!.Count];
            for (int i = 0; i < list.Count; i++) 
            {
                res[i] = list[i];
            }

            return res;
        }
    }
}
