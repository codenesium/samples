using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "TicketStatus")]
        [Trait("Area", "Integration")]
        public class TicketStatusTests
        {
                private TestServer server;
                private ApiClient client;

                public TicketStatusTests()
                {
                }

                [Fact]
                public async void TestCreate()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestUpdate()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestDelete()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestGetById()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestSearch()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestBulkInsert()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }
        }
}

/*<Codenesium>
    <Hash>29ce049932c3e212380e5d55fbedc01b</Hash>
</Codenesium>*/