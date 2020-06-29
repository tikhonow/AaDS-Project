#region

using System.Windows;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly PersonContainer PersonContainer = new PersonContainer(400);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}