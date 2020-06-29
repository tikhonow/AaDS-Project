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
        PlaceContainer places;

        Layout layout;

        Way way;

        bool onhold = false;

        public MainWindow()
        {
            InitializeComponent();
            places = new PlaceContainer();
            layout = new Layout(cvs.Width, cvs.Height, places.GetPlaces());
            cvs.Children.Add(layout.visuals);

            way = new Way(places.GetWay(0, 0));
            layout.drawables.Add(way);
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