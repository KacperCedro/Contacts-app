using ContactsApp.Classes;
using SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDataBase();
        }

        public void ReadDataBase()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(x => x.Name).ToList();
            }
            if(contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }
        private void createNewContactButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            string query = searchBox.Text.ToLower();
            List<Contact> filteredList = contacts.Where(x => x.Name.ToLower().Contains(query)).ToList();
        }
    }
}
