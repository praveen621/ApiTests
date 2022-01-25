using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ApiTests
{
[TestClass]

    public class RegressionTests
    {
        [TestMethod]
        public void Test_Pagination()
        {
            var api = new ReqResApi();
            var resp = api.GetAllUsers(2);
            Assert.AreEqual(2,resp.Page);
            Assert.AreEqual(6,resp.PerPage);
            Assert.AreEqual(12,resp.Total);
            Assert.AreEqual(2,resp.TotalPages);
        }
        
        [TestMethod]
        public void Test_CreateUser()
        {
            string payload = "{\"name\":\"morpheus\",\"job\":\"leader\"}";
            var api = new ApiHelper();
            var url = api.SetEndpointUrl("api/users");
            var request = api.CreatePostRequest(payload);
            var response = api.ExecuteRequest();
            var resp = api.GetResponse<CreateUser>(response);
            Assert.AreEqual("morpheus",resp.Name);
            Assert.AreEqual("leader",resp.Job);
            Assert.IsNotNull(resp.Id);
        }
    }
}