using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ApiTests
{
[TestClass]

    public class RegressionTests
    {
        [TestMethod]
        public void Test_UserCount()
        {
            var users = new Users();
            var resp = users.GetAllUsers();
            Assert.AreEqual(resp.Data.Count, 12);
            Assert.AreEqual(resp.Data[0].Email, "");
        }
    }
}