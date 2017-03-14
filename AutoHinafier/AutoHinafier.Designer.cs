namespace AutoHinafier
{
    partial class AutoHinafier
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
            this.btnImportImage = new System.Windows.Forms.Button();
            this.chkAnime = new System.Windows.Forms.CheckBox();
            this.btnImportVideo = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.lblActiveVideo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportImage
            // 
            this.btnImportImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportImage.Location = new System.Drawing.Point(693, 446);
            this.btnImportImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(116, 24);
            this.btnImportImage.TabIndex = 3;
            this.btnImportImage.Text = "Import Image";
            this.btnImportImage.UseVisualStyleBackColor = true;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // chkAnime
            // 
            this.chkAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAnime.AutoSize = true;
            this.chkAnime.Location = new System.Drawing.Point(9, 450);
            this.chkAnime.Margin = new System.Windows.Forms.Padding(2);
            this.chkAnime.Name = "chkAnime";
            this.chkAnime.Size = new System.Drawing.Size(55, 17);
            this.chkAnime.TabIndex = 4;
            this.chkAnime.Text = "Anime";
            this.chkAnime.UseVisualStyleBackColor = true;
            // 
            // btnImportVideo
            // 
            this.btnImportVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportVideo.Location = new System.Drawing.Point(581, 447);
            this.btnImportVideo.Name = "btnImportVideo";
            this.btnImportVideo.Size = new System.Drawing.Size(107, 23);
            this.btnImportVideo.TabIndex = 5;
            this.btnImportVideo.Text = "Import Video";
            this.btnImportVideo.UseVisualStyleBackColor = true;
            this.btnImportVideo.Click += new System.EventHandler(this.btnImportVideo_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Location = new System.Drawing.Point(485, 447);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play/Pause";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.Location = new System.Drawing.Point(9, 25);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(800, 417);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // lblActiveVideo
            // 
            this.lblActiveVideo.AutoSize = true;
            this.lblActiveVideo.Location = new System.Drawing.Point(12, 9);
            this.lblActiveVideo.Name = "lblActiveVideo";
            this.lblActiveVideo.Size = new System.Drawing.Size(0, 13);
            this.lblActiveVideo.TabIndex = 7;
            // 
            // AutoHinafier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(818, 475);
            this.Controls.Add(this.lblActiveVideo);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnImportVideo);
            this.Controls.Add(this.chkAnime);
            this.Controls.Add(this.btnImportImage);
            this.Controls.Add(this.imageBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AutoHinafier";
            this.Text = "AutoHinafier";
            this.Load += new System.EventHandler(this.AutoHinafier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Button btnImportImage;
        private System.Windows.Forms.CheckBox chkAnime;
        private System.Windows.Forms.Button btnImportVideo;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblActiveVideo;
    }
}