using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    public abstract class Window
    {
        public App app { get; set; }
        public abstract void Draw();
        public abstract void KeyHandle(ConsoleKeyInfo info);
    }
}
