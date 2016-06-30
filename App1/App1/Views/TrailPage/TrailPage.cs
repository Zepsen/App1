using App1.HelperClasses;
using App1.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.Views.LoginPage;

namespace App1.Views.TrailPage
{
    public class TrailPage : ContentPage
    {
        public TrailPage(string id)
        {
            var trail = DbQueryAsync.GetTrailById(id);           
            Content = GenerateMainGrid(trail);
        }

        public Grid GenerateMainGrid(FullTrail trail)
        {
            var gridContainer = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = 50 },                    
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)}                    
                },
            };

            var mainLabel = GenerateHeader();

            gridContainer.Children.Add(mainLabel, 0, 0);            
            gridContainer.Children.Add(GenerateMainScrollTrailPage(trail), 0, 1);
                        
            return gridContainer;
        }

        private StackLayout GenerateHeader()
        {
            var stack = new StackLayout { Orientation = StackOrientation.Horizontal };

            var mainLabel = GenericsContent.GetHeaderLabel();
            var loginLabel = GenericsContent.GetHeaderRegistrationLabel();

            AddTapNavToMainPage(mainLabel);
            AddTapNavToLoginPage(loginLabel);

            stack.Children.Add(mainLabel);
            stack.Children.Add(loginLabel);

            return stack;
        }

        private void AddTapNavToMainPage(Label label)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (object obj, EventArgs e) =>
            {
                Navigation.PushAsync(new MainPage());
            };
            label.GestureRecognizers.Add(tap);
        }

        private void AddTapNavToLoginPage(Label label)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (object obj, EventArgs e) =>
            {
                Navigation.PushAsync(new Views.LoginPage.LoginPage());
            };
            label.GestureRecognizers.Add(tap);
        }

        private ScrollView GenerateMainScrollTrailPage(FullTrail trail)
        {
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            stack.Children.Add(GenerateGallery(trail.Photos));
            stack.Children.Add(GenerateMainContentForTrailPage(trail));
            
            return new ScrollView { Content = stack };
        }
        private ScrollView GenerateMainContentForTrailPage(FullTrail trail)
        {
            var stack = new StackLayout
            {
                Padding = new Thickness(30, 0),
                BackgroundColor = Color.White,
            };
            
            stack.Children.Add(GenerateTrailNameLabel(trail.Name));
            stack.Children.Add(GenerateTableForStaticOptions(trail));        
            stack.Children.Add(GenerateTableForOptions(trail));
            stack.Children.Add(GenerateReferencesLabels(trail.References));
            stack.Children.Add(GenericsContent.GenerateTextBlockWithHeader(nameof(trail.Description), trail.Description));
            stack.Children.Add(GenericsContent.GenerateTextBlockWithHeader("Full description", trail.FullDescription));
            stack.Children.Add(GenericsContent.GenerateTextBlockWithHeader("Why go?", trail.WhyGo));
            stack.Children.Add(GenerateCommentsView(trail.Comments));
            //stack.Children.Add(GenerateMap());

            return new ScrollView { Content = stack };
        }

        private Grid GenerateTableForOptions(FullTrail trail)
        {
            var table = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 }
                },

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },

            };

            table.Children.Add(GenerateLabelForTableColumn("Distance"), 0, 0);
            table.Children.Add(GenerateLabelForTableValue(trail.Distance.ToString()), 1, 0);

            table.Children.Add(GenerateLabelForTableColumn("Peak"), 0, 1);
            table.Children.Add(GenerateLabelForTableValue(trail.Peak.ToString()), 1, 1);

            table.Children.Add(GenerateLabelForTableColumn("Season start"), 0, 2);
            table.Children.Add(GenerateLabelForTableValue(trail.SeasonStart), 1, 2);

            table.Children.Add(GenerateLabelForTableColumn("Season end"), 0, 3);
            table.Children.Add(GenerateLabelForTableValue(trail.SeasonEnd), 1, 3);

            table.Children.Add(GenerateLabelForTableColumn("Good For Kids"), 2, 0);
            if (trail.GoodForKids)
                table.Children.Add(GenericsContent.CreateIcon("icon_black_ood_for_kids.png"), 3, 0);

            table.Children.Add(GenerateLabelForTableColumn("Dog Allowed"), 2, 1);
            if (trail.DogAllowed)
                table.Children.Add(GenericsContent.CreateIcon("icon_black_dog_freindly.png"), 3, 1);

            table.Children.Add(GenerateLabelForTableColumn("Type"), 2, 2);
            if (!string.IsNullOrEmpty(trail.Type))
                table.Children.Add(GenericsContent.CreateBlackIconByType(trail.Type), 3, 2);

            table.Children.Add(GenerateLabelForTableColumn("Duration Type"), 2, 3);
            if (!string.IsNullOrEmpty(trail.DurationType))
                table.Children.Add(GenericsContent.CreateBlackIconByType(trail.DurationType), 3, 3);

            return table;
        }
        private Grid GenerateTableForStaticOptions(FullTrail trail)
        {
            var table = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 }
                },

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                }
            };

            table.Children.Add(GenerateLabelForTableColumn(nameof(trail.Difficult)), 0, 0);
            table.Children.Add(GenerateDifficultLabel(trail.Difficult), 1, 0);

            table.Children.Add(GenerateLabelForTableColumn(nameof(trail.Rate)), 0, 1);
            table.Children.Add(GenerateLabelForTableValue(trail.Rate.ToString("N1")), 1, 1);

            table.Children.Add(GenerateLabelForTableColumn(nameof(trail.Region)), 2, 0);
            table.Children.Add(GenerateLabelForTableValue(trail.Region), 3, 0);

            table.Children.Add(GenerateLabelForTableColumn(nameof(trail.Country)), 2, 1);
            table.Children.Add(GenerateLabelForTableValue(trail.Country), 3, 1);

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
        private Label GenerateDifficultLabel(string diff)
        {
            var backColor = GenericsContent.GetColorForLableByDifficultData(diff);
            return new Label
            {
                Text = diff,
                TextColor = Color.White,
                BackgroundColor = backColor,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start                
            };
        }

        private ScrollView GenerateGallery(List<string> photos)
        {
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            foreach (var photo in photos)
            {
                stack.Children.Add(GeneratePhoto(photo));
            }

            return new ScrollView
            {
                Content = stack,
                Orientation = ScrollOrientation.Horizontal
            };
        }
        private Image GeneratePhoto(string photoName)
        {
            return new Image
            {
                Source = ImageSource.FromFile(photoName),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 150
            };
        }

        private StackLayout GenerateReferencesLabels(List<string> references)
        {
            var stack = new StackLayout { Orientation = StackOrientation.Vertical };

            if (references.Count > 0)
            {
                stack.Children.Add(GenericsContent.GenerateHeaderLabel("Web-sites"));
                foreach (var reference in references)
                {
                    stack.Children.Add(GenerateLinkRef(reference));
                };
            }

            return stack;            
        }
        private Label GenerateLinkRef(string reference)
        {
            var label = new Label
            {
                Text = reference,
                TextColor = Color.Blue
            };

            var tap = new TapGestureRecognizer();
            tap.Tapped += (object obj, EventArgs e) =>
            {
                var link = (obj as Label).Text;
                Device.OpenUri(new Uri(link));
            };
            label.GestureRecognizers.Add(tap);


            return label;
        }

        private StackLayout GenerateCommentsView(List<Comments> comments)
        {
            var stack = new StackLayout();

            if (comments.Count > 0)
            {
                stack.Children.Add(GenericsContent.GenerateHeaderLabel("Comments"));
                foreach (var comment in comments)
                {
                    stack.Children.Add(GenerateComment(comment));
                }
            }
            return stack;
        }
        private StackLayout GenerateComment(Comments comment)
        {
            var stack = new StackLayout()
            {
                Padding = new Thickness(0, 10)
            };
                        
            stack.Children.Add(GenerateLayoutForCommentHeader(comment));         
            stack.Children.Add(GenerateCommentField(comment.Comment));

            return stack;
        }
        private StackLayout GenerateLayoutForCommentHeader(Comments comment)
        {
            var stack = new StackLayout { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(GenericsContent.GenerateLabelWithLayoutOption(comment.Name, LayoutOptions.Start));
            stack.Children.Add(GenerateStarForCommentMark(comment.Rate));
            return stack;
        }       
        private StackLayout GenerateStarForCommentMark(double rate)
        {
            var stack = new StackLayout{ Orientation = StackOrientation.Horizontal };

            for (int i = 0; i < rate; i++)
            {
                stack.Children.Add(GenericsContent.CreateIcon("gold_star_icon.png"));
            }

            return stack;
        }
        private Frame GenerateCommentField(string comment)
        {
            return new Frame
            {
                Content = GenericsContent.GenerateDefaultLabel(comment),
                Padding = new Thickness(10),
                HasShadow = true,
                OutlineColor = Color.Silver,
                BackgroundColor = Color.FromRgba(0, 0, 7, 0.1)
            };
        }

        //private Frame GenerateMap()
        //{
        //    var map = new Map(
        //    MapSpan.FromCenterAndRadius(
        //            new Position(37, -122), Distance.FromMiles(0.3)))
        //    {
        //        IsShowingUser = true,
        //        HeightRequest = 100,
        //        WidthRequest = 960,
        //        VerticalOptions = LayoutOptions.FillAndExpand
        //    };

        //    var frame = new Frame { HasShadow = true, OutlineColor = Color.Silver, Content = map };
        //    return frame;
        //}
    }
}
