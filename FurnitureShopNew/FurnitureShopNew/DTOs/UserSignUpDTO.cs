public class UserSignUpDTO
{
    public UserSignUpDTO(string userName, string password, string firstName, string lastName, string email, string phoneNumber)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public string UserName {  get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}