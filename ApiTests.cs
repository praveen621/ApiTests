using System;

namespace ApiTests
{
    public class ApiTests
    {
        public List<User> GetAllUsers()
        {
           return new List<User>
           {
               new User
               {
                   Id = 1,
                   Email = ""
                   }
           };
        
    }
}
}