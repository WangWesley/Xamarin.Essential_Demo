using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Xamarin.Essential_Demo
{
    public class AccelerometerDemo : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        Button button;
        Label label;

        public AccelerometerDemo()
        {
            Label header = new Label
            {
                Text = "Accelerometer",
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
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

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
            ToggleAccelerometer();
            button.Text = String.Format("{0}", Accelerometer.IsMonitoring == true ? "Stop" : "Start");
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            label.Text = String.Format("X: {0,0:F4} G\nY: {1,0:F4} G\nZ: {2,0:F4} G", data.Acceleration.X, data.Acceleration.Y, data.Acceleration.Z);
            // Process Acceleration X, Y, and Z
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Console.WriteLine(fnsEx);
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                Console.WriteLine(ex);
            }
        }
    }
}