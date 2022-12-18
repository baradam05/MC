using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Items
{
    internal class ItemHead :IItems
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime LastTimeModified { get; set; }
        public long Size { get; set; }

        public ItemHead(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            this.Name = "/..";
            this.FullName = Convert.ToString(dir.Parent);
                
        }
    }
}
