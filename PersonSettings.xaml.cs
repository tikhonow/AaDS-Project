using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AaDS_Project.Data;

namespace AaDS_Project
{
    public partial class PersonSettings : Window
    {
        private readonly Dictionary<Time, string> _schedule;
        private static int _id = -1;

        public PersonSettings()
        {
            InitializeComponent();

            if (_id == -1)
            {
                _schedule = new Dictionary<Time, string>();
                for (var j = Time.T0; j <= Time.T23; j++) _schedule.Add(j, "Home");
            }
            else
            {
                _schedule = MainWindow.PersonContainer.Users[_id].Schedule;
            }

            for (var i = 0; i < 24; i++)
            {
                TimeBox.Items.Add($"{i:00}:00");
                PlaceBox.Items.Add(_schedule[(Time) i]);
            }

            TimeBox.SelectedIndex = 0;
            PlaceBox.SelectedIndex = Places.Names.IndexOf(_schedule[Time.T0]);
        }

        private void NameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox nameBox)) return;

            if (nameBox.Text == "Имя") nameBox.Text = "";
            nameBox.Foreground = Brushes.Black;
        }

        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox nameBox)) return;
            if (nameBox.Text.Length != 0) return;

            nameBox.Text = "Имя";
            nameBox.Foreground = Brushes.DimGray;
        }

        private void TimeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is ComboBox time)) return;

            var index = (Time) time.SelectedIndex;
            PlaceBox.SelectedIndex = Places.Names.IndexOf(_schedule[index]);
        }

        private void PlaceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is ComboBox place)) return;

            var index = (Time) TimeBox.SelectedIndex;
            _schedule[index] = place.SelectedValue.ToString();
        }

        private void PersonSettings_Closed(object sender, EventArgs e)
        {
            if (_id != -1) return;

            MainWindow.PersonContainer.Users.Add(new Person(NameBox.Text, _schedule));
            _id = MainWindow.PersonContainer.Users.Count - 1;
        }
    }
}