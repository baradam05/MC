using System;
using project1_ref2.Buttons;
using project1_ref2.Buttons.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.TextWindow
{
    public class Search : Window
    {
        public event Action<string> updateSearchValue;

        public PopUpWindow popUp = new PopUpWindow();
        public List<string> data = new List<string>();
        private List<IComponents> components = new List<IComponents>();
        public int selected = 0;
        public F4_EditText f4;

        public int tableHight;

        public Search(F4_EditText f4)
        {
            this.f4 = f4;

            if (data.Count > 30)
                tableHight = 30;
            else
                tableHight = data.Count;

            this.components.Add(new TextBox());

            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnCancel_Clicked;

            this.components.Add(btnOk);
            this.components.Add(btnCancel);
        }

        public override void Draw()
        {
            popUp.Draw(30, 7);

            Console.SetCursorPosition(53, 14);
            Console.Write(" Search: ");

            Console.SetCursorPosition(50, 16);
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
        public void BtnCancel_Clicked()
        {
            this.app.WindowStack.Pop();
        }

        public void BtnOk_Clicked()
        {
            string searchItem = (components[0] as TextBox).Value;

            while (f4.yCursor+f4.yOffset != f4.data.Count || f4.xCursor+f4.xOffset != f4.data[f4.data.Count].Length)
            {
                f4.RightArrow();
                if ((f4.xCursor + f4.xOffset) + searchItem.Length >= f4.data[f4.yCursor + f4.yOffset].Length)
                    continue;

                if (f4.data[f4.yCursor+ f4.yOffset][f4.xCursor+f4.xOffset] == searchItem[0])
                {
                    for (int i = 1; i < searchItem.Length; i++)
                    {
                        f4.RightArrow();
                        if (!(f4.data[f4.yCursor + f4.yOffset][f4.xCursor + f4.xOffset] == searchItem[i]))
                            continue;                        
                    }

                    if (f4.xCursor+searchItem.Length >= f4.tableWidth)
                    {
                        f4.xOffset += f4.xCursor + searchItem.Length - f4.tableWidth;
                    }

                    f4.searchValue = searchItem;
                    this.app.WindowStack.Pop();
                    return;
                }                

            }    
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
