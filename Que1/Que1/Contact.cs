//creating a class Contactbook

class Contactbook
{
    private string _Firstname;
    private string _Lastname;
    private string _Contactnumber;

    private string _Companyname;
    private string _Emailaddress;
    private string _DOB;

    public string Firstname                //Geter and seter for the user to input detailes
    {
        get
        {
            return _Firstname;
        }

        set
        {
            _Firstname = value;
        }
    }

    public string Lastname
    {
        get
        {
            return _Lastname;
        }
        set
        {
            _Lastname = value;
        }
    }

    public string Companyname
    {
        get
        {
            return _Companyname;
        }
        set
        {
            _Companyname = value;
        }
    }
    public string Contactnumber
    {
        get
        {
            return _Contactnumber;
        }
        set
        {
            _Contactnumber = value;
        }
    }

    public string Emailaddress
    {
        get
        {
            return _Emailaddress;
        }
        set
        {
            _Emailaddress = value;
        }
    }
    public string DOB
    {
        get
        {
            return _DOB;
        }
        set
        {
            _DOB = value;
        }
    }

    public Contactbook()         // Usage of constructors
    {
    }

    public Contactbook(string firstname, string lastname, string contactnumber, string dOB, string emailaddress, string companyname)
    {
        Firstname = firstname;
        Lastname = lastname;
        Contactnumber = contactnumber;
        DOB = dOB;
        Companyname = companyname;
        Emailaddress = emailaddress;

    }

    public override string ToString()
    {
        return
            $"<-----Personal Data--------->\n" +
            $"Name: {Firstname} {Lastname}\n" +
            $"Email: {Emailaddress}\n" +
            $"contactnumber: {Contactnumber}\n" +
            $"DOB: {DOB}\n" +
            $"Companyname: {Companyname}\n";


    }
}