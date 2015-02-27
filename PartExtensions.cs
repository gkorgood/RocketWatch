using System.Collections.Generic;
using UnityEngine;

namespace In_Game_Clock.Extensions
{
    public static class PartExtensions
    {
        public static bool IsPrimary(this Part thisPart, List<Part> partsList, int moduleClassID)
        {
            foreach (Part part in partsList)
            {
                if (part.Modules.Contains(moduleClassID))
                {
                    if (part == thisPart)
                        return true;
                    else
                        break;
                }
            }

            return false;
        }
    }
}
