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
        }

        private void ExpandCollapseMenuIcon_Click(object sender, MouseButtonEventArgs e)
        {
            var storyboardName = _isMenuExpanded ? "CollapseMenuStoryboard" : "ExpandMenuStoryboard";

            var storyboard = (Storyboard)FindResource(storyboardName);

            storyboard.Begin(this);

            _isMenuExpanded = !_isMenuExpanded;

        }

        private void CloseWindowIcon_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
