#region
using System.Windows.Input;
using System.Windows;
using AaDS_Project.Data;
using AaDS_Project.Appearance;
#endregion

namespace AaDS_Project
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Layout layout;
        bool onhold = false;

        public MainWindow()
        {
            InitializeComponent();
            layout = new Layout(cvs.Width, cvs.Height);
            cvs.Children.Add(layout.visuals);
            layout.Refresh();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cvs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            onhold = true;
            layout.OnHold(e.GetPosition(cvs).X, e.GetPosition(cvs).Y);
        }

        private void cvs_MouseMove(object sender, MouseEventArgs e)
        {
            if (onhold)
            {
                layout.OnMove(e.GetPosition(cvs).X, e.GetPosition(cvs).Y);
                layout.Refresh();
            }
        }

        private void cvs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            onhold = false;
        }

        private void cvs_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }
    }
}