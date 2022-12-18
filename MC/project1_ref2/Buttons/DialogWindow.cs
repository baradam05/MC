using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    public abstract class DialogWindow : Window
    {
        public abstract string Name { get; set; }
        public abstract ConsoleKey Key { get; set; }
    }
}

