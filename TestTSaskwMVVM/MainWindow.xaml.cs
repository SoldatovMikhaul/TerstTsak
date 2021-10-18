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
        SqlDataAdapter adapter;
        DataTable parametrsTable;
        public MainWindow()
        {

            InitializeComponent();
            DataContext = new ApplicationViewModel();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            /*XmlSerializer formatter = new XmlSerializer(typeof(StudentsList));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, dashboard);
            }*/

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Parametrs_Table";
            parametrsTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                Console.WriteLine("new SqlDataAdapter(command) " + new SqlDataAdapter(command));
                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InserParametr", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 50, "Title"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50, "Types"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(parametrsTable);
                parametrsGrid.ItemsSource = parametrsTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(parametrsTable);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //parametrsGrid.Items.Add(new Parametr());
            UpdateDB();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            parametrsGrid.Items.Remove(parametrsGrid.SelectedItem);
            UpdateDB();
        }
        private void ChangeText_Click(object sender, RoutedEventArgs e)
        {
            ParametrList taskWindow = new ParametrList();
            taskWindow.Show();
        }
        /*private void Main_wimndow_Load(object sender, RoutedEventArgs e) 
        {
            List<Parametr> parametrs = new List<Parametr>();
            parametrs.Add(new Parametr("param5", Parametr.ParametrTypes.Значение_из_списка));

        }*/
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
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
            //UpdateDB();
        }
    }
}
