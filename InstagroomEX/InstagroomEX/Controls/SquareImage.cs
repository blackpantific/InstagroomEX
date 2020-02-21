using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Controls
{
    public class SquareImage : CachedImage
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            HeightRequest = width;
        }
    }
}
