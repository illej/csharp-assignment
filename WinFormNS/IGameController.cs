using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IGameController
    {
        void ShowForm(/*string modifier*/);
        void BuildView();
        //void EditLevel(char part, int row, int column);
        //void NewLevel(int width, int height);
        void Save();
        void Load();
        void Restart();
        void KeyPresses(System.Windows.Forms.Keys msg);
    }
}
