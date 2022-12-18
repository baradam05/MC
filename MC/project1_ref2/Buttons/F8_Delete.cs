using System;
using project1_ref2.Windows;
using project1_ref2.Buttons.Components;
using project1_ref2.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    internal class F8_Delete : DialogWindow
    {
        public PopUpWindow popUp = new PopUpWindow();
        private List<IComponents> components = new List<IComponents>();
        public int selected = 0;

        public int rowCount;
        public Dir data;

        public override string Name { get; set; } = "8.Smazat";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F8;

        public F8_Delete(MainWindow mw)
        {
            this.rowCount = mw.rowCount;
            this.data = mw.data;

            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnCancel_Clicked;

            this.components.Add(btnOk);
            this.components.Add(btnCancel);

            mw.UpdateButtonsData += UpadteData;
        }

        public void UpadteData(string path1, string path2, int rowCount, Dir data1, Dir data2)
        {
            this.rowCount = rowCount;
            this.data = data1;
        }

        public void BtnCancel_Clicked()
        {
            this.app.WindowStack.Pop();
            (this.app.WindowStack.Peek() as MainWindow).rowCount = 0;
            this.selected = 0;
        }

        public void BtnOk_Clicked()
        {
            DeleteItem();            
            this.selected = 0;
            this.app.WindowStack.Pop();
            (this.app.WindowStack.Peek() as MainWindow).rowCount = 0;
            (this.app.WindowStack.Peek() as MainWindow).RedrawData();
        }

        public void DeleteItem()
        {
            if (data.Items[this.rowCount] is ItemDirectories)
            {
                DirectoryInfo directory = new DirectoryInfo(data.Items[this.rowCount].FullName);

                foreach (FileInfo file in directory.EnumerateFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in directory.EnumerateDirectories())
                {
                    dir.Delete(true);
                }

                Directory.Delete(data.Items[this.rowCount].FullName);
            }
            else if (data.Items[this.rowCount] is ItemFiles)
                File.Delete(data.Items[this.rowCount].FullName);
        }


        public override void Draw()
        {
            if (data.Items[this.rowCount] is ItemHead)
                throw new ArgumentException("You can't delete this");

            popUp.Draw(30, 7);

            Console.SetCursorPosition(53, 14);
            Console.Write(" Deleted file: ");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60 - (data.Items[this.rowCount].Name.Length / 2), 15);
            Console.Write(data.Items[this.rowCount].Name);

            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(50, 17);
            ItemDraw(0);
            Console.Write("".PadRight(4, ' '));
            ItemDraw(1);
        }

        public void ItemDraw(int positon)
        {
            if (selected == positon)
                Console.BackgroundColor = ConsoleColor.Cyan;
            components[positon].Draw();
            Console.BackgroundColor = ConsoleColor.White;
        }

        public override void KeyHandle(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Tab)
            {
                this.selected = (this.selected + 1) % this.components.Count;
            }
            else
            {
                this.components[this.selected].HandleKey(info);
            }
        }
    }
}
