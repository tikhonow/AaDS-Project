#region

using System.Windows;
using System.Windows.Input;
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
        public static PersonContainer Persons = new PersonContainer(400);

        private readonly Layout _layout;

        private bool _onHold;
        private readonly PlaceContainer _places;

        private readonly Way _way;

        public MainWindow()
        {
            InitializeComponent();
            _places = new PlaceContainer();
            _layout = new Layout(cvs.Width, cvs.Height, _places.GetPlaces());
            cvs.Children.Add(_layout.visuals);

            _way = new Way(_places.GetWay(0, 0));
            _layout.drawables.Add(_way);
            _layout.Refresh();
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
            if (_onHold)
            {
                _layout.OnMove(e.GetPosition(cvs).X, e.GetPosition(cvs).Y);
                _layout.Refresh();
            }
        }

        private void cvs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _onHold = false;
        }

        private void cvs_MouseWheel(object sender, MouseWheelEventArgs e)
        {
        }

        /// TODO 

        // слайдер хэндлер, при изменении значения =>
        // foreach place in places => place.peoples = 0,
        // foreach person in personContainer => { places[person.Schedule[time(slider.Value)].ToPlaceID]++; }
        // Вышеописанная строчка - берём по значению слайдера время, от него получаем строковое значение ->
        // -> затем получаем ID этого значения и инкрементируем значение числа людей в этом месте
        // layout = new Layout(cvs.Width, cvs.Height, places.GetPlaces()); - обновляем холсты

        /// TODO
    }
}