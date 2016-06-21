using App1.HelperClasses;
using App1.Models;
using Xamarin.Forms;

namespace App1.Views.TrailPage
{
    public class TrailPage : ContentPage
    {
        public TrailPage(string id)
        {
            var trail = DbQueryAsync.GetTrailById(id);
            var stackContainer = GenerateMainGrid(trail);
            Content =  stackContainer;
        }

        public Grid GenerateMainGrid(FullTrail trail)
        {
            var gridContainer = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = new GridLength(6, GridUnitType.Star)}
                },                
            };

            var mainLabel = GenericsContent.GenerateMainLabel();

            gridContainer.Children.Add(mainLabel, 0, 0);
            StackLayout stack = GenerateContentForTrailPage(trail);
            gridContainer.Children.Add(new ScrollView { Content = stack }, 0, 1);

            return gridContainer;
        }

        private StackLayout GenerateContentForTrailPage(FullTrail trail)
        {
            var stack = new StackLayout
            {                
                Padding = new Thickness(30, 0),                                
                BackgroundColor = Color.White                
            };

            var trailNameLabel = GenerateTrailNameLabel(trail.Name);
            var trailRateLabel = GenerateRateLabel(trail.Rate);
            var trailDescription = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.Description);
            var trailFullDescription = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.FullDescription);
            var trailWhyGo = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.WhyGo);
            var trailLocation = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.Region, trail.Country);
            var trailDifficult = GenerateDifficultLabel(trail.Difficult);


            stack.Children.Add(trailDifficult);
            stack.Children.Add(trailRateLabel);
            stack.Children.Add(trailNameLabel);
            stack.Children.Add(trailLocation);
            stack.Children.Add(trailDescription);
            stack.Children.Add(trailFullDescription);
            stack.Children.Add(trailWhyGo);

            return stack;
        }

        private Label GenerateTrailNameLabel(string name)
        {
            return new Label
            {
                Text = name,
                TextColor = DefaultAppStyles.DefaultTextColor,
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
            };
        }
        private Label GenerateRateLabel(double rate)
        {
            return new Label
            {
                Text = $"Rate: {rate.ToString("N1")}",
                TextColor = DefaultAppStyles.DefaultTextColor,
                FontSize = DefaultAppStyles.DefaultFontSize
            };
        }
        private Label GenerateDifficultLabel(string diff)
        {
            var backColor = DefaultAppStyles.GetColorForLableByDifficultData(diff);
            return new Label
            {
                Text = diff,
                TextColor = Color.White,
                BackgroundColor = backColor,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20     
            };
        }

    }
}
