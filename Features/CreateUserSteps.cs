
using System;
using TechTalk.SpecFlow;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUser _createUser;
        private readonly string _payload;
        private CreateUser _createdUSer;

        public CreateUserSteps(CreateUser createUser)
        {
            _createUser = createUser;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIinputname(string name)
        {
            _createUser.Name = name;
        }

        [Given(@"I input Job ""(.*)""")]
        public void GivenIinputJob(string job)
        {
            _createUser.Job = job;
        }

        [When(@"I send create a user request")]
        public void WhenIsendcreateauserrequest()
        {
            var payload = ApiHelper<CreateUser>.SerializeObject(_createUser);
            var api = new ReqResApi<CreateUser>();
            _createdUSer = api.PostRequest("api/users", payload);
        }

        [Then(@"validate user is created")]
        public void Thenvalidateuseriscreated()
        {
            Assert.AreEqual("morpheus", _createdUSer.Name);
            Assert.AreEqual("leader", _createdUSer.Job);
            Assert.IsNotNull(_createdUSer.Id);
        }

    }
}