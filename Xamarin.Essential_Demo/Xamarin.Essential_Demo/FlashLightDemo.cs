﻿using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Xamarin.Essential_Demo
{
    public class FlashLightDemo : ContentPage
    {
        Label header;
        Button button1;
        Button button2;

        public FlashLightDemo()
        {
            header = new Label
            {
                Text = "FlashLight",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            button1 = new Button
            {
                Text = "On",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                CornerRadius = 10
            };
            button1.Clicked += OnButtonClicked1Async;

            button2 = new Button
            {
                Text = "Off",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                CornerRadius = 10
            };
            button2.Clicked += OnButtonClicked2Async;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header, button1, button2
                }
            };
        }

        async void OnButtonClicked1Async(object sender, EventArgs e)
        {
            try
            {
                // Turn On
                await Flashlight.TurnOnAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception  
                Console.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
                Console.WriteLine(ex);
            }
        }

        async void OnButtonClicked2Async(object sender, EventArgs e)
        {
            try
            {
                // Turn Off
                await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
                Console.WriteLine(ex);
            }
        }
    }
}