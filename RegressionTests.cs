using System;
namespace ApiTests
{
[TestClass]

    public class RegressionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var users = new Users();
            var resp = users.GetAllUsers();
            Assert.AreEqual(resp.Data.Count, 12);
            Assert.AreEqual(resp.Data[0].Email, "");
        }
    }
    {
        public AllUsers GetAllUsers()
        {
            var restClient = new RestClient("https://reqres.in");
            var restRequest = new RestRequest("api/users?page=2", Method.GET);
            restRequest.AddHeader("content-type", "application/json");


        }
}