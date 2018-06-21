using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Admin")]
        [Trait("Area", "Integration")]
        public class AdminIntegrationTests
        {
                public AdminIntegrationTests()
                {
                }

                [Fact]
                public async void TestCreate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestUpdate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestDelete()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestGet()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestAll()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }
        }
}

/*<Codenesium>
    <Hash>8a1520a7f4d839a6b341f5faa049c042</Hash>
</Codenesium>*/