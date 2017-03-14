using System;
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

        private Image<Bgra, byte> _hina;

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
            _hina = new Image<Bgra, byte>(Properties.Resources.Hinaface);
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp;*.gif" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var imageFrame = new Image<Bgr, byte>(ofd.FileName);
                DoHina(imageFrame, 3, chkAnime.Checked ? FaceType.Anime : FaceType.Human);
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

        private void DoHina(Image<Bgr, byte> source, int sensitivity, FaceType type)
        {
            CascadeClassifier classifier;
            if (CascadeClassifiers.ContainsKey(type))
                classifier = CascadeClassifiers[type];
            else return;

            var adjustment = AdjustmentFactor[type];
            var faces = classifier.DetectMultiScale(source, 1.1, sensitivity, Size.Empty);
            var bitm = source.Bitmap;
            Graphics g = Graphics.FromImage(bitm);
            g.InterpolationMode = InterpolationMode.Low;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.TextRenderingHint = TextRenderingHint.SystemDefault;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            foreach (var face in faces)
            {
                Rectangle adjusted = new Rectangle(
                    (int)(face.X + face.Width * adjustment.X), (int)(face.Y + face.Height * adjustment.Y),
                    (int)(face.Width * adjustment.Width), (int)(face.Height * adjustment.Height));
                source.ROI = adjusted;
                var overlay = _hina.Resize(adjusted.Width, adjusted.Height, Inter.Area, false);

                var k = adjusted.Width / 8;
                if (k % 2 == 0) k++;
                source._SmoothGaussian(k);

                g.DrawImageUnscaled(overlay.Bitmap, source.ROI.X, source.ROI.Y);
                overlay.Dispose();
            }
            g.Dispose();
            source.ROI = Rectangle.Empty;
        }

        private Image<Bgr, byte> ActiveFrame;
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
            var img = mat.ToImage<Bgr, byte>();
            ActiveFrame = img.Resize(500, 500, Inter.Nearest, true);
            img.Dispose();
            mat.Dispose();

            DoHina(ActiveFrame, 3, chkAnime.Checked ? FaceType.Anime : FaceType.Human);
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
                    ThreadWait = (int) (1000 / VideoCapture.GetCaptureProperty(CapProp.Fps));
                    if(Time != null)
                        Time.Start();
                    VideoPlaying = true;
                    LastTick = 0;
                    new Thread(() =>
                    {
                        while (VideoPlaying)
                        {
                            VideoTick();
                            var pass = Time.ElapsedMilliseconds - LastTick;
                            LastTick = Time.ElapsedMilliseconds;
                            Thread.Sleep((int) Math.Max(0, ThreadWait - pass));
                        }
                    }).Start();
                }
            }
        }

    }

    enum FaceType
    {
        Human,
        Anime
    }
}
