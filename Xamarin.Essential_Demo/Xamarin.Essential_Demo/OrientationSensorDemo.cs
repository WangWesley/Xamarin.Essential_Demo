using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Xamarin.Essential_Demo
{
    public class OrientationSensorDemo : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        Button button;
        Label label;

        public OrientationSensorDemo()
        {
            Label header = new Label
            {
                Text = "OrientationSensor",
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
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;

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
            ToggleOrientationSensor();
            button.Text = String.Format("{0}", OrientationSensor.IsMonitoring == true ? "Stop" : "Start");
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;
            // Process Orientation quaternion (X, Y, Z, and W)
            Console.WriteLine($"Reading: X: {data.Orientation.X}, Y: {data.Orientation.Y}, Z: {data.Orientation.Z}, W: {data.Orientation.W}");
            label.Text = String.Format("X: {0,0:F4} \nY: {1,0:F4} \nZ: {2,0:F4} \nW: {3,0:F4}", data.Orientation.X, data.Orientation.Y, data.Orientation.Z, data.Orientation.W);
        }

        public void ToggleOrientationSensor()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                    OrientationSensor.Stop();
                else
                    OrientationSensor.Start(speed);
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