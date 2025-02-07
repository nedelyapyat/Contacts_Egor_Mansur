using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Contacts.Models;
using Contacts.Views;

namespace Contacts;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Contact> _contacts;
    private AddContact _addContact;
    private SelectedContact _selectedContact;
    private List<Contact> _filteredContacts;
    public MainWindow()
    {
        InitializeComponent();
        _addContact = new AddContact();
        ReadDatabase();
    }

    private void ReadDatabase()
    {
        _contacts = DatabaseHelper.DatabaseHelper.GetContacts();
        contactsListBox.ItemsSource = _contacts;
    }

    private void OpenAddWindow(object sender, RoutedEventArgs e)
    {
        _addContact.ShowDialog();
        ReadDatabase();
    }

    private void FilterCurrentContacts(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text.Length == 0)
        {
            _filteredContacts = _contacts;
        }
        else
        {
            _filteredContacts = _contacts.Where(q => q.Name.Contains(textBox.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        contactsListBox.ItemsSource = _filteredContacts;
    }

    private void ContactsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = (ListBox)sender;
        var selectedItem = listBox.SelectedItem;
        if (selectedItem != null)
        {
            new SelectedContact(selectedItem as Contact).ShowDialog();
            ReadDatabase();
        }
    }
}