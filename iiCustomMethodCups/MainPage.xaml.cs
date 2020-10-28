using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iiCustomMethodCups
{
    public partial class MainPage : ContentPage
    {
        // Make the conversion multiplier a constant
        const int CUPS_TO_OUNCES = 8;

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   Validate input, calculate cups to ounces, display results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvert_Clicked(object sender, EventArgs e)
        {
            // Store cups and ounces in a double
            double cups = 0, 
                   ounces = 0;

            // Check if cups is valid
            if (ValidCups(ref cups))
            {
                ounces = CupsToOunces(cups);
                DisplayResults(ounces);
            }
        }


        /// <summary>
        ///  Display the results of the calculation
        /// </summary>
        /// <param name="ounces"></param>
        private void DisplayResults(double ounces)
        {
            // Change the label text to display the results
            LblResults.Text = ounces.ToString("n1");
        }

        /// <summary>
        ///  convert cups to ounces
        /// </summary>
        /// <param name="cups"></param>
        /// <returns>value for ounces</returns>
        private double CupsToOunces(double cups)
        {
            double ounces = 0;
            ounces = cups * CUPS_TO_OUNCES;
            return ounces;
        }

        /// <summary>
        ///     Validate cups
        /// </summary>
        /// <param name="cups"></param>
        /// <returns></returns>
        private bool ValidCups(ref double cups)
        {
            // Make sure cups is a number, output and return true cups if valid, return false if not
            if (double.TryParse(EntryCups.Text, out cups)) return true;

            DisplayAlert("Invalid Input", "Enter a number for cups", "Close");

            return false;
        }
    }
}
