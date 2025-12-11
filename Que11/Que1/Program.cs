using System.Diagnostics.CodeAnalysis;

class Programming
{
    public static void Main()
    {
        int choice;
        Contacthandler handlers = new Contacthandler();

        do
        {
            Console.WriteLine(" This is my contact Book");
            Console.WriteLine("1: Add contact");
            Console.WriteLine("2:Show all the contact details");
            Console.WriteLine("3:show contact details");
            Console.WriteLine("4:Update contact");
            Console.WriteLine("5:Delete Number");
            Console.WriteLine("0:Exit");

            Console.WriteLine("input your choice");
            choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1: handlers.Addcontact(); break;
                case 2: handlers.ShowAllContacts(); break;
                case 3: handlers.ShowContact(); break;
                case 4: handlers.Editcontact(); break;
                case 5: handlers.Deletecontact(); break;
                default: Console.WriteLine("You have entered an invalid input"); break;
            }

        } while (choice != 0);
    }

}