using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;
using DesignerNS;

namespace WinFormNS
{
    public class DesignerController : IDesignerController
    {
        IFilerView FilerView;
        IDesignerView DesignerView;
        IDesigner Designer;
        IFiler Filer;
        IFileable DesignerFileable;
        public DesignerController(IFilerView filerView, IDesignerView designerView, IFiler filer, IDesigner designer, IFileable designerFileable)
        {
            FilerView = filerView;
            DesignerView = designerView;
            Designer = designer;
            Filer = filer;
            DesignerFileable = designerFileable;
        }
        public void Build(string modifier)
        {
            int iconSize = 50;
            int rows = DesignerFileable.GetRowCount();
            int columns = DesignerFileable.GetColumnCount();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    char part = (char)DesignerFileable.WhatsAt(i, j);

                    switch (modifier)
                    {
                        case "New":
                            DesignerView.NewButton(part, iconSize, rows, columns, i, j);
                            break;
                        case "Update":
                            DesignerView.UpdateButton(part, i, j);
                            break;
                    }
                }
            }
            DesignerView.Show();
        }

        public void EditLevel(char part, int row, int column)
        {
            switch (part)
            {
                case '#':
                    Designer.AddWall(row, column);
                    RebuildLevel();
                    break;
                case '@':
                    Designer.AddPlayer(row, column);
                    RebuildLevel();
                    break;
                case '$':
                    Designer.AddBlock(row, column);
                    RebuildLevel();
                    break;
                case '.':
                    Designer.AddGoal(row, column);
                    RebuildLevel();
                    break;
                case '-':
                    Designer.AddEmpty(row, column);
                    RebuildLevel();
                    break;
            }
        }

        public void Load()
        {
            string[] newLevel = FilerView.Load();
            string filename = newLevel[0];
            string rawLevel = newLevel[1];
            Filer.SetString(rawLevel);
            string level = Filer.Load(filename);
            Designer.Load(level);
        }

        public void NewLevel(int width, int height)
        {
            try
            {
                Designer.LevelBuilder(width, height);
                BuildDesignerView();
            }
            catch (ArgumentOutOfRangeException e)
            {
                DesignerView.Display(e);
            }
        }

        public void BuildDesignerView() { Build("New"); }
        public void UpdateDesignerView() { Build("Update"); }

        public void RebuildLevel()
        {
            int rows = DesignerFileable.GetRowCount();
            int columns = DesignerFileable.GetColumnCount();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    char part = (char)DesignerFileable.WhatsAt(i, j);
                    DesignerView.UpdateButtonText(part, i, j);
                }
            }
        }

        public void Save()
        {
            try
            {
                if (Designer.IsValid())
                {
                    string filename = FilerView.Save();
                    Filer.Save(filename, DesignerFileable);
                }
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }
        }

        public void ShowForm()
        {
            DesignerView.Show();
        }
    }
}
