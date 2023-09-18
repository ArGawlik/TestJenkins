using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestProject1
{
    public class BaseTest
    {
        public WireMockServer server;

        [SetUp]
        public void SetUpMock()
        {
            server = WireMockServer.Start(9876);

            server.Given(Request.Create().WithPath("/hello-world").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "text/plain")
                        .WithBody("Hello, world!"));
        }

        [TearDown]
        public void StopServer()
        {
            server.Stop();
        }

    }
}
