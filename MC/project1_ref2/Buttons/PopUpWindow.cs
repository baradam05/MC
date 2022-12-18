using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons
{
    public class PopUpWindow
    {
        public void Draw(int width, int height)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            int SPwidth = 60 - (width / 2);
            int SPheight = 16 - (height / 2);

            Console.SetCursorPosition(SPwidth, SPheight);
            Console.Write("┌".PadRight(width - 1, '─') + "┐");
            for (int i = 1; i < height - 2; i++)
            {
                Console.SetCursorPosition(SPwidth, SPheight + i); ;
                Console.Write("│".PadRight(width - 1, ' ') + "│");
            }
            Console.SetCursorPosition(SPwidth, SPheight + height - 2);
            Console.Write("└".PadRight(width - 1, '─') + "┘");
        }
    }
}
