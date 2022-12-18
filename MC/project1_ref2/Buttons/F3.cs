using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    internal class F3 : DialogWindow
    {

        public override string Name { get; set; } = "3.Zobrazit";
        public override ConsoleKey Key { get; set; } = ConsoleKey.F3;
        public void Press()
        { }

        public override void Draw()
        {

        }
        public override void KeyHandle(ConsoleKeyInfo info)
        {

        }
    }
}
