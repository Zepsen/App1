using App1.HelperClasses;
using Xamarin.Forms;

namespace App1.Views
{
    public class GenericsContent
    {
        public static Label GenerateMainLabel()
        {
            return new Label
            {
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                Text = "OUTDOOR.ROCKS",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center                
            };
        }
        
        public static StackLayout GenerateTextBlockWithHeader(string header, string text)
        {
            var stack = new StackLayout { Orientation = StackOrientation.Vertical };
            stack.Children.Add(GenerateHeaderLabel(header));
            stack.Children.Add(GenerateDefaultLabel(text));
            return stack;
        }

        public static Label GenerateHeaderLabel(string headerText)
        {
            return new Label
            {
                Text = headerText,
                FontSize = DefaultAppStyles.DefaultFontSize,
                TextColor = DefaultAppStyles.DefaultTextColor,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold
            };

        }

        public static Label GenerateDefaultLabel(string text, string text2 = null)
        {
            return new Label
            {
                Text = string.IsNullOrEmpty(text2) ? text : $"{text} {text2}",
                TextColor = DefaultAppStyles.DefaultTextColor,
                FontSize = DefaultAppStyles.DefaultFontSize,
            };
        }

        public static Label GenerateLabelWithLayoutOption(string text, LayoutOptions layoutOption)
        {
            return new Label
            {
                Text = text,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = DefaultAppStyles.DefaultTextColor,
                FontSize = DefaultAppStyles.DefaultFontSize,
            };
        }

        public static Label GenerateFilterLabels(string text)
        {
            return new Label
            {
                Text = text,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.White,
                FontSize = DefaultAppStyles.DefaultFontSize,
                BackgroundColor = DefaultAppStyles.DefaultMainBackColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
        }

        public static Image CreateIcon(string name)
        {
            return new Image
            {
                Source = ImageSource.FromFile(name),
                IsOpaque = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start

            };
        }

        public static Image CreateBlackIconByType(string name)
        {
            Image icon = null;
            switch (name)
            {
                case "loop":
                    icon = CreateIcon("icon_black_loop.png");
                    break;

                case "in-and-out":
                    icon = CreateIcon("icon_black_in_and_out.png");
                    break;

                case "point-to-point":
                    icon = CreateIcon("icon_black_point_to_point.png");
                    break;

                case "weekend":
                    icon = CreateIcon("icon_black_weekend.png");
                    break;

                case "oneday":
                    icon = CreateIcon("icon_black_one_day.png");
                    break;

                case "manydays":
                    icon = CreateIcon("icon_black_many_days.png");
                    break;
            }
            return icon;
        }

        public static Image CreateWhiteIconByType(string name)
        {
            Image icon = null;
            switch (name)
            {
                case "loop":
                    icon = CreateIcon("icon_white_loop.png");
                    break;

                case "in-and-out":
                    icon = CreateIcon("icon_white_in_and_out.png");
                    break;

                case "point-to-point":
                    icon = CreateIcon("icon_white_point_to_point.png");
                    break;

                case "weekend":
                    icon = CreateIcon("icon_white_weekend.png");
                    break;

                case "oneday":
                    icon = CreateIcon("icon_white_one_day.png");
                    break;

                case "manydays":
                    icon = CreateIcon("icon_white_many_days.png");
                    break;
            }
            return icon;
        }

        public static Color GetColorForLableByDifficultData(string diff)
        {
            return diff == "Easy" ? Color.Green
                                  : diff == "Hard" ? Color.Red
                                                   : Color.Yellow;
        }
    }
}
