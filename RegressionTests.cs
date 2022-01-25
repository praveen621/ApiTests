using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ApiTests
{
    [TestClass]

    public class RegressionTests
    {
        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void SetUpReportsConfig(TestContext context)
        {
            var dir = context.TestRunDirectory;
            Reports.InitializeExtentReports(dir, "Api Test Report,", "Api Regression Test Report");
        }

        [TestInitialize]
        public void SetUpTest()
        {
            Reports.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            AventStack.ExtentReports.Status logStatus;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = AventStack.ExtentReports.Status.Fail;
                    Reports.TestStatus(logStatus, "Test Failed");
                    break;
                case UnitTestOutcome.Inconclusive:
                    logStatus = AventStack.ExtentReports.Status.Warning;
                    Reports.TestStatus(logStatus, "Test Inconclusive");
                    break;
                case UnitTestOutcome.Passed:
                    logStatus = AventStack.ExtentReports.Status.Pass;
                    Reports.TestStatus(logStatus, "Test Passed");
                    break;
                case UnitTestOutcome.Timeout:
                    logStatus = AventStack.ExtentReports.Status.Warning;
                    Reports.TestStatus(logStatus, "Test Timeout");
                    break;
                default:
                    logStatus = AventStack.ExtentReports.Status.Warning;
                    Reports.TestStatus(logStatus, "Test Inconclusive");
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUpReportsConfig()
        {
            Reports.FlushExtentReports();
        }

        [TestMethod]
        public void Test_Pagination()
        {
            var pagination = new ReqResApi<Pagination>();
            var paginationDetails = pagination.GetRequest("api/users?page=2");
            Assert.AreEqual(2, paginationDetails.Page);
            Reports.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
            Assert.AreEqual(12, paginationDetails.Total);
            Assert.AreEqual(6, paginationDetails.Data.Count);
            Assert.AreEqual(2, paginationDetails.TotalPages);
        }

        [TestMethod]
        public void Test_SingleUser()
        {
            var user = new ReqResApi<User>();
            var userDetails = user.GetRequest("api/users/2");
            Assert.AreEqual(2, userDetails.Id);
            Assert.AreEqual("Janet", userDetails.FirstName);
            Assert.AreEqual("Weaver", userDetails.LastName);
            Assert.AreEqual("janet.weaver@reqres.in", userDetails.Email);

        }

        [TestMethod]
        public void Test_CreateUser()
        {
            string payload = "{\"name\":\"morpheus\",\"job\":\"leader\"}";
            var user = new ReqResApi<CreateUser>();
            var createdUser = user.PostRequest("api/users", payload);
            Assert.AreEqual("morpheus", createdUser.Name);
            Assert.AreEqual("leader", createdUser.Job);
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

        [TestMethod]
        public void Test_RegisterUser_Failed()
        {
            string payload = "{\"email\":\"sydney@fife\"}";
            var reg = new ReqResApi<RegisterUserError>();
            var registerUser = reg.PostRequest("api/register", payload);
            Assert.AreEqual("Missing password", registerUser.Error);
        }

        [DeploymentItem("TestData\\createuser.json")]
        [TestMethod]
        public void Test_CreateUserFromTestData()
        {
            var payload = System.IO.File.ReadAllText("createuser.json");
            var user = new ReqResApi<CreateUser>();
            var createdUser = user.PostRequest("api/users", payload);
            Assert.AreEqual("morpheus", createdUser.Name);
            Assert.AreEqual("leader", createdUser.Job);
        }
    }
}