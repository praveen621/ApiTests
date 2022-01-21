using System;
namespace ApiTests
{
[TestClass]

    public class RegressionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var restClient = new RestClient("https://reqres.in");
            var restRequest = new RestRequest("api/users?page=2", Method.GET);
            restRequest.AddHeader("content-type", "application/json");

            var response = restClient.Execute<AllUsers>(restRequest);
            var content = response.Content; // raw content as string

            var users = JsonConvert.DeserializeObject<AllUsers>(content);
            Assert.AreEqual(users.Data.Count, 6);
        }
    }
    {
        public AllUsers GetAllUsers()
        {
            var restClient = new RestClient("https://reqres.in");
            var restRequest = new RestRequest("api/users?page=2", Method.GET);
            restRequest.AddHeader("content-type", "application/json");



}