using System;
using System.Collections.Generic;
using project1_ref2.TextWindow;
using project1_ref2.Items;
using project1_ref2.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    public class F4_EditText : DialogWindow
    {
        public override string Name { get; set; } = "4.Upravit";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F4;

        public ReadData rd;
        public WriteData wd;
        public Search search;
        public List<string> data = new List<string>();

        public int xOffset = 0;
        public int yOffset = 0;

        public int xCursor = 0;
        public int yCursor = 0;

        public int tableWidth = 120;
        public int tableHight = 30;

        public bool selected = false;
        public int xStartSelected=0;
        public int yStartSelected = 0;
        public int xEndSelected = 0;
        public int yEndSelected = 0;

        public string searchValue = "";

        public bool start = true;
        public string path;

        public MainWindow mw;


        public F4_EditText(MainWindow mw)
        {
            this.mw = mw;
            this.app = mw.app;
            wd = new WriteData();
            rd = new ReadData();
            mw.UpdateTextWindowData += UpdateDataPress;
        }


        public void UpdateDataPress(Dir data1, int rowCount)
        {
            this.path = data1.Items[rowCount].FullName;

            rd.Read(this.path);
            this.data = rd.data;

            if (data.Count < tableHight)
                this.tableHight = data.Count;
        }

        public override void Draw()
        {
            consoleclear();
            for (int i = yOffset; i < yOffset + tableHight; i++)
            {
                Console.CursorVisible = false;

                Console.SetCursorPosition(0, i);
                if (data[i].Length - xOffset <= 0)
                    continue;
                else if (data[i].Length - xOffset <= tableWidth)
                {
                    Console.Write(data[i].Substring(xOffset, data[i].Length - xOffset));
                }
                else if (data[i].Length - xOffset > tableWidth)
                {
                    Console.Write(data[i].Substring(xOffset, tableWidth));
                }
            }
            //Console.SetCursorPosition(0, 28);
            //Console.Write(data.Count);
            //Console.SetCursorPosition(0, 29);
            //Console.Write(yCursor);

            DrawSelect();
            DrawSearch();

            Console.CursorVisible = true;
            Console.SetCursorPosition(xCursor, yCursor);
        }

        public override void KeyHandle(ConsoleKeyInfo info)
        {
            searchValue = "";

            if (info.Key == ConsoleKey.F10)
            {
                wd.Draw(this.data, this.path);
                consoleclear();
                this.app.WindowStack.Pop();
            }
            else if (info.Key == ConsoleKey.F7)
            {
                this.app.SwitchWindow(new Search(this));
            }
            else if (info.Key == ConsoleKey.F3)
            {
                if (selected)
                {
                    if ((yStartSelected == yEndSelected && xEndSelected < xStartSelected) || (yEndSelected < yStartSelected))
                    {
                        (xStartSelected, xEndSelected) = (xEndSelected, xStartSelected);
                        (yStartSelected, yEndSelected) = (yEndSelected, yStartSelected);
                    }
                    if (xStartSelected == xEndSelected && yEndSelected == yStartSelected)
                    {
                        xStartSelected = 0;
                        yStartSelected = 0;
                        xEndSelected = 0;
                        yEndSelected = 0;
                    }

                    selected = false;
                }
                else if (!selected)
                {
                    selected = true;
                    xStartSelected = xCursor;
                    yStartSelected = yCursor;
                    xEndSelected = xCursor;
                    yEndSelected = yCursor;
                }
            }

            else if (info.Key == ConsoleKey.RightArrow)
            {
                RightArrow();
            }

            else if (info.Key == ConsoleKey.LeftArrow)
            {
                xCursor--;

                if (selected)
                {
                    xEndSelected--;
                    if (xEndSelected < 0)
                        xEndSelected++;
                }
            }

            else if (info.Key == ConsoleKey.UpArrow)
            {
                if (yCursor <= 0)
                    return;

                yCursor--;

                if (selected)
                {
                    yEndSelected--;
                }

                if (data[yCursor].Length < xCursor && data[yCursor].Length < xOffset)
                {
                    xOffset = data[yCursor].Length;
                    xCursor = data[yCursor].Length - xOffset - 1;
                }
                else if (data[yCursor].Length < xCursor)
                    xCursor = data[yCursor].Length - xOffset - 1;
            }

            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (yCursor >= data.Count - 1)
                    return;

                yCursor++;

                if (selected)
                {
                    yEndSelected++;
                }

                if (data[yCursor].Length < xCursor && data[yCursor].Length < xOffset)
                {
                    xOffset = data[yCursor].Length;
                    xCursor = data[yCursor].Length - xOffset - 1;
                }
                else if (data[yCursor].Length < xCursor)
                    xCursor = data[yCursor].Length - xOffset - 1;
            }

            else if (info.Key == ConsoleKey.Home)
            {
                xCursor = 0;
                xOffset = 0;
            }

            else if (info.Key == ConsoleKey.End)
            {
                if (data[yCursor].Length >= tableWidth)
                {
                    xOffset = data[yCursor].Length - tableWidth;
                    xCursor = tableWidth-1;
                }
                else
                    xCursor = data[yCursor].Length - 1;

            }
            else if (info.Key == ConsoleKey.PageUp)
            {
                if (yOffset > tableHight)
                {
                    yOffset = -tableHight;
                }
                else if (yOffset < tableHight && yCursor != 0)
                {
                    yOffset = 0;
                }
                else if (yCursor != 0)
                {
                    yCursor = 0;
                }
            }

            else if (info.Key == ConsoleKey.Enter)
            {
                data.Insert(yCursor + 1, "");

                data[yCursor + 1] = data[yCursor].Substring(xCursor, data[yCursor].Length - xCursor);
                data[yCursor] = data[yCursor].Substring(0, xCursor);

                xCursor = 0;
                yCursor++;


            }

            else if (info.Key == ConsoleKey.Backspace)
            {
                if (xCursor == 0 && yCursor != 0)
                {
                    xCursor = data[yCursor - 1].Length;
                    data[yCursor - 1] = data[yCursor - 1] + data[yCursor];
                    data.RemoveAt(yCursor);
                    yCursor--;
                }
                else if (xCursor != 0 && yCursor != 0)
                {
                    data[yCursor] = data[yCursor].Remove(xCursor + xOffset - 1, 1);
                    xCursor--;
                }
            }

            else
            {
                data[yCursor] = data[yCursor].Insert(xCursor, info.KeyChar.ToString());
                xCursor++;
            }

            if (!selected)
            {
                KeyHandleSelect(info);
            }

            //Horizontal offset
            if (xCursor == tableWidth)
            {
                xOffset++;
                xCursor--;
            }
            if (xCursor + xOffset == data[yCursor].Length)
            {
                xOffset--;
            }
            if (xCursor < 0)
            {
                xOffset--;
                xCursor++;
            }
            if (xOffset < 0)
            {
                xOffset++;
            }

            //Vertycal offset
            if (yCursor == yOffset - 1)
                yOffset--;

            if (yCursor == yOffset + Math.Min(30, this.data.Count))
                yOffset++;

            if(selected)
            {
                xEndSelected = xCursor;
                yEndSelected = yCursor;
            }
                
        }

        public void RightArrow()
        {
            if (xCursor + xOffset>= data[yCursor+ yOffset].Length-1)
            {
                if(data.Count >= yCursor + yOffset)
                {
                    xCursor = 0;
                    yCursor++;
                    xOffset = 0;
                }
                return;
            }

            xCursor++;

            if (selected)
            {
                xEndSelected++;
                if (xEndSelected >= data[yEndSelected].Length - 1)
                    xEndSelected--;
            }
        }

        public void KeyHandleSelect(ConsoleKeyInfo info)
        {            
            if (info.Key == ConsoleKey.F8) //delete
            {
                DeleteText();

                xCursor = xStartSelected;
                yCursor = yStartSelected;
                xStartSelected = 0;
                yStartSelected = 0;
                xEndSelected = 0;
                yEndSelected = 0;
            }

            else if (info.Key == ConsoleKey.F5) //copy
            {
                CopyText();

                xStartSelected = 0;
                yStartSelected = 0;
                xEndSelected = 0;
                yEndSelected = 0;
            }
            else if (info.Key == ConsoleKey.F6)
            {
                List<string> momentaryRows;
                momentaryRows = CopyText();
                DeleteText();

                xCursor = xEndSelected;
                yCursor = yEndSelected + momentaryRows.Count - 2 ;

                xStartSelected = 0;
                yStartSelected = 0;
                xEndSelected = 0;
                yEndSelected = 0;
            }
        }

        public List<string> CopyText()
        {
            List<string> momentaryRows = new List<string>();

            if (yStartSelected == yEndSelected)
            {
                momentaryRows.Add(data[yStartSelected].Substring(xStartSelected, xEndSelected - xStartSelected + 1));
            }
            else
            {
                momentaryRows.Add(data[yStartSelected].Substring(xStartSelected, data[yStartSelected].Length - xStartSelected));
                if (yEndSelected - yStartSelected > 1)
                {
                    for (int i = 0; i < (yEndSelected - yStartSelected - 1); i++)
                    {
                        momentaryRows.Add(data[yStartSelected + 1 + i]);
                    }
                }
                momentaryRows.Add(data[yEndSelected].Substring(0, xEndSelected + 1));
            }

            if (momentaryRows.Count > 1)
            {
                for (int i = 1; i < momentaryRows.Count; i++)
                {
                    data.Insert(yCursor + i, momentaryRows[i]);
                }
                data[yCursor + momentaryRows.Count - 1] = data[yCursor + momentaryRows.Count - 1] + data[yCursor].Substring(xCursor, data[yCursor].Length - xCursor);
                data[yCursor] = data[yCursor].Substring(0, xCursor) + momentaryRows[0];

                yCursor += momentaryRows.Count - 1;
                xCursor = momentaryRows[momentaryRows.Count - 1].Length;
            }
            else
            {
                data[yCursor] = data[yCursor].Substring(0, xCursor) +
                                momentaryRows[0] +
                                data[yCursor].Substring(xCursor, data[yCursor].Length - xCursor);

                xCursor += momentaryRows[momentaryRows.Count - 1].Length - 1;
            }
            return momentaryRows;
        }

        public void DeleteText()
        {
            data[yStartSelected] = data[yStartSelected].Substring(0, xStartSelected) +
                                       data[yEndSelected].Substring(xEndSelected + 1, data[yEndSelected].Length - xEndSelected - 1);

            if (yEndSelected - yStartSelected > 1)
            {
                for (int i = 0; i < (yEndSelected - yStartSelected - 1); i++)
                {
                    data.RemoveAt(yStartSelected + 1 + i);
                }
                data.RemoveAt(yStartSelected + 1);
            }

            else if (yEndSelected != yStartSelected)
                data.RemoveAt(yEndSelected);
        }

        public void DrawSelect()
        {
            //PODBARVENÍ

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            //Select start < end
            if ((yStartSelected == yEndSelected && xEndSelected < xStartSelected) || (yEndSelected < yStartSelected))
                DrawSelect1(xEndSelected, yEndSelected, xStartSelected, yStartSelected);

            //Select end < start
            else
                DrawSelect1(xStartSelected,yStartSelected,xEndSelected,yEndSelected);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            //BAREVNÝ START A END

            Console.SetCursorPosition(xStartSelected, yStartSelected);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(data[yStartSelected].Substring(xStartSelected, 1));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(xEndSelected, yEndSelected);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            if (data[yCursor] == "")
                Console.WriteLine(" ");
            else
                Console.WriteLine(data[yEndSelected].Substring(xEndSelected, 1));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawSelect1(int xStarting,int yStarting,int xEnding, int yEnding)
        {
            if (yStarting == yEnding)
            {
                Console.SetCursorPosition(xStarting, yStarting);
                Console.WriteLine(data[yStarting].Substring(xStarting, xEnding - xStarting+1));

            }
            else
            {
                Console.SetCursorPosition(xStarting, yStarting);
                if (data[yStarting].Length - 1 < 120)
                    Console.WriteLine(data[yStarting].Substring(xStarting, data[yStarting].Length - 1 - xStarting));
                else if (data[yStarting].Length - 1 >= 120)
                    Console.WriteLine(data[yStarting].Substring(xStarting, 120 - xStarting));
                
                if (yEnding - yStarting > 1)
                {
                    for (int i = 0; i < (yEnding - yStarting - 1); i++)
                    {
                        Console.SetCursorPosition(0, yStarting + 1 + i);
                        if (data[yStarting + i + 1].Length >= 120)
                            Console.WriteLine(data[yStarting + i + 1].Substring(0, 120));
                        else if (data[yStarting + i + 1].Length < 120)
                            Console.WriteLine(data[yStarting + i + 1].Substring(0, data[yStarting + 1 + i].Length));
                        else
                            continue;
                    }
                }
                if (data[yEnding].Length != 0)
                {
                    Console.SetCursorPosition(0, yEnding);
                    Console.WriteLine(data[yEnding].Substring(0, xEnding + 1));
                }                
            }
        }

        public void UpdateSearchValue(string Value)
        {
            this.searchValue = Value;
        }

        public void DrawSearch()
        {
            if (searchValue == "")
                return;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            //Console.SetCursorPosition(xCursor, yCursor);
            Console.Write(searchValue);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void consoleclear()
        {
            Console.BackgroundColor = ConsoleColor.Black    ;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("".PadRight(120, ' '));
            }
        }
    }
}
