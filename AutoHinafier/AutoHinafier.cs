﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace AutoHinafier
{
    public partial class AutoHinafier : Form
    {
        public AutoHinafier()
        {
            InitializeComponent();
        }

        private Dictionary<FaceType, CascadeClassifier> CascadeClassifiers = new Dictionary<FaceType, CascadeClassifier>();
        private Dictionary<FaceType, RectangleF> AdjustmentFactor = new Dictionary<FaceType, RectangleF>();

        private UMat _hina;

        private Capture VideoCapture;
        private int ThreadWait;
        private Stopwatch Time;
        private bool VideoPlaying;
        private long LastTick;

        private void AutoHinafier_Load(object sender, EventArgs e)
        {
            LoadResources();
        }

        private void LoadResources()
        {
            CascadeClassifiers[FaceType.Anime] = new CascadeClassifier(Application.StartupPath + "/lbpcascade_animeface.xml");
            CascadeClassifiers[FaceType.Human] = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            AdjustmentFactor[FaceType.Anime] = new RectangleF(1f / 5, 1f / 5, 3f / 5, 3f / 5);
            AdjustmentFactor[FaceType.Human] = new RectangleF(1f / 8, 1f / 8, 6f / 8, 6f / 8);

            var img = new Image<Bgra, byte>(Properties.Resources.Hinaface);
            _hina = img.ToUMat();
        }

        #region LivePlayback
        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp;*.gif" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var imageFrame = new UMat();
                var mat = CvInvoke.Imread(ofd.FileName, LoadImageType.Color);
                mat.CopyTo(imageFrame);
                DoHina(imageFrame, 1.1, 3, chkAnime.Checked ? FaceType.Anime : FaceType.Human);
                imageBox.Image = imageFrame;
            }
        }
        private void btnImportVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Video|*.wmv;*.mp4;*.avi;*.mkv" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                VideoPlaying = false;
                VideoCapture = new Capture(ofd.FileName);
                lblActiveVideo.Text = "Active Video: " + ofd.FileName;
                Time = new Stopwatch();
            }
        }

        private UMat ActiveFrame;
        private void VideoTick()
        {
            var mat = VideoCapture.QueryFrame();

            if (mat == null)
            {
                VideoCapture = null;
                VideoPlaying = false;
                return;
            }
            string[] debug =
            {
                $"Time: {VideoCapture.GetCaptureProperty(CapProp.PosMsec)}",
                $"Frame: {VideoCapture.GetCaptureProperty(CapProp.PosFrames)}",
                $"Delay: {ThreadWait}"
            };

            ThreadWait = (int)(1000 / VideoCapture.GetCaptureProperty(CapProp.Fps));
            if (ActiveFrame != null)
                ActiveFrame.Dispose();

            ActiveFrame = new UMat();
            double scale = Math.Min((double)500 / (double)mat.Width, (double)500 / (double)mat.Height);
            CvInvoke.Resize(mat, ActiveFrame, new Size((int)(mat.Width * scale), (int)(mat.Height * scale)), 0, 0,
                Inter.Nearest);

            mat.Dispose();

            DoHina(ActiveFrame, 1.5, 3, chkAnime.Checked ? FaceType.Anime : FaceType.Human);
            for (int i = 0; i < debug.Length; i++)
            {
                CvInvoke.PutText(
                ActiveFrame,
                debug[i],
                new Point(10, 20 + i * 10),
                FontFace.HersheyPlain,
                0.75,
                new Bgr(0, 255, 0).MCvScalar);
            }

            imageBox.Image = ActiveFrame;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (VideoPlaying)
            {
                VideoPlaying = false;
                Time.Stop();
            }
            else
            {
                if (VideoCapture != null)
                {
                    ThreadWait = (int)(1000 / VideoCapture.GetCaptureProperty(CapProp.Fps));
                    if (Time != null)
                        Time.Start();
                    VideoPlaying = true;
                    LastTick = 0;
                    new Thread(() =>
                    {
                        while (VideoPlaying)
                        {
                            LastTick = Time.ElapsedMilliseconds;
                            VideoTick();
                            var pass = Time.ElapsedMilliseconds - LastTick;
                            Thread.Sleep((int)Math.Max(0, ThreadWait - pass));
                        }
                    }).Start();
                }
            }
        }

        #endregion

        /**
         * Optimized version which uses OpenCL
         */
        private void DoHina(UMat source, double scale, int sensitivity, FaceType type)
        {
            CascadeClassifier classifier;
            if (CascadeClassifiers.ContainsKey(type))
                classifier = CascadeClassifiers[type];
            else return;

            var adjustment = AdjustmentFactor[type];
            var faces = classifier.DetectMultiScale(source, scale, sensitivity, Size.Empty);

            foreach (var face in faces)
            {
                Rectangle adjusted = new Rectangle(
                    (int)(face.X + face.Width * adjustment.X), (int)(face.Y + face.Height * adjustment.Y),
                    (int)(face.Width * adjustment.Width), (int)(face.Height * adjustment.Height));

                using (var resizedOverlay = new UMat())
                {
                    CvInvoke.Resize(_hina, resizedOverlay, adjusted.Size, 0, 0, Inter.Nearest);
                    using (var addableOverlay = new UMat())
                    {
                        CvInvoke.CvtColor(resizedOverlay, addableOverlay, ColorConversion.Bgra2Bgr);

                        //CvInvoke.Rectangle(source, adjusted, new MCvScalar(255,0,0,255), 2,LineType.EightConnected, 0);
                        using (var overlayAlphaChannel = new UMat())
                        {
                            CvInvoke.ExtractChannel(resizedOverlay, overlayAlphaChannel, 3);

                            using (var roi = new UMat(source, adjusted))
                            {
                                var k = adjusted.Width / 8;
                                if (k % 2 == 0) k++;
                                CvInvoke.GaussianBlur(roi, roi, new Size(k, k), 0, 0, BorderType.Reflect101);
                                roi.SetTo(new MCvScalar(0, 0, 0), overlayAlphaChannel);
                                CvInvoke.Add(roi, addableOverlay, roi, overlayAlphaChannel);
                            }
                        }
                    }
                }
            }
        }

        /**
         * Slow version that uses CPU
         */
        //private void DoHina(Image<Bgr, byte> source, double scale, int sensitivity, FaceType type)
        //{
        //    CascadeClassifier classifier;
        //    if (CascadeClassifiers.ContainsKey(type))
        //        classifier = CascadeClassifiers[type];
        //    else return;

        //    var adjustment = AdjustmentFactor[type];
        //    var faces = classifier.DetectMultiScale(source, scale, sensitivity, Size.Empty);
        //    var bitm = source.Bitmap;
        //    Graphics g = Graphics.FromImage(bitm);
        //    g.InterpolationMode = InterpolationMode.Low;
        //    g.CompositingQuality = CompositingQuality.HighSpeed;
        //    g.SmoothingMode = SmoothingMode.HighSpeed;
        //    g.TextRenderingHint = TextRenderingHint.SystemDefault;
        //    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

        //    foreach (var face in faces)
        //    {
        //        Rectangle adjusted = new Rectangle(
        //            (int)(face.X + face.Width * adjustment.X), (int)(face.Y + face.Height * adjustment.Y),
        //            (int)(face.Width * adjustment.Width), (int)(face.Height * adjustment.Height));
        //        source.ROI = adjusted;
        //        var overlay = _hina.Resize(adjusted.Width, adjusted.Height, Inter.Area, false);

        //        var k = adjusted.Width / 8;
        //        if (k % 2 == 0) k++;
        //        source._SmoothGaussian(k);

        //        g.DrawImageUnscaled(overlay.Bitmap, source.ROI.X, source.ROI.Y);
        //        overlay.Dispose();
        //    }
        //    g.Dispose();
        //    source.ROI = Rectangle.Empty;
        //}

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Video|*.wmv;*.mp4;*.avi;*.mkv" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSource.Text = ofd.FileName;
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Video|*.wmv;*.mp4;*.avi;*.mkv" };
            var result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestination.Text = sfd.FileName;
            }
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            btnRender.Enabled = false;
            new Thread(() =>
            {
                var vc = new Capture(txtSource.Text);

                var vw = new VideoWriter(txtDestination.Text,
                    (int)vc.GetCaptureProperty(CapProp.Fps),
                    new Size((int)vc.GetCaptureProperty(CapProp.FrameWidth), (int)vc.GetCaptureProperty(CapProp.FrameHeight)),
                    true);

                int totalFrames = (int)vc.GetCaptureProperty(CapProp.FrameCount);
                int renderedFrames = 0;
                UMat lastFrame = null;
                Mat frame;

                while ((frame = vc.QuerySmallFrame()) != null && !IsDisposed)
                {
                    lastFrame?.Dispose();
                    lastFrame = frame.ToUMat(AccessType.Fast);
                    frame.Dispose();

                    DoHina(lastFrame, 1.1, 10, chkAnime.Checked ? FaceType.Anime : FaceType.Human);

                    using (var writeMat = lastFrame.ToMat(AccessType.Fast))
                        vw.Write(writeMat);

                    imageBoxRenderPreview.Image = lastFrame;
                    renderedFrames++;
                    if (renderedFrames % 15 == 0)
                    {
                        BeginInvoke((MethodInvoker) delegate
                        {
                            progressBarRender.Value = 100 * renderedFrames / totalFrames;
                        });
                    }
                }
                lastFrame?.Dispose();
                vw.Dispose();

                BeginInvoke((MethodInvoker)delegate
                {
                    btnRender.Enabled = true;
                    MessageBox.Show("Rendering completed", "AutoHinafier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });

            }).Start();
        }
    }

    enum FaceType
    {
        Human,
        Anime
    }
}
