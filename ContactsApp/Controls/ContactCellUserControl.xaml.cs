using ContactsApp.Classes;
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

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactCellUserControl.xaml
    /// </summary>
    public partial class ContactCellUserControl : UserControl
    {
        //private Contact contact;

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactCellUserControl), new PropertyMetadata(new Contact() { Name = "Name Lastname", Email = "example@domain.com", PhoneNumber = "123 1234 1234" }, SetText));
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactCellUserControl control = d as ContactCellUserControl;

            if (control != null)
            {
                control.contactNameTextBlock.Text = (e.NewValue as Contact).Name;
                control.contactEmailTextBlock.Text = (e.NewValue as Contact).Email;
                control.contactPhoneNumberTextBlock.Text = (e.NewValue as Contact).PhoneNumber;
            }
        }
        public ContactCellUserControl()
        {
            InitializeComponent();
        }
    }
}
