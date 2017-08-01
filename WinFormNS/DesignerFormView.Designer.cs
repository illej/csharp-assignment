namespace WinFormNS
{
    partial class DesignerFormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.button_Wall = new System.Windows.Forms.Button();
            this.button_Player = new System.Windows.Forms.Button();
            this.button_Block = new System.Windows.Forms.Button();
            this.button_Goal = new System.Windows.Forms.Button();
            this.button_Empty = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Build = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_Width
            // 
            this.numericUpDown_Width.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.numericUpDown_Width.Location = new System.Drawing.Point(876, 28);
            this.numericUpDown_Width.Name = "numericUpDown_Width";
            this.numericUpDown_Width.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_Width.TabIndex = 2;
            this.numericUpDown_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_Height
            // 
            this.numericUpDown_Height.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.numericUpDown_Height.Location = new System.Drawing.Point(876, 55);
            this.numericUpDown_Height.Name = "numericUpDown_Height";
            this.numericUpDown_Height.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_Height.TabIndex = 3;
            this.numericUpDown_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_Wall
            // 
            this.button_Wall.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Wall.Location = new System.Drawing.Point(13, 144);
            this.button_Wall.Name = "button_Wall";
            this.button_Wall.Size = new System.Drawing.Size(30, 30);
            this.button_Wall.TabIndex = 4;
            this.button_Wall.Text = "#";
            this.button_Wall.UseVisualStyleBackColor = true;
            this.button_Wall.Click += new System.EventHandler(this.button_Wall_Click);
            // 
            // button_Player
            // 
            this.button_Player.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Player.Location = new System.Drawing.Point(13, 180);
            this.button_Player.Name = "button_Player";
            this.button_Player.Size = new System.Drawing.Size(30, 30);
            this.button_Player.TabIndex = 5;
            this.button_Player.Text = "@";
            this.button_Player.UseVisualStyleBackColor = true;
            this.button_Player.Click += new System.EventHandler(this.button_Player_Click);
            // 
            // button_Block
            // 
            this.button_Block.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Block.Location = new System.Drawing.Point(13, 216);
            this.button_Block.Name = "button_Block";
            this.button_Block.Size = new System.Drawing.Size(30, 30);
            this.button_Block.TabIndex = 6;
            this.button_Block.Text = "$";
            this.button_Block.UseVisualStyleBackColor = true;
            this.button_Block.Click += new System.EventHandler(this.button_Block_Click);
            // 
            // button_Goal
            // 
            this.button_Goal.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Goal.Location = new System.Drawing.Point(13, 252);
            this.button_Goal.Name = "button_Goal";
            this.button_Goal.Size = new System.Drawing.Size(30, 30);
            this.button_Goal.TabIndex = 7;
            this.button_Goal.Text = ".";
            this.button_Goal.UseVisualStyleBackColor = true;
            this.button_Goal.Click += new System.EventHandler(this.button_Goal_Click);
            // 
            // button_Empty
            // 
            this.button_Empty.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Empty.Location = new System.Drawing.Point(13, 288);
            this.button_Empty.Name = "button_Empty";
            this.button_Empty.Size = new System.Drawing.Size(30, 30);
            this.button_Empty.TabIndex = 8;
            this.button_Empty.Text = "-";
            this.button_Empty.UseVisualStyleBackColor = true;
            this.button_Empty.Click += new System.EventHandler(this.button_Empty_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label1.Location = new System.Drawing.Point(821, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label2.Location = new System.Drawing.Point(814, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Height:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Build
            // 
            this.button_Build.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Build.Location = new System.Drawing.Point(876, 85);
            this.button_Build.Name = "button_Build";
            this.button_Build.Size = new System.Drawing.Size(75, 23);
            this.button_Build.TabIndex = 11;
            this.button_Build.Text = "Build";
            this.button_Build.UseVisualStyleBackColor = true;
            this.button_Build.Click += new System.EventHandler(this.button1_Click);
            // 
            // DesignerFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.button_Build);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Empty);
            this.Controls.Add(this.button_Goal);
            this.Controls.Add(this.button_Block);
            this.Controls.Add(this.button_Player);
            this.Controls.Add(this.button_Wall);
            this.Controls.Add(this.numericUpDown_Height);
            this.Controls.Add(this.numericUpDown_Width);
            this.Name = "DesignerFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DesignerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignerFormView_FormClosing);
            this.Controls.SetChildIndex(this.numericUpDown_Width, 0);
            this.Controls.SetChildIndex(this.numericUpDown_Height, 0);
            this.Controls.SetChildIndex(this.button_Wall, 0);
            this.Controls.SetChildIndex(this.button_Player, 0);
            this.Controls.SetChildIndex(this.button_Block, 0);
            this.Controls.SetChildIndex(this.button_Goal, 0);
            this.Controls.SetChildIndex(this.button_Empty, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button_Build, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_Width;
        private System.Windows.Forms.NumericUpDown numericUpDown_Height;
        private System.Windows.Forms.Button button_Wall;
        private System.Windows.Forms.Button button_Player;
        private System.Windows.Forms.Button button_Block;
        private System.Windows.Forms.Button button_Goal;
        private System.Windows.Forms.Button button_Empty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Build;
    }
}
