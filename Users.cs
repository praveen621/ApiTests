using System;

namespace ApiTests
{
    public class Users
    {
        public AllUsers GetAllUsers()
        {
          var restClient = new  RestClient("https://reqres.in");
          var restRequest = new RestRequest("api/users?page=2", Method.GET);
          restRequest.AddHeader("Accept", "application/json");
          

            var response = restClient.Execute<AllUsers>(restRequest);
            var content = response.Content; // raw content as string

            var users = JsonConvert.DeserializeObject<AllUsers>(content);
            return users;
    }
}
}