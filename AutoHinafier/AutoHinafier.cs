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
        private Image<Bgr, Byte> _hina;

        private void AutoHinafier_Load(object sender, EventArgs e)
        {
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/lbpcascade_animeface.xml");
            _hina = new Image<Bgr, Byte>(Properties.Resources.Hinaface);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp;*.gif" };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var imageFrame = new Image<Bgr, Byte>(ofd.FileName);
                var grayframe = imageFrame.Convert<Gray, byte>();
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.08, 10, Size.Empty);
                
                foreach (var face in faces)
                {
                    Rectangle adjusted = new Rectangle(face.X + face.Width / 5, face.Y + face.Height / 5, face.Width * 3 / 5, face.Width * 3 / 5);
                    imageFrame.ROI = adjusted;
                    var overlay = _hina.Resize(adjusted.Width, adjusted.Height, Inter.Area, false);
                    var k = adjusted.Width / 8;
                    if (k % 2 == 0) k++;
                    imageFrame._SmoothGaussian(k);
                    imageFrame._And(overlay);
                    imageFrame.ROI = Rectangle.Empty;
                }
                imageFrame.ROI = Rectangle.Empty;
                imageBox.Image = imageFrame;
            }
        }
    }
}
