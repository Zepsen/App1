using App1.HelperClasses;
using Xamarin.Forms;

namespace App1.Views
{
    public class GenericsContent
    {
        public static Label GenerateMainLabel()
        {
            return new Label
            {
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                Text = "OUTDOOR.ROCKS",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center                
            };
        }

        public static Label GenerateGenericTextLabelWithDefaultSettings(string text, string text2 = null)
        {
            return new Label
            {
                Text = string.IsNullOrEmpty(text2) ? text : $"{text} {text2}",
                TextColor = DefaultAppStyles.DefaultTextColor,
                FontSize = DefaultAppStyles.DefaultFontSize,
                 
            };
        }
    }
}
