using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PopoutMenuTest
{
    public partial class MenuView : UserControl
    {
        private bool _isMenuExpanded = false;

        public MenuView()
        {
            InitializeComponent();
        }

        private void ExpandCollapseMenuIcon_Click(object sender, MouseButtonEventArgs e)
        {
            ToggleMenuExpansion();
        }

        private void ToggleMenuExpansion()
        {
            var storyboardName = _isMenuExpanded ? "CollapseMenuStoryboard" : "ExpandMenuStoryboard";

            var storyboard = (Storyboard)FindResource(storyboardName);

            storyboard.Begin(this);

            _isMenuExpanded = !_isMenuExpanded;
        }
    }
}
