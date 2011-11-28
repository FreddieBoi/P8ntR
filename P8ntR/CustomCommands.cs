using System.Windows.Input;

namespace P8ntR
{
    static class CustomCommands
    {
        public static RoutedCommand New = new RoutedCommand();
        public static RoutedCommand Open = new RoutedCommand();
        public static RoutedCommand Save = new RoutedCommand();
        public static RoutedCommand SaveAs = new RoutedCommand();
        public static RoutedCommand About = new RoutedCommand();
        public static RoutedCommand ZoomIn = new RoutedCommand();
        public static RoutedCommand ZoomOut = new RoutedCommand();
    }
}
