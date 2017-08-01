namespace WinFormNS
{
    partial class GameFormView
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
            this.components = new System.ComponentModel.Container();
            this.moveCount_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Restart = new System.Windows.Forms.Button();
            this.label_LevelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.time_Label = new System.Windows.Forms.Label();
            this.gameClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // moveCount_Label
            // 
            this.moveCount_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moveCount_Label.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.moveCount_Label.Location = new System.Drawing.Point(921, 36);
            this.moveCount_Label.Name = "moveCount_Label";
            this.moveCount_Label.Size = new System.Drawing.Size(75, 25);
            this.moveCount_Label.TabIndex = 2;
            this.moveCount_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label1.Location = new System.Drawing.Point(831, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Move Count:";
            // 
            // button_Restart
            // 
            this.button_Restart.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button_Restart.Location = new System.Drawing.Point(921, 92);
            this.button_Restart.Name = "button_Restart";
            this.button_Restart.Size = new System.Drawing.Size(75, 25);
            this.button_Restart.TabIndex = 4;
            this.button_Restart.Text = "Restart";
            this.button_Restart.UseVisualStyleBackColor = true;
            this.button_Restart.Click += new System.EventHandler(this.button_Restart_Click);
            // 
            // label_LevelName
            // 
            this.label_LevelName.AutoSize = true;
            this.label_LevelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_LevelName.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label_LevelName.Location = new System.Drawing.Point(512, 36);
            this.label_LevelName.Name = "label_LevelName";
            this.label_LevelName.Size = new System.Drawing.Size(2, 17);
            this.label_LevelName.TabIndex = 5;
            this.label_LevelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label2.Location = new System.Drawing.Point(873, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // time_Label
            // 
            this.time_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.time_Label.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.time_Label.Location = new System.Drawing.Point(921, 64);
            this.time_Label.Name = "time_Label";
            this.time_Label.Size = new System.Drawing.Size(75, 25);
            this.time_Label.TabIndex = 7;
            this.time_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameClock
            // 
            this.gameClock.Interval = 1000;
            this.gameClock.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.time_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_LevelName);
            this.Controls.Add(this.button_Restart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveCount_Label);
            this.Name = "GameFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameFormView_FormClosing);
            this.Controls.SetChildIndex(this.moveCount_Label, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button_Restart, 0);
            this.Controls.SetChildIndex(this.label_LevelName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.time_Label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label moveCount_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Restart;
        private System.Windows.Forms.Label label_LevelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label time_Label;
        private System.Windows.Forms.Timer gameClock;
    }
}
