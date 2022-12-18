using project1_ref2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Windows
{
    public class Table
    {
        public Dir data;
        public event Action<Table> EnterPressed;
        public event Action ArrowPressed;
        public string path = "";
        public int rowCount = 0;
        public bool tableSelcted = true;
        public string selectedData = "";
        public int CursorP;
        public int i;
        public int offset = 0;

        public Table(string Path, Dir Data, int cursorP)
        {
            offset = 0;
            path = Path;
            data = Data;
            CursorP = cursorP;
        }

        public void Draw()
        {
            DrawHead();
            DrawBody();
            DrawBottom();
        }

        public void DrawHead()
        {
            string thispath = this.path;
            if (this.path.Length > 57)
                thispath = this.path.Substring(0, 53) + "...";

            //hlavička tablu
            Console.SetCursorPosition(this.CursorP, 1);
            Console.Write("┌<─");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(thispath);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".[^]>┐".PadLeft(57 - thispath.Length, '─'));

            Console.SetCursorPosition(CursorP, 2);
            Console.Write('│');
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("NAME".PadRight(28, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('│');
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("SIZE".PadRight(9, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('│');
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("MODIFY TIME".PadRight(19, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('│');
        }

        public void DrawBody()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(CursorP, i + 3);

                if (i + offset < data.Items.Count) //pokud je pocet dat > velikosti mc
                {
                    if (i + offset == rowCount && tableSelcted)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }

                    string name =data.Items[i + offset].Name;
                    string size = data.Items[i + offset].Size.ToString();
                    string lng = data.Items[i + offset].LastTimeModified.ToString();

                    if (name.Length > 24)
                        name = name.Substring(0, 25) + " ..";

                    if (size.Length > 5)
                        size = size.Substring(0, 5) + "..";

                    size = size + " B";

                    //├──────────────────────────────────────────────────┤
                    //┤ name            ┤ size  ┤ modify time            ┤
                    //1 (1,4,12)} 17    1(1,4,1)1 (1,11,12) }24          1 - 51

                    Console.Write('│');
                    Console.Write(name.PadRight(28, ' '));
                    Console.Write('│');
                    Console.Write(size.PadRight(9, ' '));
                    Console.Write('│');
                    Console.Write(lng.PadRight(19, ' '));
                    Console.Write('│');

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else // pokud je mene dat nez delka mc
                {
                    Console.Write("│".PadRight(29, ' '));
                    Console.Write("│".PadRight(10, ' '));
                    Console.Write("│".PadRight(20, ' ') + '│');
                }
            }
        }

        public void DrawBottom()
        {
            Console.SetCursorPosition(CursorP, 23);
            Console.Write("├".PadRight(59, '─') + '┤');

            Console.SetCursorPosition(CursorP, 24);
            Console.Write('│' + selectedData.PadRight(58, ' ') + '│');

            Console.SetCursorPosition(CursorP, 25);
            Console.Write("└".PadRight(59, '─') + '┘');
        }

        public void Keyhandle(ConsoleKeyInfo info)
        {
            if (tableSelcted)
            {
                if (info.Key == ConsoleKey.DownArrow)
                {
                    if(rowCount != data.Items.Count - 1)
                        rowCount++;
                    if (rowCount == offset + 20)
                        offset++;
                    ArrowPressed.Invoke();
                }

                if (info.Key == ConsoleKey.UpArrow)
                {
                    rowCount--;
                    if (rowCount == offset - 1)
                        offset--;
                    ArrowPressed.Invoke();
                }

                if (info.Key == ConsoleKey.Enter)
                    EnterPressed.Invoke(this);

                 if (offset < 0)
                    offset = 0;

                if (rowCount <= 0)
                    rowCount = 0;

                if (rowCount > data.Items.Count - 1)
                {
                    rowCount = data.Items.Count - 1;
                }

                selectedData = data.Items[rowCount].Name;
            }
        }

    }
}
