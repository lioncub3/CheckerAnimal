using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVisionApp
{
    public partial class Form1 : Form
    {

        // subscriptionKey = "0123456789abcdef0123456789ABCDEF"
        private const string subscriptionKey = "17aee88adf394be9b7d1141f805c49cb";

        // localImagePath = @"C:\Documents\LocalImage.jpg"
        private const string localImagePath = @"<LocalImage>";

        private const string remoteImageUrl =
            "https://upload.wikimedia.org/wikipedia/commons/3/3c/Shaki_waterfall.jpg";

        // Specify the features to return
        private List<VisualFeatureTypes> features = new List<VisualFeatureTypes>()
        {
            // VisualFeatureTypes.Description
            //, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags,
            VisualFeatureTypes.Objects
        };

        ComputerVisionClient computerVision;

        public Form1()
        {
            InitializeComponent();

            computerVision = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            // Specify the Azure region
            computerVision.Endpoint = "https://superchecker.cognitiveservices.azure.com/";
        }

        // Analyze a remote image
        private async Task AnalyzeRemoteAsync(string imageUrl)
        {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                MessageBox.Show("Invalid remoteImageUrl:\n{0}", imageUrl);
                return;
            }

            ImageAnalysis analysis = await computerVision.AnalyzeImageAsync(imageUrl, features);
            DisplayResults(analysis, imageUrl);
        }

        // Display the most relevant caption for the image
        private void DisplayResults(ImageAnalysis analysis, string imageUri)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(imageUri);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            ms.Close();
            if (analysis.Objects.Any(o => o.ObjectProperty == "animal"))
            {
                MessageBox.Show("Увага тварина!");
                using (Graphics g = Graphics.FromImage(img))
                {
                    BoundingRect animalRectangle = analysis.Objects.First(o => o.ObjectProperty == "animal").Rectangle;
                    g.DrawRectangle(new Pen(Color.Red), new Rectangle(animalRectangle.X, animalRectangle.Y, animalRectangle.W, animalRectangle.H));
                }
            }
            else
            {
                if (analysis.Objects.Any(o => o.Parent != null))
                {
                    List<DetectedObject> childObjects = analysis.Objects.Where(o => o.Parent != null).ToList();
                    List<ObjectHierarchy> parentObject = new List<ObjectHierarchy>();
                    foreach (var detectedObject in childObjects)
                    {
                        parentObject.Add(detectedObject.Parent);
                    }

                    if (checkedAnimal(parentObject))
                    {
                        MessageBox.Show("Увага тварина!");

                        using (Graphics g = Graphics.FromImage(img))
                        {
                            List<DetectedObject> animalObjects = new List<DetectedObject>();


                            foreach (var item in childObjects)
                            {
                                if (checkedAnimal(new List<ObjectHierarchy>() { item.Parent }))
                                {
                                    BoundingRect animalRectangle = item.Rectangle;
                                    g.DrawRectangle(new Pen(Color.Red), new Rectangle(animalRectangle.X, animalRectangle.Y, animalRectangle.W, animalRectangle.H));
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Усе безпечно");
                }
            }

            pictureBox1.Image = img;
        }

        private bool checkedAnimal(List<ObjectHierarchy> objects)
        {
            if (objects.Any(o => o.ObjectProperty == "animal"))
            {
                return true;
            }
            else
            {
                if (objects.Any(o => o.Parent != null))
                {
                    List<ObjectHierarchy> childObjects = objects.Where(o => o.Parent != null).ToList();
                    List<ObjectHierarchy> parentObject = new List<ObjectHierarchy>();
                    foreach (var detectedObject in childObjects)
                    {
                        parentObject.Add(detectedObject.Parent);
                    }
                    if (checkedAnimal(parentObject))
                        return true;
                }
                return false;
            }
        }

        private async void ButtonScan_Click(object sender, EventArgs e)
        {
            await AnalyzeRemoteAsync(textBoxLink.Text);
        }
    }
}
