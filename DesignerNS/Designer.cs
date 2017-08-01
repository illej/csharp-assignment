using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace DesignerNS
{
    public class Designer : IDesigner, IFileable
    {

        private string widthTooSmallMessage = "width too small";
        private string heightTooSmallMessage = "height too small";
        private string levelAreaTooSmallMessage = "level area too small";
        private string outOfGridMessage = "placement is not within the grid";
        private List<List<Parts>> Grid = new List<List<Parts>>();

        private int playerXLocation = -1;
        private int playerYLocation = -1;

        protected List<int> RowsChecked = new List<int>();
        protected List<int> ColumnsChecked = new List<int>();

        public string WidthTooSmallMessage { get { return widthTooSmallMessage; } }
        public string HeightTooSmallMessage { get { return heightTooSmallMessage; } }
        public string LevelAreaTooSmallMessage { get { return levelAreaTooSmallMessage; } }
        public string OutOfGridMessage { get { return outOfGridMessage; } }
        public List<List<Parts>> GridIndex { get { return Grid; } }

        public string Level { get; private set; }
        public int WhatsAtCallCount { get; private set; }

        public Parts WhatsAt(int row, int column)
        {
            return Grid[row][column];
        }
        public void Load(string newLevel)
        {
            Level = newLevel;
            BuildGrid();
        }

        private void BuildGrid()
        {
            string[] arrayOfRows = Level.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int height = arrayOfRows.Length;
            for (var i = 0; i < height; i++)
            {
                string row = arrayOfRows[i];
                int width = row.Length;
                char[] columns = new char[width];
                columns = row.ToCharArray();
                Grid.Add(new List<Parts>());
                for (var j = 0; j < width; j++)
                {
                    char element = columns[j];
                    switch (element)
                    {
                        case '#':
                            Grid[i].Add(Parts.Wall);
                            break;
                        case '-':
                            Grid[i].Add(Parts.Empty);
                            break;
                        case '@':
                            Grid[i].Add(Parts.Player);
                            break;
                        case '.':
                            Grid[i].Add(Parts.Goal);
                            break;
                        case '$':
                            Grid[i].Add(Parts.Block);
                            break;
                        case '*':
                            Grid[i].Add(Parts.BlockOnGoal);
                            break;
                        case '+':
                            Grid[i].Add(Parts.PlayerOnGoal);
                            break;
                    }
                }
            }
        }

        public void LevelBuilder(int width, int height)
        {
            LevelValidation(width, height);
            Grid.Clear();
            for (int i = 0; i < height; i++)
            {
                Grid.Add(new List<Parts>());
                for (int j = 0; j < width; j++)
                {
                    Grid[i].Add(Parts.Empty);
                }
            }
        }

        private void LevelValidation(int width, int height)
        {
            if (width <= 2)
            {
                string exception = "Width: " + width.ToString();
                throw new ArgumentOutOfRangeException(exception, "Width of grid too small.");
            }
            if (height <= 2)
            {
                string exception = "Height: " + height.ToString();
                throw new ArgumentOutOfRangeException(exception, "Height of grid too small");
            }
            if (width * height < 15)
            {
                string exception = "Total units: " + (width * height).ToString();
                throw new ArgumentOutOfRangeException(exception, "Playable area too small.");
            }
            if (width > 18)
            {
                string exception = "Width: " + width.ToString();
                throw new ArgumentOutOfRangeException(exception, "Width of grid too large");
            }
            if (height > 11)
            {
                string exception = "height: " + height.ToString();
                throw new ArgumentOutOfRangeException(exception, "Width of grid too large");
            }
        }


        public void AddWall(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            Grid[gridY][gridX] = Parts.Wall;
        }

        public void AddPlayer(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            if (WhatsAt(gridY, gridX) == Parts.Wall || WhatsAt(gridY, gridX) == Parts.Block || WhatsAt(gridY, gridX) == Parts.BlockOnGoal)
            {
                return;
            }
            if (playerXLocation != -1)
            {
                if (WhatsAt(playerYLocation, playerXLocation) == Parts.PlayerOnGoal)
                {
                    removePlayer(playerYLocation, playerXLocation);
                    AddGoal(playerYLocation, playerXLocation);
                }
                else
                {
                    removePlayer(playerYLocation, playerXLocation);
                }
            }
            if (WhatsAt(gridY, gridX) == Parts.Goal)
            {
                AddPlayerOnGoal(gridY, gridX);
            }
            else
            {
                Grid[gridY][gridX] = Parts.Player;
            }
            playerXLocation = gridX;
            playerYLocation = gridY;
        }

        public void AddBlock(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            if (WhatsAt(gridY, gridX) == Parts.Wall)
            {
                return;
            }
            if (WhatsAt(gridY, gridX) == Parts.BlockOnGoal)
            {
                return;
            }
            if (WhatsAt(gridY, gridX) == Parts.Goal)
            {
                Grid[gridY][gridX] = Parts.BlockOnGoal;
            }
            else
            {
                Grid[gridY][gridX] = Parts.Block;
            }
        }

        public void AddGoal(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            if (WhatsAt(gridY, gridX) == Parts.Wall)
            {
                return;
            }
            if (WhatsAt(gridY, gridX) == Parts.Block)
            {
                Grid[gridY][gridX] = Parts.BlockOnGoal;
            }
            else if (WhatsAt(gridY, gridX) == Parts.Player)
            {
                Grid[gridY][gridX] = Parts.PlayerOnGoal;
            }
            if (WhatsAt(gridY, gridX) == Parts.BlockOnGoal)
            {
                return;
            }
            if (WhatsAt(gridY, gridX) == Parts.PlayerOnGoal)
            {
                return;
            }
            else
            {
                Grid[gridY][gridX] = Parts.Goal;
            }

        }

        private void AddBlockOnGoal(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            Grid[gridY][gridX] = Parts.BlockOnGoal;
        }

        private void AddPlayerOnGoal(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            Grid[gridY][gridX] = Parts.PlayerOnGoal;
        }

        public void AddEmpty(int gridY, int gridX)
        {
            if (OutOfBounds(gridX, gridY))
            {
                throw new ArgumentOutOfRangeException(OutOfGridMessage);
            }
            Grid[gridY][gridX] = Parts.Empty;
        }

        private void removePlayer(int y, int x)
        {
            AddEmpty(y, x);
        }

        private bool OutOfBounds(int x, int y)
        {
            bool result = false;
            if (x > Grid[0].Count
                || y > Grid.Count)
            {
                result = true;
            }
            return result;
        }

        public bool IsValid()
        {
            int block = 0;
            int goal = 0;
            int player = 0;
            bool valid = true;
            foreach (var row in Grid)
            {
                foreach (var part in row)
                {
                    if (part == Parts.Block)
                    {
                        block++;
                    }
                    if (part == Parts.Goal)
                    {
                        goal++;
                    }
                    if (part == Parts.Player)
                    {
                        player++;
                    }
                    if (part == Parts.PlayerOnGoal)
                    {
                        player++;
                        goal++;
                    }
                    if (part == Parts.BlockOnGoal)
                    {
                        block++;
                        goal++;
                    }
                }
            }
            if (block == 0)
            {
                throw new ArgumentOutOfRangeException("No blocks on grid");
            }
            if (goal == 0)
            {
                throw new ArgumentOutOfRangeException("No goals on grid");
            }
            if (player == 0)
            {
                throw new ArgumentOutOfRangeException("No player");
            }
            if (block > goal)
            {
                throw new ArgumentOutOfRangeException("More blocks than goals");
            }
            if (block < goal)
            {
                throw new ArgumentOutOfRangeException("More goals than blocks");
            }
            return valid;
        }

        public int GetColumnCount()
        {
            return Grid[0].Count;
        }

        public int GetRowCount()
        {
            return Grid.Count;
        }
    }
}

