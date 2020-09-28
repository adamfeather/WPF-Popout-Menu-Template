using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PopoutMenuTest
{
    public partial class MainWindow : Window
    {
        private bool _isMenuExpanded = false;

        public MainWindow()
        {
            InitializeComponent();

            StateChanged += MainWindow_StateChanged;

            SetMaximizedRestoreButtonStates();
        }

        private void MainWindow_StateChanged(object sender, System.EventArgs e)
        {
            SetMaximizedRestoreButtonStates();
        }

        private void ExpandCollapseMenuIcon_Click(object sender, MouseButtonEventArgs e)
        {
            ToggleMenuExpansion();
        }

        private void ToggleMenuExpansion()
        {
            var storyboardName = _isMenuExpanded ? "CollapseMenuStoryboard" : "ExpandMenuStoryboard";

            var storyboard = (Storyboard) FindResource(storyboardName);

            storyboard.Begin(this);

            _isMenuExpanded = !_isMenuExpanded;
        }

        private void CloseWindowIcon_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void RestoreWindowButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;

                SetMaximizedRestoreButtonStates();
            }
        }

        private void MaximizeWindowButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;

                SetMaximizedRestoreButtonStates();
            }
        }

        private void SetMaximizedRestoreButtonStates()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                MaximizeWindowButton.Visibility = Visibility.Collapsed;
                RestoreWindowButton.Visibility = Visibility.Visible;
            }
            else
            {
                MaximizeWindowButton.Visibility = Visibility.Visible;
                RestoreWindowButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
