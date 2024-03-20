using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BD_TochnoPoslednea
{
    /// <summary>
    /// Логика взаимодействия для EntityFrameworkWindow.xaml
    /// </summary>
    public partial class EntityFrameworkWindow : Window
    {
        private Cinema_practicEntities context = new Cinema_practicEntities();

        int FilmsID;
        int ProducerID;
        public EntityFrameworkWindow()
        {
            InitializeComponent();

            AllDataGrid.ItemsSource = context.Films.ToList();
            List<string> tables = new List<string>() { "Фильмы", "Режиссёры", "Кино" };
            AllComboBox.ItemsSource = tables;
            AllComboBox.SelectionChanged += AllComboBox_SelectionChanged;

            All1ComboBox.ItemsSource = context.Films.ToList();
            All1ComboBox.DisplayMemberPath = "Name_Film";
            All2ComboBox.ItemsSource = context.Producers.ToList();
            All2ComboBox.DisplayMemberPath = "Surname";
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    Films f = new Films();
                    f.Name_Film = NameTbx.Text;
                    f.Description_Film = NameTBX.Text;
                    context.Films.Add(f);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Films.ToList();

                }
                else if (selected == "Режиссёры")
                {
                    Producers p = new Producers();
                    p.Name = NameTBX.Text;
                    p.Surname = NameTbx.Text;
                    p.Middle_name = MiddleName2.Text;
                    context.Producers.Add(p);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Producers.ToList();
                }
                else if (selected == "Кино")
                {
                    Movies m = new Movies();
                    m.Price = Convert.ToInt32(NameTBX.Text);
                    m.Age_Rating = NameTbx.Text;
                    m.Payment_of_Pushkin_card = MiddleName2.Text;
                    m.Film_ID = FilmsID;
                    m.Producer_ID = ProducerID;
                    context.Movies.Add(m);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Movies.ToList();
                }
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    var selected1 = AllDataGrid.SelectedItem as Films;

                    selected1.Name_Film = NameTbx.Text;
                    selected1.Description_Film = NameTBX.Text;
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Films.ToList();
                }
                else if (selected == "Режиссёры")
                {
                    var selected2 = AllDataGrid.SelectedItem as Producers;
                    selected2.Name = NameTBX.Text;
                    selected2.Surname = NameTbx.Text;
                    selected2.Middle_name = MiddleName2.Text;
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Producers.ToList();
                }
                else if (selected == "Кино")
                {
                    var selected3 = AllDataGrid.SelectedItem as Movies;
                    selected3.Price = Convert.ToInt32(NameTBX.Text);
                    selected3.Age_Rating = NameTbx.Text;
                    selected3.Payment_of_Pushkin_card = MiddleName2.Text;
                    selected3.Film_ID = FilmsID;
                    selected3.Producer_ID = ProducerID;
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Movies.ToList();
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    context.Films.Remove(AllDataGrid.SelectedItem as Films);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Films.ToList();
                }
                else if (selected == "Режиссёры")
                {
                    context.Producers.Remove(AllDataGrid.SelectedItem as Producers);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Producers.ToList();
                }
                else if (selected == "Кино")
                {

                    context.Movies.Remove(AllDataGrid.SelectedItem as Movies);
                    context.SaveChanges();
                    AllDataGrid.ItemsSource = context.Movies.ToList();

                }
            }
        }
        private void All1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = All1ComboBox.SelectedItem as Films;
            FilmsID = context.Films.Where(x => x.Name_Film == selectedItem.Name_Film).Select(x => x.ID_Films).FirstOrDefault();
        }
        private void All2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectID = All2ComboBox.SelectedItem as Producers;
            ProducerID = context.Producers.Where(x => x.Surname == selectID.Surname).Select(x => x.ID_Producer).FirstOrDefault();

        }
        private void AllComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    AllDataGrid.ItemsSource = context.Films.ToList();
                    NameTbx.Text = "Название_Фильма";
                    NameTBX.Text = "Описание_Фильма";
                    MiddleName2.Text = "Не_Трогать";
                }
                else if (selected == "Режиссёры")
                {
                    AllDataGrid.ItemsSource = context.Producers.ToList();
                    NameTbx.Text = "Фамилия_Режиссёра";
                    NameTBX.Text = "Имя_Режиссёра";
                    MiddleName2.Text = "Отчество_Режиссёра";
                }
                else if (selected == "Кино")
                {
                    AllDataGrid.ItemsSource = context.Movies.ToList();
                    NameTbx.Text = "Возрастные_Ограничения";
                    NameTBX.Text = "Цена_Билета";
                    MiddleName2.Text = "Оплата_Пушкинской_картой";
                }
            }
        }
    }
}
