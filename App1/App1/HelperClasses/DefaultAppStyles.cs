using Xamarin.Forms;

namespace App1.HelperClasses
{
    public static class DefaultAppStyles
    {
        public static readonly Color DefaultTextColor = Color.Black;
        public static readonly int DefaultFontSize = 18;
        public static readonly int DefaultMargin = 10;
        //public static readonly Image WhiteDogAllowed = CreateIcon("icon_white_dog_freindly.png");
        //public static readonly Image WhiteGoodForKids = CreateIcon("icon_white_good_for_kids.png");

        public static Color GetColorForLableByDifficultData(string diff)
        {
            return diff == "Easy" ? Color.Green 
                                  : diff == "Hard" ? Color.Red 
                                                   : Color.Yellow;
        }
               

        public static Image CreateIcon(string name)
        {
            return new Image
            {
                Source = ImageSource.FromFile(name),                
                IsOpaque = true                
            };
        }
    }
}
