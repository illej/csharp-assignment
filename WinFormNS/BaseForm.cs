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
    public partial class BaseForm : Form
    {
        protected ToolStripMenuItem OpenMenutItem_Game { get { return this.openToolStripMenuItem; } }
        protected ToolStripMenuItem SaveMenuItem_Game { get { return this.saveToolStripMenuItem_Game; } }
        protected ToolStripMenuItem NewMenuItem_Designer { get { return this.newToolStripMenuItem; } }
        protected ToolStripMenuItem EditMenuItem_Designer { get { return this.editToolStripMenuItem; } }
        protected ToolStripMenuItem SaveMenuItem_Designer { get { return this.saveToolStripMenuItem_Designer; } }
        protected static IGameController GameController;
        protected static IDesignerController DesignerController;

        public BaseForm()
        {
            InitializeComponent();
            this.SaveMenuItem_Game.Enabled = false;
            this.SaveMenuItem_Designer.Enabled = false;

            /*this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.ResizeEnd += new EventHandler(CreateBackbuffer);
            this.Load += new EventHandler(CreateBackbuffer);
            this.Paint += new PaintEventHandler(Painter);*/
        }
        /*protected void Painter(object sender, PaintEventArgs e)
        {
            if (Backbuffer != null)
            {
                e.Graphics.DrawImageUnscaled(Backbuffer, Point.Empty);
            }
        }
        protected void CreateBackbuffer(object sender, EventArgs e)
        {
            if (Backbuffer != null)
            {
                Backbuffer.Dispose();
            }
            Backbuffer = new Bitmap(Size.Width, Size.Height);
        }
        protected void Draw()
        {
            if (Backbuffer != null)
            {
                using (var gfx = Graphics.FromImage(Backbuffer))
                {
                    gfx.Clear(Color.White);
                    Rectangle rekt = new Rectangle(20, 20, 20, 20);
                    gfx.FillRectangle(Brushes.Black, rekt);
                }
                Invalidate();
            }
        }*/

        public void SetControllers(IGameController gameController, IDesignerController designerController)
        {
            GameController = gameController;
            DesignerController = designerController;
        }
        public void Display<T>(T message)
        {
            MessageBox.Show(message.ToString());
        }
        public void NewButton(char part, int iconSize, int rows, int columns, int row, int column)
        {
            Button btn = new Button();
            btn.Name = "btn_" + column + "_" + row;
            btn.Height = iconSize;
            btn.Width = iconSize;
            btn.Font = new Font("Consolas", 20);
            btn.Text = part.ToString();
            btn.Visible = true;
            int xStartPos = (this.Size.Width - (columns * iconSize)) / 2;
            int yStartPos = (this.Size.Height - (rows * iconSize)) / 2;
            int xLoc = (column * iconSize) + xStartPos;
            int yLoc = (row * iconSize) + yStartPos;
            btn.Location = new Point(xLoc, yLoc);
            Controls.Add(btn);
        }
        public void UpdateButton(char part, int row, int column)
        {
            foreach (Control control in Controls)
            {
                if (control.Name == "btn_" + column + "_" + row)
                {
                    if (control.Text != part.ToString())
                    {
                        control.Text = part.ToString();
                    }
                }
            }
        }

        protected void ClearButtons()
        {
            for (int x = this.Controls.Count - 1; x >= 0; x--)
            {
                if (this.Controls[x] is Button)
                {
                    if (this.Controls[x].Name.StartsWith("btn"))
                    {
                        this.Controls[x].Dispose();
                    }
                }
            }
        }

        public void UpdateButtonText(char part, int row, int column)
        {
            Control btn = Controls.Find("btn_" + (column + "_" + row), true)[0];
            if (btn.Text != part.ToString())
            {
                btn.Text = part.ToString();
            }
        }

        public virtual void LevelName(string levelname)
        {

        }
        protected virtual void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.Load();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignerController.ShowForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignerController.Load();
            DesignerController.BuildDesignerView();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.Save();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DesignerController.Save();
        }
    }
}
