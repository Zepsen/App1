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
            var gridContainer = GenerateMainGrid(trail);
            Content =  gridContainer;            
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
                BackgroundColor = Color.White,

            };

            var trailNameLabel = GenerateTrailNameLabel(trail.Name);
            var trailRateLabel = GenerateRateLabel(trail.Rate);
            var trailDescription = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.Description);
            var trailFullDescription = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.FullDescription);
            var trailWhyGo = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.WhyGo);
            var trailLocation = GenericsContent.GenerateGenericTextLabelWithDefaultSettings(trail.Region, trail.Country);
            var trailDifficult = GenerateDifficultLabel(trail.Difficult);
            Grid table = GenerateTableForOptions(trail);

            stack.Children.Add(trailDifficult);
            stack.Children.Add(trailRateLabel);
            stack.Children.Add(trailNameLabel);
            stack.Children.Add(trailLocation);
            stack.Children.Add(trailDescription);
            stack.Children.Add(trailFullDescription);
            stack.Children.Add(trailWhyGo);
            stack.Children.Add(table);

            return stack;
        }

        private Grid GenerateTableForOptions(FullTrail trail)
        {
            var table = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                },

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                }
            };

            table.Children.Add(GenerateLabelForTableColumn("Distance:"), 0, 0);
            table.Children.Add(GenerateLabelForTableValue(trail.Distance.ToString()), 1, 0);

            table.Children.Add(GenerateLabelForTableColumn("Peak:"), 0, 1);
            table.Children.Add(GenerateLabelForTableValue(trail.Peak.ToString()), 1, 1);

            table.Children.Add(GenerateLabelForTableColumn("Season start:"), 0, 2);
            table.Children.Add(GenerateLabelForTableValue(trail.SeasonStart), 1, 2);

            table.Children.Add(GenerateLabelForTableColumn("Season end:"), 0, 3);
            table.Children.Add(GenerateLabelForTableValue(trail.SeasonEnd), 1, 3);

            table.Children.Add(GenerateLabelForTableColumn("Good For Kids:"), 2, 0);
            table.Children.Add(GenerateLabelForTableValue(trail.GoodForKids.ToString()), 3, 0);

            table.Children.Add(GenerateLabelForTableColumn("Dog Allowed:"), 2, 1);
            table.Children.Add(GenerateLabelForTableValue(trail.DogAllowed.ToString()), 3, 1);

            table.Children.Add(GenerateLabelForTableColumn("Type:"), 2, 2);
            table.Children.Add(GenerateLabelForTableValue(trail.Type), 3, 2);

            table.Children.Add(GenerateLabelForTableColumn("Duration Type:"), 2, 3);
            table.Children.Add(GenerateLabelForTableValue(trail.DurationType), 3, 3);
            
            return table;
        }
        
        private Label GenerateLabelForTableColumn(string columnName)
        {
            return new Label
            {
                Text = columnName,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = DefaultAppStyles.DefaultTextColor,
                HorizontalTextAlignment = TextAlignment.Center,
            };
        }
        private Label GenerateLabelForTableValue(string value)
        {
            return new Label
            {
                Text = value,
                HorizontalOptions = LayoutOptions.Center,                
                TextColor = DefaultAppStyles.DefaultTextColor,
                HorizontalTextAlignment = TextAlignment.Center
            };
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
