using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IDesignerController
    {
        void ShowForm();
        void Load();
        void NewLevel(int width, int height);
        void RebuildLevel();
        void EditLevel(char part, int row, int column);
        void Save();
        void Build(string modifier);
        void BuildDesignerView();
    }
}
