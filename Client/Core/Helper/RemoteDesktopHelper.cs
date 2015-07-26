﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace xClient.Core.Helper
{
    public static class RemoteDesktopHelper
    {
        public static Bitmap GetDesktop(int screenNumber)
        {
            var bounds = GetBounds(screenNumber);
            var screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics graph = Graphics.FromImage(screenshot))
            {
                graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
                return screenshot;
            }
        }

        public static Rectangle GetBounds(int screenNumber)
        {
            return Screen.AllScreens[screenNumber].Bounds;
        }
    }
}
