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
    public partial class GameFormView_Manual : Form, IGameView_Manual
    {
        IGameController GameController;
        protected int Time { get; private set; }
        protected int UpperLimit { get; private set; }

        public GameFormView_Manual()
        {
            InitializeComponent();
            HideUnused();
            UpperLimit = 7;
        }

        public void SetController(IGameController gameController)
        {
            GameController = gameController;
        }

        public void Display<T>(T message)
        {
            MessageBox.Show(message.ToString());
        }
        public void LevelName(string filepath)
        {
            string levelname = System.IO.Path.GetFileNameWithoutExtension(filepath);
            label_LevelName.Text = levelname;
            int xStartPos = (Size.Width - label_LevelName.Width) / 2;
            Point centered = new Point(xStartPos, 36);
            label_LevelName.Location = centered;
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

        public void UpdateButton(char part, int iconSize, int rows, int columns, int row, int column)
        {
            int unusedColumns = UpperLimit - columns;
            int xStart = unusedColumns / 2;
            int unusedRows = UpperLimit - rows;
            int yStart = unusedRows / 2;

            Control btn = Controls.Find("btn_" + (xStart + row) + "_" + (yStart + column), true)[0];
            if (btn.Text != part.ToString())
            {
                btn.Text = part.ToString();
                btn.Visible = true;
            }
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

        private void gameClock_Tick(object sender, EventArgs e)
        {
            Time++;
            time_Label.Text = Time.ToString();
        }

        private void HideUnused()
        {
            foreach (Control btn in Controls)
            {
                if (btn.Name.StartsWith("btn_"))
                {
                    btn.Text = null;
                    btn.Visible = false;
                }
            }
        }

        private void Restart()
        {
            GameController.Restart();
            gameClock.Stop();
            gameClock.Enabled = false;
            Time = 0;
            time_Label.Text = Time.ToString();
        }

        private void button1_Restart_Click_1(object sender, EventArgs e)
        {
            Restart();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideUnused();
            this.Hide();
        }

        private void GameFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /* Unused */
        private void button1_Restart_Click(object sender, EventArgs e) { }
        private void label_LevelName_Click(object sender, EventArgs e) { }
    }
}
