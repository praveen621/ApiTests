namespace ApiTests
{

    public partial class Pagination
    {
        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<User> Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Avatar { get; set; }
    }

    public partial class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }

     public class CreateUser
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

        public class RegisterUser
    {
        public string Id { get; set; }
        public string Token { get; set; }
    }

       public class RegisterUserError
    {
        public string Error { get; set; }
    }
}
