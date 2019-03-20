﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Essential_Demo
{
	public class TextToSpeechDemo : ContentPage
	{
        private Label title;
        private Label instructer1;
        private Slider slider_volume;
        private Label instructer2;
        private Slider slider_pitch;
        private Button button_speak;
        private Entry entry;

        // dont know how this works
        //private CancellationTokenSource cts;

        public TextToSpeechDemo()
        {
            title = new Label { Text = "This is a text to speech demo." };
            entry = new Entry { Placeholder = "input here text to speech" };
            entry.Completed += Button_speak_Clicked;
            button_speak = new Button { Text = "Text to speech" };
            button_speak.Clicked += Button_speak_Clicked;
            slider_volume = new Slider { Maximum = 1.0 };
            slider_pitch = new Slider { Maximum = 2.0 };
            slider_pitch.Value = 1.0;
            slider_volume.Value = 0.75;
            instructer1 = new Label { Text = "volume" };
            instructer2 = new Label { Text = "pitch" };

            Content = new StackLayout
            {
                Children = {
                    title,instructer1,slider_volume,instructer2,slider_pitch,entry,button_speak
                }
            };
        }

        private void Button_speak_Clicked(object sender, EventArgs e)
        {
            //SpeakNow();
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                SpeakNow((float)slider_volume.Value, (float)slider_pitch.Value, entry.Text);
            }
            else
            {
                SpeakNow((float)slider_volume.Value, (float)slider_pitch.Value, "Please enter something.");
            }
        }

        /// <summary>
        /// A method to speak
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="pitch"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task SpeakNow(float volume, float pitch, string text)
        {
            var locales = await TextToSpeech.GetLocalesAsync();
            Console.WriteLine(locales.ToString());

            // Grab the first locale
            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = volume,
                Pitch = pitch,
             //   Locale = locale ********************************************* dont know how locale works.
            };

            await TextToSpeech.SpeakAsync(text, settings);
        }

        //public async Task SpeakNow()
        //{
        //    var settings = new SpeechOptions()
        //    {
        //        Volume = (float).75,
        //        Pitch = (float) 1.0
        //    };

        //    await TextToSpeech.SpeakAsync("Hello World", settings);
        //}

        // dont know how this cancelation works
        //public void CancelSpeech()
        //{
        //    if (cts?.IsCancellationRequested ?? false)
        //        return;

        //    cts.Cancel();
        //}
    }
}