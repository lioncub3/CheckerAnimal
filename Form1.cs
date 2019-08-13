using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVisionApp
{
    public partial class Form1 : Form
    {

        // subscriptionKey = "0123456789abcdef0123456789ABCDEF"
        private const string subscriptionKey = "7801552db9cd438a8839d5a219efc8a0";

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
            computerVision.Endpoint = "https://mytest-vision.cognitiveservices.azure.com/";
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
            if (analysis.Objects.Any(o => o.Parent.Parent.Parent.ObjectProperty == "animal"))
                MessageBox.Show("Увага тварина!");
            else
                MessageBox.Show("Усе безпечно");

        }

        private async void ButtonScan_Click(object sender, EventArgs e)
        {
            await AnalyzeRemoteAsync(textBoxLink.Text);
        }
    }
}
