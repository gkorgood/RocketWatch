using UnityEngine;

namespace In_Game_Clock.Extensions
{
    public static class RectExtension
    {
        public static Rect HighLeftScreen(this Rect thisRect)
        {
            if (Screen.width > 0 && Screen.height > 0 && thisRect.width > 0f && thisRect.height > 0f)
            {
                thisRect.x = 0;
                thisRect.y = 54;
            }

            return thisRect;
        }
    }
}
