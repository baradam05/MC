using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    internal class F1 : DialogWindow
    {
        public override string Name { get; set; } = "1.Nápověda";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F1;
        public void Press()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine(Name);
        }
        public override void Draw()
        {

        }
        public override void KeyHandle(ConsoleKeyInfo info)
        {

        }
    }
}
