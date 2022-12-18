using project1_ref2.Items;
using project1_ref2.Windows;
using project1_ref2.Buttons.Components;

namespace project1_ref2.Buttons
{
    internal class F5_cOPY : DialogWindow
    {
        public PopUpWindow popUp = new PopUpWindow();
        private List<IComponents> components = new List<IComponents>();
        public int selected = 0;

        public string path1;
        public string path2;

        public int rowCount;
        public Dir data1;
        public Dir data2;

        public override string Name { get; set; } = "5.Kopie";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F5;

        public F5_cOPY(MainWindow mw)
        {
            this.path1 = mw.path1;
            this.path2 = mw.path2;
            this.rowCount = mw.rowCount;
            this.data1 = mw.data1;
            this.data2 = mw.data2;

            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnCancel_Clicked;

            this.components.Add(btnOk);
            this.components.Add(btnCancel);
            mw.UpdateButtonsData += UpadteData;
        }

        public void UpadteData(string path1,string path2,int rowCount,Dir data1,Dir data2)
        {
            this.path1 = path1;
            this.path2 = path2;
            this.rowCount = rowCount;
            this.data1 = data1;
            this.data2 = data2;
        }        

        private void BtnCancel_Clicked()
        {
            this.app.WindowStack.Pop();
            this.selected = 0;
        }

        private void BtnOk_Clicked()
        {
            CopyData();
            this.app.WindowStack.Pop();
            this.selected = 0;
            (this.app.WindowStack.Peek() as MainWindow).RedrawData();
        }

        public void CopyData()
        {
            if (data1.Items[this.rowCount] is ItemDirectories)
                Directory.CreateDirectory(path2 + @"\" + data1.Items[this.rowCount].Name);
            else if (data1.Items[this.rowCount] is ItemFiles)
                File.Create(path2 + @"\" + data1.Items[this.rowCount].Name);
        }

        public override void Draw()
        {
            popUp.Draw(30, 7);

            if (this.path1 == this.path2)
                throw new Exception("Paths are same");
            if (data1.Items[this.rowCount] is ItemHead)
                throw new Exception("You can't copy this");

            Console.SetCursorPosition(59 - ((data1.Items[this.rowCount].Name.Length + 17) / 2), 12);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("'" + this.data1.Items[rowCount].Name + "'");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" is copiead to:");

            Console.SetCursorPosition(45, 15);
            Console.Write(path2 + @"\" + data1.Items[this.rowCount].Name);

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
