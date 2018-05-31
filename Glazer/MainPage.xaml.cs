using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Glazer
{
    public sealed partial class MainPage : Page
    {

        List<string> tintArray = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();

            tintArray.Add("Black");
            tintArray.Add("Brown");
            tintArray.Add("Blue");

            TintBox.ItemsSource = tintArray;

            TintBox.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(glassHeight.Text == "" || glassWidth.Text == "" || woodHeight.Text == "" || woodWidth.Text == "")
            {
                //error
            }
            else
            {
                compute();
            }
        }

        public void compute()
        {
            double gHeight, gWidth, wHeight, wWidth, gArea, wLength;

            gHeight = double.Parse(glassHeight.Text);
            gWidth = double.Parse(glassWidth.Text);
            wHeight = double.Parse(woodHeight.Text);
            wWidth = double.Parse(woodWidth.Text);

            gArea = 2 * (gHeight + gWidth);
            wLength = 2 * (wHeight + wWidth) * 3.25;

            var tint = TintBox.SelectedValue;
            var today = DateTime.Now.ToString("MM/dd/yyyy");

            AreaSolution.Text = gArea.ToString();
            LengthSolution.Text = wLength.ToString();
            TintChoice.Text = tint.ToString();
            Date.Text = today;

        }
    }
}
