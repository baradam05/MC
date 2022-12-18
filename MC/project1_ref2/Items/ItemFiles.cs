using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Items
{
    public class ItemFiles : IItems
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime LastTimeModified { get; set; }
        public long Size { get; set; }


        public ItemFiles(FileInfo info)
        {
            this.Name = info.Name;
            this.FullName = info.FullName;
            this.LastTimeModified = Directory.GetLastWriteTime(info.FullName);
            this.Size = info.Length;
        }
    }
}
