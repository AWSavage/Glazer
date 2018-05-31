using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;


namespace Glazer
{
    public sealed partial class MainPage : Page
    {
        double tempQuantity = 1;
        List<string> tintArray = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();

            tintArray.Add("None");
            tintArray.Add("Black");
            tintArray.Add("Brown");
            tintArray.Add("Blue");

            TintBox.ItemsSource = tintArray;

            TintBox.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(glassHeight.Text == "" || glassWidth.Text == "" || woodHeight.Text == "" || woodWidth.Text == "" ||
                !IsNumber(glassHeight.Text) || !IsNumber(glassWidth.Text) || !IsNumber(woodHeight.Text) || !IsNumber(woodWidth.Text))
            {
                ErrorBlock.Text = "ERROR: Every field must have a number to calculate";
            }
            else
            {
                ErrorBlock.Text = "";
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
            QuantityChoice.Text = tempQuantity.ToString();

        }

        private void Quantity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var slider = sender as Slider;
            tempQuantity = slider.Value;
            QuantitySelected.Text = tempQuantity.ToString();

        }


        private bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            return regex.IsMatch(text);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AreaSolution.Text = "0";
            LengthSolution.Text = "0";
            TintChoice.Text = "0";
            Date.Text = "0";
            QuantityChoice.Text = "0";
            ErrorBlock.Text = "";
            glassHeight.Text = "";
            glassWidth.Text = "";
            woodHeight.Text = "";
            woodWidth.Text = "";
            TintBox.SelectedIndex = 0;
            Quantity.Value = 0;
        }
    }
}
