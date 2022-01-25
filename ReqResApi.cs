using System;
using RestSharp;
using Newtonsoft.Json;
namespace ApiTests
{
    public class ReqResApi
    {
        public AllUsers GetAllUsers(int pageIndex)
        {
          var restClient = new  RestClient("https://reqres.in");
          var restRequest = new RestRequest($"api/users?page={pageIndex}", Method.GET);
          restRequest.AddHeader("Accept", "application/json");
          

            var response = restClient.Execute<AllUsers>(restRequest);
            var content = response.Content; // raw content as string

            var users = JsonConvert.DeserializeObject<AllUsers>(content);
            return users;
    }
}
}