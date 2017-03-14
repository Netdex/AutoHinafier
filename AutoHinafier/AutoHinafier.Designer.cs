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
            this.grpLivePlayback = new System.Windows.Forms.GroupBox();
            this.grpRender = new System.Windows.Forms.GroupBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblSourceVideo = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.progressBarRender = new System.Windows.Forms.ProgressBar();
            this.imageBoxRenderPreview = new Emgu.CV.UI.ImageBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnSelectDestination = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.grpLivePlayback.SuspendLayout();
            this.grpRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRenderPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportImage
            // 
            this.btnImportImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportImage.Location = new System.Drawing.Point(560, 549);
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
            this.chkAnime.Location = new System.Drawing.Point(9, 596);
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
            this.btnImportVideo.Location = new System.Drawing.Point(448, 550);
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
            this.btnPlay.Location = new System.Drawing.Point(352, 550);
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
            this.imageBox.Location = new System.Drawing.Point(5, 36);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(670, 509);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // lblActiveVideo
            // 
            this.lblActiveVideo.AutoSize = true;
            this.lblActiveVideo.Location = new System.Drawing.Point(9, 17);
            this.lblActiveVideo.Name = "lblActiveVideo";
            this.lblActiveVideo.Size = new System.Drawing.Size(0, 13);
            this.lblActiveVideo.TabIndex = 7;
            // 
            // grpLivePlayback
            // 
            this.grpLivePlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLivePlayback.Controls.Add(this.imageBox);
            this.grpLivePlayback.Controls.Add(this.btnImportVideo);
            this.grpLivePlayback.Controls.Add(this.lblActiveVideo);
            this.grpLivePlayback.Controls.Add(this.btnPlay);
            this.grpLivePlayback.Controls.Add(this.btnImportImage);
            this.grpLivePlayback.Location = new System.Drawing.Point(12, 12);
            this.grpLivePlayback.Name = "grpLivePlayback";
            this.grpLivePlayback.Size = new System.Drawing.Size(680, 579);
            this.grpLivePlayback.TabIndex = 8;
            this.grpLivePlayback.TabStop = false;
            this.grpLivePlayback.Text = "Live Playback";
            // 
            // grpRender
            // 
            this.grpRender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRender.Controls.Add(this.btnSelectDestination);
            this.grpRender.Controls.Add(this.btnSelectSource);
            this.grpRender.Controls.Add(this.txtDestination);
            this.grpRender.Controls.Add(this.txtSource);
            this.grpRender.Controls.Add(this.imageBoxRenderPreview);
            this.grpRender.Controls.Add(this.progressBarRender);
            this.grpRender.Controls.Add(this.lblDestination);
            this.grpRender.Controls.Add(this.lblSourceVideo);
            this.grpRender.Controls.Add(this.btnRender);
            this.grpRender.Location = new System.Drawing.Point(698, 12);
            this.grpRender.Name = "grpRender";
            this.grpRender.Size = new System.Drawing.Size(313, 579);
            this.grpRender.TabIndex = 9;
            this.grpRender.TabStop = false;
            this.grpRender.Text = "Render";
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRender.Location = new System.Drawing.Point(229, 122);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 0;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblSourceVideo
            // 
            this.lblSourceVideo.AutoSize = true;
            this.lblSourceVideo.Location = new System.Drawing.Point(6, 17);
            this.lblSourceVideo.Name = "lblSourceVideo";
            this.lblSourceVideo.Size = new System.Drawing.Size(41, 13);
            this.lblSourceVideo.TabIndex = 1;
            this.lblSourceVideo.Text = "Source";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(6, 67);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(60, 13);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "Destination";
            // 
            // progressBarRender
            // 
            this.progressBarRender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarRender.Location = new System.Drawing.Point(9, 151);
            this.progressBarRender.Name = "progressBarRender";
            this.progressBarRender.Size = new System.Drawing.Size(295, 23);
            this.progressBarRender.TabIndex = 3;
            // 
            // imageBoxRenderPreview
            // 
            this.imageBoxRenderPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxRenderPreview.Location = new System.Drawing.Point(9, 180);
            this.imageBoxRenderPreview.Name = "imageBoxRenderPreview";
            this.imageBoxRenderPreview.Size = new System.Drawing.Size(298, 393);
            this.imageBoxRenderPreview.TabIndex = 2;
            this.imageBoxRenderPreview.TabStop = false;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(9, 33);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(247, 20);
            this.txtSource.TabIndex = 4;
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestination.Location = new System.Drawing.Point(9, 83);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(247, 20);
            this.txtDestination.TabIndex = 5;
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSource.Location = new System.Drawing.Point(262, 31);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(42, 23);
            this.btnSelectSource.TabIndex = 6;
            this.btnSelectSource.Text = "...";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // btnSelectDestination
            // 
            this.btnSelectDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDestination.Location = new System.Drawing.Point(262, 81);
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size(42, 23);
            this.btnSelectDestination.TabIndex = 7;
            this.btnSelectDestination.Text = "...";
            this.btnSelectDestination.UseVisualStyleBackColor = true;
            this.btnSelectDestination.Click += new System.EventHandler(this.btnSelectDestination_Click);
            // 
            // AutoHinafier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1023, 621);
            this.Controls.Add(this.grpRender);
            this.Controls.Add(this.grpLivePlayback);
            this.Controls.Add(this.chkAnime);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AutoHinafier";
            this.Text = "AutoHinafier";
            this.Load += new System.EventHandler(this.AutoHinafier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.grpLivePlayback.ResumeLayout(false);
            this.grpLivePlayback.PerformLayout();
            this.grpRender.ResumeLayout(false);
            this.grpRender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRenderPreview)).EndInit();
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
        private System.Windows.Forms.GroupBox grpLivePlayback;
        private System.Windows.Forms.GroupBox grpRender;
        private System.Windows.Forms.Label lblSourceVideo;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtSource;
        private Emgu.CV.UI.ImageBox imageBoxRenderPreview;
        private System.Windows.Forms.ProgressBar progressBarRender;
        private System.Windows.Forms.Label lblDestination;
    }
}