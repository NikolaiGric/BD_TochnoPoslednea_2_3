using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using BD_TochnoPoslednea.Cinema_practicDataSetTableAdapters;

namespace BD_TochnoPoslednea
{
    public partial class DataSetWindow : Window
    {
        
        FilmsTableAdapter films = new FilmsTableAdapter();
        ProducersTableAdapter producers = new ProducersTableAdapter();
        MoviesTableAdapter movies = new MoviesTableAdapter();

        int FilmsID;
        int ProducerID;
        public DataSetWindow()
        {
            InitializeComponent();
            
            List<string> tables = new List<string>() {"Фильмы", "Режиссёры", "Кино"};
            
            AllComboBox.ItemsSource = tables;
            All1ComboBox.ItemsSource = producers.GetData();
            All2ComboBox.ItemsSource = films.GetData();
            All1ComboBox.DisplayMemberPath = "Surname";
            All2ComboBox.DisplayMemberPath = "Name_Film";



            AllDataGrid.ItemsSource = films.GetData();
            AllComboBox_SelectionChanged(null, null);
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    films.InsertQuery(NameTbx.Text, NameTBX.Text);
                    AllDataGrid.ItemsSource = films.GetData();
                }
                else if (selected == "Режиссёры")
                {
                    producers.InsertQuery(NameTbx.Text, NameTBX.Text, MiddleName2.Text);
                    AllDataGrid.ItemsSource = producers.GetData();
                }
                else if (selected == "Кино")
                {
                    movies.InsertQuery(Convert.ToInt32(FilmsID), Convert.ToInt32(ProducerID), NameTbx.Text, Convert.ToInt32(NameTBX.Text), MiddleName2.Text);
                    AllDataGrid.ItemsSource = movies.GetData();
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
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    films.UpdateQuery(NameTbx.Text, NameTBX.Text, Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = films.GetData();
                }
                else if (selected == "Режиссёры")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    producers.UpdateQuery(NameTbx.Text, NameTBX.Text, MiddleName2.Text, Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = producers.GetData();
                }
                else if (selected == "Кино")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    
                    movies.UpdateQuery(Convert.ToInt32(FilmsID), Convert.ToInt32(ProducerID), NameTbx.Text, Convert.ToInt32(NameTBX.Text), MiddleName2.Text, Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = movies.GetData();
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
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    films.DeleteQuery(Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = films.GetData();
                }
                else if (selected == "Режиссёры")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    producers.DeleteQuery(Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = producers.GetData();
                }
                else if (selected == "Кино")
                {
                    object id = (AllDataGrid.SelectedItem as DataRowView).Row[0];
                    movies.DeleteQuery(Convert.ToInt32(id));
                    AllDataGrid.ItemsSource = movies.GetData();
                }
            }
        }

        private void AllComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllComboBox.SelectedItem != null)
            {
                string selected = AllComboBox.SelectedItem as string;
                if (selected == "Фильмы")
                {
                    AllDataGrid.ItemsSource = films.GetData();
                    NameTbx.Text = "Название_Фильма";
                    NameTBX.Text = "Описание_Фильма";
                    MiddleName2.Text = "Не_Трогать";
                }
                else if (selected == "Режиссёры")
                {
                    AllDataGrid.ItemsSource = producers.GetData();
                    NameTbx.Text = "Фамилия_Режиссёра";
                    NameTBX.Text = "Имя_Режиссёра";
                    MiddleName2.Text = "Отчество_Режиссёра";
                }
                else if (selected == "Кино")
                {
                    AllDataGrid.ItemsSource = movies.GetData();
                    NameTbx.Text = "Возрастные_Ограничения";
                    NameTBX.Text = "Цена_Билета";
                    MiddleName2.Text = "Оплата_Пушкинской_картой";
                }
            }
            
        }
        private void All1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView moviesRow = (DataRowView)All1ComboBox.SelectedItem;
            ProducerID = (int)moviesRow["ID_Producer"]; 
        }
        private void All2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView moviesRow1 = (DataRowView)All2ComboBox.SelectedItem;
            FilmsID = (int)moviesRow1["ID_Films"];
        }
    }
}
