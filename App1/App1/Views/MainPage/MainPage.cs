using App1.HelperClasses;
using App1.Views;
using App1.Views.TrailPage;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    class MainPage : ContentPage
    {
        public MainPage()
        {
            Grid gridContainer = GenerateGridContainer();
            Content = gridContainer;
        }

        private Grid GenerateGridContainer()
        {
            var gridContainer = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = new GridLength(6, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                }
            };

            Label label = GenericsContent.GenerateMainLabel();
            Grid gridTrails = GenerateGridOfTrails();
            Button button = GenerateButton();

            gridContainer.Children.Add(label, 0, 0);
            gridContainer.Children.Add(new ScrollView { Content = gridTrails }, 0, 1);
            gridContainer.Children.Add(button, 0, 2);

            return gridContainer;
        }

        private Grid GenerateGridOfTrails()
        {
            var listOfTrails = DbQueryAsync.GetTrails();
            var trailsCount = listOfTrails.Count % 2 == 0 ? listOfTrails.Count / 2 : listOfTrails.Count / 2 + 1;

            var rowDefinitionsCollection = new RowDefinitionCollection();
            for (int i = 0; i < trailsCount; i++)
            {
                rowDefinitionsCollection.Add(new RowDefinition { Height = 200 });
            }

            var gridTrails = new Grid
            {
                RowDefinitions = rowDefinitionsCollection,
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < trailsCount; j++)
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

                    //TRAILS CONTENT
                    if (listOfTrails.Count > count)
                    {
                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Id,
                            IsVisible = false
                            
                        }, 0, 2);

                        //Image Style
                        var backgroundImage = new Image()
                        {
                            Source = ImageSource.FromFile(listOfTrails[count].CoverPhoto),
                            Aspect = Aspect.AspectFill,
                            IsOpaque = true,
                            Opacity = 0.8,
                        };

                        StackLayout icons = SetIconsToTrail(listOfTrails[count]);
                        stack.Children.Add(icons, 1, 2);

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
                            BackgroundColor = DefaultAppStyles.GetColorForLableByDifficultData(listOfTrails[count].Difficult)
                        }, 0, 0);

                        stack.Children.Add(new Label
                        {
                            Text = listOfTrails[count].Country,
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

            return gridTrails;
        }

        private StackLayout SetIconsToTrail(Models.Trail trail)
        {
            var icons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand                      
            };

            if (trail.DogAllowed)
                icons.Children.Add(DefaultAppStyles.CreateIcon("icon_white_dog_freindly.png"));

            if (trail.GoodForKids)
                icons.Children.Add(DefaultAppStyles.CreateIcon("icon_white_good_for_kids.png"));

            return icons;
        }

        private static Button GenerateButton()
        {
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
            return button;
        }
    }
}
