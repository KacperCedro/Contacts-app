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
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact selectedContact;
        public ContactDetailsWindow(Contact selectedContact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.selectedContact = selectedContact;
            nameTextBox.Text = selectedContact.Name;
            emailTextBox.Text = selectedContact.Email;
            phoneTextBox.Text = selectedContact.PhoneNumber;
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            selectedContact.Name = nameTextBox.Text;
            selectedContact.Email = emailTextBox.Text;
            selectedContact.PhoneNumber = phoneTextBox.Text;
            
            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(selectedContact);
            }

            this.Close();
        }

        private void deleteButton_Click(Object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(selectedContact);
            }

            this.Close();
        }

    }
}
