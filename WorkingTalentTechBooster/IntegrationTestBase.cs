using NUnit.Framework;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace WorkingTalentTechBooster
{
    public class IntegrationTestBase
    {
        private WireMockServer? server;

        private string loanRequest_100_10 = "{\"Amount\":100,\"DownPayment\":10}";
        private string loanRequest_500_50 = "{\"Amount\":500,\"DownPayment\":50}";
        private string loanRequest_500_10 = "{\"Amount\":500,\"DownPayment\":10}";

        private string responseApproved = "{\"Result\":\"Approved\"}";
        private string responseDenied = "{\"Result\":\"Denied\"}";


        [SetUp]
        public void StartMockServer()
        {
            server = WireMockServer.Start(9876);

            CreateStubFor10010LoanRequest();
            CreateStubFor50050LoanRequest();
            CreateStubFor50010LoanRequest();
        }

        [TearDown]
        public void StopMockServer()
        {
            server?.Stop();
        }

        private void CreateStubFor10010LoanRequest()
        {
            server?.Given(Request.Create().WithPath("/requestLoan").UsingPost()
                .WithBody(new JsonMatcher(loanRequest_100_10)))
                .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseApproved));
        }
        private void CreateStubFor50050LoanRequest()
        {
            server?.Given(Request.Create().WithPath("/requestLoan").UsingPost()
                .WithBody(new JsonMatcher(loanRequest_500_50)))
                .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseApproved));
        }
        private void CreateStubFor50010LoanRequest()
        {
            server?.Given(Request.Create().WithPath("/requestLoan").UsingPost()
                .WithBody(new JsonMatcher(loanRequest_500_10)))
                .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseDenied));
        }
    }
}
