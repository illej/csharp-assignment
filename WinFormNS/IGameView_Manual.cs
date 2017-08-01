using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IGameView_Manual
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        void UpdateButton(char part, int iconSize, int rows, int columns, int row, int column);
        void UpdateMoveCount(int num);
        void Show();
        void LevelName(string filepath);
        void SetController(IGameController gameController);
    }
}
