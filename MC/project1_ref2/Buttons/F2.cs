using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    internal class F2 : DialogWindow
    {

        public override string Name { get; set; } = "2.Nabídka";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F2;
        public void Press()
        {
            Console.SetCursorPosition(12, 28);
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
