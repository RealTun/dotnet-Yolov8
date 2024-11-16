using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;
using Yolov8Net;
using PointF = SixLabors.ImageSharp.PointF;
using Color = SixLabors.ImageSharp.Color;
using System.Windows.Forms;

namespace WinformApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_detect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                InitialDirectory = Directory.GetCurrentDirectory()
            };


            string path = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            var yolo = YoloV8Predictor.Create(@"D:\Work\Report\job52\Yolov8.Net\WinformApp\assets\models\yolov8m.onnx");

            var image = SixLabors.ImageSharp.Image.Load<Rgba32>(path);
            var predictions = yolo.Predict(image);

            // random color for prediction
            //Random rand = new Random();
            //Rgba32[] colors = new Rgba32[predictions.Length];

            //for (int i = 0; i < predictions.Length; i++)
            //{
            //    colors[i] = new Rgba32((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)); // Random color
            //}

            int c = 0;
            foreach (var prediction in predictions)
            {
                // Draw a rectangle (bounding box) around the detected object
                var box = prediction.Rectangle;

                // Draw rectangle on the image
                image.Mutate(ctx => ctx.DrawPolygon(
                    Color.Red,
                    //colors[c++],    // Bounding box color
                    2,            // Line thickness
                    new PointF[]  // Rectangle corners
                    {
                    new PointF(box.Left, box.Top),        // Top-left
                    new PointF(box.Right, box.Top),       // Top-right
                    new PointF(box.Right, box.Bottom),    // Bottom-right
                    new PointF(box.Left, box.Bottom)      // Bottom-left
                    }
                ));

                // Optionally, you can also draw the label and confidence score
                var label = $"{prediction.Label.Name}: {prediction.Score:P2}";
                var font = SixLabors.Fonts.SystemFonts.CreateFont("Arial", 24);
                image.Mutate(ctx => ctx.DrawText(label, font, Color.White, new PointF(box.Left, box.Top - 30)));
            }

            MessageBox.Show("Nhận diện và vẽ ô thành công!");

            // Save the modified image with bounding boxes
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save an image file",
                Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
                MessageBox.Show("Xuất ảnh thành công!");
            }
        }
    }
}
