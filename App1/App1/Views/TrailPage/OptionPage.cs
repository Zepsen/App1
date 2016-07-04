using App1.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.Views.TrailPage
{
    public class OptionPage : ContentPage
    {
        private Option options;
        public OptionPage()
        {
            options = DbQueryAsync.GetOptions();
            Content = GenerateOptionLayout();
        }

        private ScrollView GenerateOptionLayout()
        {
            var stack = new StackLayout { Orientation = StackOrientation.Vertical };
              
            var table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new EntryCell { Keyboard = Keyboard.Numeric, Placeholder = "Peak" },
                    },
                    new TableSection
                    {
                        new EntryCell { Keyboard = Keyboard.Numeric, Placeholder = "Distance" }
                    },
                    
                    new TableSection
                    {
                        new SwitchCell {  Text = "Dog allowed" }
                    },
                    new TableSection
                    {
                        new SwitchCell {  Text = "Good for kids" }
                    }
                }
            };
            stack.Children.Add(table);

            var seasonStart = new Picker { Title = "SeasonStart" };
            foreach (var season in options.Seasons)
            {
                seasonStart.Items.Add(season.Value);
            }
            stack.Children.Add(seasonStart);

            var seasonEnd = new Picker { Title = "SeasonEnd" };
            foreach (var season in options.Seasons)
            {
                seasonEnd.Items.Add(season.Value);
            }
            stack.Children.Add(seasonEnd);

            var trailType = new Picker() { Title = "Trail Type" };
            stack.Children.Add(trailType);
            foreach (var type in options.TrailsTypes)
            {
                trailType.Items.Add(type.Value);
            }
            
            var trailDurationType = new Picker() { Title = "Trail Duration Type" };
            foreach (var durType in options.TrailsDurationTypes)
            {
                trailDurationType.Items.Add(durType.Value);
            }
            stack.Children.Add(trailDurationType);

            var button = GenericsContent.GenerateDefaultButton("Update");
            button.Clicked += (o, e) =>
            {

            };
            stack.Children.Add(button);

            return new ScrollView { Content = stack };
        }
    }
}
