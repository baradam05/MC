using System;
using project1_ref2.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    internal class CreateButtons
    {
        //public List<Window> buttons = new List<Window>();
        //public event Action<string,string> UpdateData;

        //public string path1;
        //public string path2;
        //public int rowCount;

        //public Dir data1;
        //public Dir data2;

        //public F1 f1;
        //public F2 f2;
        //public F3 f3;
        //public F4 f4;
        //public F5_cOPY f5;
        //public F6_RenameMove f6 ;
        //public F7_NewItem f7;
        //public F8_Delete f8;
        //public F9 f9;
        //public F10 f10;

        //public CreateButtons(string path1,string path2, Dir data1, Dir data2,int rowCount)
        //{
        //    this.path1 = path1;
        //    this.path2 = path2;
        //    this.data1 = data1;
        //    this.data2 = data2;
        //    this.rowCount = rowCount;

        //    f1 = new F1();
        //    f2 = new F2();
        //    f3 = new F3();
        //    f4 = new F4();
        //    f5 = new F5_cOPY();
        //    f6 = new F6_RenameMove();
        //    f7 = new F7_NewItem();
        //    f8 = new F8_Delete();
        //    f9 = new F9();
        //    f10 = new F10();

        //    buttons.Add(f1);
        //    buttons.Add(f2);
        //    buttons.Add(f3);
        //    buttons.Add(f4);
        //    buttons.Add(f5);
        //    buttons.Add(f6);
        //    buttons.Add(f7);
        //    buttons.Add(f8);
        //    buttons.Add(f9);
        //    buttons.Add(f10);

        //    DrawButtons();

        //    f7.path = this.path1;

        //    f8.data = this.data1;
        //    f8.path = this.path1;
        //    f8.rowCount = this.rowCount;

        //    f5.path1 = this.path1;
        //    f5.path2 = this.path2;
        //    f5.data1 = this.data1;
        //    f5.data2 = this.data2;
        //    f5.rowCount = this.rowCount;

        //    f6.path1 = this.path1;
        //    f6.path2 = this.path2;
        //    f6.data1 = this.data1;
        //    f6.data2 = this.data2;
        //    f6.rowCount = this.rowCount;

        //    f7.UpdataData += SendEvent;
        //    f8.UpdataData += SendEvent;
        //    f5.UpdataData += SendEvent;
        //    f6.UpdataData += SendEvent;
        //}

        //public void UpdataData()
        //{
        //    f7.path = this.path1;
        //    f7.path2 = this.path2;

        //    f8.data = this.data1;
        //    f8.path = this.path1;
        //    f8.path2 = this.path2;
        //    f8.rowCount = this.rowCount;

        //    f5.path1 = this.path1;
        //    f5.path2 = this.path2;
        //    f5.data1 = this.data1;
        //    f5.data2 = this.data2;
        //    f5.rowCount = this.rowCount;

        //    f6.path1 = this.path1;
        //    f6.path2 = this.path2;
        //    f6.data1 = this.data1;
        //    f6.data2 = this.data2;
        //    f6.rowCount = this.rowCount;
        //}
        //public void SendEvent(string path1,string path2)
        //{
        //    UpdateData.Invoke(path1,path2);
        //}

        //public void HandleKey(ConsoleKeyInfo info)
        //{
        //    for (int i = 0; i < buttons.Count; i++)
        //    {
        //        if (buttons[i].Key == info.Key)
        //            buttons[i].Press();
        //    }
        //}

        //public void DrawButtons()
        //{
        //    Console.SetCursorPosition(0, 27);
        //    Console.Write("  ");
        //    for (int i = 0; i < buttons.Count; i++)
        //    {
        //        Console.Write(buttons[i].Name.PadRight(buttons[i].Name.Length + 5, ' '));
        //    }
        //}
    }
}
