using App1.Views;
using System;
using Xamarin.Forms;

namespace App1
{
    class MainPage : ContentPage
    {
        public MainPage()
        {
            var gridContainer = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(6, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                }
            };

            var label = new Label
            {
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                Text = "OUTDOOR.ROCKS",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            //TRAILS
            var gridTrails = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    //new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },

                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    //new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            var listOfTrails = DbQueryAsync.GetTrails();



            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Create Container            
                    var rel = new RelativeLayout();
                    var stack = new Grid
                    {
                        RowDefinitions =
                        {
                            new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                            new RowDefinition {Height = new GridLength(3, GridUnitType.Star)},
                            new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                        },

                        ColumnDefinitions =
                        {
                            new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                            new ColumnDefinition {Width = new GridLength(3, GridUnitType.Star)},
                            new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                        }
                    };

                    //Add events for tap on TRAIL
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += (object obj, EventArgs e) =>
                    {
                        var id = ((obj as Grid).Children[0] as Label).Text;
                        Navigation.PushAsync(new TrailPage(id));
                    };
                    stack.GestureRecognizers.Add(tap);

                    //Image Style
                    var backgroundImage = new Image()
                    {
                        Source = ImageSource.FromFile("trails.jpg"),
                        Aspect = Aspect.AspectFill,
                        IsOpaque = true,
                        Opacity = 0.8,
                    };

                    //TRAILS CONTENT
                    if (listOfTrails.Count > count)
                    {
                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Id,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            BackgroundColor = new Color(0, 8, 0, 0.5)
                        }, 0, 2);

                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Name,
                            VerticalTextAlignment = TextAlignment.Start,
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 16
                        }, 1, 1);

                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Difficult,                            
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            BackgroundColor = new Color(0, 8, 0, 0.5)
                        }, 0, 0);

                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Rate.ToString("N1"),                            
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            BackgroundColor = new Color(0, 8, 0, 0.5)
                        }, 2, 0);

                        rel.Children.Add(
                                backgroundImage,
                                Constraint.Constant(0),
                                Constraint.Constant(0),
                                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                Constraint.RelativeToParent((parent) => { return parent.Height; }));

                        rel.Children.Add(
                                stack,
                                Constraint.Constant(0),
                                Constraint.Constant(0),
                                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                Constraint.RelativeToParent((parent) => { return parent.Height; }));

                        gridTrails.Children.Add(rel, i, j);
                        count++;
                    }
                }
            }


            //BUTTON
            var button = new Button
            {
                Text = "More",
                BackgroundColor = Color.Green,
                TextColor = Color.White
            };

            button.Clicked += (object sender, EventArgs e) =>
            {
                //Navigation.PushAsync(new TrailPage());
            };
            //button.SetBinding(Button.CommandProperty, nameof(TrailsViewModel.GetTrails));


            gridContainer.Children.Add(label, 0, 0);
            gridContainer.Children.Add(gridTrails, 0, 1);
            gridContainer.Children.Add(button, 0, 2);

            Content = gridContainer;
        }



    }
}
