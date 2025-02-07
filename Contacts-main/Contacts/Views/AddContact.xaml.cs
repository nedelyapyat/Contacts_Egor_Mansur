using System.Windows;
using Contacts.Models;

namespace Contacts.Views;

public partial class AddContact : Window
{
    public AddContact()
    {
        InitializeComponent();
    }


    private void AddContact_Click(object sender, RoutedEventArgs e)
    {
        DatabaseHelper.DatabaseHelper.AddContact
        (
            new Contact
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            }
        );
        if (MessageBox.Show("Contact added! Want add another one?", "Success", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
        {
            Hide();
        }
    }
}