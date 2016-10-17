using System;
using System.Linq;
using entity1.Models;

namespace entity1
{
    public class Program
    {
        public static void Create(YourContext db)
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter an email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter an age: ");
            string age = Console.ReadLine();
            int new_age = Int32.Parse(age);

            User NewUser = new User
            {
                name = name,
                email = email,
                password = password,
                age = new_age
            };
            
            db.Add(NewUser);
            db.SaveChanges();
            Console.WriteLine(NewUser.name + " has been added to the database.");
        }
        public static void Read(YourContext db)
        {
            Console.WriteLine("Enter the id of the user you wish to view: ");
            string id = Console.ReadLine();
            int new_id = Int32.Parse(id); 
            User ReturnedValue = db.Users.SingleOrDefault(User => User.id == new_id);
            
            if(ReturnedValue != null)
            {
                Console.WriteLine("Name: " + ReturnedValue.name);
                Console.WriteLine("Email: " + ReturnedValue.email);
                Console.WriteLine("Password: TOP SECRET!!!");
                Console.WriteLine("Age: " + ReturnedValue.age);
            }
            else
            {
                Console.WriteLine("Sorry, that user does not exist!");
            }
        }
        public static void Update(YourContext db)
        {
            Console.WriteLine("Enter the id of the user you wish to update: ");
            string id = Console.ReadLine();
            int new_id = Int32.Parse(id);
            User RetrievedUser = db.Users.SingleOrDefault(user => user.id == new_id);

            if(RetrievedUser != null)
            {
                Console.WriteLine("Enter a new name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a new email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter a new password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Enter a new age: ");
                string age = Console.ReadLine();
                int new_age = Int32.Parse(age);

                RetrievedUser.name = name;
                RetrievedUser.email = email;
                RetrievedUser.password = password;
                RetrievedUser.age = new_age;

                db.SaveChanges();
                Console.WriteLine(RetrievedUser.name + " has been updated!");
            }
            else
            {
                Console.WriteLine("Sorry, that user does not exist!");
            }
        }
        public static void Delete(YourContext db)
        {
            Console.WriteLine("Enter the id of the user you wish to delete: ");
            string id = Console.ReadLine();
            int new_id = Int32.Parse(id);
            User RetrievedUser = db.Users.SingleOrDefault(user => user.id == new_id);

            Console.WriteLine("Are you SURE you want to delete " + RetrievedUser.name + " ? Type 'Y' or 'N'");
            string answer = Console.ReadLine();
            if(answer == "Y")
            {
                Console.WriteLine("Deleting " + RetrievedUser.name + " ... ");
                db.Users.Remove(RetrievedUser);
                db.SaveChanges();
                Console.WriteLine("The user has been deleted!");
            }
            else if(answer != "Y" && answer != "N")
            {
                Console.WriteLine("Type 'Y' or 'N' to continue.");
            }
            else if(answer == "N")
            {
                Console.WriteLine(RetrievedUser.name + " will not be deleted. Goodbye!");
            }
        }
        public static void Main(string[] args)
        {
            using(var db = new YourContext())
            {
                // Create(db);
                // Read(db);
                // Update(db);
                Delete(db);
            }
        }
    }
}


