using project1_ref2.Windows;
using project1_ref2.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2
{
    public class App
    {
        public Stack<Window> WindowStack = new Stack<Window>();

        public App()
        {
            SwitchWindow(new MainWindow());

        }

        public void HandleKey(ConsoleKeyInfo info)
        {
            try
            {
                WindowStack.Peek().KeyHandle(info);
            }
            catch (Exception)
            {
                WindowStack.Push(new ErrorWindow());
            }
        }

        public void Draw()
        {
            try
            {
                WindowStack.Peek().Draw();
            }
            catch (Exception)
            {
                WindowStack.Push(new ErrorWindow());
            }
        }       

        public void SwitchWindow(Window window)
        {
            window.app = this;
            WindowStack.Push(window);
        }

    }
}
