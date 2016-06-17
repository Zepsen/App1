using Xamarin.Forms;

namespace App1.Views
{
    class TrailPage : ContentPage
    {
        public TrailPage(string id)
        {
            Content = new Grid
            {
                Children =
                {
                    new Label { Text = "Text" + id }
                }
            };
        }
    }
}
