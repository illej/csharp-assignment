using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;
using DesignerNS;
using GameNS;
using System.Windows.Forms;

namespace WinFormNS
{
    public class Element
    {
        public int Id { get; private set; }
        public char Part { get; private set; }
        public int ElementSize { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Element(int id, char part, int eltSize, int rows, int columns, int row, int column)
        {
            Id = id;
            Part = part;
            ElementSize = eltSize;
            Rows = rows;
            Columns = columns;
            Row = row;
            Column = column;
        }
    }
    public class GameController : IGameController
    {
        IGameView GameView;
        //IGameView_Render GameView;
        //IGameView_Manual GameView;
        IFilerView FilerView;
        IFiler Filer;
        IGame Game;
        IFileable GameFileable;
        public GameController(IGameView /*IGameView_Render*/ /*IGameView_Manual*/ gameView, IFilerView filerView, IFiler filer, IGame game, IFileable gameFileable)
        {
            GameView = gameView;
            FilerView = filerView;
            Filer = filer;
            Game = game;
            GameFileable = gameFileable;
        }

        public void ShowForm()
        {
            GameView.Show();
        }

        public void Load()
        {
            string[] newLevel = FilerView.Load();
            string filename = newLevel[0];
            string rawLevel = newLevel[1];
            Filer.SetString(rawLevel);
            string level = Filer.Load(filename);
            try
            {
                Game.Load(level);
                BuildView();
                //UpdateView();
                GameView.LevelName(filename);
            }
            catch (ArgumentOutOfRangeException e)
            {
                FilerView.Display(e);
            }
        }

        public void Save()
        {
            try
            {
                string filename = FilerView.Save();
                Filer.Save(filename, GameFileable);
            }
            catch (ArgumentException e)
            {
                FilerView.Display(e);
            } 
        }

        protected void Builder(string modifier)
        {
            int count = 0;
            int iconSize = 50;
            int rows = GameFileable.GetRowCount();
            int columns = GameFileable.GetColumnCount();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    char part = (char)GameFileable.WhatsAt(i, j);
                    switch (modifier)
                    {
                        case "New":
                            GameView.NewButton(part, iconSize, rows, columns, i, j);
                            //GameView.NewImage(part, iconSize, rows, columns, i, j);
                            //GameView.NewDrawing(part, iconSize, rows, columns, i, j);
                            
                            //Element elt = new Element(count, part, iconSize, rows, columns, i, j);
                            //GameView.SetElementData(elt);
                            break;
                        case "Update":
                            GameView.UpdateButton(part, /*iconSize, rows, columns,*/ i, j);
                            break;
                    }
                    count++;
                }
            }
            int moveCount = Game.GetMoveCount();
            GameView.UpdateMoveCount(moveCount);
            GameView.Show();
        }
        
        public void BuildView()
        {
            Builder("New");
        }

        protected void UpdateView()
        {
            Builder("Update");
        }

        public void KeyPresses(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    Game.MoveUp();
                    break;
                case Keys.Down:
                    Game.MoveDown();
                    break;
                case Keys.Left:
                    Game.MoveLeft();
                    break;
                case Keys.Right:
                    Game.MoveRight();
                    break;
            }
            UpdateView();
            int moveCount = Game.GetMoveCount();
            GameView.UpdateMoveCount(moveCount);
            if (Game.IsFinished())
            {
                GameView.Stop();
            }
        }

        public void Restart()
        {
            Game.Restart();
            UpdateView();
        }
    }
}
