using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IGameView
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        void NewButton(char part, int iconSize, int rows, int columns, int row, int column);
        void NewImage(char part, int iconSize, int rows, int columns, int row, int column);
        //void NewDrawing(char part, int iconSize, int rows, int columns, int row, int column);
        void UpdateButton(char part, int row, int column);
        void UpdateMoveCount(int num);
        void Show();
        void LevelName(string filepath);
        void SetElementData(Element elt);
    }
}