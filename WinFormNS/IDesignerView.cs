using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IDesignerView
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        void NewButton(char part, int iconSize, int rows, int columns, int row, int column);
        void UpdateButton(char part, int row, int column);
        void UpdateButtonText(char part, int row, int column);
        void Show();
    }
}
