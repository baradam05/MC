using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Items
{
    public class ItemDirectories : IItems
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime LastTimeModified { get; set; }
        public long Size { get; set; }

        public ItemDirectories(DirectoryInfo info)
        {
            Name = @"/" + info.Name;
            FullName = info.FullName;
            LastTimeModified = Directory.GetLastWriteTime(info.FullName);
        }
    }
}
