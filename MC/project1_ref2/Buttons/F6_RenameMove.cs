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
    internal class F6_RenameMove : DialogWindow
    {
        public PopUpWindow popUp = new PopUpWindow();
        private List<IComponents> components = new List<IComponents>();
        public int selected = 0;

        public string path1;
        public string path2;

        public int rowCount;
        public Dir data1;
        public Dir data2;

        public override string Name { get; set; } = "6.Přej / přes";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F6;
        public F6_RenameMove(MainWindow mw)
        {
            this.path1 = mw.path1;
            this.path2 = mw.path2;
            this.rowCount = mw.rowCount;
            this.data1 = mw.data1;
            this.data2 = mw.data2;

            this.components.Add(new TextBox());

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
            this.path1 = path1;
            this.path2 = path2;
            this.rowCount = rowCount;
            this.data1 = data1;
            this.data2 = data2;
        }

        public void BtnCancel_Clicked()
        {
            this.app.WindowStack.Pop();
            (components[0] as TextBox).Value = "";
            (this.app.WindowStack.Peek() as MainWindow).rowCount = 0;
            this.selected = 0;
        }

        public void BtnOk_Clicked()
        {
            MoveData();
            this.selected = 0;
            (components[0] as TextBox).Value = "";
            this.app.WindowStack.Pop();
            (this.app.WindowStack.Peek() as MainWindow).rowCount = 0;
            (this.app.WindowStack.Peek() as MainWindow).RedrawData();
        }

        public void MoveData()
        {
            string input = (components[0] as TextBox).Value;

            if (data1.Items[this.rowCount] is ItemDirectories)
            {
                DirectoryInfo directory = new DirectoryInfo(this.data1.Items[rowCount].FullName);
                directory.MoveTo(path2 + @"\" + input);

            }
            else if (data1.Items[this.rowCount] is ItemFiles)
            {
                FileInfo file = new FileInfo(this.data1.Items[rowCount].FullName);
                file.MoveTo(path2 + @"\" + data1.Items[this.rowCount].Name);
            }
        }


        public override void Draw()
        {
            if (data1.Items[this.rowCount] is ItemHead)
                throw new Exception("You can't copy this");

            popUp.Draw(30, 7);

            Console.SetCursorPosition(45, 12);
            Console.Write(path2 + @"\" + data1.Items[this.rowCount].Name);

            Console.SetCursorPosition(45, 13);
            Console.Write(" is moved to:");

            Console.SetCursorPosition(45, 15);
            Console.Write(path2 + @"\");

            Console.SetCursorPosition(45, 16);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(" ".PadRight(20, ' '));
            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(45, 16);
            ItemDraw(0);
            Console.SetCursorPosition(50, 17);
            ItemDraw(1);
            Console.Write("".PadRight(4, ' '));
            ItemDraw(2);
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
