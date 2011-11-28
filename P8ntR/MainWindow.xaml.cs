using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace P8ntR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static DependencyProperty UnsavedChangesProperty = DependencyProperty.Register("UnsavedChanges", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        private string _fileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool UnsavedChanges
        {
            get { return (bool)GetValue(UnsavedChangesProperty); }
            set { SetValue(UnsavedChangesProperty, value); }
        }

        private void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            New();
        }

        private void NewMenuItemClick(object sender, RoutedEventArgs e)
        {
            New();
        }

        private void New()
        {
            HandleUnsavedChanges();

            // Reset changes
            UnsavedChanges = false;

            // Reset filename
            _fileName = null;

            statusText.Text = String.Format("Ready.");
        }

        private void OpenMenuItemClick(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Open();
        }

        private void Open()
        {
            HandleUnsavedChanges();

            // Create an OpenFileDialog.
            var dialog = new OpenFileDialog();

            // Show the dialog, abort if not successful
            if (dialog.ShowDialog() != true) return;

            _fileName = dialog.FileName;

            statusText.Text = String.Format("Painting opened ({0}).", _fileName);
        }

        private void SaveMenuItemClick(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void SaveAsMenuItemClick(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void SaveAsCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            // Create a SaveFileDialog.
            var dialog = new SaveFileDialog();

            // Show the dialog, abort if not successful
            if (dialog.ShowDialog() != true) return;

            _fileName = dialog.FileName;

            Save();
        }

        private void Save()
        {
            statusText.Text = String.Format("Painting saved ({0}).", _fileName);
        }

        private void AboutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            About();
        }

        private void AboutMenuItemClick(object sender, RoutedEventArgs e)
        {
            About();
        }

        private static void About()
        {
            MessageBox.Show(Properties.Resources.AboutMessageText, Properties.Resources.AboutMessageHeader, MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void ZoomInCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ZoomInMenuItemClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ZoomOutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ZoomOutMenuItemClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExitMenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            HandleUnsavedChanges();
        }

        private void HandleUnsavedChanges()
        {
            if (!UnsavedChanges) return;

            var result = MessageBox.Show(Properties.Resources.UnsavedChangesText,
                Properties.Resources.UnsavedChangesHeading, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes) return;

            Save();
        }

    }

}
