using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int SecurityLevel { get; set;}

    public User (string Entered_username, string Entered_password, int Entered_securityLevel)
    {
        Username = Entered_username;
        Password = Entered_password;
        SecurityLevel = Entered_securityLevel;
    }
}

public class FileItem
{
    public string FileName { get; set; }
    public int SecurityLevel { get; set; }

    public FileItem (string Entered_FileName, int FEntered_securitylevel)
    {
        FileName = Entered_FileName;
        SecurityLevel = FEntered_securitylevel;
    }

}

public class Creation
{
    public static void CreateUsers(List<User> users)
    {
        //List<User> users = new List<Users>();
        users.Add(new User("alice", "iamAlice", 1)); //public clearance
        users.Add(new User("bob", "iamBob", 2)); //limited clearence
        users.Add(new User("kate", "iamKate", 3)); //secret clearance
        users.Add(new User("Joe", "iamJoe", 4)); //top secret clearance
    }
    public static void CreateFiles(List<FileItem> files)
    {
        //List<FileItem> files = new List<FileItem>();
        Random rnd = new Random();
        for (int i = 1; i<=50; i++)
        {
            int level = rnd.Next(1,5);
            files.Add(new FileItem($"File{i}.txt", level));
        }
    }    
}

public class SystemFunctions
{
    public static User Authenticate(List<User> users, string username, string password)
    {
        foreach (User u in users)
        {
            if ((u.Username == username) && (u.Password == password))
            {
                return u;
            }
        }
        return null;
    }

    public static void DisplayFiles(List<FileItem> files, User u)
    {
        Console.WriteLine($"\nAccessible files for {u.Username} (Level {u.SecurityLevel}):");
        foreach (FileItem f in files)
        {
            if (f.SecurityLevel <= u.SecurityLevel)
            {
                Console.WriteLine($"- {f.FileName} [Level {f.SecurityLevel}]");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        List<User> users = new List<User>();
        List<FileItem> files = new List<FileItem>();

        Creation.CreateUsers(users);
        Creation.CreateFiles(files);

        Console.WriteLine("Welcome to the Multi-Level Security System.");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        User currentUser = SystemFunctions.Authenticate(users, username, password);

        if (currentUser != null)
        {
            Console.WriteLine("Login successful!");
            SystemFunctions.DisplayFiles(files, currentUser);
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
        }
    }
}
