using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormNS
{
    public partial class GameFormView_Render : Form, IGameView_Render
    {
        IGameController GameController;
        public List<Element> ElementData = new List<Element>();
        protected int Time = 0;

        public GameFormView_Render()
        {
            InitializeComponent();
            this.designerToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Enabled = false;
            this.gameClock.Enabled = false;
            this.time_Label.Text = Time.ToString();
        }

        public void Display<T>(T message)
        {
            MessageBox.Show(message.ToString());
        }

        public void NewImage(char part, int iconSize, int rows, int columns, int row, int column)
        {
            Graphics gfx = CreateGraphics();
            int xStartPos = (this.Size.Width - (columns * iconSize)) / 2;
            int yStartPos = (this.Size.Height - (rows * iconSize)) / 2;
            int xLoc = (column * iconSize) + xStartPos;
            int yLoc = (row * iconSize) + yStartPos;
            int xSize = iconSize;
            int ySize = iconSize;
            Rectangle rekt = new Rectangle(xLoc, yLoc, xSize, ySize);
            Image img = GetImage(part);
            
            gfx.DrawImage(img, rekt);
        }
        protected Image GetImage(char part)
        {
            //string imgPart = "empty.png";
            Bitmap imgPart = WinFormNS.Properties.Resources.empty;

            switch (part)
            {
                case '@':
                    imgPart = Properties.Resources.player; //"player.png";
                    break;
                case '#':
                    imgPart = Properties.Resources.wall; // "wall.png";
                    break;
                case '$':
                    imgPart = Properties.Resources.block; // "block.png";
                    break;
                case '.':
                    imgPart = Properties.Resources.goal; //"goal.png";
                    break;
                case '+':
                    imgPart = Properties.Resources.playerOnGoal; // "playerOnGoal.png";
                    break;
                case '*':
                    imgPart = Properties.Resources.blockOnGoal; // "blockOnGoal.png";
                    break;
                case '-':
                    imgPart = Properties.Resources.empty; // "empty.png";
                    break;
            }
            //return Image.FromFile(@"E:\BCPR283 (C#)\final assignment\assets\updated\" + imgPart + ".png");
            return imgPart;
        }

        public void SetController(IGameController gameController)
        {
            GameController = gameController;
        }

        public void SetElementData(Element elt)
        {
            int levelSize = elt.Rows * elt.Columns;
            int i = elt.Id;
            if (ElementData.Count < levelSize)
            {
                ElementData.Add(elt);
            }
            else if (!ElementData[i].Equals(elt))
            {
                ElementData.RemoveAt(i);
                ElementData.Insert(i, elt);
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            gameClock.Stop();
            MessageBox.Show("Congratulations! You have finished!\nMoves: " + moveCount_Label.Text + "\nTime: " + Time + " second(s)");
            Restart();
        }

        private void Restart()
        {
            GameController.Restart();
            gameClock.Stop();
            gameClock.Enabled = false;
            Time = 0;
            time_Label.Text = Time.ToString();
        }

        public void UpdateMoveCount(int num)
        {
            moveCount_Label.Text = num.ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            GameController.KeyPresses(keyData);
            if (gameClock.Enabled == false)
            {
                gameClock.Enabled = true;
                gameClock.Start();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LevelName(string filepath)
        {
            string levelname = System.IO.Path.GetFileNameWithoutExtension(filepath);
            label_LevelName.Text = levelname;
            int xStartPos = (Size.Width - label_LevelName.Width) / 2;
            Point centered = new Point(xStartPos, 36);
            label_LevelName.Location = centered;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time++;
            time_Label.Text = Time.ToString();
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}