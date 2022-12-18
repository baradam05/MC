using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.TextWindow
{
    public class ReadData
    {
        public List<string> data;

        public void Read(string path)
        {
            data = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                int i = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    data.Add(line.ToString());
                    i++;
                }
            }
        }
    }
}
