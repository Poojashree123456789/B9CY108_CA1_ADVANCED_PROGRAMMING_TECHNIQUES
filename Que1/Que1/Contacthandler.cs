class Contacthandler
{
    private List<Contactbook> contacts = new List<Contactbook>();
    public void Addcontact()
    {
        Contactbook contact = new Contactbook();
        Console.WriteLine("Enter your firstname");
        contact.Firstname = Console.ReadLine();
        Console.WriteLine("Enter your lastname");
        contact.Lastname = Console.ReadLine();
        Console.WriteLine("What is the name of your company");
        contact.Companyname = Console.ReadLine();
        Console.WriteLine("What is your date of birth");
        contact.DOB = Console.ReadLine();

        string phoneNumber;
        while (true)
        {
            Console.WriteLine("What is your contact number");
            phoneNumber = Console.ReadLine();
            bool phoneNumberValidation = Validation.isMobilePhoneNumberValid(phoneNumber);
            if (phoneNumberValidation == false)
            {
                Console.WriteLine("Invalid Phone number");
            }
            else
            {
                break;
            }
        }

        contact.Contactnumber = phoneNumber;

        Console.WriteLine("What is your email address");
        contact.Emailaddress = Console.ReadLine();
        contacts.Add(contact);
        Console.WriteLine("contact added successfully");
        Console.WriteLine(contact.ToString());

    }

    public void ShowAllContacts()
    {

        foreach (var item in contacts)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void ShowContact()
    {
        Console.WriteLine("Enter the phone number to search for:");
        string numberToSearch = Console.ReadLine();

        // Look for a match in the list
        var foundContact = contacts.FirstOrDefault(c => c.Contactnumber == numberToSearch);

        if (foundContact != null)
        {
            Console.WriteLine("\nContact found:");
            Console.WriteLine(foundContact.ToString());
        }
        else
        {
            Console.WriteLine("Phone number not stored.");
        }

    }
    public void Deletecontact()
    {

        Console.WriteLine("Enter the phone number of the contact you want to delete:");
        string numberToSearch = Console.ReadLine() ?? "";

        // Search for the contact
        var foundContact = contacts.FirstOrDefault(c => c.Contactnumber == numberToSearch);

        if (foundContact == null)
        {
            Console.WriteLine("Invalid phone number. Contact not found.");
            return;
        }

        Console.WriteLine("\nContact found:");
        Console.WriteLine(foundContact.ToString());

        Console.WriteLine("Are you sure you want to delete this contact? (yes/no)");
        string confirmation = Console.ReadLine()?.ToLower() ?? "no";

        if (confirmation == "yes" || confirmation == "y")
        {
            contacts.Remove(foundContact);
            Console.WriteLine("Contact deleted successfully.");
        }
        else
        {
            Console.WriteLine("Delete cancelled.");
        }
    }
    public void Editcontact()
    {
        Console.WriteLine("Enter the phone number of the contact you want to edit:");
        string numberToSearch = Console.ReadLine() ?? "";

        // Search for contact
        var foundContact = contacts.FirstOrDefault(c => c.Contactnumber == numberToSearch);

        if (foundContact == null)
        {
            Console.WriteLine("Invalid phone number. Contact not found.");
            return;
        }

        Console.WriteLine("\nContact found:");
        Console.WriteLine(foundContact.ToString());

        Console.WriteLine("\nWhat do you want to edit?");
        Console.WriteLine("1. First Name");
        Console.WriteLine("2. Last Name");
        Console.WriteLine("3. Company Name");
        Console.WriteLine("4. Date of Birth");
        Console.WriteLine("5. Email Address");
        Console.WriteLine("6. Contact Number");
        Console.WriteLine("Enter your choice:");

        string choiceInput = Console.ReadLine() ?? "0";
        int choice;
        int.TryParse(choiceInput, out choice);

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter new First Name:");
                foundContact.Firstname = Console.ReadLine() ?? "";
                break;

            case 2:
                Console.WriteLine("Enter new Last Name:");
                foundContact.Lastname = Console.ReadLine() ?? "";
                break;

            case 3:
                Console.WriteLine("Enter new Company Name:");
                foundContact.Companyname = Console.ReadLine() ?? "";
                break;

            case 4:
                Console.WriteLine("Enter new Date of Birth:");
                foundContact.DOB = Console.ReadLine() ?? "";
                break;

            case 5:
                Console.WriteLine("Enter new Email:");
                foundContact.Emailaddress = Console.ReadLine() ?? "";
                break;

            case 6:
                string newNumber;
                while (true)
                {
                    Console.WriteLine("Enter new Contact Number:");
                    newNumber = Console.ReadLine() ?? "";

                    bool valid = Validation.isMobilePhoneNumberValid(newNumber);
                    if (!valid)
                    {
                        Console.WriteLine("Invalid phone number");
                    }
                    else
                    {
                        break;
                    }
                }
                foundContact.Contactnumber = newNumber;
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("\nContact updated successfully!");
        Console.WriteLine(foundContact.ToString());
    }
    public void Exit() { }



}
