using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Xamarin.Essential_Demo
{
    public class CompassDemo : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        Button button;
        Label label;

        public CompassDemo()
        {
            Label header = new Label
            {
                Text = "Compass",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            button = new Button
            {
                Text = "Start",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                CornerRadius = 10
            };

            button.Clicked += OnButtonClicked;
            // Register for reading changes, be sure to unsubscribe when finished
            Compass.ReadingChanged += Compass_ReadingChanged;

            label = new Label
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header, button, label
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            ToggleCompass();
            button.Text = String.Format("{0}", Compass.IsMonitoring == true ? "Stop" : "Start");
        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;
            // Process Heading Magnetic North
            Console.WriteLine($"Reading: {data.HeadingMagneticNorth} degrees");
            label.Text = String.Format("HeadingMagneticNorth:\n{0,0:F1} degrees", data.HeadingMagneticNorth);
        }

        public void ToggleCompass()
        {
            try
            {
                if (Compass.IsMonitoring)
                    Compass.Stop();
                else
                    Compass.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}