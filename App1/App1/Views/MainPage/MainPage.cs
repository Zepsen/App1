using App1.HelperClasses;
using App1.Models;
using App1.Views;
using App1.Views.TrailPage;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App1
{
    class MainPage : ContentPage
    {
        private Grid mainGridContainer = null;
        private List<Trail> trails = null;
        private List<Location> locations = null;
        int Paggination = 4;
        string Filter = "All";

        public MainPage()
        {
            trails = DbQueryAsync.GetTrails();
            locations = DbQueryAsync.GetLocations().OrderBy(i => i.Region).ToList();
            
            Content = GenerateGridContainer();
        }
        
        private Grid GenerateGridContainer()
        {            
            mainGridContainer = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 30 },
                    new RowDefinition {Height = new GridLength(6, GridUnitType.Star)}                  
                }
            };
            
            mainGridContainer.Children.Add(GenericsContent.GenerateMainLabel(), 0, 0);
            mainGridContainer.Children.Add(GenerateFilterMenu(locations), 0, 1);
            mainGridContainer.Children.Add(GenerateGridOfTrails(), 0, 2);
            
            return mainGridContainer;
        }

        private StackLayout GenerateFilterMenu(List<Location> locations)
        {
            var stack = new StackLayout { Orientation = StackOrientation.Horizontal };

            var allLabel = GenericsContent.GenerateFilterLabels(Filter);
            AddTapForFilter(allLabel);
            stack.Children.Add(allLabel);
            
            foreach (var item in locations)
            {
                var label = GenericsContent.GenerateFilterLabels(item.Region);
                AddTapForFilter(label);
                stack.Children.Add(label);
            }
            
            return stack;
        }

        private ScrollView GenerateGridOfTrails()
        {
            var listOfTrails = GetListOfTrailsByFilter();
            var trailsCount = GetTrailsCountForGrid(listOfTrails.Count);
            var rowDefinitionsCollection = InitRowDefinitionCollectionByCount(trailsCount);

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

                    AddTapForTrail(stack);

                    if (listOfTrails.Count > count && count < Paggination)
                    {
                        stack.Children.Add(GenerateHiddenlabelById(listOfTrails[count].Id), 0, 2);
                        stack.Children.Add(GenerateDifficultLabelByMainPage(listOfTrails[count].Difficult), 0, 0);
                        stack.Children.Add(GenerateTrailNameByMainPage(listOfTrails[count].Name), 1, 1);
                        var icons = SetIconsToTrail(listOfTrails[count]);
                        stack.Children.Add(icons, 1, 2);

                        rel.Children.Add(
                                CreateCoverPhotoByTrail(listOfTrails[count].CoverPhoto),
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

            var btn = GenerateButtonMore();
            gridTrails.Children.Add(btn, 0, count);
            Grid.SetColumnSpan(btn, 2);            
            return new ScrollView { Content = gridTrails };
        }

        private Button GenerateButtonMore()
        {
            var btn = new Button { Text = "More", BackgroundColor = DefaultAppStyles.DefaultMainBackColor };
            AddClickToMoreButton(btn);
            btn.IsVisible = (trails.Count > Paggination) ? true : false;
            return btn;
        }

        private void AddClickToMoreButton(Button btn)
        {
            btn.Clicked += (object obj, EventArgs e) =>
            {
                if (trails.Count > Paggination)
                {
                    Paggination += 4;                                        
                }
                               
                mainGridContainer.Children.RemoveAt(2);
                mainGridContainer.Children.Add(GenerateGridOfTrails(), 0, 2);
            };
        }

        private static Label GenerateHiddenlabelById(string id)
        {
            return new Label
            {
                Text = id,
                IsVisible = false
            };
        }

        private static Label GenerateDifficultLabelByMainPage(string difficult)
        {
            return new Label
            {
                Text = difficult,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = GenericsContent.GetColorForLableByDifficultData(difficult)
            };
        }

        private static Label GenerateTrailNameByMainPage(string name)
        {
            return new Label
            {
                Text = name,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                BackgroundColor = new Color(0, 0, 0, 0.2)
            };
        }

        private static Image CreateCoverPhotoByTrail(string coverPhoto)
        {            
            return new Image()
            {
                Source = ImageSource.FromFile(coverPhoto),
                Aspect = Aspect.AspectFill,
                IsOpaque = true,
                Opacity = 0.8,
            };
        }

        private void AddTapForTrail(Grid stack)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (object obj, EventArgs e) =>
            {
                var id = ((obj as Grid).Children[0] as Label).Text;
                Navigation.PushAsync(new TrailPage(id));
            };
            stack.GestureRecognizers.Add(tap);
        }

        private void AddTapForFilter(Label label)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (object obj, EventArgs e) =>
            {
                Filter = (obj as Label).Text;
                Paggination = 4;
                mainGridContainer.Children.RemoveAt(2);
                mainGridContainer.Children.Add(GenerateGridOfTrails(), 0, 2);
            };
            label.GestureRecognizers.Add(tap);
        }

        private List<Trail> GetListOfTrailsByFilter()
        {
            var listOfTrails = new List<Trail>();
            if (Filter != "All")
            {
                listOfTrails.AddRange(trails.Where(i => i.Region == Filter));
            }
            else
            {
                listOfTrails.AddRange(trails);
            }

            return listOfTrails;
        }

        private static RowDefinitionCollection InitRowDefinitionCollectionByCount(int trailsCount)
        {
            var rowDefinitionsCollection = new RowDefinitionCollection();
            for (int i = 0; i < trailsCount; i++)
            {
                rowDefinitionsCollection.Add(new RowDefinition { Height = 200 });
            }
            rowDefinitionsCollection.Add(new RowDefinition { Height = 50 });

            return rowDefinitionsCollection;
        }

        private static int GetTrailsCountForGrid(int count)
        {
            return count % 2 == 0 ? count / 2 
                                  : count / 2 + 1;
        }

        private StackLayout SetIconsToTrail(Trail trail)
        {
            var icons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            if (trail.DogAllowed)
                icons.Children.Add(GenericsContent.CreateIcon("icon_white_dog_freindly.png"));

            if (trail.GoodForKids)
                icons.Children.Add(GenericsContent.CreateIcon("icon_white_good_for_kids.png"));

            if (!string.IsNullOrEmpty(trail.DurationType))
                icons.Children.Add(GenericsContent.CreateWhiteIconByType(trail.DurationType));


            if (!string.IsNullOrEmpty(trail.Type))
                icons.Children.Add(GenericsContent.CreateWhiteIconByType(trail.Type));

            return icons;
        }

      
    }
}
