using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestEase;
using TestProject1.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace TestProject1
{
    public class Tests : BaseTest
    {
        private TestApi api;


        [SetUp]
        public void SetUp()
        {
            api = RestClient.For<TestApi>("http://localhost:9876");
        }

        [Test]
        public void HelloWorldTest()
        {
            var a = api.GetHelloWorldText().Result;
            Assert.That(a, Is.EqualTo("Hello, world!"));
        }

        [Test]
        public async Task GetUserTest()
        {
            User user = User.GenerateUser();

            server.Given(Request.Create().WithPath("/user").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(JsonConvert.SerializeObject(user)));

            var response = await api.GetUser();
            var us = JsonConvert.SerializeObject(user);

            Assert.That(response.Name, Is.EqualTo(user.Name));
            response.Should().BeEquivalentTo(user);
        }   

        [Test]
        public async Task GetUserWithIdTest()
        {
            User user = User.GenerateUser();

            server.Given(Request.Create().WithPath($"/user/{user.Id}").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(JsonConvert.SerializeObject(user)));

            var response = await api.GetUser(user.Id);

            Assert.That(response.Name, Is.EqualTo(user.Name));
            Assert.That(response.Id, Is.EqualTo(user.Id));
            response.Should().BeEquivalentTo(user);
        }        
        
        [Test]
        public async Task GetUsersListTest()
        {
            List<User> users = new List<User>()
            {
                User.GenerateUser(),
                User.GenerateUser(),
                User.GenerateUser(),
            };

            server.Given(Request.Create().WithPath("/users").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(JsonConvert.SerializeObject(users)));

            var response = await api.GetUsers();

            Assert.That(response[1].Name, Is.EqualTo(users[1].Name));
            response.Should().BeEquivalentTo(users);
        }

        [Test]
        public async Task PostUserTest()
        {
            User user = User.GenerateUser();

            server.Given(Request.Create()
                    .WithPath("/user")
                    .WithBody(new JsonMatcher(user))
                    .UsingPost())
                .RespondWith(Response.Create()
                    .WithStatusCode(201)
                    .WithBody("ok"));

            var response = await api.PostUser(user);

            response.Should().Be("ok");
            server.LogEntries.Last().RequestMessage.Body.Should().BeEquivalentTo(JsonConvert.SerializeObject(user));
        }
    }
}
