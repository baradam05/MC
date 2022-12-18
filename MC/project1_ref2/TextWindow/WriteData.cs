using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.TextWindow
{
    public class WriteData
    {
        public void Draw(List<string> data,string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sw.WriteLine(data[i]);
                }
            }
        
                    
        }
    }
}
