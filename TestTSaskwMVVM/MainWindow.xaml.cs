using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using TestTaskMVVM;

namespace TestTakMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Serializable]
        public class StudentsList
        {
            public List<Parametr> Parametrs;
        }

        string connectionString;
        public MainWindow()
        {

            InitializeComponent();
            DataContext =
                 new ApplicationViewModel(new DefaultDialogService(), new JsonFileService());
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            parametrsGrid.Items.Remove(parametrsGrid.SelectedItem);
        }
        private void ChangeText_Click(object sender, RoutedEventArgs e)
        {
            ParametrList taskWindow = new ParametrList();
            taskWindow.Show();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }   
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (parametrsGrid.SelectedItems != null)
            {
                for (int i = 0; i < parametrsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = parametrsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }
        public void MoveItemInGrid(int direction)
        {
            // Checking selected item
            if (parametrsGrid.SelectedItem == null || parametrsGrid.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = parametrsGrid.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= parametrsGrid.Items.Count)
                return; // Index out of range - nothing to do

            object selected = parametrsGrid.SelectedItem;

            // Removing removable element
            //parametrsGrid.Items.Remove(selected);

            if (parametrsGrid.SelectedItems != null)
            {
                for (int i = 0; i < parametrsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = parametrsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.ItemArray[i] = dataRow.ItemArray[i - 1];
                        Console.WriteLine("dataRow.ItemArray[i] = " + dataRow.ItemArray[i]);
                        Console.WriteLine();
                    }
                }
            }


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MoveItemInGrid(-1);

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MoveItemInGrid(1);
        }
        private void Window_FormClosing(object sender, RoutedEventArgs e) 
        { 

        }
    }
}
