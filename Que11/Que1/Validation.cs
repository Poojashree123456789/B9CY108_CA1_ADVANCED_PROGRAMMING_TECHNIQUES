class Validation
{

    public static bool isMobilePhoneNumberValid(string mobileNumber)
    {
        if (mobileNumber.Length != 9) return false;
        return true;
    }
}