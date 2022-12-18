using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Items
{
    public class Dir
    {
        public string path { get; set; }

        public List<IItems> Items = new List<IItems>();


        public Dir(string path)
        {
            this.path = path;
            GetData();

        }

        public void GetData()
        {
            if (path == "")
                GetDrives();
            else
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                Items.Add(new ItemHead(path));
                GetDirData(dir);
                GetDirFiles(dir);

            }
        }

        public void GetDrives() //zjistí disky
        {
            foreach (var item in DriveInfo.GetDrives())
            {
                Items.Add(new ItemDrives(item));
            }
        }

        public void GetDirData(DirectoryInfo dir) //zjistí složky
        {
            foreach (var item in dir.GetDirectories())
            {
                Items.Add(new ItemDirectories(item));
            }
        }

        public void GetDirFiles(DirectoryInfo dir) //zjistí soubory
        {
            foreach (var item in dir.GetFiles())
            {
                Items.Add(new ItemFiles(item));
            }
        }
    }
}
