using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_ref2.Buttons.Components
{
    public interface IComponents
    {
        public void HandleKey(ConsoleKeyInfo info);
        public void Draw();
    }
}
