#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using AaDS_Project.Appearance;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly PersonContainer Persons = new PersonContainer(5000);

        private readonly Layout _layout;

        private bool _onHold;
        private readonly PlaceContainer _places;

        private Way _way;
        private int start = -1;
        private int finish = -1;

        public MainWindow()
        {
            InitializeComponent();

            _places = new PlaceContainer();
            foreach (var pers in Persons.Users)
            {
                _places.AddPerson(pers.Schedule[Time.T0]);
            }

            _layout = new Layout(cvs.Width, cvs.Height, _places.GetPlaces);
            cvs.Children.Add(_layout.Visuals);

            _way = new Way(_places.GetWay(0, 0));
            _layout.Drawables.Add(_way);
            _layout.Refresh();

            foreach (var i in Places.Names)
            {
                FromBox.Items.Add(i);
                ToBox.Items.Add(i);
            }

            FromBox.SelectedIndex = 0;
            ToBox.SelectedIndex = 0;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void cvs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _onHold = true;
            _layout.OnHold(e.GetPosition(cvs).X, e.GetPosition(cvs).Y);
        }

        private void cvs_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_onHold) return;

            _layout.OnMove(e.GetPosition(cvs).X, e.GetPosition(cvs).Y);
            _layout.Refresh();
        }

        private void cvs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _onHold = false;
        }

        private void cvs_MouseWheel(object sender, MouseWheelEventArgs e)
        {
        }

        private void FromBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            start = FromBox.SelectedIndex;
            finish = ToBox.SelectedIndex;

            if (start == -1 || finish == -1) return;

            var way = _places.GetWay(start, finish);

            _layout.Drawables.Remove(_way);
            _way = new Way(way);
            _layout.Drawables.Add(_way);
            _layout.Refresh();

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slide = (Slider)sender;
            var val = (int)slide.Value;
            HourLabel.Content = $"Hour: {val:00}:00";

            foreach (var place in _places.GetPlaces)
                place.NumberOfPeople = 0;

            foreach (var pers in Persons.Users)
                _places.AddPerson(pers.Schedule[(Time)val]);


            _layout.ChangeVerticles(_places.GetPlaces);

            var way = _places.GetWay(start, finish);

            _layout.Drawables.Remove(_way);
            _way = new Way(way);
            _layout.Drawables.Add(_way);

            _layout.Refresh();
        }
    }
}