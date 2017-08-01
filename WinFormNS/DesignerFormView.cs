using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormNS
{
    public partial class DesignerFormView : WinFormNS.BaseForm, IDesignerView
    {
        protected char Part { get; private set; }
        public DesignerFormView()
        {
            InitializeComponent();
            this.OpenMenutItem_Game.Enabled = false;
            this.SaveMenuItem_Game.Enabled = false;
            this.NewMenuItem_Designer.Enabled = false;
            this.EditMenuItem_Designer.Enabled = false;
            this.SaveMenuItem_Designer.Enabled = true;
        }
        public void Start()
        {
            throw new NotImplementedException();
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int width = (int)numericUpDown_Width.Value;
            int height = (int)numericUpDown_Height.Value;
            //Controller.NewLevel(width, height);
            DesignerController.NewLevel(width, height);
            SetClicks();
        }
        protected void SetClicks()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    if (control.Name.StartsWith("btn_"))
                    {
                        Button who = control as Button;
                        who.Click += new EventHandler(WhoClicked);
                    }
                }
            }
        }
        protected void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            string[] output = btnWho.Name.Split('_', '_');
            int column = int.Parse(output[1]);
            int row = int.Parse(output[2]);
            //Controller.EditLevel(Part, row, column);
            DesignerController.EditLevel(Part, row, column);
        }
        private void SetChar(char part)
        {
            Part = part;
        }
        private void button_Wall_Click(object sender, EventArgs e) { SetChar('#'); }
        private void button_Player_Click(object sender, EventArgs e) { SetChar('@'); }
        private void button_Block_Click(object sender, EventArgs e) { SetChar('$'); }
        private void button_Goal_Click(object sender, EventArgs e) { SetChar('.'); }
        private void button_Empty_Click(object sender, EventArgs e) { SetChar('-'); }
        private void DesignerFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        protected override void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
