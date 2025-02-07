using System.Windows;
using Contacts.Models;

namespace Contacts.Views;

public partial class SelectedContact : Window
{
    private Contact _selectedContact;
    public SelectedContact(Contact selectedContact)
    {
        _selectedContact = selectedContact;
        InitializeComponent();
        nameTextBox.Text = selectedContact.Name;
        phoneTextBox.Text = selectedContact.Phone;
        emailTextBox.Text = selectedContact.Email;
    }


    private void ChangeContact(object sender, RoutedEventArgs e)
    {
        DatabaseHelper.DatabaseHelper.ChangeContact(new Contact
        {
            Id = _selectedContact.Id,
            Email = emailTextBox.Text,
            Phone = phoneTextBox.Text,
            Name = nameTextBox.Text
        });
    }
}