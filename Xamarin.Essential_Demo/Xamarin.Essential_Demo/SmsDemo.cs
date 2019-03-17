using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Essential_Demo
{
	public class SmsDemo : ContentPage
	{
        private Label title;
        private Editor editor_textContent;
        private Entry entry_recipient1;
        private Entry entry_recipient2;
        private Button button_send;
        private Label label_result;

        public SmsDemo()
        {
            title = new Label { Text = "This is a SMS demo." };
            editor_textContent = new Editor { Placeholder = "Enter text here.", VerticalOptions = LayoutOptions.FillAndExpand };
            entry_recipient1 = new Entry { Placeholder = "Enter recipient 1 here." };
            entry_recipient2 = new Entry { Placeholder = "Enter recipient 2 here." };
            button_send = new Button { Text = "Send" };
            button_send.Clicked += Button_send_Clicked;
            label_result = new Label();

            Content = new StackLayout
            {
                Children = {
                    title,editor_textContent,entry_recipient1,entry_recipient2,button_send,label_result
                }
            };
        }

        private void Button_send_Clicked(object sender, EventArgs e)
        {
            string text;
            string recipient;
            string[] recipients = new string[2];

            if (!string.IsNullOrWhiteSpace(editor_textContent.Text) && !string.IsNullOrWhiteSpace(entry_recipient1.Text) && !string.IsNullOrWhiteSpace(entry_recipient2.Text))
            {
                text = editor_textContent.Text;
                recipients[0] = entry_recipient1.Text;
                recipients[1] = entry_recipient2.Text;
                SendSms2(text, recipients);
            }
            else if (!string.IsNullOrWhiteSpace(editor_textContent.Text) && !string.IsNullOrWhiteSpace(entry_recipient1.Text))
            {
                text = editor_textContent.Text;
                recipient = entry_recipient1.Text;
                SendSms1(text, recipient);
            }
            else
            {
                text = "";
                recipient = "";
                SendSms1(text, recipient);
            }


        }

        public async Task SendSms1(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
                label_result.Text = "Sms is not supported on this device";
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                label_result.Text = "Other error has occurred.";
            }
        }

        public async Task SendSms2(string messageText, string[] recipients)
        {
            try
            {
                var message = new SmsMessage(messageText, recipients);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
                label_result.Text = "Sms is not supported on this device";
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                label_result.Text = "Other error has occurred.";
            }
        }
    }
}