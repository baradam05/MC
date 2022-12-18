using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons.Components
{
    public class TextBox : IComponents
    {
        public string Value { get; set; } = "";
        public int Size { get; set; }

        public void Draw()
        {
            Console.Write(this.Value);
        }

        public void HandleKey(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Backspace)
            {
                if (this.Value.Length == 0)
                    return;

                this.Value = this.Value.Substring(0, this.Value.Length - 1);
            }
            else
            {
                this.Value += info.KeyChar;
            }
        }
    }
}
