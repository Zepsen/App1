using App1.Models;
using Xamarin.Forms;

namespace App1.Views
{
    class TrailPage : ContentPage
    {
        private readonly int pageDefaultFontSize = 18;
        private readonly Color pageDefaultFontColor = Color.Black;
        
        public TrailPage(string id)
        {
            var trail = DbQueryAsync.GetTrailById(id);
            StackLayout stackContainer = GenerateStackContainer(trail);
            Content = new ScrollView { Content = stackContainer };           
        }

        private StackLayout GenerateStackContainer(Trails trail)
        {
            StackLayout stackContainer = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
                //Padding = new Thickness(10, 10)                          
            };

            Label mainLabel = GenericsContent.GenerateMainLabel();
            stackContainer.Children.Add(mainLabel);

            Label rateLabel = new Label
            {
                Text = $"Rate {trail.Rate.ToString("N1")}",
                FontSize = pageDefaultFontSize,
                TextColor = pageDefaultFontColor
            };
            stackContainer.Children.Add(rateLabel);

            Label trailName = new Label
            {
                Text = trail.Name,
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                TextColor = pageDefaultFontColor
            };
            stackContainer.Children.Add(trailName);

            Label locationLabel = new Label
            {
                Text = $"{trail.Region} {trail.Country}",
                FontSize = pageDefaultFontSize,
                TextColor = pageDefaultFontColor
            };
            stackContainer.Children.Add(locationLabel);
                        
            //var map = new Map(
            //MapSpan.FromCenterAndRadius(
            //        new Position(37, -122), Distance.FromMiles(0.3)))
            //{
            //    IsShowingUser = true,
            //    HeightRequest = 100,
            //    WidthRequest = 960,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //stackContainer.Children.Add(map);
                        
            return stackContainer;
        }
    }
}
