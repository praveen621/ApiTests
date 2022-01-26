using System;
using TechTalk.SpecFlow;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [Binding]
    public class CreateUserSteps
    {
        private readonly CreateUser _createUser;
        private CreateUserSteps _createdUser;

        public CreateUserSteps(CreateUser createUser)
        {
            _createUser = createUser;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIinputname(string args1)
        {
            _createUser.Name = args1;
        }

        [Given(@"I input Job ""(.*)""")]
        public void GivenIinputJob(string args1)
        {
            _createUser.Job = args1;
        }

        [When(@"I send create a user request")]
        public void WhenIsendcreateauserrequest()
        {
            var payload = ApiHelper<CreateUser>.SerializeObject(_createUser);
            var api = new ReqResApi<CreateUser>();
            _createdUser = api.PostRequest("api/users", payload);
        }

        [Then(@"validate user is created")]
        public void Thenvalidateuseriscreated()
        {
            Assert.AreEqual("John",_createdUser.Name);
            Assert.AreEqual("Developer",_createdUser.Job);
            Assert.IsNotNull(_createdUser.Id);
        }

    }
}