using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace WinFormNS
{
    public partial class GameFormView : WinFormNS.BaseForm, IGameView
    {
        public List<Element> ElementData = new List<Element>();
        protected int Time = 0;

        public GameFormView() : base()
        {
            InitializeComponent();
            this.OpenMenutItem_Game.Enabled = false;
            this.SaveMenuItem_Game.Enabled = true;
            this.NewMenuItem_Designer.Enabled = false;
            this.EditMenuItem_Designer.Enabled = false;
            this.SaveMenuItem_Designer.Enabled = false;

            this.gameClock.Enabled = false;
            this.time_Label.Text = Time.ToString();

            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);
        }

        public void Start()
        {
            
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

        public override void LevelName(string filepath)
        {
            base.LevelName(filepath);
            string levelname = System.IO.Path.GetFileNameWithoutExtension(filepath);
            label_LevelName.Text = levelname;
            int xStartPos = (Size.Width - label_LevelName.Width) / 2;
            Point centered = new Point(xStartPos, 36);
            label_LevelName.Location = centered;
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
        public void UpdateMoveCount(int num)
        {
            moveCount_Label.Text = num.ToString();
        }
        private void GameFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        protected override void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearButtons();
            this.Hide();
        }

        // Being called when GameFormView is Show()n.
        /*protected override void OnPaint(PaintEventArgs e)
        {
            // could use List.Equals to optimize???
            List<Element> eltData = GetElementData();
            int width = eltData[0].Columns;
            int height = eltData[0].Rows;
            int multiplier = eltData[0].ElementSize;

            int xStartPos2 = (this.Size.Width - (width * multiplier)) / 2;
            int yStartPos2 = (this.Size.Height - (height * multiplier)) / 2;
            Rectangle gameRegion = new Rectangle(xStartPos2, yStartPos2, (width * multiplier), (height * multiplier));
            Invalidate(gameRegion);
            //e.Graphics.Clear(this.BackColor);
            base.OnPaint(e);

            foreach (var item in eltData)
            {
                char part = item.Part;
                int eltSize = item.ElementSize;
                int rows = item.Rows;
                int columns = item.Columns;
                int row = item.Row;
                int column = item.Column;

                int xStartPos = (this.Size.Width - (columns * eltSize)) / 2;
                int yStartPos = (this.Size.Height - (rows * eltSize)) / 2;
                int xLoc = (column * eltSize) + xStartPos;
                int yLoc = (row * eltSize) + yStartPos;

                Image img = GetImage(part);
                e.Graphics.DrawImage(img, xLoc, yLoc, eltSize, eltSize); 
            }   
        }*/

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
        private List<Element> GetElementData()
        {
            return ElementData;
        }

        /* IMAGE */
        public void NewImage(char part, int iconSize, int rows, int columns, int row, int column)
        {
            //Draw();
            /*Image img = GetImage(part);
            //Graphics gfx = CreateGraphics();
            using (Graphics gfx = Graphics.FromImage(img))
            {
                int xStartPos = (this.Size.Width - (columns * iconSize)) / 2;
                int yStartPos = (this.Size.Height - (rows * iconSize)) / 2;
                float xLoc = (column * iconSize) + xStartPos;
                float yLoc = (row * iconSize) + yStartPos;
                float xSize = iconSize;
                float ySize = iconSize;
                gfx.DrawImage(img, xLoc, yLoc, xSize, ySize);
            }*/

            

        }
        public void UpdateImg()
        {

        }
        protected Image GetImage(char part)
        {
            string imgPart = "empty";
            switch (part)
            {
                case '@':
                    imgPart = "player";
                    break;
                case '#':
                    imgPart = "wall";
                    break;
                case '$':
                    imgPart = "block";
                    break;
                case '.':
                    imgPart = "goal";
                    break;
                case '+':
                    imgPart = "playerOnGoal";
                    break;
                case '*':
                    imgPart = "blockOnGoal";
                    break;
                case '-':
                    imgPart = "empty";
                    break;
            }
            return Image.FromFile(@"F:\BCPR283 (C#)\final assignment\assets\updated\" + imgPart + ".png");
        }

        private void button_Restart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time++;
            time_Label.Text = Time.ToString();
        }
    }
}
