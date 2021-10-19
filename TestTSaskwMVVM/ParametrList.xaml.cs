using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TestTakMVVM
{
    /// <summary>
    /// Логика взаимодействия для ParametrList.xaml
    /// </summary>
    public partial class ParametrList : Window
    {
        public ParametrList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List.Items.Add("Value");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//remove
        {
            List.Items.Remove(List.SelectedItem);
            //List.Items
           // List.SelectedItems.IsReadOnly=false
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//eddit
        {
            /*if (List.SelectedIndex < 0) return;

            var tmpValue = List.Items[List.SelectedIndex].ToString();
            RoomDisplayForm newRoomDisplayForm = new RoomDisplayForm();
            newRoomDisplayForm.value = tmpValue;
            newRoomDisplayForm.ShowDialog();

            //TODO: inside "newRoomDisplayForm" set the value to the textbox
            // ie.: myValueTextBox.Text = this.value;

            if (newRoomDisplayForm.DialogResult == DialogResult.OK)
            {
                // replace the selected item with the new value
                List.Items[List.SelectedIndex] = newRoomDisplayForm.value;
            }*/
            /*private void Button_Click_3(object sender, RoutedEventArgs e)//remove
            {
                List.Items.Remove(List.SelectedItem);
                //List.Items
                // List.SelectedItems.IsReadOnly=false
            }*/


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MoveItem(-1);
            //List.Items.MoveCurrentToNext();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MoveItem(1);
            //List.Items.MoveCurrentToNext();
        }
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (List.SelectedItem == null || List.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = List.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= List.Items.Count)
                return; // Index out of range - nothing to do

            object selected = List.SelectedItem;

            // Removing removable element
            List.Items.Remove(selected);
            // Insert it in new position
            List.Items.Insert(newIndex, selected);
            // Restore selection
            //List.SetSelected(newIndex, true);
        }
    }
}
