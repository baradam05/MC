using System;
using project1_ref2.Buttons;
using project1_ref2.Buttons.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Windows
{
    internal class ErrorWindow : Window
    {
        private List<IComponents> components = new List<IComponents>();

        public string Text = "error";
        public int selected;

        public ErrorWindow()
        {
            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnCancel_Clicked;

            this.components.Add(btnOk);
            this.components.Add(btnCancel);
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            int SPwidth = 60 - (30 / 2);
            int SPheight = 16 - (7 / 2);

            Console.SetCursorPosition(SPwidth, SPheight);
            Console.Write("┌".PadRight(30 - 1, '─') + "┐");
            for (int i = 1; i < 7 - 2; i++)
            {
                Console.SetCursorPosition(SPwidth, SPheight + i); ;
                Console.Write("│".PadRight(30 - 1, ' ') + "│");
            }
            Console.SetCursorPosition(SPwidth, SPheight + 7 - 2);
            Console.Write("└".PadRight(30 - 1, '─') + "┘");

            Console.SetCursorPosition(56, 14);
            Console.Write(Text);
            
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

        private void BtnCancel_Clicked()
        {
            this.selected = 0;
            this.app.WindowStack.Pop();
        }

        private void BtnOk_Clicked()
        {
            this.selected = 0;
            this.app.WindowStack.Pop();
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
