using System.IO;
using Contacts.Models;
using SQLite;

namespace Contacts.DatabaseHelper;

public static class DatabaseHelper
{
    private static string _databaseConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.db");
    public static List<Contact> GetContacts()
    {
        var db = new SQLiteConnection(_databaseConnectionString);
        db.CreateTable<Contact>();
        var contacts = db.Table<Contact>().ToList();
        return contacts;
    }

    public static void ChangeContact(Contact contact)
    {
        var db = new SQLiteConnection(_databaseConnectionString);
        db.CreateTable<Contact>();
        db.Update(contact);
    }

    public static void AddContact(Contact contact)
    {
        var db = new SQLiteConnection(_databaseConnectionString);
        db.CreateTable<Contact>();
        db.Insert(contact);
    }
}