namespace Core.Utils
{
    using Core.Elements;
    using Core.Services;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Drawing;
    using System.IO;

    public static class ScreenshotTaker
    {
        private const int ScreenHeight = 923;
        private const int BorderIndent = 10;

        public static void MakeScreenshot(Browser browser)
        {
            Directory.CreateDirectory($@"{Environment.CurrentDirectory}\screenshots");
            Screenshot screenshot = browser.GetScreenshot();
            string fileName = DateTime.Now.ToLocalTime().ToString().Replace(":", "-") + ".jpeg";
            string fullPath = Path.Combine($@"{Environment.CurrentDirectory}\screenshots", fileName);
            screenshot.SaveAsFile(fullPath);
            TestContext.AddTestAttachment(fullPath);
        }

        public static void MakeMarkedScreenshot(Browser browser, BaseElement element)
        {
            if (OperatingSystem.IsWindows())
            {
                var elementLocation = element.GetLocation();
                var elementSize = element.GetSize();

                Directory.CreateDirectory($@"{Environment.CurrentDirectory}\screenshots");

                browser.MoveToElement(element);

                Screenshot screenshot = browser.GetScreenshot();

                Image image;

                using (var ms = new MemoryStream(screenshot.AsByteArray))
                {
                    image = Image.FromStream(ms);
                }

                Graphics graphics = Graphics.FromImage(image);

                int elementWidth = elementSize.Width;
                int elementHeight = elementSize.Height;

                int x = element.GetLocation().X;

                int countOfScreens = elementLocation.Y / ScreenHeight;
                countOfScreens = countOfScreens < 1 ? 0 : countOfScreens;
                int y;
                int shift;

                if (countOfScreens == 0)
                {
                    shift = 0;
                    y = elementLocation.Y - (countOfScreens * ScreenHeight);
                }
                else
                {
                    shift = 75;
                    y = ScreenHeight - elementHeight;
                }

                if (browser.GetHeightOfSite() - elementLocation.Y < 300)
                {
                    shift = 35;
                }

                var frame = new Point[] { new Point(x - BorderIndent,y - BorderIndent - shift),
                new Point(x - BorderIndent, y + elementHeight + BorderIndent - shift ),
                new Point(x + elementWidth + BorderIndent, y + elementHeight + BorderIndent - shift),
                new Point(x + elementWidth + BorderIndent, y - BorderIndent - shift) };

                var pen = new Pen(Brushes.Red, 5);

                graphics.DrawPolygon(pen, frame);

                var fileName = DateTime.Now.ToLocalTime().ToString().Replace(":", "-") + ".jpeg";
                var fullPath = Path.Combine($@"{Environment.CurrentDirectory}\screenshots", fileName);
                image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                TestContext.AddTestAttachment(fullPath);
            }
        }
    }
}
