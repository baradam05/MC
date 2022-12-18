using System;
using project1_ref2.Windows;
using project1_ref2.Buttons.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    public class F7_NewItem : DialogWindow
    {
        public PopUpWindow popUp = new PopUpWindow();
        private List<IComponents> components = new List<IComponents>();

        public string path;
        public int selected = 0;


        public override string Name { get; set; } = "7.Nová složka";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F7;        

        public F7_NewItem(MainWindow mw)
        {
            this.path = mw.path1;
            this.app = mw.app;
            this.components.Add(new TextBox());

            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnCancel_Clicked;

            this.components.Add(btnOk);
            this.components.Add(btnCancel);
        }

        private void BtnCancel_Clicked()
        {
            this.app.WindowStack.Pop();
            (components[0] as TextBox).Value = "";
            this.selected = 0;
        }

        private void BtnOk_Clicked()
        {
            NewItem();
            (components[0] as TextBox).Value = "";
            this.selected = 0;
            this.app.WindowStack.Pop();
            (this.app.WindowStack.Peek() as MainWindow).RedrawData();
        }

        public void NewItem()
        {
            string input = (this.components[0] as TextBox).Value;

            if (input.ToString().Split('.').Length > 2)
                throw new ArgumentException("Invalid input");

            if (Directory.Exists(this.path + @"\" + input.Trim()))
                throw new ArgumentException("Invalid input");


            else if (input.Split('.').Length == 2)
            {
                FileStream stream = File.Create(this.path + @"\" + input.Trim());
                stream.Close();
            }

            else if (input.Split('.').Length == 1)
            {
                Directory.CreateDirectory(this.path + @"\" + input.Trim());
            }
        }

        public override void Draw()
        {
            popUp.Draw(30, 7);

            Console.SetCursorPosition(56, 14);
            Console.Write("Create:");
            Console.SetCursorPosition(49, 16);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("|                    |");
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(50, 16);
            ItemDraw(0);            
            Console.SetCursorPosition(50, 17);
            ItemDraw(1);
            Console.Write("".PadRight(4,' '));
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
