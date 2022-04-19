namespace LOLTTIPN
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.loginButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.menuIconPicBox = new System.Windows.Forms.PictureBox();
            this.titleMenuLabel = new System.Windows.Forms.Label();
            this.maxiButton = new System.Windows.Forms.Label();
            this.miniButton = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SRiconPicBox = new System.Windows.Forms.PictureBox();
            this.TFTiconPicBox = new System.Windows.Forms.PictureBox();
            this.ARAMiconPicBox = new System.Windows.Forms.PictureBox();
            this.LORiconPicBox = new System.Windows.Forms.PictureBox();
            this.SRiconLabel = new System.Windows.Forms.Label();
            this.TFTiconLabel = new System.Windows.Forms.Label();
            this.ARAMiconLabel = new System.Windows.Forms.Label();
            this.LORiconLabel = new System.Windows.Forms.Label();
            this.rememberChkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.menuIconPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SRiconPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFTiconPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARAMiconPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LORiconPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.loginButton.FlatAppearance.BorderSize = 2;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.loginButton.Location = new System.Drawing.Point(520, 465);
            this.loginButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(103, 30);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Clicked);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.exitButton.Location = new System.Drawing.Point(1086, 10);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(37, 35);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "X";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitButton_MouseDown);
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.userTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userTextBox.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextBox.Location = new System.Drawing.Point(488, 344);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(186, 22);
            this.userTextBox.TabIndex = 2;
            this.userTextBox.WordWrap = false;
            this.userTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.userTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // passTextBox
            // 
            this.passTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.passTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passTextBox.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.passTextBox.Location = new System.Drawing.Point(488, 391);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(186, 22);
            this.passTextBox.TabIndex = 3;
            this.passTextBox.UseSystemPasswordChar = true;
            this.passTextBox.WordWrap = false;
            this.passTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // userLabel
            // 
            this.userLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.userLabel.Location = new System.Drawing.Point(401, 348);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(74, 15);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Username:";
            this.userLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGoldenrodBorderLABEL);
            // 
            // passLabel
            // 
            this.passLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.passLabel.Location = new System.Drawing.Point(403, 395);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(72, 15);
            this.passLabel.TabIndex = 5;
            this.passLabel.Text = "Password:";
            this.passLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGoldenrodBorderLABEL);
            // 
            // menuIconPicBox
            // 
            this.menuIconPicBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuIconPicBox.Image = ((System.Drawing.Image)(resources.GetObject("menuIconPicBox.Image")));
            this.menuIconPicBox.Location = new System.Drawing.Point(336, 256);
            this.menuIconPicBox.Name = "menuIconPicBox";
            this.menuIconPicBox.Size = new System.Drawing.Size(80, 74);
            this.menuIconPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuIconPicBox.TabIndex = 6;
            this.menuIconPicBox.TabStop = false;
            // 
            // titleMenuLabel
            // 
            this.titleMenuLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleMenuLabel.AutoSize = true;
            this.titleMenuLabel.Font = new System.Drawing.Font("Lucida Fax", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleMenuLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.titleMenuLabel.Location = new System.Drawing.Point(423, 274);
            this.titleMenuLabel.Name = "titleMenuLabel";
            this.titleMenuLabel.Size = new System.Drawing.Size(280, 56);
            this.titleMenuLabel.TabIndex = 7;
            this.titleMenuLabel.Text = "That LoL Thing That \rI Personally Need.";
            // 
            // maxiButton
            // 
            this.maxiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxiButton.AutoSize = true;
            this.maxiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxiButton.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxiButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.maxiButton.Location = new System.Drawing.Point(1034, -2);
            this.maxiButton.Margin = new System.Windows.Forms.Padding(0);
            this.maxiButton.Name = "maxiButton";
            this.maxiButton.Size = new System.Drawing.Size(55, 53);
            this.maxiButton.TabIndex = 8;
            this.maxiButton.Text = "▢";
            this.maxiButton.Click += new System.EventHandler(this.maxiButton_Click);
            this.maxiButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maxiButton_MouseDown);
            // 
            // miniButton
            // 
            this.miniButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miniButton.AutoSize = true;
            this.miniButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.miniButton.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.miniButton.Location = new System.Drawing.Point(988, -12);
            this.miniButton.Margin = new System.Windows.Forms.Padding(0);
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(54, 53);
            this.miniButton.TabIndex = 9;
            this.miniButton.Text = "_";
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            this.miniButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miniButton_MouseDown);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.logoutButton.FlatAppearance.BorderSize = 2;
            this.logoutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.logoutButton.Location = new System.Drawing.Point(14, 758);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(103, 30);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.TabStop = false;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // SRiconPicBox
            // 
            this.SRiconPicBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SRiconPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SRiconPicBox.Image = ((System.Drawing.Image)(resources.GetObject("SRiconPicBox.Image")));
            this.SRiconPicBox.Location = new System.Drawing.Point(270, 256);
            this.SRiconPicBox.Name = "SRiconPicBox";
            this.SRiconPicBox.Size = new System.Drawing.Size(175, 175);
            this.SRiconPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SRiconPicBox.TabIndex = 11;
            this.SRiconPicBox.TabStop = false;
            this.SRiconPicBox.Visible = false;
            this.SRiconPicBox.Click += new System.EventHandler(this.SRiconPicBox_Click);
            // 
            // TFTiconPicBox
            // 
            this.TFTiconPicBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TFTiconPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TFTiconPicBox.Image = ((System.Drawing.Image)(resources.GetObject("TFTiconPicBox.Image")));
            this.TFTiconPicBox.Location = new System.Drawing.Point(488, 256);
            this.TFTiconPicBox.Name = "TFTiconPicBox";
            this.TFTiconPicBox.Size = new System.Drawing.Size(175, 175);
            this.TFTiconPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TFTiconPicBox.TabIndex = 12;
            this.TFTiconPicBox.TabStop = false;
            this.TFTiconPicBox.Visible = false;
            // 
            // ARAMiconPicBox
            // 
            this.ARAMiconPicBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ARAMiconPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ARAMiconPicBox.Image = ((System.Drawing.Image)(resources.GetObject("ARAMiconPicBox.Image")));
            this.ARAMiconPicBox.Location = new System.Drawing.Point(700, 256);
            this.ARAMiconPicBox.Name = "ARAMiconPicBox";
            this.ARAMiconPicBox.Size = new System.Drawing.Size(175, 175);
            this.ARAMiconPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ARAMiconPicBox.TabIndex = 13;
            this.ARAMiconPicBox.TabStop = false;
            this.ARAMiconPicBox.Visible = false;
            // 
            // LORiconPicBox
            // 
            this.LORiconPicBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LORiconPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LORiconPicBox.Image = ((System.Drawing.Image)(resources.GetObject("LORiconPicBox.Image")));
            this.LORiconPicBox.Location = new System.Drawing.Point(488, 501);
            this.LORiconPicBox.Name = "LORiconPicBox";
            this.LORiconPicBox.Size = new System.Drawing.Size(175, 175);
            this.LORiconPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LORiconPicBox.TabIndex = 14;
            this.LORiconPicBox.TabStop = false;
            this.LORiconPicBox.Visible = false;
            // 
            // SRiconLabel
            // 
            this.SRiconLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SRiconLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SRiconLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.SRiconLabel.Location = new System.Drawing.Point(265, 442);
            this.SRiconLabel.Name = "SRiconLabel";
            this.SRiconLabel.Size = new System.Drawing.Size(180, 44);
            this.SRiconLabel.TabIndex = 15;
            this.SRiconLabel.Text = "Summoner\'s Rift";
            this.SRiconLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SRiconLabel.Visible = false;
            // 
            // TFTiconLabel
            // 
            this.TFTiconLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TFTiconLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TFTiconLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.TFTiconLabel.Location = new System.Drawing.Point(451, 442);
            this.TFTiconLabel.Name = "TFTiconLabel";
            this.TFTiconLabel.Size = new System.Drawing.Size(238, 44);
            this.TFTiconLabel.TabIndex = 16;
            this.TFTiconLabel.Text = "Teamfight Tactics";
            this.TFTiconLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TFTiconLabel.Visible = false;
            // 
            // ARAMiconLabel
            // 
            this.ARAMiconLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ARAMiconLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARAMiconLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.ARAMiconLabel.Location = new System.Drawing.Point(695, 442);
            this.ARAMiconLabel.Name = "ARAMiconLabel";
            this.ARAMiconLabel.Size = new System.Drawing.Size(180, 44);
            this.ARAMiconLabel.TabIndex = 17;
            this.ARAMiconLabel.Text = "ARAM";
            this.ARAMiconLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ARAMiconLabel.Visible = false;
            // 
            // LORiconLabel
            // 
            this.LORiconLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LORiconLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LORiconLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.LORiconLabel.Location = new System.Drawing.Point(428, 690);
            this.LORiconLabel.Name = "LORiconLabel";
            this.LORiconLabel.Size = new System.Drawing.Size(298, 44);
            this.LORiconLabel.TabIndex = 18;
            this.LORiconLabel.Text = "Legends of Runeterra";
            this.LORiconLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LORiconLabel.Visible = false;
            // 
            // rememberChkBox
            // 
            this.rememberChkBox.AutoSize = true;
            this.rememberChkBox.Location = new System.Drawing.Point(514, 437);
            this.rememberChkBox.Name = "rememberChkBox";
            this.rememberChkBox.Size = new System.Drawing.Size(116, 19);
            this.rememberChkBox.TabIndex = 19;
            this.rememberChkBox.Text = "Remember Me";
            this.rememberChkBox.UseVisualStyleBackColor = true;
            this.rememberChkBox.CheckedChanged += new System.EventHandler(this.rememberChkBox_CheckedChanged);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1143, 800);
            this.ControlBox = false;
            this.Controls.Add(this.rememberChkBox);
            this.Controls.Add(this.LORiconLabel);
            this.Controls.Add(this.ARAMiconLabel);
            this.Controls.Add(this.TFTiconLabel);
            this.Controls.Add(this.SRiconLabel);
            this.Controls.Add(this.LORiconPicBox);
            this.Controls.Add(this.ARAMiconPicBox);
            this.Controls.Add(this.TFTiconPicBox);
            this.Controls.Add(this.SRiconPicBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.miniButton);
            this.Controls.Add(this.maxiButton);
            this.Controls.Add(this.titleMenuLabel);
            this.Controls.Add(this.menuIconPicBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loginButton);
            this.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Goldenrod;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League of Legends Thing That I Personally Need, Bro.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.menuIconPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SRiconPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFTiconPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARAMiconPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LORiconPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label exitButton;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.PictureBox menuIconPicBox;
        private System.Windows.Forms.Label titleMenuLabel;
        private System.Windows.Forms.Label maxiButton;
        private System.Windows.Forms.Label miniButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.PictureBox SRiconPicBox;
        private System.Windows.Forms.PictureBox TFTiconPicBox;
        private System.Windows.Forms.PictureBox ARAMiconPicBox;
        private System.Windows.Forms.PictureBox LORiconPicBox;
        private System.Windows.Forms.Label SRiconLabel;
        private System.Windows.Forms.Label TFTiconLabel;
        private System.Windows.Forms.Label ARAMiconLabel;
        private System.Windows.Forms.Label LORiconLabel;
        private System.Windows.Forms.CheckBox rememberChkBox;
    }
}

