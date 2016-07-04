using App1.Models;
using App1.Models.HelperModel;
using App1.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.Views.TrailPage
{
    public class OptionPage : ContentPage
    {
        private Option options;       
        public OptionPage(string id)
        {
            options = DbQueryAsync.GetOptions();
            BindingContext = new OptionViewModel(id, options);                        
            Content = GenerateOptionLayout();
        }
        
        private ScrollView GenerateOptionLayout()
        {
            var stack = new StackLayout { Orientation = StackOrientation.Vertical };

            var peak = new Entry { Keyboard = Keyboard.Numeric, Placeholder = "Peak" };
            peak.SetBinding(Entry.TextProperty, OptionViewModel.PeakCommandPropertyName);
            stack.Children.Add(peak);
            
            var distance = new Entry { Keyboard = Keyboard.Numeric, Placeholder = "Distance" };
            distance.SetBinding(Entry.TextProperty, OptionViewModel.DistanceCommandPropertyName);
            stack.Children.Add(distance);

            var dogAllowed = new Switch();
            dogAllowed.SetBinding(Switch.IsToggledProperty, OptionViewModel.DogAllowedCommandPropertyName);
            stack.Children.Add(dogAllowed);

            var goodForKids = new Switch();
            goodForKids.SetBinding(Switch.IsToggledProperty, OptionViewModel.GoodForKidsCommandPropertyName);
            stack.Children.Add(goodForKids);

            var seasonStart = new Picker { Title = "SeasonStart" };
            foreach (var season in options.Seasons)
            {
                seasonStart.Items.Add(season.Value);
            }
            seasonStart.SetBinding(Picker.SelectedIndexProperty, OptionViewModel.SeasonStartCommandPropertyName);
            stack.Children.Add(seasonStart);

            var seasonEnd = new Picker { Title = "SeasonEnd" };
            foreach (var season in options.Seasons)
            {
                seasonEnd.Items.Add(season.Value);
            }
            seasonEnd.SetBinding(Picker.SelectedIndexProperty, OptionViewModel.SeasonEndCommandPropertyName);
            stack.Children.Add(seasonEnd);

            var trailType = new Picker() { Title = "Trail Type" };
            stack.Children.Add(trailType);
            foreach (var type in options.TrailsTypes)
            {
                trailType.Items.Add(type.Value);
            }
            trailType.SetBinding(Picker.SelectedIndexProperty, OptionViewModel.TypeCommandPropertyName);

            var trailDurationType = new Picker() { Title = "Trail Duration Type" };
            foreach (var durType in options.TrailsDurationTypes)
            {
                trailDurationType.Items.Add(durType.Value);
            }
            trailDurationType.SetBinding(Picker.SelectedIndexProperty, OptionViewModel.DurationTypeCommandPropertyName);
            stack.Children.Add(trailDurationType);

            var button = GenericsContent.GenerateDefaultButton("Update");
            button.SetBinding(Button.CommandProperty, OptionViewModel.UpdateCommandPropertyName);            
            stack.Children.Add(button);

            return new ScrollView { Content = stack };
        }
    }
}
