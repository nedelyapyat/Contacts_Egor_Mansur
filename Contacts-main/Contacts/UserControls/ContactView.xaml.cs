using System.Windows;
using System.Windows.Controls;
using Contacts.Models;

namespace Contacts.UserControls;

public partial class ContactView : UserControl
{
    public static readonly DependencyProperty ContactValue = DependencyProperty.Register(
        nameof(Contact), typeof(Contact), typeof(ContactView), new PropertyMetadata(new Contact{Email = "", Name = "", Phone = ""}, SetText));

    private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = d as ContactView;
        var contact = (Contact)e.NewValue;

        if (view != null)
        {
            view.emailTextBlock.Text = contact.Email;
            view.phoneTextBlock.Text = contact.Phone;
            view.nameTextBlock.Text = contact.Name;
        }
    }

    public Contact Contact
    {
        get { return (Contact)GetValue(ContactValue); }
        set { SetValue(ContactValue, value); }
    }
    public ContactView()
    {
        InitializeComponent();
    }
}