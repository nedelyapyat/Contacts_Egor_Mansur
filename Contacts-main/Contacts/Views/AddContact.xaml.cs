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

    private void DeleteContact_Click(object sender, RoutedEventArgs e)
    {
        string name = nameTextBox.Text.Trim();
        string email = emailTextBox.Text.Trim();
        string phone = phoneTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phone))
        {
            MessageBox.Show("Enter at least one field to delete a contact.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        using (var context = new ContactsDbContext())
        {
            var contactToDelete = context.Contacts
                .FirstOrDefault(c => c.Name == name && c.Email == email && c.Phone == phone);

            if (contactToDelete != null)
            {
                context.Contacts.Remove(contactToDelete);
                context.SaveChanges();
                MessageBox.Show("Contact deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("No matching contact found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void ClearFields()
    {
        nameTextBox.Text = "";
        emailTextBox.Text = "";
        phoneTextBox.Text = "";
    }

}