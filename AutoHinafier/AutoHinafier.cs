using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private CascadeClassifier _cascadeClassifier;
        private Image<Bgra, Byte> _hina;

        private void AutoHinafier_Load(object sender, EventArgs e)
        {
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            _hina = new Image<Bgra, Byte>(Properties.Resources.Hinaface);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp;*.gif" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var imageFrame = new Image<Bgra, Byte>(ofd.FileName);
                var grayframe = imageFrame.Convert<Gray, byte>();
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                
                foreach (var face in faces)
                {
                    Rectangle adjusted;
                    if (chkAnime.Checked)
                        adjusted = new Rectangle(face.X + face.Width / 5, face.Y + face.Height / 5, face.Width * 3 / 5, face.Width * 3 / 5);
                    else
                        adjusted = new Rectangle(face.X + face.Width / 8, face.Y + face.Height / 8, face.Width * 6 / 8, face.Width * 6 / 8);
                    imageFrame.ROI = adjusted;
                    var overlay = _hina.Resize(adjusted.Width, adjusted.Height, Inter.Area, false);
                    var k = adjusted.Width / 8;
                    if (k % 2 == 0) k++;
                    imageFrame._SmoothGaussian(k);
                    imageFrame._And(overlay);
                    imageFrame.ROI = Rectangle.Empty;
                }
                imageBox.Image = imageFrame;
            }
        }

        private void chkHuman_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAnime.Checked)
                _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/lbpcascade_animeface.xml");
            else
                _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
        }
    }
}
