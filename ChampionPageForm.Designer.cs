
namespace LOLTTIPN
{
    partial class ChampionPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChampionPageForm));
            this.champName = new System.Windows.Forms.Label();
            this.champTitle = new System.Windows.Forms.Label();
            this.miniButton = new System.Windows.Forms.Label();
            this.maxiButton = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Label();
            this.champPic = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.champLore = new System.Windows.Forms.Label();
            this.champRole = new System.Windows.Forms.Label();
            this.champRolePic = new System.Windows.Forms.PictureBox();
            this.champSubRole = new System.Windows.Forms.Label();
            this.champSubRolePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.champPic)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.champRolePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.champSubRolePic)).BeginInit();
            this.SuspendLayout();
            // 
            // champName
            // 
            this.champName.AutoSize = true;
            this.champName.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.champName.Location = new System.Drawing.Point(14, 10);
            this.champName.Name = "champName";
            this.champName.Size = new System.Drawing.Size(260, 39);
            this.champName.TabIndex = 0;
            this.champName.Text = "championName";
            // 
            // champTitle
            // 
            this.champTitle.AutoSize = true;
            this.champTitle.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.champTitle.Location = new System.Drawing.Point(16, 49);
            this.champTitle.Name = "champTitle";
            this.champTitle.Size = new System.Drawing.Size(145, 23);
            this.champTitle.TabIndex = 1;
            this.champTitle.Text = "championTitle";
            // 
            // miniButton
            // 
            this.miniButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miniButton.AutoSize = true;
            this.miniButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.miniButton.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.miniButton.Location = new System.Drawing.Point(900, -16);
            this.miniButton.Margin = new System.Windows.Forms.Padding(0);
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(54, 53);
            this.miniButton.TabIndex = 15;
            this.miniButton.Text = "_";
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            this.miniButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miniButton_MouseDown);
            // 
            // maxiButton
            // 
            this.maxiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxiButton.AutoSize = true;
            this.maxiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxiButton.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxiButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.maxiButton.Location = new System.Drawing.Point(962, -4);
            this.maxiButton.Margin = new System.Windows.Forms.Padding(0);
            this.maxiButton.Name = "maxiButton";
            this.maxiButton.Size = new System.Drawing.Size(55, 53);
            this.maxiButton.TabIndex = 14;
            this.maxiButton.Text = "▢";
            this.maxiButton.Click += new System.EventHandler(this.maxiButton_Click);
            this.maxiButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maxiButton_MouseDown);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.exitButton.Location = new System.Drawing.Point(1032, 10);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(37, 35);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "X";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitButton_MouseDown);
            // 
            // champPic
            // 
            this.champPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.champPic.BackColor = System.Drawing.Color.Goldenrod;
            this.champPic.Image = ((System.Drawing.Image)(resources.GetObject("champPic.Image")));
            this.champPic.Location = new System.Drawing.Point(467, 89);
            this.champPic.Name = "champPic";
            this.champPic.Padding = new System.Windows.Forms.Padding(10);
            this.champPic.Size = new System.Drawing.Size(602, 427);
            this.champPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.champPic.TabIndex = 16;
            this.champPic.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.champLore);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 89);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 427);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // champLore
            // 
            this.champLore.AutoSize = true;
            this.champLore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.champLore.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.champLore.Location = new System.Drawing.Point(13, 10);
            this.champLore.Name = "champLore";
            this.champLore.Size = new System.Drawing.Size(129, 18);
            this.champLore.TabIndex = 0;
            this.champLore.Text = "championLore";
            // 
            // champRole
            // 
            this.champRole.AutoSize = true;
            this.champRole.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.champRole.Location = new System.Drawing.Point(487, 31);
            this.champRole.Name = "champRole";
            this.champRole.Size = new System.Drawing.Size(128, 18);
            this.champRole.TabIndex = 1;
            this.champRole.Text = "championRole";
            // 
            // champRolePic
            // 
            this.champRolePic.Image = ((System.Drawing.Image)(resources.GetObject("champRolePic.Image")));
            this.champRolePic.Location = new System.Drawing.Point(467, 27);
            this.champRolePic.Name = "champRolePic";
            this.champRolePic.Size = new System.Drawing.Size(23, 22);
            this.champRolePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.champRolePic.TabIndex = 18;
            this.champRolePic.TabStop = false;
            // 
            // champSubRole
            // 
            this.champSubRole.AutoSize = true;
            this.champSubRole.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.champSubRole.Location = new System.Drawing.Point(487, 53);
            this.champSubRole.Name = "champSubRole";
            this.champSubRole.Size = new System.Drawing.Size(160, 18);
            this.champSubRole.TabIndex = 19;
            this.champSubRole.Text = "championSubRole";
            // 
            // champSubRolePic
            // 
            this.champSubRolePic.Image = ((System.Drawing.Image)(resources.GetObject("champSubRolePic.Image")));
            this.champSubRolePic.Location = new System.Drawing.Point(467, 52);
            this.champSubRolePic.Name = "champSubRolePic";
            this.champSubRolePic.Size = new System.Drawing.Size(23, 22);
            this.champSubRolePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.champSubRolePic.TabIndex = 20;
            this.champSubRolePic.TabStop = false;
            // 
            // ChampionPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1084, 548);
            this.Controls.Add(this.champSubRolePic);
            this.Controls.Add(this.champSubRole);
            this.Controls.Add(this.champRolePic);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.champRole);
            this.Controls.Add(this.champPic);
            this.Controls.Add(this.miniButton);
            this.Controls.Add(this.maxiButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.champTitle);
            this.Controls.Add(this.champName);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Fax", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Goldenrod;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChampionPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChampionPageForm";
            this.Load += new System.EventHandler(this.ChampionPageForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CPFForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPFForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CPFForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.champPic)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.champRolePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.champSubRolePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label champName;
        private System.Windows.Forms.Label champTitle;
        private System.Windows.Forms.Label miniButton;
        private System.Windows.Forms.Label maxiButton;
        private System.Windows.Forms.Label exitButton;
        private System.Windows.Forms.PictureBox champPic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label champLore;
        private System.Windows.Forms.Label champRole;
        private System.Windows.Forms.PictureBox champRolePic;
        private System.Windows.Forms.Label champSubRole;
        private System.Windows.Forms.PictureBox champSubRolePic;
    }
}