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
                        new EntryCell { Keyboard = Keyboard.Numeric, Placeholder = nameof(Option.Peak) },
                    },
                    new TableSection
                    {
                        new EntryCell { Keyboard = Keyboard.Numeric, Placeholder = nameof(Option.Distance) }
                    },
                    new TableSection
                    {
                        new EntryCell { Keyboard = Keyboard.Numeric, Placeholder = nameof(Option.SeasonStart) }
                    },
                    new TableSection
                    {
                        new EntryCell { Keyboard = Keyboard.Text, Placeholder = nameof(Option.SeasonEnd) }
                    },
                    new TableSection
                    {
                        new SwitchCell {  Text = nameof(Option.DogAllowed) }
                    },
                    new TableSection
                    {
                        new SwitchCell {  Text = nameof(Option.GoodForKids) }
                    }
                }
            };
            stack.Children.Add(table);

            var trailType = new Picker() { Title = "Trail Type" };
            stack.Children.Add(trailType);
            trailType.Items.Add("Asd1");            

            var trailDurationType = new Picker() { Title = "Trail Duration Type" };
            trailDurationType.Items.Add("Asd2");
            stack.Children.Add(trailDurationType);

            return new ScrollView { Content = stack };
        }
    }
}
