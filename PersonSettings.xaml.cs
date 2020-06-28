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

        // TODO реализовать подгрузку пользователя

        public PersonSettings()
        {
            InitializeComponent();

            _schedule = new Dictionary<Time, string>
            {
                {Time.T0, "Home"}, {Time.T1, "Home"},
                {Time.T2, "Home"}, {Time.T3, "Home"},
                {Time.T4, "Home"}, {Time.T5, "Home"},
                {Time.T6, "Home"}, {Time.T7, "Home"},
                {Time.T8, "Home"}, {Time.T9, "Home"},
                {Time.T10, "Home"}, {Time.T11, "Home"},
                {Time.T12, "Home"}, {Time.T13, "Home"},
                {Time.T14, "Home"}, {Time.T15, "Home"},
                {Time.T16, "Home"}, {Time.T17, "Home"},
                {Time.T18, "Home"}, {Time.T19, "Home"},
                {Time.T20, "Home"}, {Time.T21, "Home"},
                {Time.T22, "Home"}, {Time.T23, "Home"}
            };

            for (var i = 0; i < 24; i++) TimeBox.Items.Add($"{i:00}:00");
            TimeBox.SelectedIndex = 0;

            foreach (var place in Places.Names) PlaceBox.Items.Add(place);
            PlaceBox.SelectedIndex = 0;
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
            var person = new Person(NameBox.Text, _schedule);
            // TODO реализовать сохранение 
        }
    }
}