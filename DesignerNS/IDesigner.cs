using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace DesignerNS
{
    public interface IDesigner
    {
        List<List<Parts>> GridIndex { get; }
        void LevelBuilder(int width, int height);
        void AddWall(int gridX, int gridY);
        void AddPlayer(int gridX, int gridY);
        void AddBlock(int gridX, int gridY);
        void AddGoal(int gridX, int gridY);
        void AddEmpty(int gridX, int gridY);
        bool IsValid();
        void Load(string newLevel);
    }
}
