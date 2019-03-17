using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Essential_Demo
{
    public class ShareDemo : ContentPage
    {
        private Button button_share;
        public ShareDemo()
        {
            button_share = new Button { Text = "Share" };
            button_share.Clicked += Button_share_Clicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "This is a Share Demo." }, button_share
                }
            };
        }

        private void Button_share_Clicked(object sender, EventArgs e)
        {
            ShareText("I am shared!", "Share Demo");
        }

        public async Task ShareText(string text, string title)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = title
            });
        }
    }
}