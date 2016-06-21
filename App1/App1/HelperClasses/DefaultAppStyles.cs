using Xamarin.Forms;

namespace App1.HelperClasses
{
    public static class DefaultAppStyles
    {
        public static readonly Color DefaultTextColor = Color.Black;
        public static readonly int DefaultFontSize = 18;
        public static readonly int DefaultMargin = 10;

        public static Color GetColorForLableByDifficultData(string diff)
        {
            return diff == "Easy" ? Color.Green 
                                  : diff == "Hard" ? Color.Red 
                                                   : Color.Yellow;
        }
    }
}
