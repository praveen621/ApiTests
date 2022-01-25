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
           var pagination = new ReqResApi<Pagination>();
              var paginationDetails = pagination.GetRequest("api/users?page=2", 2);
            Assert.AreEqual(2, paginationDetails.Page);
            Assert.AreEqual(12, paginationDetails.Total);
            Assert.AreEqual(6, paginationDetails.Data.Count);
            Assert.AreEqual(2,paginationDetails.TotalPages);
        }
        
        [TestMethod]
        public void Test_CreateUser()
        {
            string payload = "{\"name\":\"morpheus\",\"job\":\"leader\"}";
            var user = new ReqResApi<CreateUser>();
            var createdUser = user.PostRequest("api/users", payload);
            Assert.AreEqual("morpheus",createdUser.Name);
            Assert.AreEqual("leader",createdUser.Job);
            Assert.IsNotNull(createdUser.Id);
        }

         [TestMethod]
        public void Test_RegisterUser_Success()
        {
            string payload = "{\"email\":\"eve.holt@reqres.in\",\"password\":\"pistol\"}";
            var reg = new ReqResApi<RegisterUser>();
            var registerUser = reg.PostRequest("api/register", payload);
            Assert.IsNotNull(registerUser.Id);
            Assert.IsNotNull(registerUser.Token);
            
        }
    }
}