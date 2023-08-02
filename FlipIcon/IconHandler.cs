using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace FlipIcon
{
    public static class IconHandler
    {
        public static string FlipIcon => "FlipIcon.png";

        public static string CloseFile => "Close.png";

        public static BitmapSource FlipSource => ImageFromResource(FlipIcon);
        public static BitmapSource CloseSource => ImageFromResource(CloseFile);

        public static BitmapSource ImageFromResource(string fileName)
        {
            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri($"pack://application:,,,/{assemblyName};component/Resources/{fileName}");
            logo.EndInit();
            return logo;
        }
    }
}
