using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons.Components
{
    public class Button : IComponents
    {
        public event Action Clicked;

        public string Title { get; set; } = "";

        public void Draw()
        {
            Console.Write($"[ {this.Title} ]");
        }

        public void HandleKey(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Enter)
            {
                this.Clicked();
            }
        }
    }
}
