using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Essential_Demo
{
	public class VibrationDemo : ContentPage
	{
        private Label title;
        private Label result;
        private Entry entry;
        private Button button_vibrarte;
        public VibrationDemo()
        {
            title = new Label { Text = "This is a vibration demo" };
            result = new Label();
            entry = new Entry { Placeholder = "Enter how many seconds you want to vibrate" };
            entry.Completed += Button_vibrarte_Clicked;

            button_vibrarte = new Button
            {
                Text = "Vibrate once"
            };
            button_vibrarte.Clicked += Button_vibrarte_Clicked;

            Content = new StackLayout
            {
                Children = { title, entry, button_vibrarte, result }
            };
        }
        private void Button_vibrarte_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    // Use default vibration length
                    Vibration.Vibrate();
                }
                else
                {
                    // Or use specified time
                    double second = 0;
                    Double.TryParse(entry.Text, out second);
                    var duration = TimeSpan.FromSeconds(second);
                    Vibration.Vibrate(duration);
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                result.Text = "Feature not supported";
            }
            catch (Exception ex)
            {
                result.Text = "Other error has occurred";
            }
        }
    }
}