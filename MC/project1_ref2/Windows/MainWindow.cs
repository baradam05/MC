using project1_ref2.Buttons;
using project1_ref2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Windows
{
    public class MainWindow : Window
    {
        public event Action<string,string,int,Dir,Dir> UpdateButtonsData;
        public event Action<Dir,int> UpdateTextWindowData;

        public List<DialogWindow> buttons = new List<DialogWindow>();

        public List<ConsoleKey> buttonskey = new List<ConsoleKey>() { ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10 };

        public Dir data;
        public Dir data1;
        public Dir data2;

        public Table table1;
        public Table table2;    

        public string path = @"C:\Users\Uzivatel\OneDrive\Plocha\00000-testProjekt1";
        public string path1;
        public string path2;
        public int rowCount;


        // ─ │ ┌ ┐ └ ┘ ├ ┤ ┬ ┴

        public MainWindow()
        {
            data = new Dir(path);
            data1 = data;
            data2 = data;
            table1 = new Table(path, data1, 0);
            table2 = new Table(path, data2, 60);
            this.path1 = path;
            this.path2 = path;

            CreateButtons();

            table1.EnterPressed += KeyHandleEnter;
            table2.EnterPressed += KeyHandleEnter;
            table1.ArrowPressed += UpdateData;
            table2.ArrowPressed += UpdateData;

            table2.tableSelcted = false;
        }

        public override void Draw()
        {
            DrawHead();
            Console.BackgroundColor = ConsoleColor.Blue;
            table1.Draw();
            table2.Draw();

            Console.SetCursorPosition(0, 28);
            Console.Write("".PadRight(120,' '));
            Console.SetCursorPosition(0, 28);
            Console.Write((buttons[3] as F4_EditText).path);
            //Console.SetCursorPosition(0, 29);
        }

        public void RedrawData()
        {
            table1.rowCount = 0;
            table1.data = new Dir(table1.path);
            table1.Draw();
            table2.rowCount = 0;
            table2.data = new Dir(table2.path);
            table2.Draw();
        }


        public override void KeyHandle(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Tab)
            {
                if (table1.tableSelcted)
                {
                    table1.tableSelcted = false;
                    table2.tableSelcted = true;
                }

                else if (table2.tableSelcted)
                {
                    table1.tableSelcted = true;
                    table2.tableSelcted = false;
                }
            }


            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Key == info.Key)
                {
                    if (buttons[i] is F4_EditText)
                        UpdateTextWindowData.Invoke(table1.data, table1.rowCount);

                    this.app.SwitchWindow(buttons[i]);
                }
            }

            table1.Keyhandle(info);
            table2.Keyhandle(info);
        }


        public void KeyHandleEnter(Table table) //referenční datový typ není nutno return
        {
            if(Directory.Exists(table.data.Items[table.rowCount].FullName))
            {
                table.offset = 0;
                table.path = table.data.Items[table.rowCount].FullName;
                table.data = new Dir(table.path);
                UpdateData();
            }
            else
            {
                this.app.SwitchWindow(buttons[3]);
            }
        }

        public void UpdateData()
        {
            UpdateButtonsData.Invoke(table1.path, table2.path, table1.rowCount, table1.data, table2.data);
        }


        public void CreateButtons()
        {
            buttons.Add(new F1());
            buttons.Add(new F2());
            buttons.Add(new F3());
            buttons.Add(new F4_EditText(this));
            buttons.Add(new F5_cOPY(this));
            buttons.Add(new F6_RenameMove(this));
            buttons.Add(new F7_NewItem(this));
            buttons.Add(new F8_Delete(this));
            buttons.Add(new F9());
            buttons.Add(new F10());
        }

        public void DrawHead()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;

            Console.SetCursorPosition(0, 0);
            Console.Write("  Left".PadRight(11, ' '));
            Console.Write("File".PadRight(9, ' '));
            Console.Write("Command".PadRight(12, ' '));
            Console.Write("Options".PadRight(12, ' '));
            Console.Write("Right".PadRight(76, ' '));
        }
    }
}
